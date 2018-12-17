using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using SeoPoc.Web.Services;

namespace SeoPoc.Web.DataAccess.Entities
{
    [Table("dbo.PhraseSeoParameter")]
    public class DbPhraseSeoParameter : ISeoParameter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(256)]
        public string Value { get; set; }

        [MaxLength(256)]
        public string Alias { get; set; }

        public void UpdateRoutingResult(SeoRoutingResult routingResult)
        {
        }
    }
}