using CricBazaar.Application.Common;
using CricBazaar.Application.DTOs.Teams;
using CricBazaar.Application.Interfaces.Teams;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CricBazaar.Api.Controllers
{
    [Route("api/v1/teams/{teamId}/players")]
    [ApiController]
    public class TeamPlayersController : ControllerBase
    {
        private readonly ITeamPlayerService _service;

        public TeamPlayersController(ITeamPlayerService service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll(int teamId)
        {
            var result = await _service.GetByTeamIdAsync(teamId);

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Players fetched successfully.",
                Data = result
            });
        }

        [HttpPost]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> Add(
            int teamId,
            AddTeamPlayerDto dto)
        {
            var userId = int.Parse(
                User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            var id = await _service.AddAsync(
                teamId,
                dto,
                userId);

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Player added successfully.",
                Data = new { Id = id }
            });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> Update(
            int teamId,
            int id,
            UpdateTeamPlayerDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);

            if (!updated)
                return NotFound();

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Player updated successfully."
            });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> Delete(
            int teamId,
            int id)
        {
            await _service.DeleteAsync(id);

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Player removed successfully."
            });
        }
    }
}