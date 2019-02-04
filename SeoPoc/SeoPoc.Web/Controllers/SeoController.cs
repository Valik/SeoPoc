using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

using SeoPoc.Web.Services;

namespace SeoPoc.Web.Controllers
{
    public class SeoController : Controller
    {
        public ActionResult Index()
        {
            var seoRoutingResult = HttpContext.Items["HTTPCONTEXT:SEOROUTING:RESULT"] as SeoRoutingResult;
            var details = new SeoRoutingService().ConstructSeoDetails(seoRoutingResult);

            return View(details);
        }

        public ActionResult SitemapIndex()
        {
            var xml = new SiteMapService().GetSiteMapIndex();
            return Content(xml, "text/xml", Encoding.UTF8);
        }

        //[Route("/sitemap/{articleGroup}/{city}", Name = "sitemap")]
        public ActionResult Sitemap(string articleGroup, string city)
        {
            var xml = new SiteMapService().GetSiteMap(articleGroup, city);
            return Content(xml, "text/xml", Encoding.UTF8);
        }
    }
}