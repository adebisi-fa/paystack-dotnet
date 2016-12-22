using System.Collections.Generic;
using Newtonsoft.Json;
using XtremeIT.Library.Pins;

namespace PayStack.Net
{
    public class TransactionInitializeRequest : IPreparable
    {
        public TransactionInitializeRequest()
        {
            CustomFields = new List<CustomField>();
            MetadataObject = new Dictionary<string, object>();
        }

        public string Reference { get; set; }

        [JsonProperty("amount")]
        public string AmountInKobo { get; set; }

        public string Email { get; set; }
        public string Plan { get; set; }

        [JsonProperty("callback_url")]
        public string CallbackUrl { get; set; }

        public string SubAccount { get; set; }

        [JsonProperty("transaction_charge")]
        public int TransactionCharge { get; set; }

        [JsonIgnore]
        public List<CustomField> CustomFields { get; set; }

        [JsonIgnore]
        public Dictionary<string, object> MetadataObject { get; set; }

        public string Metadata { get; set; }

        public string Bearer { get; set; }

        public void Prepare()
        {
            MetadataObject["custom_fields"] = CustomFields.ToArray();
            Metadata = JsonConvert.SerializeObject(MetadataObject, PayStackApi.SerializerSettings);
            Reference = $"{Reference};{Generator.NewPin(new GeneratorSettings { Domain = GeneratorCharacterDomains.AlphaNumerics, PinLength = 7 })}";
        }
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

        public static CustomField From(string displayName, string variableName, string value)
            => new CustomField(displayName, variableName, value);
    }

    public static class PayStackChargesBearer
    {
        public static string Account = nameof(Account).ToLower();
        public static string SubAccount = nameof(SubAccount).ToLower();
    }

    public class TransactionInitialize
    {
        public class Data
        {

            [JsonProperty("authorization_url")]
            public string AuthorizationUrl { get; set; }

            [JsonProperty("access_code")]
            public string AccessCode { get; set; }

            [JsonProperty("reference")]
            public string Reference { get; set; }
        }
    }

    public class TransactionInitializeResponse
    {

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public TransactionInitialize.Data Data { get; set; }
    }
}