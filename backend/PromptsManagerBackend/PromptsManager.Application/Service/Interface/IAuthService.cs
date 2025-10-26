using PromptsManager.Application.Request;
using PromptsManager.Core.Utils;

namespace PromptsManager.Application.Service.Interface
{
    public interface IAuthService
    {
        public Task<ResultBase> Register(RegisterUserRequest request);
        public Task<ResultBase> Login(LoginUserRequest request);
    }
}
