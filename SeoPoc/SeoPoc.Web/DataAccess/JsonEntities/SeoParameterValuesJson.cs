﻿namespace SeoPoc.Web.DataAccess.JsonEntities
{
    public class SeoParameterValuesJson
    {
        public SeoParameterValueJson[] Values { get; set; }

        public int Version { get; } = 1;
    }
}