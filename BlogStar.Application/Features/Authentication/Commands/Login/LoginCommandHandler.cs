using BlogStar.Application.Repositories.Authentication.Commands;
using BlogStar.Shared.Requests.Authentication.Commands;
using BlogStar.Shared.Wrapper.Abstract;
using MediatR;

namespace BlogStar.Application.Features.Authentication.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest,IResponse>
    {
        private readonly IAuthenticationCommandRepository _repo;

        public LoginCommandHandler(IAuthenticationCommandRepository repo)
        {
            _repo = repo;
        }

        public async Task<IResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            return await _repo.Login(request, cancellationToken);
        }
    }
}
