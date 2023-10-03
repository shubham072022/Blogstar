using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogStar.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public ISender mediator = null;

        protected ISender Mediator => mediator ?? HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
