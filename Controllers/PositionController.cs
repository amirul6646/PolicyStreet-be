using Microsoft.AspNetCore.Mvc;
using PolicyStreetBackEnd.Data.Interface;

namespace PolicyStreetBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : Controller
    {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }
        // GET: api/employee
        [HttpGet]
        public async Task<IActionResult> GetAllPosition()
        {
            var data = _positionService.GetAllPosition();
            return Ok(data);
        }
    }
}
