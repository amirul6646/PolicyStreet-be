using Microsoft.AspNetCore.Mvc;
using PolicyStreetBackEnd.Data.Interface;

namespace PolicyStreetBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly IDeparmentService _departmentService;

        public DepartmentController(IDeparmentService departmentService)
        {
            _departmentService = departmentService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllDepartment()
        {
            var data = _departmentService.GetAllDepartment();
            return Ok(data);
        }
    }
}
