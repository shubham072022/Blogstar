namespace BlogStar.Shared.Wrapper.Abstract
{
    public interface IErrorResponse : IResponse
    {
        List<string> Errors { get; }
    }
}
