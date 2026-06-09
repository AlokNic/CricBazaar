using CricBazaar.Application.Common;
using CricBazaar.Application.DTOs.Teams;
using CricBazaar.Application.Interfaces.Teams;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CricBazaar.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        // GET: api/v1/teams
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var teams = await _teamService.GetAllAsync();

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Teams fetched successfully.",
                Data = teams
            });
        }

        // GET: api/v1/teams/1
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var team = await _teamService.GetByIdAsync(id);

            if (team == null)
            {
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Team not found."
                });
            }

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Team fetched successfully.",
                Data = team
            });
        }

        // POST: api/v1/teams
        [HttpPost]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> Create(CreateTeamDto dto)
        {
            var userId = int.Parse(
                User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            var teamId = await _teamService.CreateAsync(dto, userId);

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Team created successfully.",
                Data = new { Id = teamId }
            });
        }

        // PUT: api/v1/teams/1
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> Update(
            int id,
            UpdateTeamDto dto)
        {
            var updated = await _teamService.UpdateAsync(id, dto);

            if (!updated)
            {
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Team not found."
                });
            }

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Team updated successfully."
            });
        }

        // DELETE: api/v1/teams/1
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _teamService.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Team not found."
                });
            }

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Team deleted successfully."
            });
        }
    }
}