using CricBazaar.Application.DTOs.Players;
using CricBazaar.Application.Interfaces.Players;
using CricBazaar.Domain.Entities.Players;

namespace CricBazaar.Application.Services.Players
{
    public class PlayerRoleService : IPlayerRoleService
    {
        private readonly IPlayerRoleRepository _repository;

        public PlayerRoleService(IPlayerRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PlayerRoleDto>> GetAllAsync()
        {
            var roles = await _repository.GetAllAsync();

            return roles.Select(x => new PlayerRoleDto
            {
                Id = x.Id,
                Name = x.Name,
                IsActive = x.IsActive
            });
        }

        public async Task<PlayerRoleDto?> GetByIdAsync(int id)
        {
            var role = await _repository.GetByIdAsync(id);

            if (role == null)
                return null;

            return new PlayerRoleDto
            {
                Id = role.Id,
                Name = role.Name,
                IsActive = role.IsActive
            };
        }

        public async Task<int> CreateAsync(CreatePlayerRoleDto dto)
        {
            return await _repository.CreateAsync(
                new PlayerRole
                {
                    Name = dto.Name.Trim()
                });
        }

        public async Task<bool> UpdateAsync(
            int id,
            UpdatePlayerRoleDto dto)
        {
            var role = await _repository.GetByIdAsync(id);

            if (role == null)
                return false;

            role.Name = dto.Name.Trim();
            role.IsActive = dto.IsActive;

            return await _repository.UpdateAsync(role);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}