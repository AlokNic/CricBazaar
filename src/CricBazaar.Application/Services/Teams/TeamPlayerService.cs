using CricBazaar.Application.DTOs.Teams;
using CricBazaar.Application.Interfaces.Teams;
using CricBazaar.Domain.Entities.Teams;

namespace CricBazaar.Application.Services.Teams
{
    public class TeamPlayerService : ITeamPlayerService
    {
        private readonly ITeamPlayerRepository _repository;

        public TeamPlayerService(ITeamPlayerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TeamPlayerDto>> GetByTeamIdAsync(int teamId)
        {
            var players = await _repository.GetByTeamIdAsync(teamId);

            return players.Select(x => new TeamPlayerDto
            {
                Id = x.Id,
                PlayerId = x.PlayerId,
                PlayerName = x.PlayerName ?? "",
                ShirtNumber = x.ShirtNumber,
                IsCaptain = x.IsCaptain,
                IsViceCaptain = x.IsViceCaptain,
                FromDate = x.FromDate,
                ToDate = x.ToDate
            });
        }

        public async Task<int> AddAsync(
            int teamId,
            AddTeamPlayerDto dto,
            int createdByUserId)
        {
            var entity = new TeamPlayer
            {
                TeamId = teamId,
                PlayerId = dto.PlayerId,
                FromDate = dto.FromDate,
                ShirtNumber = dto.ShirtNumber,
                IsCaptain = dto.IsCaptain,
                IsViceCaptain = dto.IsViceCaptain,
                CreatedByUserId = createdByUserId
            };

            return await _repository.AddAsync(entity);
        }

        public async Task<bool> UpdateAsync(
            int id,
            UpdateTeamPlayerDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);

            if (existing == null)
                return false;

            existing.ToDate = dto.ToDate;
            existing.ShirtNumber = dto.ShirtNumber;
            existing.IsCaptain = dto.IsCaptain;
            existing.IsViceCaptain = dto.IsViceCaptain;

            return await _repository.UpdateAsync(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}