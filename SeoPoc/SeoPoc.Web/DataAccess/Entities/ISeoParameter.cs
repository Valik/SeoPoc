using SeoPoc.Web.Services;

namespace SeoPoc.Web.DataAccess.Entities
{
    public interface ISeoParameter
    {
        string Value { get; set; }

        string Alias { get; set; }

        bool UpdateRoutingResult(SeoRoutingResult routingResult);
    }
}