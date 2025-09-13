using HumanResourcesService.Models;
using System.Collections.Generic;

namespace HumanResourcesService.Repositories
{
    public interface IDepartmentRepository
    {
        // IEnumerable<Department> GetAll();
        Task<IEnumerable<Department>> GetAllAsync();
        // Department GetById(int departmentId);
        Task<Department> GetByIdAsync(int departmentId);
        // void Add(Department department);
        Task AddAsync(Department department);
        // void Update(Department department);
        Task UpdateAsync(Department department);
        Task DeleteAsync(int departmentId);
        // void Delete(int departmentId);
    }
}
