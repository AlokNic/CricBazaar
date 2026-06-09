using CricBazaar.Application.Interfaces.Teams;
using CricBazaar.Domain.Entities.Teams;
using CricBazaar.Infrastructure.Data;
using Dapper;
using System.Data;

namespace CricBazaar.Infrastructure.Repositories.Teams
{
    public class TeamRepository : ITeamRepository
    {
        private readonly DbConnectionFactory _dbConnectionFactory;

        public TeamRepository(DbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<IEnumerable<Team>> GetAllAsync()
        {
            using var connection = _dbConnectionFactory.CreateConnection();

            return await connection.QueryAsync<Team>(
                "sp_Team_Manage",
                new { Action = "GETALL" },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<Team?> GetByIdAsync(int id)
        {
            using var connection = _dbConnectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Team>(
                "sp_Team_Manage",
                new { Action = "GETBYID", Id = id },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> CreateAsync(Team team)
        {
            using var connection = _dbConnectionFactory.CreateConnection();

            return await connection.ExecuteScalarAsync<int>(
                "sp_Team_Manage",
                new
                {
                    Action = "CREATE",
                    team.Name,
                    team.ShortName,
                    team.TeamTypeId,
                    team.CountryId,
                    team.LogoUrl,
                    team.OwnerUserId,
                    team.Description,
                    team.CreatedByUserId
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> UpdateAsync(Team team)
        {
            using var connection = _dbConnectionFactory.CreateConnection();

            var result = await connection.ExecuteScalarAsync<int>(
                "sp_Team_Manage",
                new
                {
                    Action = "UPDATE",
                    team.Id,
                    team.Name,
                    team.ShortName,
                    team.TeamTypeId,
                    team.CountryId,
                    team.LogoUrl,
                    team.OwnerUserId,
                    team.Description,
                    team.IsActive
                },
                commandType: CommandType.StoredProcedure);

            return result > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var connection = _dbConnectionFactory.CreateConnection();

            var result = await connection.ExecuteScalarAsync<int>(
                "sp_Team_Manage",
                new { Action = "DELETE", Id = id },
                commandType: CommandType.StoredProcedure);

            return result > 0;
        }
    }
}