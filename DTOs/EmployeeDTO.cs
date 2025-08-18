namespace HumanResourcesService.DTOs
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public required string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Compensation { get; set; }
        public int DepartmentId { get; set; }
    }
}
