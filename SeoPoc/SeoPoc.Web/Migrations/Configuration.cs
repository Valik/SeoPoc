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
                    Name = "�������������� �����",
                    SeoParameters = new List<DbDistrictSeoParameter>
                    {
                        new DbDistrictSeoParameter
                        {
                            Value = "�������������� �����",
                            Alias = "Admiraltejskij-rajon"
                        },
                        new DbDistrictSeoParameter
                        {
                            Value = "� �������������� ������",
                            Alias = "Admiraltejskom-rajone"
                        },
                    },
                },
                new DbDistrict
                {
                    Name = "������������� �����",
                    SeoParameters = new List<DbDistrictSeoParameter>
                    {
                        new DbDistrictSeoParameter
                        {
                            Value = "������������� �����",
                            Alias = "Petrogradskij-rajon"
                        },
                        new DbDistrictSeoParameter
                        {
                            Value = "� ������������� ������",
                            Alias = "Petrogradskom-rajone"
                        },
                    },
                },
            };
            var spb = new DbCity
            {
                Name = "�����-���������",
                SeoParameters = new List<DbCitySeoParameter>
                {
                    new DbCitySeoParameter
                    {
                        Value = "�����-���������",
                        Alias = "Sankt-Peterburg"
                    },
                    new DbCitySeoParameter
                    {
                        Value = "� �����-����������",
                        Alias = "Sankt-Peterburge"
                    },
                },
                Districts = spbDistricts,
            };

            var nskDistricts = new[]
            {
                new DbDistrict
                {
                    Name = "����������� �����",
                    SeoParameters = new List<DbDistrictSeoParameter>
                    {
                        new DbDistrictSeoParameter
                        {
                            Value = "����������� �����",
                            Alias = "Dzerzhinskij-rajon"
                        },
                        new DbDistrictSeoParameter
                        {
                            Value = "� ����������� ������",
                            Alias = "Dzerzhinskom-rajone"
                        },
                    },
                },
                new DbDistrict
                {
                    Name = "����������� �����",
                    SeoParameters = new List<DbDistrictSeoParameter>
                    {
                        new DbDistrictSeoParameter
                        {
                            Value = "����������� �����",
                            Alias = "Kalininskij-rajon"
                        },
                        new DbDistrictSeoParameter
                        {
                            Value = "� ����������� ������",
                            Alias = "Kalininskom-rajone"
                        },
                    },
                },
            };
            var nsk = new DbCity
            {
                Name = "�����������",
                SeoParameters= new List<DbCitySeoParameter>
                {
                    new DbCitySeoParameter
                    {
                        Value = "�����������",
                        Alias = "Novosibirsk"
                    },
                    new DbCitySeoParameter
                    {
                        Value = "� ������������",
                        Alias = "Novosibirske"
                    },
                },
                Districts = nskDistricts,
            };

            var cities = new [] { spb, nsk };
            context.Set<DbCity>().AddRange(cities);

            context.SaveChanges();

            //var titles = new List<DbSeoUrlAlias>();

            //foreach (var city in cities)
            //{
            //    city.Districts.SelectMany(
            //        x => SelectSeoUrlAliases(city, x));


            //}
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
        }

        //private static IEnumerable<DbSeoUrlAlias> SelectSeoUrlAliases(DbCity city, DbDistrict district)
        //{
            //var titleFormat1 = $"����� �������� {{{city.PlaceholderName}}} {{{district.PlaceholderName}}}";
            //var titleFormat2 = $"����� �������� {{{city.PlaceholderName}}}";
            //var titleFormat3 = $"����� �������� {{{district.PlaceholderName}}}";

            //var cityValues = JsonConvert.DeserializeObject<SeoParameterValuesJson>(city.SeoParameterValuesJson)
            //    .Values;

            //var districtValues = JsonConvert.DeserializeObject<SeoParameterValuesJson>(district.SeoParameterValuesJson)
            //    .Values;

            //var result = new List<DbSeoUrlAlias>();

            //cityValues.Select(
            //    x =>
            //    {
                    
            //    });



            //yield return JsonConvert.DeserializeObject<SeoParameterValuesJson>(district.SeoParameterValuesJson)
            //    .Values
            //    .SelectMany(x => new [] {
            //        $"����� �������� {x.Value}"

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
        //}
    }
}
