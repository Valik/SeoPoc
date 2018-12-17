using System;
using System.Collections.Generic;
using System.Linq;
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

            return View(seoRoutingResult);
        }
    }
}