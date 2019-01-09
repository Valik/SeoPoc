using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using SeoPoc.Web.Services;

namespace SeoPoc.Web.DataAccess.Entities
{
    [Table("dbo.AliasSeoParameter")]
    public class DbAliasSeoParameter : ISeoParameter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(512)]
        public string Value { get; set; }

        [MaxLength(512)]
        public string Alias { get; set; }

        public int? CityId { get; set; }

        public int? DistrictId { get; set; }

        public int? PriceFrom { get; set; }

        public int? PriceTo { get; set; }

        [MaxLength(256)]
        public string ArticleGroupInternalName { get; set; }

        [ForeignKey("CityId")]
        public virtual DbCity City { get; set; }

        [ForeignKey("DistrictId")]
        public virtual DbDistrict District { get; set; }

        public bool UpdateRoutingResult(SeoRoutingResult routingResult)
        {
            bool result =
                routingResult.CityId.HasValue && CityId != routingResult.CityId ||
                routingResult.DistrictId.HasValue && DistrictId != routingResult.DistrictId ||
                routingResult.PriceFrom.HasValue && PriceFrom != routingResult.PriceFrom ||
                routingResult.PriceTo.HasValue && PriceTo != routingResult.PriceTo ||
                !string.IsNullOrEmpty(routingResult.SeoTitle) && !routingResult.SeoTitle.Equals(Value, StringComparison.InvariantCultureIgnoreCase) ||
                !string.IsNullOrEmpty(routingResult.ArticleGroupInternalName) && !routingResult.ArticleGroupInternalName.Equals(ArticleGroupInternalName, StringComparison.InvariantCultureIgnoreCase);

            routingResult.CityId = CityId;
            routingResult.DistrictId = DistrictId;
            routingResult.ArticleGroupInternalName = ArticleGroupInternalName;
            routingResult.PriceFrom = PriceFrom;
            routingResult.PriceTo = PriceTo;
            routingResult.SeoTitle = Value;

            return result;
        }

        bool ISeoParameter.UpdateRoutingResult(SeoRoutingResult routingResult)
        {
            throw new NotImplementedException();
        }
    }
}