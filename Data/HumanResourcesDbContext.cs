using Microsoft.EntityFrameworkCore;
using HumanResourcesService.Models;

namespace HumanResourcesService.Data
{
    public class HumanResourcesDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public HumanResourcesDbContext(DbContextOptions<HumanResourcesDbContext> options)
            : base(options)
        {
        }
    }
}