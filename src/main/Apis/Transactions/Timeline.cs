using System.Collections.Generic;
using Newtonsoft.Json;

namespace PayStack.Net
{
    public class TransactionTimeline
    {
        public class History
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("time")]
            public int Time { get; set; }
        }

        public class Data
        {
            [JsonProperty("time_spent")]
            public int TimeSpent { get; set; }

            [JsonProperty("attempts")]
            public int Attempts { get; set; }

            [JsonProperty("authentication")]
            public object Authentication { get; set; }

            [JsonProperty("errors")]
            public int Errors { get; set; }

            [JsonProperty("success")]
            public bool Success { get; set; }

            [JsonProperty("mobile")]
            public bool Mobile { get; set; }

            [JsonProperty("input")]
            public IList<object> Input { get; set; }

            [JsonProperty("channel")]
            public string Channel { get; set; }

            [JsonProperty("history")]
            public IList<History> Histories { get; set; }
        }
    }

    public class TransactionTimelineResponse : HasRawResponse, IApiResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public TransactionTimeline.Data Data { get; set; }
    }
}