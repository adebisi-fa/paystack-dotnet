using System;
using Newtonsoft.Json;

namespace PayStack.Net
{
    public class Transfer
    {
        [JsonProperty("recipient")]
        public TransferRecipient.Data Recipient { get; set; }

        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("source_details")]
        public object SourceDetails { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("failures")]
        public object Failures { get; set; }

        [JsonProperty("transfer_code")]
        public string TransferCode { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }

    public class BulkTransferEntry
    {
        public int Amount { get; set; }
        public string Recipient { get; set; }
    }

    public class InitiateTransferResponse : HasRawResponse, IApiResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}