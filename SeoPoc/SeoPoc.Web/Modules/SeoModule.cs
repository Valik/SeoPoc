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

            if (httpContext.Request.Url.AbsolutePath != "/" && httpContext.Request.Url.AbsolutePath.EndsWith("/", StringComparison.Ordinal))
            {
                var redirect = httpContext.Request.Url.AbsolutePath;
                redirect = redirect.Remove(redirect.Length - 1);
                httpContext.Response.Clear();
                httpContext.Response.Status = "301 Moved Permanently";
                httpContext.Response.StatusCode = 301;
                httpContext.Response.AddHeader("Location", redirect);
                httpContext.Response.End();
                return;
            }

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