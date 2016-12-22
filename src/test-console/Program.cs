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
        private static PayStackApi _api;

        private static void Main(string[] args)
        {
            _api = new PayStackApi(ConfigurationManager.AppSettings["PayStackSecret"]);

            TransactionExport_Setup();
            //TransactionTotals_Setup();
            //TransactionTimeline_Setup();
            // TransactionFetch_Setup();
            // TransactionList_Setup();
            // InitializeRequest_Setup();
        }

        private static void TransactionExport_Setup()
        {
            var response = _api.Transactions.Export();
            Console.WriteLine(
                JsonConvert.SerializeObject(response, Formatting.Indented, PayStackApi.SerializerSettings)
            );
        }

        private static void TransactionTotals_Setup()
        {
            var response = _api.Transactions.Totals();
            Console.WriteLine(
                JsonConvert.SerializeObject(response, Formatting.Indented, PayStackApi.SerializerSettings)
            );
        }

        private static void TransactionTimeline_Setup()
        {
            var response = _api.Transactions.Timeline("540314");
            Console.WriteLine(
                JsonConvert.SerializeObject(response, Formatting.Indented, PayStackApi.SerializerSettings)
            );
        }

        private static void TransactionFetch_Setup()
        {
            var response = _api.Transactions.Fetch("540314");
            Console.WriteLine(
                JsonConvert.SerializeObject(response, Formatting.Indented, PayStackApi.SerializerSettings)
            );
        }

        private static void TransactionList_Setup()
        {
            var response = _api.Transactions.List();
            Console.WriteLine(JsonConvert.SerializeObject(response, Formatting.Indented, PayStackApi.SerializerSettings));
        }

        private static void InitializeRequest_Setup()
        {
            var request = new TransactionInitializeRequest
            {
                AmountInKobo = "900000",
                Email = "adebisi-fa@live.com",
                Reference = Guid.NewGuid().ToString(), // or your custom reference
            };

            // Add customer fields
            request.CustomFields.Add(CustomField.From("Name", "name", "ADEBISI Foluso A."));

            // Add other metadata
            request.MetadataObject["DataKey"] = "Containerization (Docker) is super Awesome!";

            // Show what the request JSON looks like
            Console.WriteLine("Request");
            Print(request);
            Console.WriteLine();

            // Initialize api with secret from the <appSettings /> of application configuration file (app.config or web.config)
            var response = _api.Transactions.Initialize(request);

            if (!response.Status) // Initialization failed
            {
                // Display response message and quit!
                var message = response.Message;
                return;
            }
            Console.WriteLine("Response");
            Print(response);
        }

        public static void Print(object request)
        {
            (request as IPreparable)?.Prepare();

            Console.WriteLine(
                JsonConvert.SerializeObject(request, Formatting.Indented, PayStackApi.SerializerSettings)
            );
        }
    }
}