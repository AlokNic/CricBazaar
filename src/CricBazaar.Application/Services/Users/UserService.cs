using CricBazaar.Application.Common.Security;
using CricBazaar.Application.DTOs;
using CricBazaar.Application.DTOs.Auth;
using CricBazaar.Application.DTOs.Users;
using CricBazaar.Application.Interfaces.Auth;
using CricBazaar.Application.Interfaces.Users;
using CricBazaar.Domain.Entities;
using System.Security.Claims;

namespace CricBazaar.Application.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenService _jwtTokenService;

        public UserService(
            IUserRepository userRepository,
            IJwtTokenService jwtTokenService)
        {
            _userRepository = userRepository;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<int> RegisterAsync(RegisterUserDto dto)
        {
            var existingUser = await _userRepository.GetByEmailAsync(
                dto.Email.Trim().ToLower());

            if (existingUser != null)
                throw new ArgumentException("Email already registered.");

            var user = new User
            {
                FullName = dto.FullName.Trim(),
                Email = dto.Email.Trim().ToLower(),
                Phone = dto.Phone?.Trim(),
                PasswordHash = PasswordHasher.Hash(dto.Password),
                RoleId = 6,
                IsActive = true
            };

            return await _userRepository.RegisterAsync(user);
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
        {
            var user = await _userRepository.GetByEmailAsync(
                dto.Email.Trim().ToLower());

            if (user == null)
                throw new ArgumentException("Invalid email or password.");

            if (!user.IsActive)
                throw new ArgumentException("Account inactive.");

            if (!PasswordHasher.Verify(dto.Password, user.PasswordHash))
                throw new ArgumentException("Invalid email or password.");

            var accessToken = _jwtTokenService.GenerateAccessToken(
                user,
                user.RoleName ?? "User");

            var refreshToken = _jwtTokenService.GenerateRefreshToken();

            await _userRepository.UpdateRefreshTokenAsync(
                user.Id,
                refreshToken,
                DateTime.UtcNow.AddDays(7));

            await _userRepository.UpdateLastLoginAsync(user.Id);

            return new AuthResponseDto
            {
                UserId = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.RoleName ?? "User",
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        public async Task<AuthResponseDto> RefreshTokenAsync(
            RefreshTokenRequestDto dto)
        {
            var user = await _userRepository.GetByRefreshTokenAsync(
                dto.RefreshToken);

            if (user == null)
                throw new ArgumentException("Invalid refresh token.");

            if (user.RefreshTokenExpiryTime < DateTime.UtcNow)
                throw new ArgumentException("Refresh token expired.");

            var accessToken = _jwtTokenService.GenerateAccessToken(
                user,
                user.RoleName ?? "User");

            var refreshToken = _jwtTokenService.GenerateRefreshToken();

            await _userRepository.UpdateRefreshTokenAsync(
                user.Id,
                refreshToken,
                DateTime.UtcNow.AddDays(7));

            return new AuthResponseDto
            {
                UserId = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.RoleName ?? "User",
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        public async Task<bool> LogoutAsync(int userId)
        {
            return await _userRepository.ClearRefreshTokenAsync(userId);
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                return null;

            return new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Phone = user.Phone,
                ProfileImageUrl = user.ProfileImageUrl,
                Role = user.RoleName ?? "",
                IsActive = user.IsActive,
                CreatedAt = user.CreatedAt,
                LastLoginAt = user.LastLoginAt
            };
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();

            return users.Select(user => new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Phone = user.Phone,
                ProfileImageUrl = user.ProfileImageUrl,
                Role = user.RoleName ?? "",
                IsActive = user.IsActive,
                CreatedAt = user.CreatedAt,
                LastLoginAt = user.LastLoginAt
            });
        }

        public async Task<bool> UpdateAsync(int id, UpdateUserDto dto)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                return false;

            user.FullName = dto.FullName.Trim();
            user.Phone = dto.Phone?.Trim();
            user.ProfileImageUrl = dto.ProfileImageUrl;
            user.IsActive = dto.IsActive;

            return await _userRepository.UpdateAsync(user);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _userRepository.DeleteAsync(id);
        }
    }
}