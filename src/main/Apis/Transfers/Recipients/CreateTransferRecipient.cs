using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PayStack.Net
{
    public class TransferRecipient
    {
        public class Details
        {

            [JsonProperty("account_number")]
            public string AccountNumber { get; set; }

            [JsonProperty("account_name")]
            public object AccountName { get; set; }

            [JsonProperty("bank_code")]
            public string BankCode { get; set; }

            [JsonProperty("bank_name")]
            public string BankName { get; set; }
        }

        public class Data
        {

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("metadata")]
            public Metadata Metadata { get; set; }

            [JsonProperty("domain")]
            public string Domain { get; set; }

            [JsonProperty("details")]
            public Details Details { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("recipient_code")]
            public string RecipientCode { get; set; }

            [JsonProperty("active")]
            public bool Active { get; set; }

            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("createdAt")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("updatedAt")]
            public DateTime UpdatedAt { get; set; }
        }
    }

    public class CreateTransferRecipientResponse : HasRawResponse, IApiResponse
    {

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public TransferRecipient.Data Data { get; set; }
    }

    public class CreateTransferRecipientRequest : RequestMetadataExtender
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }

        [JsonProperty("bank_code")]
        public string BankCode { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}