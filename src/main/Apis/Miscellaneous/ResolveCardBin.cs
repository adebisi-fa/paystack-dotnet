using Newtonsoft.Json;

namespace PayStack.Net
{
    public class ResolveCardBin
    {
        public class Data
        {
            [JsonProperty("bin")]
            public string Bin { get; set; }

            [JsonProperty("brand")]
            public string Brand { get; set; }

            [JsonProperty("sub_brand")]
            public string SubBrand { get; set; }

            [JsonProperty("country_code")]
            public string CountryCode { get; set; }

            [JsonProperty("country_name")]
            public string CountryName { get; set; }

            [JsonProperty("card_type")]
            public string CardType { get; set; }

            [JsonProperty("bank")]
            public string Bank { get; set; }

            [JsonProperty("linked_bank_id")]
            public int? LinkedBankId { get; set; }
        }
    }

    public class ResolveCardBinResponse : HasRawResponse, IApiResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public ResolveCardBin.Data Data { get; set; }
    }
}