using CricBazaar.Application.Interfaces.Teams;
using CricBazaar.Domain.Entities.Teams;
using CricBazaar.Infrastructure.Data;
using Dapper;
using System.Data;

namespace CricBazaar.Infrastructure.Repositories.Teams
{
    public class TeamTypeRepository : ITeamTypeRepository
    {
        private readonly DbConnectionFactory _dbConnectionFactory;

        public TeamTypeRepository(DbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<IEnumerable<TeamType>> GetAllAsync()
        {
            using var connection = _dbConnectionFactory.CreateConnection();

            return await connection.QueryAsync<TeamType>(
                "sp_TeamType_Manage",
                new { Action = "GETALL" },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<TeamType?> GetByIdAsync(int id)
        {
            using var connection = _dbConnectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<TeamType>(
                "sp_TeamType_Manage",
                new { Action = "GETBYID", Id = id },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> CreateAsync(TeamType teamType)
        {
            using var connection = _dbConnectionFactory.CreateConnection();

            return await connection.ExecuteScalarAsync<int>(
                "sp_TeamType_Manage",
                new
                {
                    Action = "CREATE",
                    teamType.Name
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> UpdateAsync(TeamType teamType)
        {
            using var connection = _dbConnectionFactory.CreateConnection();

            var result = await connection.ExecuteScalarAsync<int>(
                "sp_TeamType_Manage",
                new
                {
                    Action = "UPDATE",
                    teamType.Id,
                    teamType.Name,
                    teamType.IsActive
                },
                commandType: CommandType.StoredProcedure);

            return result > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var connection = _dbConnectionFactory.CreateConnection();

            var result = await connection.ExecuteScalarAsync<int>(
                "sp_TeamType_Manage",
                new { Action = "DELETE", Id = id },
                commandType: CommandType.StoredProcedure);

            return result > 0;
        }
    }
}