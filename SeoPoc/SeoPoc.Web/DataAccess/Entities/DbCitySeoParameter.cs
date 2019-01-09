using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using SeoPoc.Web.Services;

namespace SeoPoc.Web.DataAccess.Entities
{
    [Table("dbo.CitySeoParameter")]
    public class DbCitySeoParameter : ISeoParameter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(256)]
        public string Value { get; set; }

        [MaxLength(256)]
        public string Alias { get; set; }

        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public virtual DbCity City { get; set; }

        public bool UpdateRoutingResult(SeoRoutingResult routingResult)
        {
            var result = routingResult.CityId.HasValue && CityId != routingResult.CityId;

            routingResult.CityId = CityId;

            return result;
        }
    }
}