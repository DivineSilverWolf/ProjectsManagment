using DataBaseAccessService.Models;
using DataBaseAccessService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataBaseAccessService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesProjectsController(ILogger<EmployeesProjectsController> logger, EmployeeProjectRepository repository) : ControllerBase
    {
        private readonly ILogger<EmployeesProjectsController> _logger = logger;
        private readonly EmployeeProjectRepository _repository = repository;

        [HttpPost]
        public IActionResult AddEmployeeProject(EmployeeProject employeeProject)
        {
            try
            {
                _repository.Add(employeeProject);
                return Ok("EmployeeProject added successfully");
            }
            catch (DbUpdateException ex)
            {
                // Обработка исключения
                var innerException = ex.InnerException;
                while (innerException != null)
                {
                    _logger.LogError($"Error adding employee_project: {innerException.Message}");

                    innerException = innerException.InnerException;
                }
                return StatusCode(500, "Internal server error");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error adding employee_project: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPut]
        public IActionResult UpdateEmployeeProject(EmployeeProject employeeProject)
        {
            try
            {
                bool updated = _repository.Update(employeeProject);
                if (updated)
                    return Ok("EmployeeProject updated successfully");
                else
                    return NotFound("EmployeeProject not found");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating employee_project: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete]
        public IActionResult DeleteEmployeeProject(EmployeeProject employeeProject)
        {
            try
            {
                bool deleted = _repository.Delete(employeeProject);
                if (deleted)
                    return Ok("EmployeeProject deleted successfully");
                else
                    return NotFound("EmployeeProject not found");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting employee_project: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public IActionResult GetAllEmployeesProjects()
        {
            try
            {
                IReadOnlyCollection<EmployeeProject> employeesProjects = _repository.GetAll();
                return Ok(employeesProjects);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting all employees_projects: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{offset}/{count}")]
        public IActionResult GetEmployeesProjects(int offset, int count)
        {
            try
            {
                IEnumerable<EmployeeProject> employeesProjects = _repository.GetItems(offset, count);
                return Ok(employeesProjects);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting employees_projects: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}