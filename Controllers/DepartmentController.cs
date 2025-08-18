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
        public IActionResult GetAll()
        {
            var departments = _departmentService.GetAll();
            var dtos = departments.Select(d => new DepartmentDTO
            {
                DepartmentId = d.DepartmentId,
                Name = d.Name
            });
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var department = _departmentService.GetById(id);
            if (department == null) return NotFound();
            var dto = new DepartmentDTO
            {
                DepartmentId = department.DepartmentId,
                Name = department.Name
            };
            return Ok(dto);
        }

        [HttpPost]
        public IActionResult Add(DepartmentDTO dto)
        {
            var department = new Department
            {
                DepartmentId = dto.DepartmentId,
                Name = dto.Name
            };
            var success = _departmentService.TryAddDepartment(department);
            if (!success)
            {
                return BadRequest("DepartmentId must be unique.");
            }
            return CreatedAtAction(nameof(GetById), new { id = department.DepartmentId }, dto);
        }

        [HttpPut]
        public IActionResult Update(DepartmentDTO dto)
        {
            var department = new Department
            {
                DepartmentId = dto.DepartmentId,
                Name = dto.Name
            };
            _departmentService.Update(department);
            return NoContent();
        }

        [HttpDelete("{departmentId}")]
        public IActionResult Delete(int departmentId)
        {
            _departmentService.Delete(departmentId);
            return NoContent();
        }
    }
}
