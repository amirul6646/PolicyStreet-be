using PolicyStreetBackEnd.Models.DTO.Response;

namespace PolicyStreetBackEnd.Data.Interface
{
    public interface IPositionService
    {
        public List<PositionResponse> GetAllPosition();
    }
}
