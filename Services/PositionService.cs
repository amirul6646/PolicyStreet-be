using PolicyStreetBackEnd.Data;
using PolicyStreetBackEnd.Data.Interface;
using PolicyStreetBackEnd.Models.DAO;
using PolicyStreetBackEnd.Models.DTO.Response;

namespace PolicyStreetBackEnd.Services
{
    public class PositionService : IPositionService
    {
        private readonly AppDbContext _context;
        private readonly PositionDAO _positionDAO;

        public PositionService(AppDbContext context)
        {
            _context = context;
            _positionDAO = new PositionDAO(context);
        }

        public List<PositionResponse> GetAllPosition()
        {
            var data = _positionDAO.Query();

            return data.Select(dept => new PositionResponse
            {
                PositionId = dept.PositionId,
                PositionCode = dept.PositionCode,
                PositionName = dept.PositionName
            }).ToList();
        }
    }
}
