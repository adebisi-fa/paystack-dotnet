namespace PayStack.Net
{
    public interface IApiResponse
    {
        bool Status { get; set; }
        string Message { get; set; }
    }

    public class ApiResponse<T> : IApiResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }

        public T Data { get; set; }
    }
}