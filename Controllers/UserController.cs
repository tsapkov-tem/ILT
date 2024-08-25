using ILT.Core.Data.Contracts.Services;
using ILT.Core.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace ILT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService UserService;
        public UserController(IServiceManager manager) 
        {
            UserService = manager.UserService;
        }

        [HttpGet]
        public string Get()
        {
            return "success";
        }
    }
}
