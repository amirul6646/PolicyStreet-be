using PolicyStreetBackEnd.Data;
using PolicyStreetBackEnd.Models.Entities;

namespace PolicyStreetBackEnd.Models.DAO
{
    public class DepartmentDAO : AbstractDAO<Department>
    {
        private readonly AppDbContext _context;
        public DepartmentDAO(AppDbContext ctx) : base(ctx)
        {
            _context = ctx;
        }

        public override IQueryable<Department> Query()
        {
            return _context.Department;
        }
    }
}
