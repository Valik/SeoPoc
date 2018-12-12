using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SeoPoc.Web.DataAccess.Entities
{
    [Table("dbo.SeoUrlAlias")]
    public class DbSeoUrlAlias
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string TitleFormat { get; set; }

        public int? CityId { get; set; }

        public int? DistrictId { get; set; }

        public int? PriceFrom { get; set; }

        public int? PriceTo { get; set; }
    }
}