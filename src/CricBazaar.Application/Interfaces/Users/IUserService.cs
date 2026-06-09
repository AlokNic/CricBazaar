using CricBazaar.Application.DTOs;
using CricBazaar.Application.DTOs.Auth;
using CricBazaar.Application.DTOs.Users;

namespace CricBazaar.Application.Interfaces.Users
{
    public interface IUserService
    {
        Task<int> RegisterAsync(RegisterUserDto dto);

        Task<AuthResponseDto> LoginAsync(LoginDto dto);

        Task<AuthResponseDto> RefreshTokenAsync(
            RefreshTokenRequestDto dto);

        Task<bool> LogoutAsync(int userId);

        Task<UserDto?> GetByIdAsync(int id);

        Task<IEnumerable<UserDto>> GetAllAsync();

        Task<bool> UpdateAsync(int id, UpdateUserDto dto);

        Task<bool> DeleteAsync(int id);
    }
}