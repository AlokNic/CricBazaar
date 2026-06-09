using CricBazaar.Domain.Entities.Teams;

namespace CricBazaar.Application.Interfaces.Teams
{
    public interface ITeamRepository
    {
        Task<IEnumerable<Team>> GetAllAsync();

        Task<Team?> GetByIdAsync(int id);

        Task<int> CreateAsync(Team team);

        Task<bool> UpdateAsync(Team team);

        Task<bool> DeleteAsync(int id);
    }
}