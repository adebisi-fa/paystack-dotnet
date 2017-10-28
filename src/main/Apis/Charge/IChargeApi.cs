using System;
using PayStack.Net;

namespace PayStack.Net
{
    public interface IChargeApi
    {
        ChargeTokenizeResponse Tokenize(string email, string cardNumber, string cardCvv, string cardExpiryMonth, string cardExpiryYear);

        ChargeResponse ChargeBank(string email, string amount, string bankCode, string bankAccountNumber);

        ChargeResponse ChargeBank(BankChargeRequest request);

        ChargeResponse ChargeCard(string email, string amount, string cardNumber, string cardCvv, string cardExpiryMonth, string cardExpiryYear, string pin);

        ChargeResponse ChargeCard(CardChargeRequest request);

        ChargeResponse ChargeAuthorizationCode(string email, string amount, string authorizationCode, string pin);

        ChargeResponse ChargeAuthorizationCode(AuthorizationCodeChargeRequest request);

        ChargeResponse SubmitPIN(string reference, string pin);

        ChargeResponse SubmitOTP(string reference, string otp);

        ChargeResponse SubmitPhone(string reference, string phone);

        ChargeResponse SubmitBirthday(string reference, DateTime birthday);

        ChargeResponse CheckPendingCharge(string reference);
        
    }
}