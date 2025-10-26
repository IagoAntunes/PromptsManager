using AutoMapper;
using PromptsManager.Application.Request;
using PromptsManager.Application.Service.Interface;
using PromptsManager.Core.Utils;
using PromptsManager.Domain.Repository;

namespace PromptsManager.Application.Service.Implementation
{
    internal class AuthServiceImpl : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly IAuthRepository _authRepository;
        private readonly IJwtService _jwtService;

        public AuthServiceImpl(
            IMapper mapper,
            IAuthRepository authRepository,
            IJwtService jwtService
        )
        {
            this._mapper = mapper;
            this._authRepository = authRepository;
            this._jwtService = jwtService;
        }

        public Task<ResultBase> Login(LoginUserRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ResultBase> Register(RegisterUserRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
