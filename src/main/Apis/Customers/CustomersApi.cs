namespace PayStack.Net
{
    public class CustomersApi : ICustomersApi
    {
        private readonly PayStackApi _api;

        public CustomersApi(PayStackApi api)
        {
            _api = api;
        }

        public CustomerCreateResponse Create(CustomerCreateRequest request) =>
            _api.Post<CustomerCreateResponse, CustomerCreateRequest>("customer", request);

        public CustomerCreateResponse Create(string email) =>
            Create(new CustomerCreateRequest { Email = email });

        public CustomerListResponse List(int perPage = 50, int page = 1) =>
            _api.Get<CustomerListResponse, CustomerListRequest>(
                "customer",
                new CustomerListRequest { Page = page, PerPage = perPage }
            );

        public CustomerFetchResponse Fetch(string customerIdOrCustomerCode) =>
            _api.Get<CustomerFetchResponse>($"customer/{customerIdOrCustomerCode}");

        public CustomerUpdateResponse Update(
            string customerIdOrCode,
            string firstName = null,
            string lastName = null,
            string phone = null
        ) =>
            Update(
                customerIdOrCode,
                new CustomerUpdateRequest
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Phone = phone,
                }
            );

        public CustomerUpdateResponse Update(
            string customerIdOrCode,
            CustomerUpdateRequest request
        ) =>
            _api.Put<CustomerUpdateResponse, CustomerUpdateRequest>(
                $"customer/{customerIdOrCode}",
                request
            );

        public CustomerSetRiskActionResponse SetRiskAction(
            string customerIdCodeOrEmail,
            string riskAction
        ) =>
            _api.Post<CustomerSetRiskActionResponse, CustomerSetRiskActionRequest>(
                "customer/set_risk_action",
                new CustomerSetRiskActionRequest
                {
                    Customer = customerIdCodeOrEmail,
                    RiskAction = riskAction,
                }
            );

        public CustomerSetRiskActionResponse WhiteList(string customerIdCodeOrEmail) =>
            SetRiskAction(customerIdCodeOrEmail, "allow");

        public CustomerSetRiskActionResponse BlackList(string customerIdCodeOrEmail) =>
            SetRiskAction(customerIdCodeOrEmail, "deny");
    }
}
