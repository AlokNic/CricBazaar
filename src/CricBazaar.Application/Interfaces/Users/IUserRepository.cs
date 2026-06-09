using CricBazaar.Domain.Entities;

namespace CricBazaar.Application.Interfaces.Users
{
    public interface IUserRepository
    {
        Task<int> RegisterAsync(User user);

        Task<User?> GetByEmailAsync(string email);

        Task<User?> GetByRefreshTokenAsync(string refreshToken);

        Task<bool> UpdateRefreshTokenAsync(
            int userId,
            string refreshToken,
            DateTime expiryTime);

        Task<bool> ClearRefreshTokenAsync(int userId);

        Task<bool> UpdateLastLoginAsync(int userId);

        Task<User?> GetByIdAsync(int id);

        Task<IEnumerable<User>> GetAllAsync();

        Task<bool> UpdateAsync(User user);

        Task<bool> DeleteAsync(int id);
    }
}