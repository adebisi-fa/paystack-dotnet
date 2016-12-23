namespace PayStack.Net
{
    public interface ICustomersApi
    {
        CustomerCreateResponse Create(CustomerCreateRequest request);
        CustomerCreateResponse Create(string email);
        CustomerListResponse List(int perPage = 50, int page = 1);
        CustomerFetchResponse Fetch(string customerIdOrCustomerCode);

        CustomerUpdateResponse Update(string customerIdOrCode, string firstName = null, string lastName = null,
            string phone = null);

        CustomerUpdateResponse Update(string customerIdOrCode, CustomerUpdateRequest request);
        CustomerSetRiskActionResponse SetRiskAction(string customerIdCodeOrEmail, string riskAction);
        CustomerSetRiskActionResponse WhiteList(string customerIdCodeOrEmail);
        CustomerSetRiskActionResponse BlackList(string customerIdCodeOrEmail);
    }
}