using HumanResourcesService.Models;
using HumanResourcesService.Repositories;
using HumanResourcesService.DTOs;
using HumanResourcesService.Services;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourcesService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentService _departmentService;
        public DepartmentController(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var departments = await _departmentService.GetAllAsync();
            var dtos = departments.Select(d => new DepartmentDTO
            {
                DepartmentId = d.DepartmentId,
                Name = d.Name
            });
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var department = await _departmentService.GetByIdAsync(id);
            if (department == null) return NotFound();
            var dto = new DepartmentDTO
            {
                DepartmentId = department.DepartmentId,
                Name = department.Name
            };
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(DepartmentDTO dto)
        {
            var department = new Department
            {
                DepartmentId = dto.DepartmentId,
                Name = dto.Name
            };
            var success = await _departmentService.TryAddDepartmentAsync(department);
            if (!success)
            {
                return BadRequest("DepartmentId must be unique.");
            }
            return CreatedAtAction(nameof(GetByIdAsync), new { id = department.DepartmentId }, dto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(DepartmentDTO dto)
        {
            var department = new Department
            {
                DepartmentId = dto.DepartmentId,
                Name = dto.Name
            };
            await _departmentService.UpdateAsync(department);
            return NoContent();
        }

        [HttpDelete("{departmentId}")]
        public async Task<IActionResult> DeleteAsync(int departmentId)
        {
            await _departmentService.DeleteAsync(departmentId);
            return NoContent();
        }
    }
}
