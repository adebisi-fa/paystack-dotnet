using System;
using Newtonsoft.Json;

namespace PayStack.Net
{
    public class TransactionExportRequest
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public bool Settled { get; set; }
        public string PaymentPage { get; set; }
    }

    public class TransactionExport
    {
        public class Data
        {
            [JsonProperty("path")]
            public string Path { get; set; }
        }
    }

    public class TransactionExportResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public TransactionExport.Data Data { get; set; }
    }
}