﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using SeoPoc.Web.DataAccess;
using SeoPoc.Web.DataAccess.Entities;
using SeoPoc.Web.Helpers;
using SeoPoc.Web.Models;

namespace SeoPoc.Web.Services
{
    public class SeoRoutingService
    {
        private readonly Dictionary<string, SeoParameterType> SeoParameterTypes = Enum.GetValues(typeof(SeoParameterType))
            .Cast<SeoParameterType>()
            .Select(x => (x.ToString(), x))
            .ToDictionary(x => x.Item1, x => x.Item2, StringComparer.InvariantCultureIgnoreCase);


        private readonly Dictionary<SeoParameterType, Func<ApplicationDbContext, IQueryable<ISeoParameter>>> DbSets = new Dictionary<SeoParameterType, Func<ApplicationDbContext, IQueryable<ISeoParameter>>>
        {
            [SeoParameterType.City] = GetDbSet<DbCitySeoParameter>(),
            [SeoParameterType.District] = GetDbSet<DbDistrictSeoParameter>(),
            [SeoParameterType.ArticleGroup] = GetDbSet<DbArticleGroupSeoParameter>(),
            [SeoParameterType.Phrase] = GetDbSet<DbPhraseSeoParameter>(),
            [SeoParameterType.Alias] = GetDbSet<DbAliasSeoParameter>(),
        };

        private static Func<ApplicationDbContext, IQueryable<T>> GetDbSet<T>() where T : class, ISeoParameter
        {
            return context => context.Set<T>();
        }

        public SeoDetails ConstructSeoDetails(string url, SeoRoutingResult routingResult)
        {
            using (var context = new ApplicationDbContext())
            {
                string citySection = string.Empty;
                string articleGroupSection = string.Empty;
                var breadcrumbs = new List<BreadcrumbItem>();

                var result = new SeoDetails
                {
                    CanonicalUrl = url.ToSeoUrl(),
                    RoutingResult = routingResult,
                    Breadcrumbs = breadcrumbs,
                };

                if (routingResult == null)
                {
                    return result;
                }
                
                if (routingResult.CityId.HasValue)
                {
                    var seoCity = context.Set<DbCitySeoParameter>().Where(x => x.CityId == routingResult.CityId.Value).OrderBy(x => x.Id).First();
                    citySection = seoCity.Alias + "-" + SeoParameterType.City;

                    breadcrumbs.Add(new BreadcrumbItem
                    {
                        Title = seoCity.Value,
                        Url = $"/{citySection}/",
                    });

                    result.CityName = seoCity.Value;
                }

                if (!string.IsNullOrEmpty(routingResult.ArticleGroupInternalName))
                {
                    var seoArticleGroup = context.Set<DbArticleGroupSeoParameter>().Where(x => x.ArticleGroupInternalName == routingResult.ArticleGroupInternalName).OrderBy(x => x.Id).First();
                    articleGroupSection = seoArticleGroup.Alias + "-" + SeoParameterType.ArticleGroup;
                    breadcrumbs.Add(new BreadcrumbItem
                    {
                        Title = seoArticleGroup.Value,
                        Url = $"/{citySection}/{articleGroupSection}/",
                    });
                }

                if (routingResult.DistrictId.HasValue)
                {
                    var seoDistrict = context.Set<DbDistrictSeoParameter>().Where(x => x.DistrictId == routingResult.DistrictId.Value).OrderBy(x => x.Id).First();
                    var seoDistrictSection = seoDistrict.Alias + "-" + SeoParameterType.District;
                    breadcrumbs.Add(new BreadcrumbItem
                    {
                        Title = seoDistrict.Value,
                        Url = $"/{citySection}/{articleGroupSection}/{seoDistrictSection}/",
                    });
                }

                return result;
            }
        }

        public SeoRoutingResult Route(Uri currentUrl)
        {
            var segments = currentUrl
                .Segments
                .Select(x => x.Trim('/'))
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(
                    x =>
                    {
                        var seoParameterTypeString = x.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                        if (seoParameterTypeString.Length < 2)
                        {
                            return (section: x, type: SeoParameterType.Unknown);
                        }

                        if (!SeoParameterTypes.TryGetValue(seoParameterTypeString[seoParameterTypeString.Length - 1], out var seoParameterType))
                        {
                            return (section: x, type: SeoParameterType.Unknown);
                        }

                        return (section: string.Join("-", seoParameterTypeString.Take(seoParameterTypeString.Length - 1)), type: seoParameterType);
                    })
                .Where(x => x.type != SeoParameterType.Unknown)
                .ToArray();

            if (segments.Length == 0 || segments.All(x => x.type == SeoParameterType.Unknown))
            {
                return null;
            }

            var result = new SeoRoutingResult();
            var titleSegments = new List<string>(segments.Length);

            using (var context = new ApplicationDbContext())
            {
                foreach (var segment in segments)
                {
                    var seoParameter = DbSets[segment.type](context)
                        .AsNoTracking()
                        .FirstOrDefault(x => x.Alias == segment.section);

                    if (seoParameter == null)
                    {
                        continue;
                    }

                    seoParameter.UpdateRoutingResult(result);
                    titleSegments.Add(seoParameter.Value);
                }
            }

            result.SeoTitle = string.Join(" ", titleSegments);

            return result;
        }
    }
}