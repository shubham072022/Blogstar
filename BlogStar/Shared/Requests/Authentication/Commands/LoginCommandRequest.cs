using BlogStar.Shared.Wrapper.Abstract;
using MediatR;

namespace BlogStar.Shared.Requests.Authentication.Commands
{
    public sealed record LoginCommandRequest : IRequest<IResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
