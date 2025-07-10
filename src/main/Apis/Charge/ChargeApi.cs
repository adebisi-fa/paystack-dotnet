using System;

namespace PayStack.Net
{
    public class ChargeApi : IChargeApi
    {
        private readonly PayStackApi _api;

        public ChargeApi(PayStackApi api)
        {
            this._api = api;
        }

        public ChargeResponse ChargeAuthorizationCode(
            string email,
            string amount,
            string authorizationCode,
            string pin,
            string reference = null,
            bool makeReferenceUnique = false
        ) =>
            ChargeAuthorizationCode(
                new AuthorizationCodeChargeRequest
                {
                    Email = email,
                    Amount = amount,
                    AuthorizationCode = authorizationCode,
                    Pin = pin,
                    Reference =
                        makeReferenceUnique && reference != null
                            ? $"{reference}-{Guid.NewGuid().ToString().Substring(0, 8)}"
                            : reference,
                },
                makeReferenceUnique
            );

        public ChargeResponse ChargeAuthorizationCode(
            AuthorizationCodeChargeRequest request,
            bool makeReferenceUnique = false
        )
        {
            if (makeReferenceUnique && request.Reference != null)
                request.Reference =
                    $"{request.Reference}-{Guid.NewGuid().ToString().Substring(0, 8)}";
            return _api.Post<ChargeResponse, AuthorizationCodeChargeRequest>("charge", request);
        }

        public ChargeResponse ChargeBank(
            string email,
            string amount,
            string bankCode,
            string bankAccountNumber,
            string reference = null,
            bool makeReferenceUnique = false
        ) =>
            ChargeBank(
                new BankChargeRequest
                {
                    Email = email,
                    Amount = amount,
                    Bank = new Bank { Code = bankCode, AccountNumber = bankAccountNumber },
                    Reference = reference,
                },
                makeReferenceUnique
            );

        public ChargeResponse ChargeBank(
            BankChargeRequest request,
            bool makeReferenceUnique = false
        )
        {
            if (makeReferenceUnique && request.Reference != null)
                request.Reference =
                    $"{request.Reference}-{Guid.NewGuid().ToString().Substring(0, 8)}";

            return _api.Post<ChargeResponse, BankChargeRequest>("charge", request);
        }

        public ChargeResponse ChargeCard(
            string email,
            string amount,
            string cardNumber,
            string cardCvv,
            string cardExpiryMonth,
            string cardExpiryYear,
            string pin,
            string reference = null,
            bool makeReferenceUnique = false
        ) =>
            ChargeCard(
                new CardChargeRequest
                {
                    Email = email,
                    Amount = amount,
                    Card = new Card
                    {
                        Number = cardNumber,
                        Cvv = cardCvv,
                        ExpiryMonth = cardExpiryMonth,
                        ExpiryYear = cardExpiryYear,
                    },
                    Pin = pin,
                    Reference = reference,
                }
            );

        public ChargeResponse ChargeCard(
            CardChargeRequest request,
            bool makeReferenceUnique = false
        )
        {
            if (makeReferenceUnique && request.Reference != null)
                request.Reference =
                    $"{request.Reference}-{Guid.NewGuid().ToString().Substring(0, 8)}";

            return _api.Post<ChargeResponse, CardChargeRequest>("charge", request);
        }

        public ChargeResponse CheckPendingCharge(string reference) =>
            _api.Get<ChargeResponse>($"charge/{reference}");

        public ChargeResponse SubmitBirthday(string reference, DateTime birthday) =>
            _api.Post<ChargeResponse, dynamic>(
                "charge/submit_birthday",
                new { birthday = birthday, reference = reference }
            );

        public ChargeResponse SubmitOTP(string reference, string otp) =>
            _api.Post<ChargeResponse, dynamic>(
                "charge/submit_otp",
                new { otp = otp, reference = reference }
            );

        public ChargeResponse SubmitPhone(string reference, string phone) =>
            _api.Post<ChargeResponse, dynamic>(
                "charge/submit_phone",
                new { phone = phone, reference = reference }
            );

        public ChargeResponse SubmitPIN(string reference, string pin) =>
            _api.Post<ChargeResponse, dynamic>(
                "charge/submit_pin",
                new { pin = pin, reference = reference }
            );

        public ChargeTokenizeResponse Tokenize(
            string email,
            string cardNumber,
            string cardCvv,
            string cardExpiryMonth,
            string cardExpiryYear
        ) =>
            _api.Post<ChargeTokenizeResponse, dynamic>(
                "charge/tokenize",
                new
                {
                    email = email,
                    card = new
                    {
                        number = cardNumber,
                        cvv = cardCvv,
                        expiry_month = cardExpiryMonth,
                        expiry_year = cardExpiryYear,
                    },
                }
            );
    }
}
