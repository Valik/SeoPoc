namespace SeoPoc.Web.Helpers
{
    public static class UrlExtensions
    {
        public static string ToSeoUrl(this string url)
        {
            return url.ToLowerInvariant().TrimEnd('/');
        }
    }
}