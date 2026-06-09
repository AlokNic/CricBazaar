using CricBazaar.Application.Common;
using CricBazaar.Application.DTOs.Auth;
using CricBazaar.Application.Interfaces.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CricBazaar.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterUserDto dto)
        {
            var id = await _userService.RegisterAsync(dto);

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Registration successful.",
                Data = new { UserId = id }
            });
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var result = await _userService.LoginAsync(dto);

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Login successful.",
                Data = result
            });
        }

        [HttpPost("refresh")]
        [AllowAnonymous]
        public async Task<IActionResult> Refresh(
            RefreshTokenRequestDto dto)
        {
            var result = await _userService.RefreshTokenAsync(dto);

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Token refreshed.",
                Data = result
            });
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            var userId = int.Parse(
                User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            await _userService.LogoutAsync(userId);

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Logout successful."
            });
        }
    }
}