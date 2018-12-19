using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;

using SeoPoc.Web.DataAccess;
using SeoPoc.Web.DataAccess.Entities;
using SeoPoc.Web.Models;

namespace SeoPoc.Web.Services
{
    public class SiteMapService
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

        private class SiteMapNode
        {
            public string Loc { get; set; }

            public string LastModified { get; set; }

            public string Priority { get; set; }

            public string ChangeFrequency { get; set; }

            public string SeaTitle { get; set; }
        }


        public string GetSiteMap()
        {
            throw new NotImplementedException();
        }

        private SiteMapNode[] GetNodes()
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

            Dictionary<SeoParameterType, ISeoParameter[]> dataSets;
            using (var context = new ApplicationDbContext())
            {
                dataSets = DbSets.Select(x => (x.Key, x.Value(context).AsNoTracking().ToArray()))
                    .ToDictionary(x => x.Item1, x => x.Item2);
            }

            var combinations = formats
                .Select(x =>
                {
                    return x.Select(y => (seoParameterType: y, dataSet: dataSets[y])).ToArray();
                })
                .ToArray();

            var result = new List<SiteMapNode>();
            foreach (var combination in combinations)
            {
                foreach (var placement in Placements(combination))
                {
                    var node = new SiteMapNode();
                    var seoTitle = string.Join(" ", placement.Select(x => x.seoParameter.Value));
                    var url = string.Join("/", placement.Select(x => x.seoParameter.Alias + "-" + UrlSectionPostfixes[x.seoParameterType]));

                    node.Loc = "/" + url;
                    node.LastModified = DateTime.Now.ToString("YYYY-MM-dd", CultureInfo.InvariantCulture);
                    node.Priority = string.Format("{0:0.0}", (0.5 + (.5 / 4 * placement.Length)));
                    node.ChangeFrequency = "hourly";

                    node.SeaTitle = seoTitle;
                }
            }

            return result.ToArray();
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
    }
}