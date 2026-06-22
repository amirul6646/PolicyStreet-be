using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PolicyStreetBackEnd.Data;
using PolicyStreetBackEnd.Data.Interface;
using PolicyStreetBackEnd.Models.DAO;
using PolicyStreetBackEnd.Models.Entities;

namespace PolicyStreetBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService) 
        {
            _employeeService = employeeService;
        }
        // GET: api/employee
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees(string? Fullname, string? EmployeeCode, int? DepartmentId, int? PositionId)
        {
            var data = _employeeService.GetAllEmployees(Fullname, EmployeeCode, DepartmentId, PositionId);
            return Ok(data);
        }

        // =========================
        // GET BY ID
        // =========================
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _employeeService.GetById(id);

            if (result == null)
                return NotFound("Employee not found");

            return Ok(result);
        }

        // =========================
        // CREATE
        // =========================
        [HttpPost]
        public IActionResult Create([FromBody] EmployeeRequest dto)
        {
            if (dto == null)
                return BadRequest(new { message = "Invalid data" });

            var result = _employeeService.Create(dto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // =========================
        // UPDATE
        // =========================
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Employee dto)
        {

            try
            {
                if (dto == null)
                    return BadRequest("Invalid data");

                // ensure route ID matches body ID
                dto.EmployeeId = id;

                var result = _employeeService.Update(dto);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Update employee fail" });
            }
            
        }

        // =========================
        // DELETE
        // =========================
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _employeeService.Delete(id);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
               return BadRequest(new { message = "delete employee fail" });
            }
        }


    }
}
