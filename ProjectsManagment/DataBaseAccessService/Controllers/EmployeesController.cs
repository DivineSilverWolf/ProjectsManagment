using DataBaseAccessService.Models;
using DataBaseAccessService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DataBaseAccessService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController(ILogger<EmployeesController> logger, EmployeeRepository repository) : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger = logger;
        private readonly EmployeeRepository _repository = repository;

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            try
            {
                _repository.Add(employee);
                return Ok("Employee added successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error adding employee: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPut]
        public IActionResult UpdateEmployee(Employee employee)
        {
            try
            {
                bool updated = _repository.Update(employee);
                if (updated)
                    return Ok("Employee updated successfully");
                else
                    return NotFound("Employee not found");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating employee: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete]
        public IActionResult DeleteEmployee(Employee employee)
        {
            try
            {
                bool deleted = _repository.Delete(employee);
                if (deleted)
                    return Ok("Employee deleted successfully");
                else
                    return NotFound("Employee not found");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting employee: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            try
            {
                IReadOnlyCollection<Employee> employees = _repository.GetAll();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting all employees: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{offset}/{count}")]
        public IActionResult GetEmployees(int offset, int count)
        {
            try
            {
                IEnumerable<Employee> employees = _repository.GetItems(offset, count);
                return Ok(employees);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting employees: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{wordsSearch}")]
        public IActionResult SearchAndGetByWordEmployees(string wordsSearch)
        {
            try
            {
                IEnumerable<Employee> employees = _repository.searchAndGetByWordForItems(wordsSearch);
                return Ok(employees);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting employees for words search: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
