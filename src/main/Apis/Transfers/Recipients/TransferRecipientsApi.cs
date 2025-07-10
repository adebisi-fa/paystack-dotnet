namespace PayStack.Net
{
    public class TransferRecipientsApi : ITransferRecipientsApi
    {
        private readonly PayStackApi _api;

        public TransferRecipientsApi(PayStackApi api)
        {
            _api = api;
        }

        public CreateTransferRecipientResponse Create(CreateTransferRecipientRequest request) =>
            _api.Post<CreateTransferRecipientResponse, CreateTransferRecipientRequest>(
                "transferrecipient",
                request
            );

        public CreateTransferRecipientResponse Create(
            string name,
            string accountNumber,
            string bankCode,
            string currency = "NGN",
            string description = null,
            string type = "nuban"
        ) =>
            Create(
                new CreateTransferRecipientRequest
                {
                    Name = name,
                    AccountNumber = accountNumber,
                    BankCode = bankCode,
                    Currency = currency,
                    Description = description,
                    Type = type,
                }
            );

        public ListTransferRecipientsResponse List(int itemPerPage = 50, int page = 1) =>
            _api.Get<ListTransferRecipientsResponse, dynamic>(
                "transferrecipient",
                new { perPage = itemPerPage, page = page }
            );
    }
}
