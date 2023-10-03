using BlogStar.Shared.Dtos;
using BlogStar.Shared.Requests.Authentication.Commands;
using BlogStar.Shared.Wrapper.Abstract;
using BlogStar.Shared.Wrapper.Concrete;

namespace BlogStar.Client.Services.IServices
{
    public interface IAuthService
    {
        Task<WebResponse<TokenDTO>> Login(LoginCommandRequest request);

        Task<WebResponse<object>> Register(RegisterCommandRequest request);
    }
}
