using CricBazaar.Application.DTOs.Players;

namespace CricBazaar.Application.Interfaces.Players
{
    public interface IPlayerService
    {
        Task<IEnumerable<PlayerDto>> GetAllAsync();

        Task<PlayerDto?> GetByIdAsync(int id);

        Task<int> CreateAsync(
            CreatePlayerDto dto,
            int createdByUserId);

        Task<bool> UpdateAsync(
            int id,
            UpdatePlayerDto dto);

        Task<bool> DeleteAsync(int id);
    }
}