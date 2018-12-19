using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

using SeoPoc.Web.Services;

namespace SeoPoc.Web.DataAccess.Entities
{
    [Table("dbo.DistrictSeoParameter")]
    public class DbDistrictSeoParameter : ISeoParameter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(256)]
        public string Value { get; set; }

        [MaxLength(256)]
        public string Alias { get; set; }

        public int CityId { get; set; }

        public int DistrictId { get; set; }

        [ForeignKey("CityId")]
        public virtual DbCity City { get; set; }

        [ForeignKey("DistrictId")]
        public virtual DbDistrict District { get; set; }

        public bool UpdateRoutingResult(SeoRoutingResult routingResult)
        {
            bool result =
                routingResult.CityId.HasValue && CityId != routingResult.CityId ||
                routingResult.DistrictId.HasValue && DistrictId != routingResult.DistrictId;

            routingResult.CityId = CityId;
            routingResult.DistrictId = DistrictId;

            return result;
        }
    }
}