using PolicyStreetBackEnd.Data;
using PolicyStreetBackEnd.Data.Interface;
using PolicyStreetBackEnd.Models.DAO;
using PolicyStreetBackEnd.Models.DTO.Response;

namespace PolicyStreetBackEnd.Services
{
    public class DepartmentService : IDeparmentService
    {
        private readonly AppDbContext _context;
        private readonly DepartmentDAO _departmentDAO;

        public DepartmentService(AppDbContext context)
        {
            _context = context;
            _departmentDAO = new DepartmentDAO(context);
        }

        public List<DepartmentResponse> GetAllDepartment()
        {
            var data = _departmentDAO.Query();

            return data.Select(dept => new DepartmentResponse
            {
                DepartmentId = dept.DepartmentId,
                DepartmentCode = dept.DepartmentCode,
                DepartmentName = dept.DepartmentName
            }).ToList();
        }
    }
}
