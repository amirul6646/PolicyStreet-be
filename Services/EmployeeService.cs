using PolicyStreetBackEnd.Data;
using PolicyStreetBackEnd.Data.Interface;
using PolicyStreetBackEnd.Models;
using PolicyStreetBackEnd.Models.DAO;
using PolicyStreetBackEnd.Models.DTO.Response;
using PolicyStreetBackEnd.Models.Entities;

namespace PolicyStreetBackEnd.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;
        private readonly EmployeeDAO _employeeDAO;
        private readonly DepartmentDAO _departmentDAO;
        private readonly PositionDAO _positionDAO;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
            _employeeDAO = new EmployeeDAO(context);
            _departmentDAO = new DepartmentDAO(context);
            _positionDAO = new PositionDAO(context);
        }

        public ServiceResult<List<EmployeeResponse>> GetAllEmployees(string? FullName, string? EmployeeCode, int? DepartmentId, int? PositionId)
        {
            var result = new ServiceResult<List<EmployeeResponse>>();
            try
            {
                var data = (from e in _employeeDAO.Query()
                            join d in _departmentDAO.Query() on e.DepartmentId equals d.DepartmentId into d1
                            from d in d1.DefaultIfEmpty()
                            join p in _positionDAO.Query() on e.PositionId equals p.PositionId into p1
                            from p in p1.DefaultIfEmpty()
                            where (string.IsNullOrEmpty(FullName) || e.FullName.Contains(FullName))
                            && (string.IsNullOrEmpty(EmployeeCode) || e.EmployeeCode.Contains(EmployeeCode))
                            && (DepartmentId == null || e.DepartmentId == DepartmentId)
                            && (PositionId == null || e.PositionId == PositionId)
                            select new EmployeeResponse
                            {
                                EmployeeId = e.EmployeeId,
                                EmployeeCode = e.EmployeeCode,
                                FullName = e.FullName,
                                Gender = e.Gender,
                                DateOfBirth = e.DateOfBirth,
                                Email = e.Email,
                                PhoneNumber = e.PhoneNumber,
                                DepartmentId = e.DepartmentId,
                                DepartmentName = d.DepartmentName,
                                PositionId = e.PositionId,
                                PositionName = p.PositionName,
                                Salary = e.Salary,
                                IsActive = e.IsActive,
                            }
                        );

                result.SuccessResult(data.ToList(), "Success");

            }
            catch (Exception ex)
            {
                result.ErrorResult(ex.Message);
            }

            return result;
                
        }

        public ServiceResult<EmployeeResponse?> GetById(int id)
        {
            var result = new ServiceResult<EmployeeResponse?>();

            try
            {
                var emp = _employeeDAO.GetById(id);

                if (emp == null)
                {
                    result.ErrorResult("Employee Not Found");

                    return result;
                }

                    var employeeResult =  new EmployeeResponse
                {
                    EmployeeId = emp.EmployeeId,
                    EmployeeCode = emp.EmployeeCode,
                    FullName = emp.FullName,
                    Gender = emp.Gender,
                    DateOfBirth = emp.DateOfBirth,
                    Email = emp.Email,
                    PhoneNumber = emp.PhoneNumber,
                    DepartmentId = emp.DepartmentId,
                    PositionId = emp.PositionId,
                    Salary = emp.Salary,
                    IsActive = emp.IsActive,
                    HireDate = emp.HireDate

                };

                result.SuccessResult(employeeResult, "fetch success");
            }
            catch (Exception ex)
            {
                result.ErrorResult(ex.Message);
            }

            return result;
        }

        // CREATE
        public ServiceResult<bool> Create(EmployeeRequest request)
        {
            var result = new ServiceResult<bool>();

            try
            {
                var existingEmpCode = GetAllEmployees(null,request.EmployeeCode,null,null);

                if (existingEmpCode.Result != null && existingEmpCode.Result.Any())
                {
                    result.ErrorResult("There is employee code was exist");

                    return result;
                }

                var entity = new Employee
                {
                    EmployeeCode = request.EmployeeCode,
                    FullName = request.FullName,
                    Gender = request.Gender,
                    DateOfBirth = request.DateOfBirth,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    DepartmentId = request.DepartmentId,
                    PositionId = request.PositionId,
                    Salary = request.Salary,
                    IsActive = request.IsActive,
                    CreatedBy = 1,
                    CreatedAt = DateTime.Now,
                    HireDate = request.HireDate
                };

                _employeeDAO.Add(entity);

                result.SuccessResult(true, "Employee created successfull");
            }
            catch (Exception ex)
            {
                result.ErrorResult(ex.Message);
            }

            return result;
            
        }

        // UPDATE
        public ServiceResult<bool> Update(Employee request)
        {
            var result = new ServiceResult<bool>();

            try
            {
                var exists = _employeeDAO.Query().Any(x => x.EmployeeCode == request.EmployeeCode && x.EmployeeId != request.EmployeeId);

                if (exists)
                {
                    result.ErrorResult("Employee code already exists");
                    return result;
                }


                var entity = new Employee
                {
                    EmployeeId = request.EmployeeId,
                    EmployeeCode = request.EmployeeCode,
                    FullName = request.FullName,
                    Gender = request.Gender,
                    DateOfBirth = request.DateOfBirth,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    DepartmentId = request.DepartmentId,
                    PositionId = request.PositionId,
                    Salary = request.Salary,
                    IsActive = request.IsActive
                };

                _employeeDAO.Update(entity);

                result.SuccessResult(true, "Employee update successfully");

            }
            catch(Exception ex)
            {
                result.ErrorResult("Employee update failed");
            }

            return result;
            
        }

        // DELETE
        public ServiceResult<string> Delete(int id)
        {
            var result = new ServiceResult<string>();

            try
            {
                var data = _employeeDAO.GetById(id);

                if (data == null)
                {
                    throw new KeyNotFoundException("Employee not found");
                }

                _employeeDAO.Delete(id);

                result.SuccessResult("Success", "Delete employee success");
            }
            catch (Exception e)
            {
                result.ErrorResult("Delete employee failed");
            }
            

            return result;
        }
    }
}
