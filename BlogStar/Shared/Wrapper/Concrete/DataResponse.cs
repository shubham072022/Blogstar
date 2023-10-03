using BlogStar.Shared.Wrapper.Abstract;
using System.Text.Json.Serialization;

namespace BlogStar.Shared.Wrapper.Concrete
{
    public class DataResponse<T> : IDataResponse<T> where T : class
    {
        public T Data { get; }

        public bool Success { get; private set; } = true;

        public int StatusCode { get; }

        public string Message { get; set; }

        public DataResponse(T data, int statusCode)
        {
            Data = data;
            StatusCode = statusCode;
        }

        public DataResponse(T data, int statudCode, string message)
        {
            Data = data;
            StatusCode = statudCode;
            Message = message;
        }
    }
}
