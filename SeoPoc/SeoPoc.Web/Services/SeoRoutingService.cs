using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Web;

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
        }

        public RouteResult Route(Uri currentUrl)
        {
            var seoParameterTypes = 
                Enum.GetValues(typeof(SeoParameterType))
                    .Cast<SeoParameterType>()
                    .Select(x => (x.ToString(), x))
                    .ToDictionary(x => x.Item1, x => x.Item2, StringComparer.InvariantCultureIgnoreCase);

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

                        if (!seoParameterTypes.TryGetValue(seoParameterTypeString[seoParameterTypeString.Length - 1], out var seoParameterType))
                        {
                            return (section: x, type: SeoParameterType.Unknown);
                        }

                        return (section: string.Join("-", seoParameterTypeString.Take(seoParameterTypeString.Length - 1)), type: seoParameterType);
                    })
                .ToArray();

            if (segments.All(x => x.type == SeoParameterType.Unknown))
            {
                return new RouteResult
                {
                };
            }

            DbCitySeoParameter citySeoParameter = null;
            DbDistrictSeoParameter districtSeoParameter = null;

            foreach (var segment in segments)
            {
                switch (segment.type)
                {
                    case SeoParameterType.City:
                        using (var context = new ApplicationDbContext())
                        {
                            citySeoParameter = context.Set<DbCitySeoParameter>()
                                .FirstOrDefault(x => x.Alias == segment.section);
                        }
                        break;

                    case SeoParameterType.District:
                        using (var context = new ApplicationDbContext())
                        {
                            var query = context.Set<DbDistrictSeoParameter>()
                                .Include(x => x.District)
                                .Where(x => x.Alias == segment.section);

                            if (citySeoParameter != null)
                            {
                                query = query.Where(x => x.District.CityId == citySeoParameter.CityId);
                            }

                            districtSeoParameter = query.FirstOrDefault();
                        }
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            var seoParams = new[] { "Снять квартиру", citySeoParameter?.Value, districtSeoParameter?.Value }
                .Select(x => !string.IsNullOrEmpty(x)).ToArray();

            var result = new RouteResult();

            result.SeoTitle = string.Join(" ", seoParams);
            result.CityId = citySeoParameter?.CityId ?? districtSeoParameter?.District.CityId;
            result.DistrictId = districtSeoParameter?.DistrictId;

            return result;
        }
    }
}