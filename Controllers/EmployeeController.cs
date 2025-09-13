using HumanResourcesService.Models;
using HumanResourcesService.Repositories;
using HumanResourcesService.DTOs;
using HumanResourcesService.Services;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourcesService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;
        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var employees = await _employeeService.GetAllAsync();
            var dtos = employees.Select(e => new EmployeeDTO
            {
                EmployeeId = e.EmployeeId,
                Name = e.Name,
                IsActive = e.IsActive,
                HireDate = e.HireDate,
                Compensation = e.Compensation,
                DepartmentId = e.DepartmentId
            });
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            if (employee == null) return NotFound();
            var dto = new EmployeeDTO
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.Name,
                IsActive = employee.IsActive,
                HireDate = employee.HireDate,
                Compensation = employee.Compensation,
                DepartmentId = employee.DepartmentId
            };
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(EmployeeDTO dto)
        {
            var employee = new Employee
            {
                EmployeeId = dto.EmployeeId,
                Name = dto.Name,
                IsActive = dto.IsActive,
                HireDate = dto.HireDate,
                Compensation = dto.Compensation,
                DepartmentId = dto.DepartmentId
            };
            var success = await _employeeService.TryAddEmployeeAsync(employee);
            if (!success)
            {
                return BadRequest("Department does not exist.");
            }
            return CreatedAtAction(nameof(GetByIdAsync), new { id = employee.Id }, dto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(EmployeeDTO dto)
        {
            var employee = new Employee
            {
                Name = dto.Name,
                IsActive = dto.IsActive,
                HireDate = dto.HireDate,
                Compensation = dto.Compensation,
                DepartmentId = dto.DepartmentId
            };
            await _employeeService.UpdateAsync(employee);
            return NoContent();
        }

        [HttpPut("disable/{employeeId}")]
        public async Task<IActionResult> DisableAsync(int employeeId)
        {
            await _employeeService.DisableAsync(employeeId);
            return NoContent();
        }
    }
}
