namespace HumanResourcesService.Models
{
    public class Employee
    {
        public int Id { get; set; } // Identity column
        public int EmployeeId { get; set; } // Business identifier
        public required string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Compensation { get; set; }
        public int DepartmentId { get; set; }
    }
}
