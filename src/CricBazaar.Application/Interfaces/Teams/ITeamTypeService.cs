using CricBazaar.Application.DTOs.Teams;

namespace CricBazaar.Application.Interfaces.Teams
{
    public interface ITeamTypeService
    {
        Task<IEnumerable<TeamTypeDto>> GetAllAsync();

        Task<TeamTypeDto?> GetByIdAsync(int id);

        Task<int> CreateAsync(CreateTeamTypeDto dto);

        Task<bool> UpdateAsync(int id, UpdateTeamTypeDto dto);

        Task<bool> DeleteAsync(int id);
    }
}