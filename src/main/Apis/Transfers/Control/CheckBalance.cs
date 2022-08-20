using System.Collections.Generic;
using Newtonsoft.Json;

namespace PayStack.Net
{
    public class TransferCheckBalance
    {
        public class Datum
        {

            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("balance")]
            public int Balance { get; set; }
        }
    }

    public class TransferCheckBalanceResponse : HasRawResponse, IApiResponse
    {

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public IList<TransferCheckBalance.Datum> Data { get; set; }
    }
}