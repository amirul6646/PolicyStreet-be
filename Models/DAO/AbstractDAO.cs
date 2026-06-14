using PolicyStreetBackEnd.Data;

namespace PolicyStreetBackEnd.Models.DAO
{
    public abstract class AbstractDAO<T>
    {
        private readonly AppDbContext _context;

        public AbstractDAO(AppDbContext context)
        {
            _context = context;
        }

        public abstract IQueryable<T> Query();
    }
}
