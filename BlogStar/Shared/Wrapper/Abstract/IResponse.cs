﻿namespace BlogStar.Shared.Wrapper.Abstract
{
    public interface IResponse
    {
        bool Success { get; }
        int StatusCode { get; }
    }
}
