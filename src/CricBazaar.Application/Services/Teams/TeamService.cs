using CricBazaar.Application.DTOs;
using CricBazaar.Application.DTOs.Teams;
using CricBazaar.Application.Interfaces.Teams;
using CricBazaar.Domain.Entities.Teams;

namespace CricBazaar.Application.Services.Teams
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<IEnumerable<TeamDto>> GetAllAsync()
        {
            var teams = await _teamRepository.GetAllAsync();

            return teams.Select(x => new TeamDto
            {
                Id = x.Id,
                Name = x.Name,
                ShortName = x.ShortName,
                TeamType = x.TeamTypeName ?? "",
                Country = x.CountryName,
                LogoUrl = x.LogoUrl,
                OwnerName = x.OwnerName,
                Description = x.Description,
                IsActive = x.IsActive
            });
        }

        public async Task<TeamDto?> GetByIdAsync(int id)
        {
            var team = await _teamRepository.GetByIdAsync(id);

            if (team == null)
                return null;

            return new TeamDto
            {
                Id = team.Id,
                Name = team.Name,
                ShortName = team.ShortName,
                TeamType = team.TeamTypeName ?? "",
                Country = team.CountryName,
                LogoUrl = team.LogoUrl,
                OwnerName = team.OwnerName,
                Description = team.Description,
                IsActive = team.IsActive
            };
        }

        public async Task<int> CreateAsync(
            CreateTeamDto dto,
            int createdByUserId)
        {
            var entity = new Team
            {
                Name = dto.Name.Trim(),
                ShortName = dto.ShortName.Trim(),
                TeamTypeId = dto.TeamTypeId,
                CountryId = dto.CountryId,
                LogoUrl = dto.LogoUrl,
                OwnerUserId = dto.OwnerUserId,
                Description = dto.Description,
                CreatedByUserId = createdByUserId
            };

            return await _teamRepository.CreateAsync(entity);
        }

        public async Task<bool> UpdateAsync(
            int id,
            UpdateTeamDto dto)
        {
            var team = await _teamRepository.GetByIdAsync(id);

            if (team == null)
                return false;

            team.Name = dto.Name.Trim();
            team.ShortName = dto.ShortName.Trim();
            team.TeamTypeId = dto.TeamTypeId;
            team.CountryId = dto.CountryId;
            team.LogoUrl = dto.LogoUrl;
            team.OwnerUserId = dto.OwnerUserId;
            team.Description = dto.Description;
            team.IsActive = dto.IsActive;

            return await _teamRepository.UpdateAsync(team);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _teamRepository.DeleteAsync(id);
        }
    }
}