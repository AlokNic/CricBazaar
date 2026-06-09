using CricBazaar.Application.Common;
using CricBazaar.Application.DTOs.Teams;
using CricBazaar.Application.Interfaces.Teams;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CricBazaar.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TeamTypesController : ControllerBase
    {
        private readonly ITeamTypeService _teamTypeService;

        public TeamTypesController(ITeamTypeService teamTypeService)
        {
            _teamTypeService = teamTypeService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var data = await _teamTypeService.GetAllAsync();

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Team types fetched successfully.",
                Data = data
            });
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _teamTypeService.GetByIdAsync(id);

            if (data == null)
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Team type not found."
                });

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Team type fetched successfully.",
                Data = data
            });
        }

        [HttpPost]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> Create(CreateTeamTypeDto dto)
        {
            var id = await _teamTypeService.CreateAsync(dto);

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Team type created successfully.",
                Data = new { Id = id }
            });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> Update(
            int id,
            UpdateTeamTypeDto dto)
        {
            var updated = await _teamTypeService.UpdateAsync(id, dto);

            if (!updated)
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Team type not found."
                });

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Team type updated successfully."
            });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _teamTypeService.DeleteAsync(id);

            if (!deleted)
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Team type not found."
                });

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Team type deleted successfully."
            });
        }
    }
}