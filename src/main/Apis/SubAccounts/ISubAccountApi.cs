namespace PayStack.Net
{
    public interface ISubAccountApi
    {
        SubAccountCreateResponse Create(SubAccountCreateRequest request);

        SubAccountCreateResponse Create(string businessName, string settlementBank, string accountNumber,
            string percentageCharge);

        SubAccountListResponse List(int perPage = 50, int page = 1);
        SubAccountFetchResponse Fetch(string idOrSlug);
        SubAccountUpdateResponse Update(string idOrSlug, SubAccountUpdateRequest request);
        PayStackBankResponse GetBanks(int perPage = 50, int page = 1);
    }
}