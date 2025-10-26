using PromptsManager.Core.Utils;

namespace PromptsManager.Domain.Repository
{
    public interface IAuthRepository
    {
        public Task<ResultBase> Login(string email, string password);
        public Task<ResultBase> Register(string username, string password, string email);
    }
}
