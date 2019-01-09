using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SeoPoc.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "sitemaps",
                url: "sitemap_index.xml",
                defaults: new { controller = "Seo", action = "SitemapIndex" }
            );

            routes.MapRoute(
                "sitemap",
                "sitemap/{articleGroup}/{city}.xml",
                new { controller = "Seo", action = "Sitemap", articleGroup = UrlParameter.Optional, city = UrlParameter.Optional }

            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Seo", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
