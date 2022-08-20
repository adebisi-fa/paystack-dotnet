using System.Collections.Generic;
using Newtonsoft.Json;

namespace PayStack.Net
{
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

    public class ListTransferRecipientsResponse : HasRawResponse, IApiResponse
    {

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public IList<TransferRecipient.Data> Data { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }

}