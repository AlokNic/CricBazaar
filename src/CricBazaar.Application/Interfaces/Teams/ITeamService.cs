using CricBazaar.Application.DTOs;
using CricBazaar.Application.DTOs.Teams;

namespace CricBazaar.Application.Interfaces.Teams
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamDto>> GetAllAsync();

        Task<TeamDto?> GetByIdAsync(int id);

        Task<int> CreateAsync(
            CreateTeamDto dto,
            int createdByUserId);

        Task<bool> UpdateAsync(
            int id,
            UpdateTeamDto dto);

        Task<bool> DeleteAsync(int id);
    }
}