using PromptsManager.Domain.Entities;

namespace PromptsManager.Application.Service.Interface
{
    public interface ITokenService
    {
        Task<(string token, DateTimeOffset expires)> CreateJwtTokenAsync(UserEntity user);
        RefreshTokenEntity GenerateRefreshToken(string createdByIp, int daysToExpire = 30);
    }
}
