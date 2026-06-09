using CricBazaar.Application.Interfaces.Players;
using CricBazaar.Domain.Entities.Players;
using CricBazaar.Infrastructure.Data;
using Dapper;
using System.Data;

namespace CricBazaar.Infrastructure.Repositories.Players
{
    public class PlayerRoleRepository : IPlayerRoleRepository
    {
        private readonly DbConnectionFactory _db;

        public PlayerRoleRepository(DbConnectionFactory db)
        {
            _db = db;
        }

        public async Task<IEnumerable<PlayerRole>> GetAllAsync()
        {
            using var con = _db.CreateConnection();

            return await con.QueryAsync<PlayerRole>(
                "sp_PlayerRole_Manage",
                new { Action = "GETALL" },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<PlayerRole?> GetByIdAsync(int id)
        {
            using var con = _db.CreateConnection();

            return await con.QueryFirstOrDefaultAsync<PlayerRole>(
                "sp_PlayerRole_Manage",
                new { Action = "GETBYID", Id = id },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> CreateAsync(PlayerRole role)
        {
            using var con = _db.CreateConnection();

            return await con.ExecuteScalarAsync<int>(
                "sp_PlayerRole_Manage",
                new
                {
                    Action = "CREATE",
                    role.Name
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> UpdateAsync(PlayerRole role)
        {
            using var con = _db.CreateConnection();

            var result = await con.ExecuteScalarAsync<int>(
                "sp_PlayerRole_Manage",
                new
                {
                    Action = "UPDATE",
                    role.Id,
                    role.Name,
                    role.IsActive
                },
                commandType: CommandType.StoredProcedure);

            return result > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var con = _db.CreateConnection();

            var result = await con.ExecuteScalarAsync<int>(
                "sp_PlayerRole_Manage",
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