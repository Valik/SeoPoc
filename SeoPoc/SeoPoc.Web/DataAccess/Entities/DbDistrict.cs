using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeoPoc.Web.DataAccess.Entities
{
    [Table("dbo.District")]
    public class DbDistrict : ISeoParameter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(256)]
        public string Name { get; set; }

        public int CityId { get; set; }

        [MaxLength(256)]
        public string PlaceholderName { get; set; } = "District";

        public string SeoParameterValuesJson { get; set; }

        [ForeignKey("CityId")]
        public virtual DbCity City { get; set; }
    }
}