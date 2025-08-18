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
        public IActionResult GetAll()
        {
            var employees = _employeeService.GetAll();
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
        public IActionResult GetById(int id)
        {
            var employee = _employeeService.GetById(id);
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
        public IActionResult Add(EmployeeDTO dto)
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
            var success = _employeeService.TryAddEmployee(employee);
            if (!success)
            {
                return BadRequest("Department does not exist.");
            }
            return CreatedAtAction(nameof(GetById), new { id = employee.Id }, dto);
        }

        [HttpPut]
        public IActionResult Update(EmployeeDTO dto)
        {
            var employee = new Employee
            {
                Name = dto.Name,
                IsActive = dto.IsActive,
                HireDate = dto.HireDate,
                Compensation = dto.Compensation,
                DepartmentId = dto.DepartmentId
            };
            _employeeService.Update(employee);
            return NoContent();
        }

        [HttpPut("disable/{employeeId}")]
        public IActionResult Disable(int employeeId)
        {
            _employeeService.Disable(employeeId);
            return NoContent();
        }
    }
}
