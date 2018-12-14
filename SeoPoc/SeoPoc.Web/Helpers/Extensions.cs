using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeoPoc.Web.Helpers
{
    public static class Extensions
    {
        public static TResult IfNotNull<T, TResult>(this T target, Func<T, TResult> getResult, TResult @default = default(TResult))
            where T : class
        {
            return target != null ? getResult(target) : @default;
        }
    }
}