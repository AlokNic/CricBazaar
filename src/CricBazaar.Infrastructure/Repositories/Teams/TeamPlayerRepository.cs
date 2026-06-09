using CricBazaar.Application.Interfaces.Teams;
using CricBazaar.Domain.Entities.Teams;
using CricBazaar.Infrastructure.Data;
using Dapper;
using System.Data;

namespace CricBazaar.Infrastructure.Repositories.Teams
{
    public class TeamPlayerRepository : ITeamPlayerRepository
    {
        private readonly DbConnectionFactory _dbConnectionFactory;

        public TeamPlayerRepository(DbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<IEnumerable<TeamPlayer>> GetByTeamIdAsync(int teamId)
        {
            using var connection = _dbConnectionFactory.CreateConnection();

            return await connection.QueryAsync<TeamPlayer>(
                "sp_TeamPlayer_Manage",
                new
                {
                    Action = "GETBYTEAM",
                    TeamId = teamId
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<TeamPlayer?> GetByIdAsync(int id)
        {
            using var connection = _dbConnectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<TeamPlayer>(
                "sp_TeamPlayer_Manage",
                new
                {
                    Action = "GETBYID",
                    Id = id
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> AddAsync(TeamPlayer teamPlayer)
        {
            using var connection = _dbConnectionFactory.CreateConnection();

            return await connection.ExecuteScalarAsync<int>(
                "sp_TeamPlayer_Manage",
                new
                {
                    Action = "ADD",
                    teamPlayer.TeamId,
                    teamPlayer.PlayerId,
                    teamPlayer.FromDate,
                    teamPlayer.ShirtNumber,
                    teamPlayer.IsCaptain,
                    teamPlayer.IsViceCaptain,
                    teamPlayer.CreatedByUserId
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> UpdateAsync(TeamPlayer teamPlayer)
        {
            using var connection = _dbConnectionFactory.CreateConnection();

            var result = await connection.ExecuteScalarAsync<int>(
                "sp_TeamPlayer_Manage",
                new
                {
                    Action = "UPDATE",
                    teamPlayer.Id,
                    teamPlayer.ToDate,
                    teamPlayer.ShirtNumber,
                    teamPlayer.IsCaptain,
                    teamPlayer.IsViceCaptain
                },
                commandType: CommandType.StoredProcedure);

            return result > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var connection = _dbConnectionFactory.CreateConnection();

            var result = await connection.ExecuteScalarAsync<int>(
                "sp_TeamPlayer_Manage",
                new
                {
                    Action = "REMOVE",
                    Id = id
                },
                commandType: CommandType.StoredProcedure);

            return result > 0;
        }
    }
}