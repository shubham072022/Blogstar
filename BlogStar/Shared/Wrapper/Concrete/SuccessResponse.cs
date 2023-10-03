using BlogStar.Shared.Wrapper.Abstract;

namespace BlogStar.Shared.Wrapper.Concrete
{
    public class SuccessResponse : ISuccessResponse
    {
        public string Message { get; }

        public bool Success { get; } = true;

        public int StatusCode { get; }

        public SuccessResponse() { }

        public SuccessResponse(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}
