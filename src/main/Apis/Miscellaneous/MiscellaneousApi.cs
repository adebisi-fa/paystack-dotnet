namespace PayStack.Net
{
    public class MiscellaneousApi : IMiscellaneousApi
    {
        private readonly PayStackApi _api;

        public MiscellaneousApi(PayStackApi api) => _api = api;

        public ListBanksResponse ListBanks(int itemsPerPage = 50, int page = 1) =>
            _api.Get<ListBanksResponse, dynamic>("bank", new { perPage = itemsPerPage, page });

        //?account_number={accountNumber}&bank_code={bankCode}
        public ResolveAccountNumberResponse ResolveAccountNumber(
            string accountNumber,
            string bankCode
        ) =>
            _api.Get<ResolveAccountNumberResponse, dynamic>(
                $"bank/resolve",
                new { account_number = accountNumber, bank_code = bankCode }
            );

        public ResolveBVNResponse ResolveBVN(string bvn) =>
            _api.Get<ResolveBVNResponse>($"bank/resolve_bvn/{bvn}");

        public ResolveCardBinResponse ResolveCardBin(string cardBin) =>
            _api.Get<ResolveCardBinResponse>($"decision/bin/{cardBin}");
    }
}
