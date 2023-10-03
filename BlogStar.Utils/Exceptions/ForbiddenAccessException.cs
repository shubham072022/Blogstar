namespace BlogStar.Shared.Exceptions
{
    [Serializable]
    public class ForbiddenAccessException : Exception
    {
        public ForbiddenAccessException() : base() { }
    }
}
