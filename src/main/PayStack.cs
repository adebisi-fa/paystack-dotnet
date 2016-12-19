using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net;
using System.Net.Http;
using XtremeIT.Library.Pins;

namespace PayStack.Net
{
    #region Initialize 

    public class InitializeRequest
    {
        public string Reference { get; set; }

        [JsonProperty("amount")]
        public string AmountInKobo { get; set; }

        public string Email { get; set; }
        public string Plan { get; set; }

        [JsonProperty("callback_url")]
        public string CallbackUrl { get; set; }

        public string SubAccount { get; set; }

        [JsonProperty("transaction_charge")]
        public int TransactionCharge { get; set; }

        public string Bearer { get; set; }
    }

    public class InitializeResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public InitializeResponseData Data { get; set; }
    }

    public class InitializeResponseData
    {
        [JsonProperty("authorization_url")]
        public string AuthorizationUrl { get; set; }

        [JsonProperty("access_code")]
        public string AccessCode { get; set; }

        public string Reference { get; set; }
    }

    #endregion

    #region Verify

    public class VerifyRequest
    {
        public string Reference { get; set; }
    }

    public class VerifyResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public VerifyResponseData Data { get; set; }
    }

    public class VerifyResponseData
    {
        public long Amount { get; set; }

        [JsonProperty("transaction_date")]
        public DateTime TransactionDate { get; set; }
        public string Success { get; set; }
        public string Reference { get; set; }
        public string Domain { get; set; }
        public VerifyResponseAuthorization Authorization { get; set; }
        public VerifyResponseCustomer Customer { get; set; }
        public string Plan { get; set; }
    }

    public class VerifyResponseAuthorization
    {
        [JsonProperty("authorization_code")]
        public string Code { get; set; }

        [JsonProperty("card_type")]
        public string CardType { get; set; }

        [JsonProperty("last4")]
        public string Last4Digits { get; set; }

        public string Bank { get; set; }
    }

    public class VerifyResponseCustomer
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        public string Email { get; set; }
    }

    #endregion

    public class PayStackApi : IPayStackApi
    {

        private HttpClient _client;
        private JsonSerializerSettings _jsonSerializerSettings;

        public PayStackApi(string secretKey)
        {
            _jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
               
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            _client = new HttpClient {BaseAddress = new Uri("https://api.paystack.co/")};
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", secretKey);
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public InitializeResponse Initialize (InitializeRequest request)
        {
            request.Reference = $"{request.Reference};{Generator.NewPin(new GeneratorSettings { Domain = GeneratorCharacterDomains.AlphaNumerics, PinLength = 7 })}";
            return Post<InitializeResponse, InitializeRequest>("transaction/initialize", request);
        }

        public VerifyResponse Verify(string reference)
        {
            return Get<VerifyResponse>($"transaction/verify/{reference}");
        }

        TR Post<TR, T>(string relativeUrl, T request)
        {
            var requestBody = JsonConvert.SerializeObject(request, Formatting.Indented, _jsonSerializerSettings);
            return JsonConvert.DeserializeObject<TR>(
                _client.PostAsync(
                    relativeUrl,
                    new StringContent(requestBody)
                ).Result.Content.ReadAsStringAsync().Result
            );
        }

        TR Get<TR>(string relativeUrl)
        {
            return JsonConvert.DeserializeObject<TR>(
                _client.GetAsync(relativeUrl).Result.Content.ReadAsStringAsync().Result
            );
        }
    }
}
