using PolicyStreetBackEnd.Data;
using PolicyStreetBackEnd.Models.Entities;

namespace PolicyStreetBackEnd.Models.DAO
{
    public class PositionDAO: AbstractDAO<Position>
    {
        private readonly AppDbContext _context;
        public PositionDAO(AppDbContext ctx) : base(ctx)
        {
            _context = ctx;
        }

        public override IQueryable<Position> Query()
        {
            return _context.Position;
        }
    }
}
