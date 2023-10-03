using BlogStar.Shared.Requests.Authentication.Commands;
using BlogStar.Shared.Requests.Authentication.Queries;
using BlogStar.Shared.Wrapper.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogStar.Server.Controllers
{
    public class AuthController : BaseController
    {
        [Route("login")]
        [HttpPost]
        public async Task<IResponse> Login(LoginCommandRequest request)
        {
            return await Mediator.Send(request);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IResponse> Register([FromBody] RegisterCommandRequest request)
        {
            return await Mediator.Send(request);
        }

        [Authorize]
        [HttpGet]
        [Route("Profile")]
        public async Task<IResponse> Profile([FromQuery] GetProfileQueryRequest request)
        {
            return await Mediator.Send(request);
        }

        [Authorize]
        [HttpPut]
        [Route("EditProfile")]
        public async Task<IResponse> EditProfile([FromBody] EditProfileCommandRequest request)
        {
            return await Mediator.Send(request);
        }
    }
}
