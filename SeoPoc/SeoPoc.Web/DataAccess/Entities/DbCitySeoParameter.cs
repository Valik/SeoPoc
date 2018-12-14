using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SeoPoc.Web.DataAccess.Entities
{
    [Table("dbo.CitySeoParameter")]
    public class DbCitySeoParameter
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
    }
}