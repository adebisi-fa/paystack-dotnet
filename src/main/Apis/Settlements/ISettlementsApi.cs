using System;

namespace PayStack.Net
{
    public interface ISettlementsApi
    {
        SettlementsFetchResponse Fetch(DateTime? from = null, DateTime? to = null, string subaccount = "none");
    }
}