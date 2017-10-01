using System.Collections.Generic;

namespace PayStack.Net
{
    public interface ITransfersApi
    {
        ITransferRecipientsApi Recipients { get; }

        TransferCheckBalanceResponse CheckBalance();

        TransferOtpResponse ResendOtp(string transferCode, ResendOtpReasons reason);
        TransferOtpResponse DisableOtpBegin();
        TransferOtpResponse DisableOtpComplete(string otp);
        TransferOtpResponse EnableOtp();
        InitiateTransferResponse InitiateTransfer(int amount, string recipientCode, string source = "balance", string currency = "NGN", string reason = null);
        ListTransfersResponse ListTransfers(int itemsPerPage = 50, int page = 1);
        FetchTransferResponse FetchTransfer(string transferIdOrCode);
        void FinalizeTransfer(string transferCode, string otp);
        InitiateTransferResponse InitiateBulkTransfer(IEnumerable<BulkTransferEntry> transfers, string currency = "NGN", string source = "balance");
    }
}