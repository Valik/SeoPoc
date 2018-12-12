using System.Collections.Generic;

using Newtonsoft.Json;

using SeoPoc.Web.DataAccess.Entities;
using SeoPoc.Web.DataAccess.JsonEntities;

namespace SeoPoc.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SeoPoc.Web.DataAccess.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SeoPoc.Web.DataAccess.ApplicationDbContext context)
        {
            var spbDistricts = new[]
            {
                new DbDistrict
                {
                    Name = "Адмиралтейский район",
                    SeoParameterValuesJson = JsonConvert.SerializeObject(
                        new SeoParameterValuesJson
                        {
                            Values = new[]
                            {
                                new SeoParameterValueJson
                                {
                                    Value = "Адмиралтейский район",
                                    Alias = "Admiraltejskij-rajon"
                                },
                                new SeoParameterValueJson
                                {
                                    Value = "в Адмиралтейском районе",
                                    Alias = "Admiraltejskom-rajone"
                                },
                            },
                        }),
                },
                new DbDistrict
                {
                    Name = "Петроградский район",
                    SeoParameterValuesJson = JsonConvert.SerializeObject(
                        new SeoParameterValuesJson
                        {
                            Values = new[]
                            {
                                new SeoParameterValueJson
                                {
                                    Value = "Петроградский район",
                                    Alias = "Petrogradskij-rajon"
                                },
                                new SeoParameterValueJson
                                {
                                    Value = "в Петроградском районе",
                                    Alias = "Petrogradskom-rajone"
                                },
                            },
                        }),
                },
            };
            var spb = new DbCity
            {
                Name = "Санкт-Петербург",
                SeoParameterValuesJson = JsonConvert.SerializeObject(
                    new SeoParameterValuesJson
                    {
                        Values = new[]
                        {
                            new SeoParameterValueJson
                            {
                                Value = "Санкт-Петербург",
                                Alias = "Novosibirsk"
                            },
                            new SeoParameterValueJson
                            {
                                Value = "в Санкт-Петербурге",
                                Alias = "Sankt-Peterburge"
                            },
                        },
                    }),
                Districts = spbDistricts,
            };

            var nskDistricts = new[]
            {
                new DbDistrict
                {
                    Name = "Дзержинский район",
                    SeoParameterValuesJson = JsonConvert.SerializeObject(
                        new SeoParameterValuesJson
                        {
                            Values = new[]
                            {
                                new SeoParameterValueJson
                                {
                                    Value = "Дзержинский район",
                                    Alias = "Dzerzhinskij-rajon"
                                },
                                new SeoParameterValueJson
                                {
                                    Value = "в Дзержинском районе",
                                    Alias = "Dzerzhinskom-rajone"
                                },
                            },
                        }),
                },
                new DbDistrict
                {
                    Name = "Калининский район",
                    SeoParameterValuesJson = JsonConvert.SerializeObject(
                        new SeoParameterValuesJson
                        {
                            Values = new[]
                            {
                                new SeoParameterValueJson
                                {
                                    Value = "Калининский район",
                                    Alias = "Kalininskij-rajon"
                                },
                                new SeoParameterValueJson
                                {
                                    Value = "в Калининском районе",
                                    Alias = "Kalininskom-rajone"
                                },
                            },
                        }),
                },
            };
            var nsk = new DbCity
            {
                Name = "Новосибирск",
                SeoParameterValuesJson = JsonConvert.SerializeObject(
                    new SeoParameterValuesJson
                    {
                        Values = new[]
                        {
                            new SeoParameterValueJson
                            {
                                Value = "Новосибирск",
                                Alias = "Novosibirsk"
                            },
                            new SeoParameterValueJson
                            {
                                Value = "в Новосибирске",
                                Alias = "Novosibirske"
                            },
                        },
                    }),
                Districts = nskDistricts,
            };

            var cities = new [] { spb, nsk };
            context.Set<DbCity>().AddRange(cities);

            context.SaveChanges();

            var titles = new List<DbSeoUrlAlias>();

            foreach (var city in cities)
            {
                city.Districts.SelectMany(
                    x => SelectSeoUrlAliases(city, x));


            }
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        })

        private static IEnumerable<DbSeoUrlAlias> SelectSeoUrlAliases(DbCity city, DbDistrict district)
        {
            var titleFormat1 = $"снять квартиру {{{city.PlaceholderName}}} {{{district.PlaceholderName}}}";
            var titleFormat2 = $"снять квартиру {{{city.PlaceholderName}}}";
            var titleFormat3 = $"снять квартиру {{{district.PlaceholderName}}}";

            var cityValues = JsonConvert.DeserializeObject<SeoParameterValuesJson>(city.SeoParameterValuesJson)
                .Values;

            var districtValues = JsonConvert.DeserializeObject<SeoParameterValuesJson>(district.SeoParameterValuesJson)
                .Values;

            var result = new List<DbSeoUrlAlias>();

            cityValues.Select(
                x =>
                {
                    
                });



            //yield return JsonConvert.DeserializeObject<SeoParameterValuesJson>(district.SeoParameterValuesJson)
            //    .Values
            //    .SelectMany(x => new [] {
            //        $"снять квартиру {x.Value}"

            //    })


            //return new[]
            //{
            //    new DbSeoUrlAlias
            //    {
            //        CityId = city.Id,
            //        DistrictId = x.Id,
            //        TitleFormat = ""
            //    },

            //};
        }
    }
}
