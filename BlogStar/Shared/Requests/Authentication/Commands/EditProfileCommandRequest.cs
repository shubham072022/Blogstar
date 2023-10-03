using BlogStar.Shared.Wrapper.Abstract;
using MediatR;

namespace BlogStar.Shared.Requests.Authentication.Commands
{
    public class EditProfileCommandRequest : IRequest<IResponse>
    {
        public string Name { get; set; }
        public string ProfileImage { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}
