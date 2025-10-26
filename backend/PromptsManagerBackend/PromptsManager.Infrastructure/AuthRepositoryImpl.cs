using PromptsManager.Core.Utils;
using PromptsManager.Domain.Repository;
using PromptsManager.Infrastructure.Data;

namespace PromptsManager.Infrastructure
{
    public class AuthRepositoryImpl : IAuthRepository
    {

        public readonly PromptsManagerDbContext _dbContext;

        public AuthRepositoryImpl(
            PromptsManagerDbContext dbContext
        )
        {
            this._dbContext = dbContext;
        }

        public async Task<ResultBase> Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<ResultBase> Register(string username, string password, string email)
        {
            throw new NotImplementedException();
        }
    }
}
