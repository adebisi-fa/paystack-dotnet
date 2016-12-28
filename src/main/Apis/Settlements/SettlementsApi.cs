using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _api.Get<SettlementsFetchResponse, SettlementsFetchRequest>("settlement", new SettlementsFetchRequest { From = from, To = to, SubAccount = subaccount});
    }
}
