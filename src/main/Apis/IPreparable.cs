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

            var properties = (request.GetType()
                    .GetProperties()
                    .Select(property => new { property, value = property.GetValue(request, null) })
                    .Where(t => t.value != null)
                    .Select(t => new { t, stringValue = GetQueryStringValue(t.value) })
                    .Select(t => $"{t.t.property.Name.ToCamelCase()}={HttpUtility.UrlEncode(t.stringValue)}"))
                .ToList();

            return string.Join("&", properties);
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