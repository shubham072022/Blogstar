namespace BlogStar.Shared.Wrapper.Abstract
{
    public interface IDataResponse<T> : IResponse where T : class
    {
        string Message { get; }
        T Data { get; }
    }
}
