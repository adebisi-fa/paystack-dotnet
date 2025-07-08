using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace PayStack.Net
{
    public interface IPayStackApi
    {
        ISubAccountApi SubAccounts { get; }
        ITransactionsApi Transactions { get; }
        ICustomersApi Customers { get; }
        ISettlementsApi Settlements { get; }
        ITransfersApi Transfers { get; }
    }

    public class PayStackApi : IPayStackApi
    {
        private readonly HttpClient _client;

        public PayStackApi(string secretKey)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            _client = new HttpClient { BaseAddress = new Uri("https://api.paystack.co/") };
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", secretKey);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Transactions = new TransactionsApi(this);
            Customers = new CustomersApi(this);
            SubAccounts = new SubAccountApi(this);
            Settlements = new SettlementsApi(this);
            Miscellaneous = new MiscellaneousApi(this);
            Transfers = new TransfersApi(this);
            Charge = new ChargeApi(this);
        }

        public static JsonSerializerSettings SerializerSettings { get; } = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate
        };

        public ISubAccountApi SubAccounts { get; }

        public ITransactionsApi Transactions { get; }

        public ICustomersApi Customers { get; }

        public ISettlementsApi Settlements { get; }

        public IMiscellaneousApi Miscellaneous { get; }

        public ITransfersApi Transfers { get; }

        public IChargeApi Charge { get; }


        [Obsolete("Use PayStack.Net.Miscellaneous.ResolveCardBin(cardBin) instead.")]
        public ResolveCardBinResponse ResolveCardBin(string cardBin) => Miscellaneous.ResolveCardBin(cardBin);

        #region Utility Methods

        private string PrepareRequest<T>(T request)
        {
            (request as IPreparable)?.Prepare();

            var requestBody = JsonConvert.SerializeObject(request, Formatting.Indented, SerializerSettings);
            return requestBody;
        }

        public TR Post<TR, T>(string relativeUrl, T request) where TR : IApiResponse
        {
            var rawJson = _client.PostAsync(
                    relativeUrl.TrimStart('/'),
                    new StringContent(PrepareRequest(request))
                ).Result.Content.ReadAsStringAsync().Result;

            return ParseAndResolveMetadata<TR>(ref rawJson);
        }

        private static TR ParseAndResolveMetadata<TR>(ref string rawJson) where TR : IApiResponse
        {
            var jo = JObject.Parse(rawJson);
            var data = jo["data"];
            if (data != null && !(data is JArray) && data["metadata"] != null)
            {
                var metadata = data["metadata"];
                jo["data"]["metadata"] = JsonConvert.DeserializeObject<JObject>(metadata.ToString());
            }

            rawJson = jo.ToString();

            var response = JsonConvert.DeserializeObject<TR>(rawJson);

            if (typeof(IHasRawResponse).IsAssignableFrom(typeof(TR)))
                (response as IHasRawResponse).RawJson = rawJson;

            return response;
        }

        public TR Put<TR, T>(string relativeUrl, T request) where TR : IApiResponse
        {
            var rawJson = _client.PutAsync(
                    relativeUrl.TrimStart('/'),
                    new StringContent(PrepareRequest(request))
                ).Result.Content.ReadAsStringAsync().Result;

            return ParseAndResolveMetadata<TR>(ref rawJson);
        }

        public TR Get<TR, T>(string relativeUrl, T request)
            where TR : class, IApiResponse
        {
            var preparable = request as IPreparable;

            var queryString = "";
            
            if (preparable != null)
                preparable.Prepare();
            
            if (request != null)
                queryString = $"?{request.ToQueryString()}";
            
            var rawJson = _client.GetAsync(relativeUrl.TrimStart('/') + queryString).Result.Content.ReadAsStringAsync().Result;
            return ParseAndResolveMetadata<TR>(ref rawJson);
        }

        public TR Get<TR>(string relativeUrl) where TR : IApiResponse
        {
            var rawJson = _client.GetAsync(relativeUrl.TrimStart('/')).Result.Content.ReadAsStringAsync().Result;
            return ParseAndResolveMetadata<TR>(ref rawJson);
        }

        #endregion
    }
}