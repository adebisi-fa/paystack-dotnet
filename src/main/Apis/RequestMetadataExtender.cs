using System.Collections.Generic;
using Newtonsoft.Json;

namespace PayStack.Net
{
    public class RequestMetadataExtender : IPreparable
    {
        public RequestMetadataExtender()
        {
            CustomFields = new List<CustomField>();
            MetadataObject = new Dictionary<string, object>();
        }

        [JsonIgnore]
        public List<CustomField> CustomFields { get; set; }

        [JsonIgnore]
        public Dictionary<string, object> MetadataObject { get; set; }

        public string Metadata { get; set; }

        public virtual void Prepare()
        {
            MetadataObject["custom_fields"] = CustomFields.ToArray();
            Metadata = JsonConvert.SerializeObject(MetadataObject, PayStackApi.SerializerSettings);
        }
    }

    public class Metadata : Dictionary<string, object>
    {
        [JsonProperty("custom_fields")]
        public IList<CustomField> CustomFields { get; set; }
    }

    public class CustomField
    {
        public CustomField(string displayName, string variableName, string value)
        {
            DisplayName = displayName;
            VariableName = variableName;
            Value = value;
        }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("variable_name")]
        public string VariableName { get; set; }

        public string Value { get; set; }

        public static CustomField From(string displayName, string variableName, string value) =>
            new CustomField(displayName, variableName, value);
    }
}
