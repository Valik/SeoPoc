using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using SeoPoc.Web.Services;

namespace SeoPoc.Web.Modules
{
    public class SeoModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += ContextOnBeginRequest;
        }

        private void ContextOnBeginRequest(object sender, EventArgs eventArgs)
        {
            var httpContext = ((HttpApplication)sender).Context;

            var service = new SeoRoutingService();

            var result = service.Route(httpContext.Request.Url);
            if (result == null)
            {
                return;
            }

            httpContext.Items["HTTPCONTEXT:SEOROUTING:RESULT"] = result;

            httpContext.RewritePath("/");
        }

        public void Dispose()
        {
        }
    }
}