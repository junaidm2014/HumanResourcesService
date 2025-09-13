using HumanResourcesService.Models;
using System.Collections.Generic;

namespace HumanResourcesService.Repositories
{
    public interface IEmployeeRepository
    {
        // IEnumerable<Employee> GetAll();
        // Employee GetById(int id);
        // void Add(Employee employee);
        // void Update(Employee employee);
        // void Disable(int id);
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> GetByIdAsync(int id);
        Task AddAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task DisableAsync(int id);
    }
}
