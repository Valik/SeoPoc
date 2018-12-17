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
                //Districts = spbDistricts,
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
                    Value = "����� ��������",
                },
                new DbArticleGroupSeoParameter
                {
                    ArticleGroupInternalName = "1k",
                    Alias = "1k-rent",
                    Value = "����� 1-��������� ��������",
                },
                new DbArticleGroupSeoParameter
                {
                    ArticleGroupInternalName = "K",
                    Alias = "k-rent",
                    Value = "����� �������",
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
                    Value = "����� ������� ��� ��������",
                },
                new DbAliasSeoParameter
                {
                    City = spb,
                    PriceFrom = 10000,
                    Alias = "spb-room-10000",
                    ArticleGroupInternalName = "K",
                    Value = "����� ������� ��� ��������",
                },
                new DbAliasSeoParameter
                {
                    City = spb,
                    PriceTo = 12000,
                    Alias = "nsk-cheep-room",
                    ArticleGroupInternalName = "K",
                    Value = "����� �������� ����������� ��������",
                },
            };
            context.Set<DbAliasSeoParameter>().AddRange(aliases);

            var phrases = new[]
            {
                new DbPhraseSeoParameter
                {
                    Alias = "wo-middlemans",
                    Value = "��� �����������",
                },
                new DbPhraseSeoParameter
                {
                    Alias = "by-owner",
                    Value = "�� ������������",
                },
                new DbPhraseSeoParameter
                {
                    Alias = "wo-agents",
                    Value = "��� ������",
                },
            };
            context.Set<DbPhraseSeoParameter>().AddRange(phrases);
            context.SaveChanges();
        }
    }
}
