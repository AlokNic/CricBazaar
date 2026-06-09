using CricBazaar.Application.Interfaces.Users;
using CricBazaar.Domain.Entities;
using CricBazaar.Infrastructure.Data;
using Dapper;
using System.Data;

namespace CricBazaar.Infrastructure.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly DbConnectionFactory _dbConnectionFactory;

        public UserRepository(DbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<int> RegisterAsync(User user)
        {
            using var connection = _dbConnectionFactory.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@Action", "REGISTER");
            parameters.Add("@FullName", user.FullName);
            parameters.Add("@Email", user.Email);
            parameters.Add("@Phone", user.Phone);
            parameters.Add("@PasswordHash", user.PasswordHash);
            parameters.Add("@RoleId", user.RoleId);
            parameters.Add("@ProfileImageUrl", user.ProfileImageUrl);

            return await connection.ExecuteScalarAsync<int>(
                "sp_User_Manage",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            using var connection = _dbConnectionFactory.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@Action", "GETBYEMAIL");
            parameters.Add("@Email", email);

            return await connection.QueryFirstOrDefaultAsync<User>(
                "sp_User_Manage",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<User?> GetByRefreshTokenAsync(string refreshToken)
        {
            using var connection = _dbConnectionFactory.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@Action", "GETBYREFRESHTOKEN");
            parameters.Add("@RefreshToken", refreshToken);

            return await connection.QueryFirstOrDefaultAsync<User>(
                "sp_User_Manage",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> UpdateRefreshTokenAsync(
            int userId,
            string refreshToken,
            DateTime expiryTime)
        {
            using var connection = _dbConnectionFactory.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@Action", "UPDATEREFRESHTOKEN");
            parameters.Add("@Id", userId);
            parameters.Add("@RefreshToken", refreshToken);
            parameters.Add("@RefreshTokenExpiryTime", expiryTime);

            var result = await connection.ExecuteScalarAsync<int>(
                "sp_User_Manage",
                parameters,
                commandType: CommandType.StoredProcedure);

            return result > 0;
        }

        public async Task<bool> ClearRefreshTokenAsync(int userId)
        {
            using var connection = _dbConnectionFactory.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@Action", "CLEARREFRESHTOKEN");
            parameters.Add("@Id", userId);

            var result = await connection.ExecuteScalarAsync<int>(
                "sp_User_Manage",
                parameters,
                commandType: CommandType.StoredProcedure);

            return result > 0;
        }

        public async Task<bool> UpdateLastLoginAsync(int userId)
        {
            using var connection = _dbConnectionFactory.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@Action", "UPDATELASTLOGIN");
            parameters.Add("@Id", userId);

            var result = await connection.ExecuteScalarAsync<int>(
                "sp_User_Manage",
                parameters,
                commandType: CommandType.StoredProcedure);

            return result > 0;
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            using var connection = _dbConnectionFactory.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@Action", "GETBYID");
            parameters.Add("@Id", id);

            return await connection.QueryFirstOrDefaultAsync<User>(
                "sp_User_Manage",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            using var connection = _dbConnectionFactory.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@Action", "GETALL");

            return await connection.QueryAsync<User>(
                "sp_User_Manage",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> UpdateAsync(User user)
        {
            using var connection = _dbConnectionFactory.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@Action", "UPDATE");
            parameters.Add("@Id", user.Id);
            parameters.Add("@FullName", user.FullName);
            parameters.Add("@Phone", user.Phone);
            parameters.Add("@ProfileImageUrl", user.ProfileImageUrl);
            parameters.Add("@IsActive", user.IsActive);

            var result = await connection.ExecuteScalarAsync<int>(
                "sp_User_Manage",
                parameters,
                commandType: CommandType.StoredProcedure);

            return result > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var connection = _dbConnectionFactory.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@Action", "DELETE");
            parameters.Add("@Id", id);

            var result = await connection.ExecuteScalarAsync<int>(
                "sp_User_Manage",
                parameters,
                commandType: CommandType.StoredProcedure);

            return result > 0;
        }
    }
}