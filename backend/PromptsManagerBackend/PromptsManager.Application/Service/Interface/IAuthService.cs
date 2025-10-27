using PromptsManager.Application.Request;
using PromptsManager.Core.Utils;
using PromptsManager.Domain.Result;

namespace PromptsManager.Application.Service.Interface
{
    public interface IAuthService
    {
        public Task<ResultBase> Register(RegisterUserRequest request);
        public Task<ResultOfT<AuthResult>> Login(LoginUserRequest request);
    }
}
