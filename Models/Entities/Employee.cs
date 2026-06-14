namespace PolicyStreetBackEnd.Models.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeCode { get; set; }

        public string FullName { get; set; }

        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public int DepartmentId { get; set; }
        public int PositionId { get; set; }

        public decimal? Salary { get; set; }
        public bool IsActive { get; set; } = true;
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }

        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? HireDate { get; set; }
    }
}
