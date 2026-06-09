using CricBazaar.Domain.Entities.Teams;

namespace CricBazaar.Application.Interfaces.Teams
{
    public interface ITeamTypeRepository
    {
        Task<IEnumerable<TeamType>> GetAllAsync();

        Task<TeamType?> GetByIdAsync(int id);

        Task<int> CreateAsync(TeamType teamType);

        Task<bool> UpdateAsync(TeamType teamType);

        Task<bool> DeleteAsync(int id);
    }
}