using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using SeoPoc.Web.DataAccess;
using SeoPoc.Web.DataAccess.Entities;

namespace SeoPoc.Web.Services
{
    public class SeoRoutingService
    {
        private enum SeoParameterType
        {
            Unknown,
            City,
            District,
            ArticleGroup,
            Phrase,
            Alias,
        }

        private readonly Dictionary<string, SeoParameterType> SeoParameterTypes = Enum.GetValues(typeof(SeoParameterType))
            .Cast<SeoParameterType>()
            .Select(x => (x.ToString(), x))
            .ToDictionary(x => x.Item1, x => x.Item2, StringComparer.InvariantCultureIgnoreCase);


        private readonly Dictionary<SeoParameterType, Func<ApplicationDbContext, DbSet<ISeoParameter>>> DbSets = new Dictionary<SeoParameterType, Func<ApplicationDbContext, DbSet<ISeoParameter>>>
        {
            [SeoParameterType.City] = (Func<ApplicationDbContext, DbSet<ISeoParameter>>)GetDbSet<DbCitySeoParameter>(),
            [SeoParameterType.District] = (Func<ApplicationDbContext, DbSet<ISeoParameter>>)GetDbSet<DbDistrictSeoParameter>(),
            [SeoParameterType.ArticleGroup] = (Func<ApplicationDbContext, DbSet<ISeoParameter>>)GetDbSet<DbArticleGroupSeoParameter>(),
            [SeoParameterType.Phrase] = (Func<ApplicationDbContext, DbSet<ISeoParameter>>)GetDbSet<DbPhraseSeoParameter>(),
            [SeoParameterType.Alias] = (Func<ApplicationDbContext, DbSet<ISeoParameter>>)GetDbSet<DbAliasSeoParameter>(),
        };

        private static Func<ApplicationDbContext, IQueryable<T>> GetDbSet<T>() where T : class, ISeoParameter
        {
            return context => context.Set<T>();
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

            foreach (var segment in segments)
            {
                using (var context = new ApplicationDbContext())
                {
                    var seoParameter = DbSets[segment.type](context)
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