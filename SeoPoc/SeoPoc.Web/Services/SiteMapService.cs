using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Xml.Linq;

using SeoPoc.Web.DataAccess;
using SeoPoc.Web.DataAccess.Entities;
using SeoPoc.Web.Models;

namespace SeoPoc.Web.Services
{
    public class SiteMapService
    {
        private static readonly string[] ArticleGroupNames = { "1k", "2k", "3k", "K", "C", "1k,K", "1k,C", "1k,2k", "2k,3k", };

        private readonly Dictionary<SeoParameterType, Func<ApplicationDbContext, string, int, IQueryable<ISeoParameter>>> DbSets = new Dictionary<SeoParameterType, Func<ApplicationDbContext, string, int, IQueryable<ISeoParameter>>>
        {
            [SeoParameterType.City] = (context, articleGroupName, cityId) => GetDbSet<DbCitySeoParameter>()(context).Where(x => x.CityId == cityId),
            [SeoParameterType.District] = (context, articleGroupName, cityId) => GetDbSet<DbDistrictSeoParameter>()(context).Where(x => x.CityId == cityId),
            [SeoParameterType.ArticleGroup] = (context, articleGroupName, cityId) => GetDbSet<DbArticleGroupSeoParameter>()(context).Where(x => x.ArticleGroupInternalName == articleGroupName),
            [SeoParameterType.Phrase] = (context, articleGroupName, cityId) => GetDbSet<DbPhraseSeoParameter>()(context),
            [SeoParameterType.Alias] = (context, articleGroupName, cityId) => GetDbSet<DbAliasSeoParameter>()(context).Where(x => (x.CityId == null || x.CityId == cityId) && (x.ArticleGroupInternalName == null || x.ArticleGroupInternalName == articleGroupName)),
        };

        private readonly Dictionary<SeoParameterType, string> UrlSectionPostfixes = new Dictionary<SeoParameterType, string>
        {
            [SeoParameterType.City] = SeoParameterType.City.ToString().ToLowerInvariant(),
            [SeoParameterType.District] = SeoParameterType.District.ToString().ToLowerInvariant(),
            [SeoParameterType.ArticleGroup] = SeoParameterType.ArticleGroup.ToString().ToLowerInvariant(),
            [SeoParameterType.Phrase] = SeoParameterType.Phrase.ToString().ToLowerInvariant(),
            [SeoParameterType.Alias] = SeoParameterType.Alias.ToString().ToLowerInvariant(),
        };

        private static Func<ApplicationDbContext, IQueryable<T>> GetDbSet<T>() where T : class, ISeoParameter
        {
            return context => context.Set<T>();
        }

        public class SiteMapNode
        {
            public string Location { get; set; }

            public string LastModified { get; set; }

            public string Priority { get; set; }

            public string ChangeFrequency { get; set; }

            public string SeaTitle { get; set; }
        }

        public string GetSiteMapIndex()
        {
            XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XElement root = new XElement(xmlns + "sitemapindex");

            var nodes = GetSiteMaps();

            foreach (var sitemap in nodes)
            {
                XElement urlElement = new XElement(
                    xmlns + "sitemap",
                    new XElement(xmlns + "loc", Uri.EscapeUriString(sitemap.url.ToString())),
                    new XElement(xmlns + "lastmod", Uri.EscapeUriString(sitemap.lastModifiedDate.ToString("yyyy-MM-dd"))),
                    new XElement(xmlns + "count", sitemap.count),
                    new XElement(xmlns + "exceeded", sitemap.exceded)
                );
                root.Add(urlElement);
            }

            XDocument document = new XDocument(root);
            return document.ToString(SaveOptions.DisableFormatting);
        }

        public (Uri url, DateTime lastModifiedDate, int count, bool exceded)[] GetSiteMaps()
        {
            string[] cities;

            using (var context = new ApplicationDbContext())
            {
                cities = context.Set<DbCity>()
                    .Select(x => x.InternalName)
                    .ToArray();
            }

            var urlSections = ArticleGroupNames
                .Select(ToUrlSection)
                .SelectMany(x => cities.Select(y => (x, y)))
                .ToArray();

            var baseUri = GetBaseUri();
            var now = DateTime.Now;

            var result = urlSections
                .Select(x =>
                {
                    var nodes = GetNodes(x.Item1, x.Item2).ToArray();
                    var count = nodes.Length;
                    var duplicates = nodes.GroupBy(y => y.Location).Select(y => y.ToArray()).ToArray();
                    var duplicatesNodes = duplicates.Where(y => y.Length > 1).ToArray();

                    var item = (
                        url: new Uri(baseUri, $"/sitemap/{x.Item1}/{x.Item2}.xml"),
                        lastModifiedDate: now,
                        count: count,
                        exceded: count > 50000
                        );
                    return item;
                })
                .OrderByDescending(x => x.count)
                .ToArray();
            return result;
        }

        public string GetSiteMap(string articleGroupUrlSection, string city)
        {
            XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XElement root = new XElement(xmlns + "urlset");

            var nodes = GetNodes(articleGroupUrlSection, city).ToArray();
            var baseUri = GetBaseUri();
            foreach (var sitemapNode in nodes)
            {
                XElement urlElement = new XElement(
                    xmlns + "url",
                    new XElement(xmlns + "loc", Uri.EscapeUriString(new Uri(baseUri, sitemapNode.Location).ToString())),
                    new XElement(xmlns + "lastmod", Uri.EscapeUriString(sitemapNode.LastModified)),
                    new XElement(xmlns + "changefreq", Uri.EscapeUriString(sitemapNode.ChangeFrequency)),
                    new XElement(xmlns + "priority", Uri.EscapeUriString(sitemapNode.Priority)),
                    new XElement(xmlns + "seatitle", sitemapNode.SeaTitle)
                    );
                root.Add(urlElement);
            }

            XDocument document = new XDocument(root);
            return document.ToString(SaveOptions.DisableFormatting);
        }

        public IEnumerable<SiteMapNode> GetNodes(string articleGroupUrlSection, string city)
        {
            var formats = new[]
            {
                new[] { SeoParameterType.ArticleGroup, SeoParameterType.City, SeoParameterType.District, SeoParameterType.Phrase, },
                new[] { SeoParameterType.ArticleGroup, SeoParameterType.City, SeoParameterType.Phrase, },
                new[] { SeoParameterType.ArticleGroup, SeoParameterType.City, SeoParameterType.District, },
                new[] { SeoParameterType.ArticleGroup, SeoParameterType.District, SeoParameterType.Phrase, },
                new[] { SeoParameterType.ArticleGroup, SeoParameterType.City, },
                new[] { SeoParameterType.ArticleGroup, SeoParameterType.District, },
                new[] { SeoParameterType.Alias, },
            };

            var cityId = SearchCityId(city);
            if (!cityId.HasValue)
            {
                yield break;
            }

            var articleGroupName = ToArticleGroupName(articleGroupUrlSection);

            Dictionary<SeoParameterType, ISeoParameter[]> dataSets;
            using (var context = new ApplicationDbContext())
            {
                dataSets = DbSets
                    .Select(x => (
                        x.Key,
                        x.Value(context, articleGroupName, cityId.Value).AsNoTracking().ToArray()
                    ))
                    .ToDictionary(x => x.Item1, x => x.Item2);
            }

            var combinations = formats
                .Select(x =>
                {
                    return x.Select(y => (seoParameterType: y, dataSet: dataSets[y])).ToArray();
                })
                .ToArray();

            var now = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

            foreach (var combination in combinations)
            {
                var nodePriority = string.Format("{0:0.0}", (0.5 + ((.5 / 4) * combination.Length)));

                foreach (var placement in Placements(combination))
                {
                    var node = new SiteMapNode();
                    var seoTitle = string.Join(" ", placement.Select(x => x.seoParameter.Value));
                    var url = string.Join("/", placement.Select(x => x.seoParameter.Alias + "-" + UrlSectionPostfixes[x.seoParameterType]));

                    node.Location = "/" + url;
                    node.LastModified = now;
                    node.Priority = nodePriority;
                    node.ChangeFrequency = "hourly";

                    node.SeaTitle = seoTitle;

                    yield return node;
                }
            }
        }

        private int? SearchCityId(string city)
        {
            using (var context = new ApplicationDbContext())
            {
                var foundCityId = context
                    .Set<DbCity>()
                    .Where(x => x.InternalName == city)
                    .Select(x => (int?)x.Id)
                    .FirstOrDefault();
                if (!foundCityId.HasValue)
                {
                    return null;
                }
                return foundCityId.Value;
            }
        }

        private IEnumerable<(SeoParameterType seoParameterType, ISeoParameter seoParameter)[]> Placements((SeoParameterType seoParameterType, ISeoParameter[] dataSet)[] combination)
        {
            var combinationMaxIndexes = combination.Select(x => x.dataSet.Length).ToArray();

            foreach (var placementIndexes in PlacementIndexes(combinationMaxIndexes))
            {
                var placement = new (SeoParameterType seoParameterType, ISeoParameter seoParameter)[combination.Length];

                for (int i = 0; i < combination.Length; i++)
                {
                    placement[i] = (combination[i].seoParameterType, combination[i].dataSet[placementIndexes[i]]);
                }

                var seoRoutingResult = new SeoRoutingResult();
                var possiblePlacement = placement.All(x => !x.seoParameter.UpdateRoutingResult(seoRoutingResult));

                if (possiblePlacement)
                {
                    yield return placement;
                }
            }
        }

        private IEnumerable<int[]> PlacementIndexes(int[] maxIndexes)
        {
            // Because we know that the max combination length is 4 is mush easy to make it as known number of nested loops
            var positions = maxIndexes.Length;

            for (int i = 0; i < maxIndexes[0]; i++)
            {
                if (positions > 1)
                {
                    for (int j = 0; j < maxIndexes[1]; j++)
                    {
                        if (positions > 2)
                        {
                            for (int k = 0; k < maxIndexes[2]; k++)
                            {
                                if (positions > 3)
                                {
                                    for (int l = 0; l < maxIndexes[3]; l++)
                                    {
                                        yield return new[] { i, j, k, l };
                                    }
                                }
                                else
                                {
                                    yield return new[] { i, j, k };
                                }
                            }
                        }
                        else
                        {
                            yield return new[] { i, j };
                        }
                    }
                }
                else
                {
                    yield return new[] { i, };
                }
            }
        }

        private static Uri GetBaseUri()
        {
            return new Uri($"{HttpContext.Current.Request.Url.Scheme}://{HttpContext.Current.Request.Url.Host}:{HttpContext.Current.Request.Url.Port}/");
        }

        private string ToUrlSection(string articleGroupName)
        {
            return articleGroupName.Replace(",", "-");
        }

        private string ToArticleGroupName(string urlSection)
        {
            return urlSection.Replace("-", ",");
        }
    }
}