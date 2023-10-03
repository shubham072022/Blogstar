namespace BlogStar.Shared.Wrapper.Abstract
{
    public interface IWebResponse<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; }
        public bool Success { get; set; }
    }
}
