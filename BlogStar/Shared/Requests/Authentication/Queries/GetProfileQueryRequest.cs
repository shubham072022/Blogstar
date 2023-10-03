using BlogStar.Shared.Wrapper.Abstract;
using MediatR;

namespace BlogStar.Shared.Requests.Authentication.Queries
{
    public class GetProfileQueryRequest : IRequest<IResponse>
    {
        public string Email { get; set; }
    }
}
