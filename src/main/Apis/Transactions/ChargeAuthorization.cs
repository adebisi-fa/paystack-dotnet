using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XtremeIT.Library.Pins;

namespace PayStack.Net
{
    public class ChargeAuthorizationRequest : IPreparable
    {
        public ChargeAuthorizationRequest()
        {
            CustomFields = new List<CustomField>();
            MetadataObject = new Dictionary<string, object>();
        }

        public string Reference { get; set; }

        [JsonProperty("authorization_code")]
        public string AuthorizationCode { get; set; }

        public string Currency { get; set; }

        [JsonProperty("amount")]
        public string AmountInKobo { get; set; }

        public string Email { get; set; }

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

    public class ChargeAuthorizationResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public TransactionList.Datum Data { get; set; }
    }
}
