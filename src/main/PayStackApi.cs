using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
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

        internal TR Post<TR, T>(string relativeUrl, T request)
        {
            return JsonConvert.DeserializeObject<TR>(
                _client.PostAsync(
                    relativeUrl,
                    new StringContent(PrepareRequest(request))
                ).Result.Content.ReadAsStringAsync().Result
            );
        }

        internal TR Put<TR, T>(string relativeUrl, T request)
        {
            return JsonConvert.DeserializeObject<TR>(
                _client.PutAsync(
                    relativeUrl,
                    new StringContent(PrepareRequest(request))
                ).Result.Content.ReadAsStringAsync().Result
            );
        }

        internal TR Get<TR, T>(string relativeUrl, T request)
            where TR : class
        {
            var preparable = request as IPreparable;

            var queryString = "";
            if (request != null)
                queryString = "?" + request.ToQueryString();

            if (preparable != null)
                preparable.Prepare();

            return JsonConvert.DeserializeObject<TR>(
                _client.GetAsync(relativeUrl + queryString).Result.Content.ReadAsStringAsync().Result
            );
        }

        internal TR Get<TR>(string relativeUrl)
        {
            return JsonConvert.DeserializeObject<TR>(
                _client.GetAsync(relativeUrl).Result.Content.ReadAsStringAsync().Result
            );
        }

        #endregion
    }
}