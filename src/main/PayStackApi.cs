using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net;
using System.Net.Http;
using XtremeIT.Library.Pins;

namespace PayStack.Net
{
    public class PayStackApi : IPayStackApi
    {

        private readonly HttpClient _client;
        private readonly JsonSerializerSettings _jsonSerializerSettings;

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
