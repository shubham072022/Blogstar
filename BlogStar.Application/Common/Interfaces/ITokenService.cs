using BlogStar.Shared.Dtos;
using BlogStar.Shared.Models;
using System.Security.Claims;

namespace BlogStar.Application.Common.Interfaces
{
    public interface ITokenService
    {
        //this will return complete login response
        Task<TokenDTO> GetToken(ApplicationUser user, CancellationToken cancellationToken);

        //this will return all claims related to logged in user
        Task<IEnumerable<Claim>> GetClaims(ApplicationUser user, List<string> audiances, CancellationToken cancellationToken);

        //this will return the refresh token to first method
        Task<string> GetRefreshToken();
    }
}
