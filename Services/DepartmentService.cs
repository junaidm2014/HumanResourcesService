using HumanResourcesService.Models;
using HumanResourcesService.Repositories;

namespace HumanResourcesService.Services
{
    public class DepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public bool TryAddDepartment(Department department)
        {
            // Check for uniqueness of DepartmentId
            var existing = _departmentRepository.GetAll().FirstOrDefault(d => d.DepartmentId == department.DepartmentId);
            if (existing != null)
            {
                return false;
            }
            _departmentRepository.Add(department);
            return true;
        }

        public IEnumerable<Department> GetAll()
        {
            return _departmentRepository.GetAll();
        }

        public Department GetById(int id)
        {
            return _departmentRepository.GetById(id);
        }

        public void Update(Department department)
        {
            _departmentRepository.Update(department);
        }

        public void Delete(int departmentId)
        {
            var department = _departmentRepository.GetAll().FirstOrDefault(d => d.DepartmentId == departmentId);
            if (department != null)
            {
                _departmentRepository.Delete(department.Id);
            }
        }
    }
}
