using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PromptsManager.Application.Request;
using PromptsManager.Application.Service.Interface;
using PromptsManager.Core.Utils;

namespace PromptsManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(
            IAuthService authService
        )
        {
            this._authService = authService;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserRequest request)
        {
            var result = await _authService.Login(request);

            return result.ToActionResult();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserRequest request)
        {
            var result = await _authService.Register(request);

            return result.ToActionResult();
        }

        [Authorize]
        [HttpGet("teste")]
        public async Task<IActionResult> Teste()
        {
            return Ok();
        }   
    }
}
