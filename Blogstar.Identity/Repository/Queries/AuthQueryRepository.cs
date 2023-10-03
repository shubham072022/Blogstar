using AutoMapper;
using BlogStar.Application.Repositories.Authentication.Queries;
using BlogStar.Shared.Dtos;
using BlogStar.Shared.Mappings;
using BlogStar.Shared.Models;
using Microsoft.AspNetCore.Identity;

namespace Blogstar.Identity.Repository.Queries
{
    public class AuthQueryRepository : IAuthQueryRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        public AuthQueryRepository(Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<UserDTO>>  GetAllUsers(CancellationToken cancellationToken)
        {
            var users = _userManager.Users.ProjectToList<UserDTO>(_mapper.ConfigurationProvider);
            return users;
        }

        public async Task<UserDTO> GetUserByEmail(string email, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                ProfileImage = user.ProfileImage,
                Name = user.Name,
                UserName = user.UserName
            };
        }
    }
}
