namespace PayStack.Net
{
    public class SubAccountApi : ISubAccountApi
    {
        private readonly PayStackApi _api;

        public SubAccountApi(PayStackApi api)
        {
            _api = api;
        }

        public SubAccountCreateResponse Create(SubAccountCreateRequest request) =>
            _api.Post<SubAccountCreateResponse, SubAccountCreateRequest>("subaccount", request);

        public SubAccountCreateResponse Create(
            string businessName,
            string settlementBank,
            string accountNumber,
            string percentageCharge
        ) =>
            Create(
                new SubAccountCreateRequest
                {
                    BusinessName = businessName,
                    SettlementBank = settlementBank,
                    AccountNumber = accountNumber,
                    PercentageCharge = percentageCharge,
                }
            );

        public SubAccountListResponse List(int perPage = 50, int page = 1) =>
            _api.Get<SubAccountListResponse, SubAccountListRequest>(
                "subaccount",
                new SubAccountListRequest { PerPage = perPage, Page = page }
            );

        public SubAccountFetchResponse Fetch(string idOrSlug) =>
            _api.Get<SubAccountFetchResponse>($"subaccount/{idOrSlug}");

        public SubAccountUpdateResponse Update(string idOrSlug, SubAccountUpdateRequest request) =>
            _api.Put<SubAccountUpdateResponse, SubAccountUpdateRequest>(
                $"subaccount/{idOrSlug}",
                request
            );

        public PayStackBankResponse GetBanks(int perPage = 50, int page = 1) =>
            _api.Get<PayStackBankResponse, PayStackBankRequest>(
                "bank",
                new PayStackBankRequest { PerPage = perPage, Page = page }
            );
    }
}
