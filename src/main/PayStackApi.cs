using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PayStack.Net;

namespace PayStack.Net
{
    public interface IPayStackApi
    {
        ITransactionsApi Transactions { get; }
    }

    public class PayStackApi : IPayStackApi
    {
        private readonly HttpClient _client;

        public PayStackApi(string secretKey)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            _client = new HttpClient {BaseAddress = new Uri("https://api.paystack.co/")};
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", secretKey);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Transactions = new TransactionsApi(this);
        }

        public static JsonSerializerSettings SerializerSettings { get; } = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate
        };

        public ITransactionsApi Transactions { get; }

        #region Utility Methods

        internal TR Post<TR, T>(string relativeUrl, T request)
        {
            (request as IPreparable)?.Prepare();

            var requestBody = JsonConvert.SerializeObject(request, Formatting.Indented, SerializerSettings);
            var filename =
                Path.GetDirectoryName(
                    Assembly.GetExecutingAssembly()
                        .GetName()
                        .EscapedCodeBase.Substring("file:///".Length)
                        .Replace('/', '\\')) + "\\request_log.txt";
            File.AppendAllText(filename, requestBody);
            return JsonConvert.DeserializeObject<TR>(
                _client.PostAsync(
                    relativeUrl,
                    new StringContent(requestBody)
                ).Result.Content.ReadAsStringAsync().Result
            );
        }

        internal TR Get<TR, T>(string relativeUrl, T request)
            where TR : class
        {
            var preparable = request as IPreparable;
            var queryString = "";
            if (preparable != null)
            {
                preparable.Prepare();
                queryString = "?" + preparable.ToQueryString();
            }

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