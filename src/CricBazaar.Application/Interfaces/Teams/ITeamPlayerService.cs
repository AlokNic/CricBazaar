using CricBazaar.Application.DTOs.Teams;

namespace CricBazaar.Application.Interfaces.Teams
{
    public interface ITeamPlayerService
    {
        Task<IEnumerable<TeamPlayerDto>> GetByTeamIdAsync(int teamId);

        Task<int> AddAsync(
            int teamId,
            AddTeamPlayerDto dto,
            int createdByUserId);

        Task<bool> UpdateAsync(
            int id,
            UpdateTeamPlayerDto dto);

        Task<bool> DeleteAsync(int id);
    }
}