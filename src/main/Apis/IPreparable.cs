using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayStack.Net
{
    public interface IPreparable
    {
        void Prepare();
    }

    public static class Extension
    {
        public static string ToQueryString(this object request)
        {
            if (request == null)
                return string.Empty;

            return string.Join("&",
                request.GetType()
                    .GetProperties()
                    .Select(p => new { p.Name, Value = p.GetValue(request, null) })
                    .Where(p => p.Value != null)
                    .Select(p => $"{p.Name.ToCamelCase()}={HttpUtility.UrlEncode(GetQueryStringValue(p.Value))}")
            );
        }
        
        private static string ToCamelCase(this string str)
        {
            if (string.IsNullOrEmpty(str) || char.IsLower(str[0]))
                return str;

            return char.ToLowerInvariant(str[0]) + str.Substring(1);
        }

        private static string GetQueryStringValue(object value)
        {
            if (value is DateTime?)
            {
                var nullableDateTime = (DateTime?)value;
                if (nullableDateTime.HasValue)
                {
                    return nullableDateTime.Value.ToString("o");
                }
            }

            return value.ToString();
        }
    }
}