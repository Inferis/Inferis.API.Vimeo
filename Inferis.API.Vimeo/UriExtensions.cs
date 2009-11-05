using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inferis.API.Vimeo
{
    public static class UriExtensions
    {
        public static Uri AddParameters(this Uri uri, IDictionary<string, string> parameters)
        {
            var result = new StringBuilder();
            result.Append(uri.ToString());

            var sep = string.IsNullOrEmpty(uri.Query) ? "?" : "&";
            foreach (var key in parameters.Keys) {
                result.Append(sep);
                result.Append(key);
                result.Append("=");
                result.Append(parameters[key] ?? "");

                sep = "&";
            }

            return new Uri(result.ToString());
        }
    }
}
