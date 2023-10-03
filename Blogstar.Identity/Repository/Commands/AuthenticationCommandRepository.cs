using BlogStar.Application.Common.Interfaces;
using BlogStar.Application.Repositories.Authentication.Commands;
using BlogStar.Shared.Constants;
using BlogStar.Shared.Dtos;
using BlogStar.Shared.Exceptions;
using BlogStar.Shared.Models;
using BlogStar.Shared.Requests.Authentication.Commands;
using BlogStar.Shared.Wrapper.Abstract;
using BlogStar.Shared.Wrapper.Concrete;
using Microsoft.AspNetCore.Identity;

namespace BlogStar.Identity.Repository.Commands
{
    public class AuthenticationCommandRepository : IAuthenticationCommandRepository
    {
        private readonly ITokenService _service;
        private readonly UserManager<ApplicationUser> _userManager;
        public AuthenticationCommandRepository(ITokenService service,UserManager<ApplicationUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }
        public async Task<IResponse> Login(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                if (user == null)
                {
                    return new ErrorResponse(ApiStatusCodes.BadRequest, Messages.CheckCredentials);
                }
                if ((await _userManager.CheckPasswordAsync(user, request.Password)))
                {
                    return new DataResponse<TokenDTO>(await _service.GetToken(user, cancellationToken),ApiStatusCodes.Ok);
                }
                return new ErrorResponse(ApiStatusCodes.BadRequest, Messages.CheckCredentials);
            }
            catch (Exception ex)
            {
                throw new ApiException(ApiStatusCodes.InternalServerError,ex.Message);
            }
        }

        public async Task<IResponse> Register(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var existinUser = await _userManager.FindByEmailAsync(request.Email);
                if(existinUser != null)
                {
                    return new ErrorResponse(ApiStatusCodes.BadRequest, Messages.AlreadyExists("User with same email"));
                }

                ApplicationUser user = new ApplicationUser
                {
                    Email = request.Email,
                    NormalizedEmail = request.Email,
                    UserName = request.Email,
                    Name = "",
                    ProfileImage = ""
                };

                var result = await _userManager.CreateAsync(user);
                if(!result.Succeeded)
                {
                    return new ErrorResponse(ApiStatusCodes.InternalServerError, Messages.IssueWithData);
                }

                result = await _userManager.AddPasswordAsync(user, request.Password);
                if (!result.Succeeded)
                {
                    return new ErrorResponse(ApiStatusCodes.InternalServerError, Messages.IssueWithData);
                }
                return new SuccessResponse(ApiStatusCodes.Created, Messages.Success("User", "Created"));
            }
            catch (Exception ex)
            {
                throw new ApiException(ApiStatusCodes.InternalServerError, ex.Message);
            }
        }

        public async Task<IResponse> EditProfile(EditProfileCommandRequest request,CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                user.Email = request.Email;
                user.UserName = request.UserName;
                user.Name = request.Name;
                user.ProfileImage = request.ProfileImage;
                await _userManager.UpdateAsync(user);

                return new SuccessResponse(ApiStatusCodes.Ok, Messages.Success("Profile", "Modified"));
            }
            catch(Exception ex)
            {
                throw new ApiException(ApiStatusCodes.InternalServerError, ex.Message);
            }
        }
    }
}
