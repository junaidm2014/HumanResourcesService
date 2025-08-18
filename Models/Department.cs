namespace HumanResourcesService.Models
{
    public class Department
    {
        public int Id { get; set; } // Identity column
        public int DepartmentId { get; set; }
        public required string Name { get; set; }
    }
}
