using CricBazaar.Domain.Entities.Players;

namespace CricBazaar.Application.Interfaces.Players
{
    public interface IPlayerRoleRepository
    {
        Task<IEnumerable<PlayerRole>> GetAllAsync();

        Task<PlayerRole?> GetByIdAsync(int id);

        Task<int> CreateAsync(PlayerRole role);

        Task<bool> UpdateAsync(PlayerRole role);

        Task<bool> DeleteAsync(int id);
    }
}