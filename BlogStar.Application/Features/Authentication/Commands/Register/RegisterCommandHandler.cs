using BlogStar.Application.Repositories.Authentication.Commands;
using BlogStar.Shared.Requests.Authentication.Commands;
using BlogStar.Shared.Wrapper.Abstract;
using MediatR;

namespace BlogStar.Application.Features.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, IResponse>
    {
        private readonly IAuthenticationCommandRepository _repo;

        public RegisterCommandHandler(IAuthenticationCommandRepository repo)
        {
            _repo = repo;
        }

        public async Task<IResponse> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            return await _repo.Register(request, cancellationToken);
        }
    }
}
