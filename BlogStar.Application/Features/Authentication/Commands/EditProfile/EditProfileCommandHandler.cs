using BlogStar.Application.Repositories.Authentication.Commands;
using BlogStar.Shared.Requests.Authentication.Commands;
using BlogStar.Shared.Wrapper.Abstract;
using MediatR;

namespace BlogStar.Application.Features.Authentication.Commands.EditProfile
{
    public class EditProfileCommandHandler : IRequestHandler<EditProfileCommandRequest,IResponse>
    {
        private readonly IAuthenticationCommandRepository _command;
        public EditProfileCommandHandler(IAuthenticationCommandRepository command)
        {
            _command = command;
        }

        public async Task<IResponse> Handle(EditProfileCommandRequest request, CancellationToken cancellationToken)
        {
            return await _command.EditProfile(request, cancellationToken);
        }
    }
}
