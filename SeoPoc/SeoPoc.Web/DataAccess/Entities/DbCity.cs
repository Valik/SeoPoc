using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SeoPoc.Web.DataAccess.Entities
{
    [Table("dbo.City")]
    public class DbCity : ISeoParameter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(256)]
        public string Name { get; set; }

        [MaxLength(256)]
        public string PlaceholderName { get; set; } = "City";

        public string SeoParameterValuesJson { get; set; }

        [InverseProperty("City")]
        public virtual ICollection<DbDistrict> Districts { get; set; }
    }
}