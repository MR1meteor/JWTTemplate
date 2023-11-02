using JWTTemplate.Models.Dtos;
using JWTTemplate.Models.ServiceModels;
using JWTTemplate.Services.Mappers;
using JWTTemplate.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTTemplate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IdentityService identityService;

        public IdentityController(IdentityService identityService)
        {
            this.identityService = identityService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDto request)
        {
            var result = await identityService.Register(request.MapToDomain());

            return result ? Ok() : BadRequest();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDto request)
        {
            var user = identityService.Get(request.Login);
        }
    }
}
