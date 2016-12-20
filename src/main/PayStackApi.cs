using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using XtremeIT.Library.Pins;

namespace PayStack.Net
{
    public class PayStackApi : IPayStackApi
    {

        private readonly HttpClient _client;
        internal static JsonSerializerSettings SerializerSettings { get; } = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate
        };

        public PayStackApi(string secretKey)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            _client = new HttpClient {BaseAddress = new Uri("https://api.paystack.co/")};
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", secretKey);
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public InitializeResponse Initialize (InitializeRequest request)
        {
            return Post<InitializeResponse, InitializeRequest>("transaction/initialize", request);
        }

        public VerifyResponse Verify(string reference)
        {
            return Get<VerifyResponse>($"transaction/verify/{reference}");
        }

        TR Post<TR, T>(string relativeUrl, T request)
        {
            (request as IPreparable)?.Prepare();

            var requestBody = JsonConvert.SerializeObject(request, Formatting.Indented, SerializerSettings);
            string filename = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().EscapedCodeBase.Substring("file:///".Length).Replace('/', '\\')) + "\\request_log.txt";
            File.AppendAllText(filename, requestBody);
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
