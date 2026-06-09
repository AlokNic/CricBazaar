using CricBazaar.Domain.Entities.Players;

namespace CricBazaar.Application.Interfaces.Players
{
    public interface IPlayerRepository
    {
        Task<IEnumerable<Player>> GetAllAsync();

        Task<Player?> GetByIdAsync(int id);

        Task<int> CreateAsync(Player player);

        Task<bool> UpdateAsync(Player player);

        Task<bool> DeleteAsync(int id);
    }
}