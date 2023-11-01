using System;

namespace Kettle
{
    internal static class StringExtensions
    {
        public static Uri FormatUri(this string pattern, params object[] args)
        {
            Ensure.ArgumentNotNullOrEmptyString(pattern, nameof(pattern));
            var uriString = string.Format(pattern, args);
            return new Uri(uriString, UriKind.Relative);
        }
    }
}