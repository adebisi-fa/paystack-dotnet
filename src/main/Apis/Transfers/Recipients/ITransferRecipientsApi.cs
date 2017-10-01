namespace PayStack.Net
{
    public interface ITransferRecipientsApi
    {
        CreateTransferRecipientResponse Create (CreateTransferRecipientRequest request);

        CreateTransferRecipientResponse Create(string name, string accountNumber, string bankCode, string currency = "NGN", string description = null, string type = "nuban");

        ListTransferRecipientsResponse List(int itemPerPage = 50, int page = 1);
    }
}