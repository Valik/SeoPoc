using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeoPoc.Web.Services
{
    public class SiteMapService
    {
        private class SiteMapNode
        {
            public string Loc { get; set; }

            public string LastModified { get; set; }

            public string Priority { get; set; }

            public string ChangeFrequency { get; set; }
        }


        public string GetSiteMap()
        {
            throw new NotImplementedException();
        }

        private SiteMapNode[] GetNodes()
        {
            throw new NotImplementedException();
        }
    }
}