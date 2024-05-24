using DataBaseAccessService.Models;
using DataBaseAccessService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataBaseAccessService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController(ILogger<ProjectsController> logger, ProjectRepository repository) : ControllerBase
    {
        private readonly ILogger<ProjectsController> _logger = logger;
        private readonly ProjectRepository _repository = repository;
        [HttpPost]
        public IActionResult AddProject(Project project)
        {
            try
            {
                _repository.Add(project);
                return Ok("Project added successfully");
            }
            catch (DbUpdateException ex)
            {
                // Обработка исключения
                var innerException = ex.InnerException;
                while (innerException != null)
                {
                    _logger.LogError($"Error adding project: {innerException.Message}");

                   innerException = innerException.InnerException;
                }
                return StatusCode(500, "Internal server error");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error adding project: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPut]
        public IActionResult UpdateProject(Project project)
        {
            try
            {
                bool updated = _repository.Update(project);
                if (updated)
                    return Ok("Project updated successfully");
                else
                    return NotFound("Project not found");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating project: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete]
        public IActionResult DeleteProject(Project project)
        {
            try
            {
                bool deleted = _repository.Delete(project);
                if (deleted)
                    return Ok("Project deleted successfully");
                else
                    return NotFound("Project not found");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting project: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public IActionResult GetAllProjects()
        {
            try
            {
                IReadOnlyCollection<Project> projects = _repository.GetAll();
                return Ok(projects);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting all projects: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{offset}/{count}")]
        public IActionResult GetProjects(int offset, int count)
        {
            try
            {
                IEnumerable<Project> projects = _repository.GetItems(offset, count);
                return Ok(projects);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting projects: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}