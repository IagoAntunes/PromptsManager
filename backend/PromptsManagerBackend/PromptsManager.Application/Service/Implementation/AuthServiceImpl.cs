using AutoMapper;
using PromptsManager.Application.Request;
using PromptsManager.Application.Service.Interface;
using PromptsManager.Core.Utils;
using PromptsManager.Domain.Repository;
using PromptsManager.Domain.Result;

namespace PromptsManager.Application.Service.Implementation
{
    internal class AuthServiceImpl : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly IAuthRepository _authRepository;
        private readonly ITokenService _jwtService;

        public AuthServiceImpl(
            IMapper mapper,
            IAuthRepository authRepository,
            ITokenService jwtService
        )
        {
            this._mapper = mapper;
            this._authRepository = authRepository;
            this._jwtService = jwtService;
        }

        public Task<ResultOfT<AuthResult>> Login(LoginUserRequest request)
        {
            return _authRepository.Login(
                request.Email,
                request.Password
            );
        }

        public Task<ResultBase> Register(RegisterUserRequest request)
        {
            return _authRepository.Register(
                request.Email,
                request.Password
            );
        }
    }
}
