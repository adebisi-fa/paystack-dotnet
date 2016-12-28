using System;

namespace PayStack.Net.Apis.Settlements
{
    public interface ISettlementsApi
    {
        SettlementsFetchResponse Fetch(DateTime? from = null, DateTime? to = null, string subaccount = "none");
    }
}