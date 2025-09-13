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

        public async Task<bool> TryAddDepartmentAsync(Department department)
        {
            // Check for uniqueness of DepartmentId
            var departments = await _departmentRepository.GetAllAsync();
            var existing = departments.FirstOrDefault(d => d.DepartmentId == department.DepartmentId);
            if (existing != null)
            {
                return false;
            }
            await _departmentRepository.AddAsync(department);
            return true;
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            return await _departmentRepository.GetAllAsync();
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            return await _departmentRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Department department)
        {
            await _departmentRepository.UpdateAsync(department);
        }

        public async Task DeleteAsync(int departmentId)
        {
            var departments = await _departmentRepository.GetAllAsync();
            var department = departments.FirstOrDefault(d => d.DepartmentId == departmentId);
            if (department != null)
            {
                await _departmentRepository.DeleteAsync(department.Id);
            }
        }
    }
}
