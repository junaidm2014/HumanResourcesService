using HumanResourcesService.Models;
using HumanResourcesService.Repositories;

namespace HumanResourcesService.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task<bool> TryAddEmployeeAsync(Employee employee)
        {
            var department = await _departmentRepository.GetByIdAsync(employee.DepartmentId);
            if (department == null)
            {
                return false;
            }
            await _employeeRepository.AddAsync(employee);
            return true;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Employee employee)
        {
            await _employeeRepository.UpdateAsync(employee);
        }

        public async Task DisableAsync(int employeeId)
        {
            var x = new List<int> { 1, 2, 3 };
            x.FirstOrDefault(a => a == 2);
            var employees = await _employeeRepository.GetAllAsync();
            var employee = employees.FirstOrDefault(e => e.EmployeeId == employeeId);
            //.FirstOrDefault(e => e.EmployeeId == employeeId);
            if (employee != null)
            {
                await _employeeRepository.DisableAsync(employee.Id);
            }
        }

        public async Task DeleteAsync(int employeeId)
        {
            var employees = await _employeeRepository.GetAllAsync();
            var employee = employees.FirstOrDefault(e => e.EmployeeId == employeeId);
            if (employee != null)
            {
                await DisableAsync(employeeId);
                // Implement repository delete if needed
                // await _employeeRepository.DeleteAsync(employee.Id);
            }
        }
    }
}
