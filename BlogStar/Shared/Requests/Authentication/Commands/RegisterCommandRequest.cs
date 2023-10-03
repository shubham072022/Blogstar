using BlogStar.Shared.Wrapper.Abstract;
using MediatR;

namespace BlogStar.Shared.Requests.Authentication.Commands
{
    public class RegisterCommandRequest : IRequest<IResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
