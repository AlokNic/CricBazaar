using CricBazaar.Application.DTOs.Players;

namespace CricBazaar.Application.Interfaces.Players
{
    public interface IPlayerRoleService
    {
        Task<IEnumerable<PlayerRoleDto>> GetAllAsync();

        Task<PlayerRoleDto?> GetByIdAsync(int id);

        Task<int> CreateAsync(CreatePlayerRoleDto dto);

        Task<bool> UpdateAsync(int id, UpdatePlayerRoleDto dto);

        Task<bool> DeleteAsync(int id);
    }
}