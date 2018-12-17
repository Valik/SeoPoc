using System.Collections.Generic;
using System.Data.Entity.Migrations;

using Newtonsoft.Json;

using SeoPoc.Web.DataAccess.Entities;
using SeoPoc.Web.DataAccess.JsonEntities;

using WebGrease.Css.Extensions;

namespace SeoPoc.Web.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SeoPoc.Web.DataAccess.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SeoPoc.Web.DataAccess.ApplicationDbContext context)
        {
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //{
            //    System.Diagnostics.Debugger.Launch();
            //}

            var spbDistricts = new[]
            {
                new DbDistrict
                {
                    Name = "Адмиралтейский район",
                    SeoParameters = new List<DbDistrictSeoParameter>
                    {
                        new DbDistrictSeoParameter
                        {
                            Value = "Адмиралтейский район",
                            Alias = "Admiraltejskij-rajon"
                        },
                        new DbDistrictSeoParameter
                        {
                            Value = "в Адмиралтейском районе",
                            Alias = "Admiraltejskom-rajone"
                        },
                    },
                },
                new DbDistrict
                {
                    Name = "Петроградский район",
                    SeoParameters = new List<DbDistrictSeoParameter>
                    {
                        new DbDistrictSeoParameter
                        {
                            Value = "Петроградский район",
                            Alias = "Petrogradskij-rajon"
                        },
                        new DbDistrictSeoParameter
                        {
                            Value = "в Петроградском районе",
                            Alias = "Petrogradskom-rajone"
                        },
                    },
                },
            };
            var spb = new DbCity
            {
                Name = "Санкт-Петербург",
                SeoParameters = new List<DbCitySeoParameter>
                {
                    new DbCitySeoParameter
                    {
                        Value = "Санкт-Петербург",
                        Alias = "Sankt-Peterburg"
                    },
                    new DbCitySeoParameter
                    {
                        Value = "в Санкт-Петербурге",
                        Alias = "Sankt-Peterburge"
                    },
                },
                //Districts = spbDistricts,
            };

            var nskDistricts = new[]
            {
                new DbDistrict
                {
                    Name = "Дзержинский район",
                    SeoParameters = new List<DbDistrictSeoParameter>
                    {
                        new DbDistrictSeoParameter
                        {
                            Value = "Дзержинский район",
                            Alias = "Dzerzhinskij-rajon"
                        },
                        new DbDistrictSeoParameter
                        {
                            Value = "в Дзержинском районе",
                            Alias = "Dzerzhinskom-rajone"
                        },
                    },
                },
                new DbDistrict
                {
                    Name = "Калининский район",
                    SeoParameters = new List<DbDistrictSeoParameter>
                    {
                        new DbDistrictSeoParameter
                        {
                            Value = "Калининский район",
                            Alias = "Kalininskij-rajon"
                        },
                        new DbDistrictSeoParameter
                        {
                            Value = "в Калининском районе",
                            Alias = "Kalininskom-rajone"
                        },
                    },
                },
            };
            var nsk = new DbCity
            {
                Name = "Новосибирск",
                SeoParameters= new List<DbCitySeoParameter>
                {
                    new DbCitySeoParameter
                    {
                        Value = "Новосибирск",
                        Alias = "Novosibirsk"
                    },
                    new DbCitySeoParameter
                    {
                        Value = "в Новосибирске",
                        Alias = "Novosibirske"
                    },
                },
                //Districts = nskDistricts,
            };

            var cities = new [] { spb, nsk };
            context.Set<DbCity>().AddRange(cities);
            context.SaveChanges();

            spbDistricts.ForEach(x =>
            {
                x.CityId = spb.Id;
                x.SeoParameters.ForEach(y => y.CityId = spb.Id);
            });
            nskDistricts.ForEach(x =>
            {
                x.CityId = nsk.Id;
                x.SeoParameters.ForEach(y => y.CityId = nsk.Id);
            });

            context.Set<DbDistrict>().AddRange(spbDistricts);
            context.Set<DbDistrict>().AddRange(nskDistricts);
            context.SaveChanges();

            var articleGroups = new[]
            {
                new DbArticleGroupSeoParameter
                {
                    ArticleGroupInternalName = "1k",
                    Alias = "1k",
                    Value = "снять квартиру",
                },
                new DbArticleGroupSeoParameter
                {
                    ArticleGroupInternalName = "1k",
                    Alias = "1k-rent",
                    Value = "снять 1-комнатную квартиру",
                },
                new DbArticleGroupSeoParameter
                {
                    ArticleGroupInternalName = "K",
                    Alias = "k-rent",
                    Value = "снять комнату",
                },
            };
            context.Set<DbArticleGroupSeoParameter>().AddRange(articleGroups);

            var aliases = new[]
            {
                new DbAliasSeoParameter
                {
                    City = spb,
                    PriceTo = 10000,
                    Alias = "spb-cheep-room",
                    ArticleGroupInternalName = "K",
                    Value = "снять комнату СПб недорого",
                },
                new DbAliasSeoParameter
                {
                    City = spb,
                    PriceFrom = 10000,
                    Alias = "spb-room-10000",
                    ArticleGroupInternalName = "K",
                    Value = "снять комнату СПб недорого",
                },
                new DbAliasSeoParameter
                {
                    City = spb,
                    PriceTo = 12000,
                    Alias = "nsk-cheep-room",
                    ArticleGroupInternalName = "K",
                    Value = "снять квартиру Новосибирск недорого",
                },
            };
            context.Set<DbAliasSeoParameter>().AddRange(aliases);

            var phrases = new[]
            {
                new DbPhraseSeoParameter
                {
                    Alias = "wo-middlemans",
                    Value = "без посредников",
                },
                new DbPhraseSeoParameter
                {
                    Alias = "by-owner",
                    Value = "от собственника",
                },
                new DbPhraseSeoParameter
                {
                    Alias = "wo-agents",
                    Value = "без агента",
                },
            };
            context.Set<DbPhraseSeoParameter>().AddRange(phrases);
            context.SaveChanges();
        }
    }
}
