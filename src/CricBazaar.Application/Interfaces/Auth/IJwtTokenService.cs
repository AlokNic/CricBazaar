using CricBazaar.Domain.Entities;

namespace CricBazaar.Application.Interfaces.Auth
{
    public interface IJwtTokenService
    {
        string GenerateAccessToken(User user, string roleName);

        string GenerateRefreshToken();
    }
}