using System;
using System.Configuration;
using Newtonsoft.Json;
using PayStack.Net;
using System.IO;
using System.Reflection;

namespace test_console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            HowToMakeInitializeRequest();
        }

        private static void HowToMakeInitializeRequest()
        {
            var request = new InitializeRequest
            {
                AmountInKobo = "900000",
                Bearer = PayStackChargesBearer.Account,
                SubAccount = "AZ_sub_account_id",
                CallbackUrl = "http://callback_url",
                Email = "adebisi-fa@live.com",
                Reference = Guid.NewGuid().ToString(), // or your custom reference
                TransactionCharge = 10000
            };

            // Add customer fields
            request.CustomFields.Add(CustomField.From("Name", "name", "ADEBISI Foluso A."));

            // Add other metadata
            request.MetadataObject["DataKey"] = "Containerization (Docker) is super Awesome!";

            // Show what the request JSON looks like
            PrintRequest(request);

            /*
                // Initialize api with secret from the <appSettings /> of application configuration file (app.config or web.config)
                var api = new PayStackApi(ConfigurationManager.AppSettings["PayStackSecret"]); 
                var response = api.Initialize(request);

                if (!response.Status) // Initialization failed
                {
                    // Display response message and quit!
                    var message = response.Message;
                    return;
                }

                // Retrieve and redirect to authorization url
                var authorizationUrl = response.Data.AuthorizationUrl;
                var accessCode = response.Data.AccessCode;
                var reference = response.Data.Reference;
            */
        }

        public static void PrintRequest(object request)
        {
            (request as IPreparable)?.Prepare();

            Console.WriteLine(
                JsonConvert.SerializeObject(request, Formatting.Indented)
            );
        }
    }
}