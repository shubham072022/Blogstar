using BlogStar.Client.Services.IServices;
using BlogStar.Client.Services.IServices.IBaseService;
using BlogStar.Shared.Dtos;
using BlogStar.Shared.Requests.Authentication.Commands;
using BlogStar.Shared.Wrapper.Abstract;
using BlogStar.Shared.Wrapper.Concrete;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Runtime.Intrinsics.X86;
using System.Text.Json.Serialization;

namespace BlogStar.Client.Services
{
    public class AuthService : IAuthService
    {
        private readonly IBaseApiService _apiService;
        private readonly ILocalStorageService _localStorageService;
        const string baseAddress = "Auth";
        public AuthService(IBaseApiService apiService, ILocalStorageService localStorageService)
        {
            _apiService = apiService;
            _localStorageService = localStorageService;
        }

        public async Task<WebResponse<TokenDTO>> Login(LoginCommandRequest request)
        {
            var response =  await _apiService.PostAsync<WebResponse<TokenDTO>>(baseAddress + "/login", request);
            if(response.Success)
            {
                await _localStorageService.SetItem("auth", response.Data);
            }
            return response;
        }

        public async Task<WebResponse<object>> Register(RegisterCommandRequest request)
        {
            return await _apiService.PostAsync<WebResponse<object>>(baseAddress + "/register", request);
        }
    }
}
