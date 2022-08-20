using System;
using Newtonsoft.Json;

namespace PayStack.Net
{
    public class SubAccountCreate
    {
        public class Data
        {
            [JsonProperty("integration")]
            public int Integration { get; set; }

            [JsonProperty("domain")]
            public string Domain { get; set; }

            [JsonProperty("subaccount_code")]
            public string SubaccountCode { get; set; }

            [JsonProperty("business_name")]
            public string BusinessName { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("primary_contact_name")]
            public string PrimaryContactName { get; set; }

            [JsonProperty("primary_contact_email")]
            public string PrimaryContactEmail { get; set; }

            [JsonProperty("primary_contact_phone")]
            public string PrimaryContactPhone { get; set; }

            [JsonProperty("metadata")]
            public Metadata Metadata { get; set; }

            [JsonProperty("percentage_charge")]
            public double PercentageCharge { get; set; }

            [JsonProperty("is_verified")]
            public bool IsVerified { get; set; }

            [JsonProperty("settlement_bank")]
            public string SettlementBank { get; set; }

            [JsonProperty("account_number")]
            public string AccountNumber { get; set; }

            [JsonProperty("settlement_schedule")]
            public string SettlementSchedule { get; set; }

            [JsonProperty("active")]
            public bool Active { get; set; }

            [JsonProperty("migrate")]
            public bool Migrate { get; set; }

            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("createdAt")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("updatedAt")]
            public DateTime UpdatedAt { get; set; }
        }
    }

    public class SubAccountCreateResponse : HasRawResponse, IApiResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public SubAccountCreate.Data Data { get; set; }
    }

    public class SubAccountCreateRequest : RequestMetadataExtender
    {
        [JsonProperty("business_name")]
        public string BusinessName { get; set; }

        [JsonProperty("settlement_bank")]
        public string SettlementBank { get; set; }

        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }

        [JsonProperty("percentage_charge")]
        public string PercentageCharge { get; set; }

        [JsonProperty("primary_contact_email")]
        public string PrimaryContactEmail { get; set; }

        [JsonProperty("primary_contact_name")]
        public string PrimaryContactName { get; set; }

        [JsonProperty("primary_contact_phone")]
        public string PrimaryContactPhone { get; set; }

        [JsonProperty("settlement_schedule")]
        public string SettlementSchedule { get; set; }
    }
}