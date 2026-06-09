using CricBazaar.Application.Common;
using CricBazaar.Application.DTOs.Users;
using CricBazaar.Application.Interfaces.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CricBazaar.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Users fetched successfully.",
                Data = users
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "User fetched successfully.",
                Data = user
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            UpdateUserDto dto)
        {
            var updated = await _userService.UpdateAsync(id, dto);

            if (!updated)
                return NotFound();

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "User updated successfully."
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _userService.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "User deleted successfully."
            });
        }
    }
}