using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeoPoc.Web.DataAccess.Entities
{
    public interface ISeoParameter
    {
        //string PlaceholderName { get; set; }

        string SeoParameterValuesJson { get; set; }
    }
}