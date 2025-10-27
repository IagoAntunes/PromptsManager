using PromptsManager.Core.Utils;
using PromptsManager.Domain.Result;

namespace PromptsManager.Domain.Repository
{
    public interface IAuthRepository
    {
        Task<ResultOfT<AuthResult>> Login(string email, string password, string? remoteIp = null);
        public Task<ResultBase> Register(string email, string password);
    }
}
