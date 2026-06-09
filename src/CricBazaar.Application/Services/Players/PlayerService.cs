using CricBazaar.Application.DTOs.Players;
using CricBazaar.Application.Interfaces.Players;
using CricBazaar.Domain.Entities.Players;

namespace CricBazaar.Application.Services.Players
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<IEnumerable<PlayerDto>> GetAllAsync()
        {
            var players = await _playerRepository.GetAllAsync();

            return players.Select(x => new PlayerDto
            {
                Id = x.Id,
                FullName = x.FullName,
                ShortName = x.ShortName,
                Country = x.CountryName,
                PlayerRole = x.PlayerRoleName ?? "",
                BattingStyle = x.BattingStyle,
                BowlingStyle = x.BowlingStyle,
                JerseyNumber = x.JerseyNumber,
                ProfileImageUrl = x.ProfileImageUrl,
                IsActive = x.IsActive
            });
        }

        public async Task<PlayerDto?> GetByIdAsync(int id)
        {
            var player = await _playerRepository.GetByIdAsync(id);

            if (player == null)
                return null;

            return new PlayerDto
            {
                Id = player.Id,
                FullName = player.FullName,
                ShortName = player.ShortName,
                Country = player.CountryName,
                PlayerRole = player.PlayerRoleName ?? "",
                BattingStyle = player.BattingStyle,
                BowlingStyle = player.BowlingStyle,
                JerseyNumber = player.JerseyNumber,
                ProfileImageUrl = player.ProfileImageUrl,
                IsActive = player.IsActive
            };
        }

        public async Task<int> CreateAsync(
            CreatePlayerDto dto,
            int createdByUserId)
        {
            var player = new Player
            {
                FullName = dto.FullName.Trim(),
                ShortName = dto.ShortName,
                DateOfBirth = dto.DateOfBirth,
                CountryId = dto.CountryId,
                PlayerRoleId = dto.PlayerRoleId,
                BattingStyle = dto.BattingStyle,
                BowlingStyle = dto.BowlingStyle,
                JerseyNumber = dto.JerseyNumber,
                HeightCm = dto.HeightCm,
                ProfileImageUrl = dto.ProfileImageUrl,
                Bio = dto.Bio,
                CreatedByUserId = createdByUserId
            };

            return await _playerRepository.CreateAsync(player);
        }

        public async Task<bool> UpdateAsync(
            int id,
            UpdatePlayerDto dto)
        {
            var player = await _playerRepository.GetByIdAsync(id);

            if (player == null)
                return false;

            player.FullName = dto.FullName.Trim();
            player.ShortName = dto.ShortName;
            player.DateOfBirth = dto.DateOfBirth;
            player.CountryId = dto.CountryId;
            player.PlayerRoleId = dto.PlayerRoleId;
            player.BattingStyle = dto.BattingStyle;
            player.BowlingStyle = dto.BowlingStyle;
            player.JerseyNumber = dto.JerseyNumber;
            player.HeightCm = dto.HeightCm;
            player.ProfileImageUrl = dto.ProfileImageUrl;
            player.Bio = dto.Bio;
            player.IsActive = dto.IsActive;

            return await _playerRepository.UpdateAsync(player);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _playerRepository.DeleteAsync(id);
        }
    }
}