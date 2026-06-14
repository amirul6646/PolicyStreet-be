namespace PolicyStreetBackEnd.Models.DTO.Response
{
    public class EmployeeResponse
    {
        public int? EmployeeId { get; set; }
        public string? EmployeeCode { get; set; }

        public string? FullName { get; set; }

        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public int? PositionId { get; set; }
        public string? PositionName { get; set; }

        public decimal? Salary { get; set; }
        public bool? IsActive { get; set; } = true;
        public DateTime? HireDate { get; set; }
    }
}
