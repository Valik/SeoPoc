using System.Collections.Generic;

namespace SeoPoc.Web.Services
{
    public class SeoDetails
    {
        public SeoRoutingResult RoutingResult { get; set; }

        public List<BreadcrumbItem>  Breadcrumbs { get; set; }

        public string CityName { get; set; }

        public string Url { get; set; }
    }
}