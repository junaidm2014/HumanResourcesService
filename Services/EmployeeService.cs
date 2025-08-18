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

        public bool TryAddEmployee(Employee employee)
        {
            var department = _departmentRepository.GetById(employee.DepartmentId);
            if (department == null)
            {
                return false;
            }
            _employeeRepository.Add(employee);
            return true;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }

        public Employee GetById(int id)
        {
            return _employeeRepository.GetById(id);
        }

        public void Update(Employee employee)
        {
            _employeeRepository.Update(employee);
        }

        public void Disable(int employeeId)
        {
            var employee = _employeeRepository.GetAll().FirstOrDefault(e => e.EmployeeId == employeeId);
            if (employee != null)
            {
                _employeeRepository.Disable(employee.Id);
            }
        }

        public void Delete(int employeeId)
        {
            var employee = _employeeRepository.GetAll().FirstOrDefault(e => e.EmployeeId == employeeId);
            if (employee != null)
            {
                // Implement repository delete if needed
                // _employeeRepository.Delete(employee.Id);
            }
    // ...existing code...
        }
    }
}
