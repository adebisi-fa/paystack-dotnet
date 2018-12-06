using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PayStack.Net
{
    public static class Extensions
    {
        // For details on how to query JObject, please visit https://www.newtonsoft.com/json/help/html/QueryingLINQtoJSON.htm
        public static JObject AsJObject(this IHasRawResponse response)
        {
            var rawJson = response.RawJson;
            if (string.IsNullOrWhiteSpace(rawJson))
                rawJson = JsonConvert.SerializeObject(response);
            return JObject.Parse(response.RawJson);
        }

        public static TD PopulateWith<TS, TD>(this TD destination, TS source)
        {
            var sourceType = typeof(TS);
            var destinationType = typeof(TD);

            foreach (var destinationProperty in destinationType.GetProperties())
            {
                var sourceProperty = sourceType.GetProperty(destinationProperty.Name);

                if (sourceProperty == null)
                    continue;

                destinationProperty.SetValue(destination, sourceProperty.GetValue(source, null), null);
            }

            foreach (var destinationField in destinationType.GetFields())
            {
                var sourceField = sourceType.GetField(destinationField.Name);

                if (sourceField == null)
                    continue;

                destinationField.SetValue(destination, sourceField.GetValue(source));
            }

            return destination;
        }
    }
}