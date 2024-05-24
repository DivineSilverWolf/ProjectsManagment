using DataBaseAccessService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DataBaseAccessService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController(ILogger<EmployeesController> logger, TaskRepository repository) : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger = logger;
        private readonly TaskRepository _repository = repository;

        [HttpPost]
        public IActionResult AddTask(Models.Task task)
        {
            try
            {
                _repository.Add(task);
                return Ok("Task added successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error adding task: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPut]
        public IActionResult UpdateTask(Models.Task task)
        {
            try
            {
                bool updated = _repository.Update(task);
                if (updated)
                    return Ok("Task updated successfully");
                else
                    return NotFound("Task not found");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating task: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete]
        public IActionResult DeleteTask(Models.Task task)
        {
            try
            {
                bool deleted = _repository.Delete(task);
                if (deleted)
                    return Ok("Task deleted successfully");
                else
                    return NotFound("Task not found");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting task: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            try
            {
                IReadOnlyCollection<Models.Task> task = _repository.GetAll();
                return Ok(task);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting all tasks: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{offset}/{count}")]
        public IActionResult GetTasks(int offset, int count)
        {
            try
            {
                IEnumerable<Models.Task> employees = _repository.GetItems(offset, count);
                return Ok(employees);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting tasks: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
