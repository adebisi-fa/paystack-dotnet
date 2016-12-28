using System;

namespace PayStack.Net
{
    public class SettlementsApi : ISettlementsApi
    {
        private readonly PayStackApi _api;

        public SettlementsApi(PayStackApi api)
        {
            _api = api;
        }

        public SettlementsFetchResponse Fetch(DateTime? from = null, DateTime? to = null, string subaccount = "none") =>
            _api.Get<SettlementsFetchResponse, SettlementsFetchRequest>("settlement",
                new SettlementsFetchRequest {From = from, To = to, SubAccount = subaccount});
    }
}