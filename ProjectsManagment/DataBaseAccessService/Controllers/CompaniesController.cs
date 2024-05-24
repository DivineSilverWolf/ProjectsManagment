using DataBaseAccessService.Models;
using DataBaseAccessService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DataBaseAccessService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController(ILogger<CompaniesController> logger, CompanyRepository repository) : ControllerBase
    {
        private readonly ILogger<CompaniesController> _logger = logger;
        private readonly CompanyRepository _repository = repository;

        [HttpPost] public IActionResult AddCompany(Company company) 
        { try 
            { 
                _repository.Add(company); 
                return Ok("Company added successfully"); 
            } 
            catch (Exception ex) 
            {
                _logger.LogError($"Error adding company: {ex.Message}"); 
                return StatusCode(500, "Internal server error"); 
            } 
        }
        [HttpPut]
        public IActionResult UpdateCompany(Company company)
        {
            try
            {
                bool updated = _repository.Update(company);
                if (updated)
                    return Ok("Company updated successfully");
                else
                    return NotFound("Company not found");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating company: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete]
        public IActionResult DeleteCompany(Company company)
        {
            try
            {
                bool deleted = _repository.Delete(company);
                if (deleted)
                    return Ok("Company deleted successfully");
                else
                    return NotFound("Company not found");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting company: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public IActionResult GetAllCompanies()
        {
            try
            {
                IReadOnlyCollection<Company> companies = _repository.GetAll();
                return Ok(companies);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting all companies: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{offset}/{count}")]
        public IActionResult GetCompanies(int offset, int count)
        {
            try
            {
                IEnumerable<Company> companies = _repository.GetItems(offset, count);
                return Ok(companies);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting companies: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
