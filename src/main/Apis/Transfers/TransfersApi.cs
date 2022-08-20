using System.Collections.Generic;

namespace PayStack.Net
{
    public class TransfersApi : ITransfersApi
    {
        private readonly PayStackApi _api;

        public TransfersApi(PayStackApi api)
        {
            _api = api;
            Recipients = new TransferRecipientsApi(api);
        }

        public ITransferRecipientsApi Recipients { get; }

        public TransferCheckBalanceResponse CheckBalance() => _api.Get<TransferCheckBalanceResponse>("balance");

        public TransferOtpResponse ResendOtp(string transferCode, ResendOtpReasons reason) => _api.Post<TransferOtpResponse, dynamic>("transfer/resend_otp", new
        {
            transfer_code = transferCode,
            reason = reason == ResendOtpReasons.ResendOtp ? "resend_otp" : "transfer"
        });

        public TransferOtpResponse DisableOtpBegin() => _api.Post<TransferOtpResponse, dynamic>("transfer/disable_otp", new { });

        public TransferOtpResponse DisableOtpComplete(string otp) => _api.Post<TransferOtpResponse, dynamic>("transfer/disable_otp_finalize",
            new { otp = otp }
        );

        public TransferOtpResponse EnableOtp() => _api.Post<TransferOtpResponse, dynamic>("transfer/enable_otp",
            new { }
        );

        public InitiateTransferResponse InitiateTransfer(int amount, string recipientCode, string source = "balance", string currency = "NGN", string reason = null) => _api.Post<InitiateTransferResponse, dynamic>("transfer", new
        {
            source = source,
            amount = amount,
            currency = currency,
            reason = reason,
            recipient = recipientCode
        });

        public ListTransfersResponse ListTransfers(int itemsPerPage = 50, int page = 1) => _api.Get<ListTransfersResponse, dynamic>("transfer", new
        {
            perPage = itemsPerPage,
            page = page
        });

        public FetchTransferResponse FetchTransfer(string transferIdOrCode) => _api.Get<FetchTransferResponse>($"transfer/{transferIdOrCode}");

        public void FinalizeTransfer(string transferCode, string otp)
        {
            _api.Post<ApiResponse<dynamic>, dynamic>("transfer/finalize_transfer", new
            {
                transfer_code = transferCode,
                otp = otp
            });
        }

        public InitiateTransferResponse InitiateBulkTransfer(IEnumerable<BulkTransferEntry> transfers, string currency = "NGN", string source = "balance") => _api.Post<InitiateTransferResponse, dynamic>("transfer/bulk", new
        {
            currency = currency,
            source = source,
            transfers = transfers
        });
    }
}