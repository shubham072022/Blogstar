
using BlogStar.Shared.Requests.Authentication.Commands;
using BlogStar.Shared.Wrapper.Abstract;

namespace BlogStar.Application.Repositories.Authentication.Commands
{
    public interface IAuthenticationCommandRepository
    {
        Task<IResponse> Register(RegisterCommandRequest request,CancellationToken cancellationToken);

        Task<IResponse> Login(LoginCommandRequest request,CancellationToken cancellationToken);

        Task<IResponse> EditProfile(EditProfileCommandRequest request,CancellationToken cancellationToken);
    }
}
