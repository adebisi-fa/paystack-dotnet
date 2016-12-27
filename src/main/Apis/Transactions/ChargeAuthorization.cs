using Newtonsoft.Json;
using XtremeIT.Library.Pins;

namespace PayStack.Net
{
    public class ChargeAuthorizationRequest : RequestMetadataExtender
    {
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

        public string Bearer { get; set; }

        public override void Prepare()
        {
            base.Prepare();
            Reference =
                $"{Reference};{Generator.NewPin(new GeneratorSettings {Domain = GeneratorCharacterDomains.AlphaNumerics, PinLength = 7})}";
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