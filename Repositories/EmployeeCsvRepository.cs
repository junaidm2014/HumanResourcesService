using HumanResourcesService.Models;
using System.Collections.Generic;

namespace HumanResourcesService.Repositories
{
    public class EmployeeCsvRepository : IEmployeeRepository
    {
        // TODO: Implement CSV logic
        public IEnumerable<Employee> GetAll() => new List<Employee>();
        public Employee GetById(int id) => null;
        public void Add(Employee employee) { }
        public void Update(Employee employee) { }
        public void Disable(int id) { }
    }
}
