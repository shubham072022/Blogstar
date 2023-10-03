using BlogStar.Shared.Wrapper.Abstract;

namespace BlogStar.Shared.Wrapper.Concrete
{
    public class WebResponse<T> : IWebResponse<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; }
        public bool Success { get; set; }
    }
}
