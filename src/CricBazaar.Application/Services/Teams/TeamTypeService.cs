using CricBazaar.Application.DTOs.Teams;
using CricBazaar.Application.Interfaces.Teams;
using CricBazaar.Domain.Entities.Teams;

namespace CricBazaar.Application.Services.Teams
{
    public class TeamTypeService : ITeamTypeService
    {
        private readonly ITeamTypeRepository _teamTypeRepository;

        public TeamTypeService(ITeamTypeRepository teamTypeRepository)
        {
            _teamTypeRepository = teamTypeRepository;
        }

        public async Task<IEnumerable<TeamTypeDto>> GetAllAsync()
        {
            var teamTypes = await _teamTypeRepository.GetAllAsync();

            return teamTypes.Select(x => new TeamTypeDto
            {
                Id = x.Id,
                Name = x.Name,
                IsActive = x.IsActive
            });
        }

        public async Task<TeamTypeDto?> GetByIdAsync(int id)
        {
            var teamType = await _teamTypeRepository.GetByIdAsync(id);

            if (teamType == null)
                return null;

            return new TeamTypeDto
            {
                Id = teamType.Id,
                Name = teamType.Name,
                IsActive = teamType.IsActive
            };
        }

        public async Task<int> CreateAsync(CreateTeamTypeDto dto)
        {
            var entity = new TeamType
            {
                Name = dto.Name.Trim()
            };

            return await _teamTypeRepository.CreateAsync(entity);
        }

        public async Task<bool> UpdateAsync(int id, UpdateTeamTypeDto dto)
        {
            var existing = await _teamTypeRepository.GetByIdAsync(id);

            if (existing == null)
                return false;

            existing.Name = dto.Name.Trim();
            existing.IsActive = dto.IsActive;

            return await _teamTypeRepository.UpdateAsync(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _teamTypeRepository.DeleteAsync(id);
        }
    }
}