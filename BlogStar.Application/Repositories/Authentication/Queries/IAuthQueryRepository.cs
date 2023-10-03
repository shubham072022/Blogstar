using BlogStar.Shared.Dtos;

namespace BlogStar.Application.Repositories.Authentication.Queries
{
    public interface IAuthQueryRepository
    {
        Task<List<UserDTO>> GetAllUsers(CancellationToken cancellationToken);

        Task<UserDTO> GetUserByEmail(string email, CancellationToken cancellationToken);
    }
}
