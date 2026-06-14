using PolicyStreetBackEnd.Models;
using PolicyStreetBackEnd.Models.DTO.Response;
using PolicyStreetBackEnd.Models.Entities;

namespace PolicyStreetBackEnd.Data.Interface
{
    public interface IEmployeeService
    {
        ServiceResult<List<EmployeeResponse>> GetAllEmployees(string? Fullname, string? EmployeeCode, int? DepartmentId, int? PositionId);
        ServiceResult<EmployeeResponse?> GetById(int id);

        ServiceResult<bool> Create(EmployeeRequest employee);

        ServiceResult<bool> Update(Employee employee);

        void Delete(int id);

    }
}
