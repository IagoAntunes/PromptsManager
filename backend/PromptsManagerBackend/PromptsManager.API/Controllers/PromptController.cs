using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromptsManager.Application.Request;
using PromptsManager.Application.Service.Interface;
using PromptsManager.Core.Utils;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PromptsManager.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class PromptController : ControllerBase
    {

        private readonly IPromptService _promptService;

        public PromptController(
            IPromptService promptService
        )
        {
            this._promptService = promptService;
        }

        private ResultOfT<Guid> GetCurrentUserId()
        {
            if (!Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var userId))
            {
                return ResultOfT<Guid>.Failure(new Error("Auth.InvalidToken", "Token de usuário inválido."));
            }
            return ResultOfT<Guid>.Success(userId);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePromptRequest request)
        {
            var userIdResult = GetCurrentUserId();
            if (userIdResult.IsFailure)
                return userIdResult.ToActionResult(); 
            var result = await _promptService.CreatePromptAsync(request, userIdResult.Value);
            if (result.IsSuccess)
            {
                return Created();
            }
            return result.ToActionResult();
        }

        [HttpGet]
        public async Task<IActionResult> GetPromptsByUser()
        {
            var userIdResult = GetCurrentUserId();
            if (userIdResult.IsFailure)
                return userIdResult.ToActionResult();
            var result = await _promptService.GetPromptsByUser(userIdResult.Value);
            return result.ToActionResult();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatePromptRequest request)
        {
            var userIdResult = GetCurrentUserId();
            if (userIdResult.IsFailure)
                return userIdResult.ToActionResult();
            var result = await _promptService.Update(request, userIdResult.Value);
            return result.ToActionResult();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid promptId)
        {
            var userIdResult = GetCurrentUserId();
            if (userIdResult.IsFailure)
                return userIdResult.ToActionResult();
            var result = await _promptService.Delete(promptId, userIdResult.Value); 
            return result.ToActionResult();
        }
    }
}
