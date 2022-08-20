using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PayStack.Net
{
    public class CustomerList
    {
        public class Photo
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("typeId")]
            public string TypeId { get; set; }

            [JsonProperty("typeName")]
            public string TypeName { get; set; }

            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("isPrimary")]
            public bool IsPrimary { get; set; }
        }

        public class Metadata : Dictionary<string, object>
        {
            [JsonProperty("photos")]
            public IList<Photo> Photos { get; set; }
        }

        public class Datum
        {
            [JsonProperty("integration")]
            public int Integration { get; set; }

            [JsonProperty("first_name")]
            public string FirstName { get; set; }

            [JsonProperty("last_name")]
            public string LastName { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("phone")]
            public string Phone { get; set; }

            [JsonProperty("metadata")]
            public Metadata Metadata { get; set; }

            [JsonProperty("domain")]
            public string Domain { get; set; }

            [JsonProperty("customer_code")]
            public string CustomerCode { get; set; }

            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("createdAt")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("updatedAt")]
            public DateTime UpdatedAt { get; set; }
        }

        public class Meta
        {
            [JsonProperty("total")]
            public int Total { get; set; }

            [JsonProperty("skipped")]
            public int Skipped { get; set; }

            [JsonProperty("perPage")]
            public int PerPage { get; set; }

            [JsonProperty("page")]
            public int Page { get; set; }

            [JsonProperty("pageCount")]
            public int PageCount { get; set; }
        }
    }

    public class CustomerListRequest
    {
        public int PerPage { get; set; }

        public int Page { get; set; }
    }

    public class CustomerListResponse : HasRawResponse, IApiResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public IList<CustomerList.Datum> Data { get; set; }

        [JsonProperty("meta")]
        public CustomerList.Meta Meta { get; set; }
    }
}