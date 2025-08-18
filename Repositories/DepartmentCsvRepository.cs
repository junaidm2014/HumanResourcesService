using HumanResourcesService.Models;
using System.Collections.Generic;

namespace HumanResourcesService.Repositories
{
    public class DepartmentCsvRepository : IDepartmentRepository
    {
        // TODO: Implement CSV logic
        public IEnumerable<Department> GetAll() => new List<Department>();
        public Department GetById(int id) => null;
        public void Add(Department department) { }
        public void Update(Department department) { }
        public void Delete(int id) { }
    }
}
