using BlogStar.Application.Common.Interfaces;
using BlogStar.Domain.Entities;
using BlogStar.Identity.DbContext;
using BlogStar.Identity.Settings;
using BlogStar.Shared.Dtos;
using BlogStar.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BlogStar.Identity.Services
{
    public class TokenService : ITokenService
    {
        private readonly JWTSettings _jwtSettings;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly BlogIdentityDbContext _db;
        private readonly ICurrentUserService _currentUserService;

        public TokenService(
            UserManager<ApplicationUser> userManager
            , IOptions<JWTSettings> jwtSettings
            , BlogIdentityDbContext db
            , ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _db = db;
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<IEnumerable<Claim>> GetClaims(ApplicationUser user, List<string> audiences, CancellationToken cancellationToken)
        {
            var claims = new List<Claim>()
             {
                 new Claim("Email", user.Email),
                 new Claim("Name", user.Name),
                 new Claim("Id",user.Id.ToString()),
                 new Claim("Expiration",DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpiration).ToString()),
                 new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
             };
            var roles = await _userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x)));
            claims.AddRange(audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));
            return claims;
        }

        public async Task<string> GetRefreshToken()
        {
            var numberByte = new byte[32];
            using var rnd = RandomNumberGenerator.Create();
            rnd.GetBytes(numberByte);
            return Convert.ToBase64String(numberByte);
        }

        public async Task<TokenDTO> GetToken(ApplicationUser user, CancellationToken cancellationToken)
        {
            var accessTokenExpiration = DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpiration);
            var refreshTokenExpiration = DateTime.UtcNow.AddMinutes(_jwtSettings.RefreshTokenExpiration);
            var securityKey = Encoding.ASCII.GetBytes(_jwtSettings.SecurityKey);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(securityKey),
                SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken accessToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience[0],
                expires: accessTokenExpiration,
                notBefore: DateTime.UtcNow,
                claims: await GetClaims(user, _jwtSettings.Audience, cancellationToken),
                signingCredentials: signingCredentials);

            var handler = new JwtSecurityTokenHandler();

            var token = handler.WriteToken(accessToken);

            var response = new TokenDTO
            {
                AccessToken = token,
                RefreshToken = await GetRefreshToken()
            };

            var refreshToken = new RefreshTokenMaster
            {
                AccessToken = token,
                RefreshToken = response.RefreshToken,
                ExpiryTime = refreshTokenExpiration
            };

            await _db.RefreshTokenMaster.AddAsync(refreshToken);
            await _db.SaveChangesAsync(cancellationToken);

            return response;
        }
    }
}
