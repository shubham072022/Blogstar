using BlogStar.Shared.Wrapper.Abstract;

namespace BlogStar.Shared.Wrapper.Concrete
{
    public class Response : IResponse
    {
        public bool Success { get; }
        public int StatusCode { get; }

        public Response(bool success, int statusCode)
        {
            Success = success;
            StatusCode = statusCode;
        }

        public Response(bool success)
        {
            Success = success;
        }
    }
}
