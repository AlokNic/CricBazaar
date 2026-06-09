using CricBazaar.Application.Interfaces.Players;
using CricBazaar.Domain.Entities.Players;
using CricBazaar.Infrastructure.Data;
using Dapper;
using System.Data;

namespace CricBazaar.Infrastructure.Repositories.Players
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly DbConnectionFactory _dbConnectionFactory;

        public PlayerRepository(DbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<IEnumerable<Player>> GetAllAsync()
        {
            using var connection = _dbConnectionFactory.CreateConnection();

            return await connection.QueryAsync<Player>(
                "sp_Player_Manage",
                new { Action = "GETALL" },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<Player?> GetByIdAsync(int id)
        {
            using var connection = _dbConnectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Player>(
                "sp_Player_Manage",
                new
                {
                    Action = "GETBYID",
                    Id = id
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> CreateAsync(Player player)
        {
            using var connection = _dbConnectionFactory.CreateConnection();

            return await connection.ExecuteScalarAsync<int>(
                "sp_Player_Manage",
                new
                {
                    Action = "CREATE",
                    player.FullName,
                    player.ShortName,
                    player.DateOfBirth,
                    player.CountryId,
                    player.PlayerRoleId,
                    player.BattingStyle,
                    player.BowlingStyle,
                    player.JerseyNumber,
                    player.HeightCm,
                    player.ProfileImageUrl,
                    player.Bio,
                    player.CreatedByUserId
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> UpdateAsync(Player player)
        {
            using var connection = _dbConnectionFactory.CreateConnection();

            var result = await connection.ExecuteScalarAsync<int>(
                "sp_Player_Manage",
                new
                {
                    Action = "UPDATE",
                    player.Id,
                    player.FullName,
                    player.ShortName,
                    player.DateOfBirth,
                    player.CountryId,
                    player.PlayerRoleId,
                    player.BattingStyle,
                    player.BowlingStyle,
                    player.JerseyNumber,
                    player.HeightCm,
                    player.ProfileImageUrl,
                    player.Bio,
                    player.IsActive
                },
                commandType: CommandType.StoredProcedure);

            return result > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var connection = _dbConnectionFactory.CreateConnection();

            var result = await connection.ExecuteScalarAsync<int>(
                "sp_Player_Manage",
                new
                {
                    Action = "DELETE",
                    Id = id
                },
                commandType: CommandType.StoredProcedure);

            return result > 0;
        }
    }
}