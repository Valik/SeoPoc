using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeoPoc.Web.DataAccess.JsonEntities
{
    public enum SeoParameterType
    {
        In = 1 << 1,
        AsIs = 1 << 2,
        Slang = 1 << 3,
    }

    public class SeoParameterValueJson
    {
        public string Value { get; set; }

        public string Alias { get; set; }
    }
}