using PolicyStreetBackEnd.Models.DTO.Response;

namespace PolicyStreetBackEnd.Data.Interface
{
    public interface IDeparmentService
    {
        List<DepartmentResponse> GetAllDepartment();
    }
}
