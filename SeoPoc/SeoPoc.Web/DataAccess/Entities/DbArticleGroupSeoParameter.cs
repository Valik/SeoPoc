using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using SeoPoc.Web.Services;

namespace SeoPoc.Web.DataAccess.Entities
{
    [Table("dbo.ArticleGroupSeoParameter")]
    public class DbArticleGroupSeoParameter : ISeoParameter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(256)]
        public string Value { get; set; }

        [MaxLength(256)]
        public string Alias { get; set; }

        [MaxLength(256)]
        public string ArticleGroupInternalName { get; set; }

        public bool UpdateRoutingResult(SeoRoutingResult routingResult)
        {
            var result = 
                !string.IsNullOrEmpty(routingResult.ArticleGroupInternalName) &&
                !routingResult.ArticleGroupInternalName.Equals(ArticleGroupInternalName, StringComparison.InvariantCultureIgnoreCase);

            routingResult.ArticleGroupInternalName = ArticleGroupInternalName;

            return result;
        }
    }
}