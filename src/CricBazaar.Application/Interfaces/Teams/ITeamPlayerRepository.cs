using CricBazaar.Domain.Entities.Teams;

namespace CricBazaar.Application.Interfaces.Teams
{
    public interface ITeamPlayerRepository
    {
        Task<IEnumerable<TeamPlayer>> GetByTeamIdAsync(int teamId);

        Task<TeamPlayer?> GetByIdAsync(int id);

        Task<int> AddAsync(TeamPlayer teamPlayer);

        Task<bool> UpdateAsync(TeamPlayer teamPlayer);

        Task<bool> DeleteAsync(int id);
    }
}