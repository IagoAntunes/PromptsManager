using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PromptsManager.Application.Service.Interface;
using PromptsManager.Core.Utils;
using PromptsManager.Domain.Entities;
using PromptsManager.Domain.Repository;
using PromptsManager.Domain.Result;
using PromptsManager.Infrastructure.Data;
using System;

namespace PromptsManager.Infrastructure
{
    public class AuthRepositoryImpl : IAuthRepository
    {

        public readonly PromptsManagerDbContext _db;
        private readonly IPasswordHasher<UserEntity> _passwordHasher;
        private readonly ITokenService _tokenService;
        private readonly ILogger<IAuthRepository> _logger;

        private const int MaxFailedAttempts = 5;
        private static readonly TimeSpan LockoutDuration = TimeSpan.FromMinutes(15);

        public AuthRepositoryImpl(
            PromptsManagerDbContext db,
            IPasswordHasher<UserEntity> passwordHasher,
            ITokenService tokenService,
            ILogger<IAuthRepository> logger)
        {
            _db = db;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
            _logger = logger;
        }

        public async Task<ResultOfT<AuthResult>> Login(string email, string password, string? remoteIp = null)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return ResultOfT<AuthResult>.Failure(Error.BadRequest);

            var normalized = email.Trim().ToLowerInvariant();

            var user = await _db.Users
                .Where(u => u.EmailNormalized == normalized)
                .SingleOrDefaultAsync();

            if (user == null)
            {
                // Não vaze existência do usuário. Pequeno delay para dificultar enumeração.
                _logger.LogWarning("Login attempt with unknown email {Email}", normalized);
                await Task.Delay(250);
                return ResultOfT<AuthResult>.Failure(Error.BadRequest);
            }

            // Check lockout
            if (user.LockoutEnd.HasValue && user.LockoutEnd.Value > DateTimeOffset.UtcNow)
            {
                _logger.LogWarning("Account locked out for user {UserId} until {LockoutEnd}", user.Id, user.LockoutEnd);
                return ResultOfT<AuthResult>.Failure(Error.BadRequest);
            }

            var verification = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
            if (verification == PasswordVerificationResult.Failed)
            {
                user.AccessFailedCount++;
                if (user.AccessFailedCount >= MaxFailedAttempts)
                {
                    user.LockoutEnd = DateTimeOffset.UtcNow.Add(LockoutDuration);
                    user.AccessFailedCount = 0;
                    _logger.LogWarning("User {UserId} locked out until {LockoutEnd}", user.Id, user.LockoutEnd);
                }

                await _db.SaveChangesAsync();
                return ResultOfT<AuthResult>.Failure(Error.BadRequest);
            }

            // Successful login: reset counters
            user.AccessFailedCount = 0;
            user.LockoutEnd = null;

            // Create tokens
            var (jwt, jwtExpires) = await _tokenService.CreateJwtTokenAsync(user);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogWarning(ex, "Falha de concorrência ao tentar logar usuário {UserId}", user.Id);
                return ResultOfT<AuthResult>.Failure(Error.BadRequest);
            }

            var authResult = new AuthResult
            {
                AccessToken = jwt,
                AccessTokenExpires = jwtExpires,
            };

            _logger.LogInformation("User {UserId} logged in successfully", user.Id);
            return ResultOfT<AuthResult>.Success(authResult);
        }

        public async Task<ResultBase> Register(string email, string password)
        {
            var emailAlreadyExists = await _db.Users.AnyAsync(u => u.EmailNormalized == email.Trim().ToLowerInvariant());   
            if(emailAlreadyExists)
            {
                return ResultBase.Failure(Error.BadRequest);
            }

            var userEntity = new UserEntity
            {
                Email = email.Trim(),
                EmailNormalized = email.Trim().ToLowerInvariant(),
            };

            userEntity.PasswordHash = _passwordHasher.HashPassword(userEntity, password);

            await _db.Users.AddAsync(userEntity);
            await _db.SaveChangesAsync();

            _logger.LogInformation("New user registered with Email {Email} and ID {UserId}",
                userEntity.Email, userEntity.Id);

            return ResultBase.Success();    
        }

    }
}
