namespace PayStack.Net
{
    public interface IPayStackApi
    {
        InitializeResponse Initialize (InitializeRequest request);
        VerifyResponse Verify(string reference);
    }
}