using PolicyStreetBackEnd.Data;
using PolicyStreetBackEnd.Data.Interface;
using PolicyStreetBackEnd.Models.Entities;

namespace PolicyStreetBackEnd.Models.DAO
{
    public class EmployeeDAO : AbstractDAO<Employee>
    {
        private readonly AppDbContext _context;
        public EmployeeDAO(AppDbContext ctx) : base(ctx)
        {
            _context = ctx;
        }

        public override IQueryable<Employee> Query()
        {
            return _context.Employee;
        }

        public Employee? GetById(int employeeId)
        {
            return Query().FirstOrDefault(c => c.EmployeeId == employeeId);
        }


        // CREATE
        public void Add(Employee employee)
        {
            _context.Employee.Add(employee);
            _context.SaveChanges();
        }

        // UPDATE
        public void Update(Employee employee)
        {
            var existing = GetById(employee.EmployeeId);

            if (existing != null)
            {
                existing.EmployeeCode = employee.EmployeeCode;
                existing.FullName = employee.FullName;
                existing.Gender = employee.Gender;
                existing.DateOfBirth = employee.DateOfBirth;
                existing.Email = employee.Email;
                existing.PhoneNumber = employee.PhoneNumber;
                existing.DepartmentId = employee.DepartmentId;
                existing.PositionId = employee.PositionId;
                existing.Salary = employee.Salary;
                existing.IsActive = employee.IsActive;

                _context.SaveChanges();
            }
        }

        // DELETE
        public void Delete(int id)
        {
            var employee = GetById(id);

            if (employee != null)
            {
                _context.Employee.Remove(employee);
                _context.SaveChanges();
            }
        }
    }
}
