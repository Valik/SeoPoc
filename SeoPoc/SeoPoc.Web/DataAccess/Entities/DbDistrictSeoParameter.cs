using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SeoPoc.Web.DataAccess.Entities
{
    [Table("dbo.DistrictSeoParameter")]
    public class DbDistrictSeoParameter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(256)]
        public string Value { get; set; }

        [MaxLength(256)]
        public string Alias { get; set; }

        public int DistrictId { get; set; }

        [ForeignKey("DistrictId")]
        public virtual DbDistrict District { get; set; }
    }
}