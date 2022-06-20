using JobSeekerMiniProject.Interfaces;
using JobSeekerMiniProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobSeekerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobSeekerAPIController : ControllerBase
    {
        private IJobSeekerRepository _repository;
        private readonly ILogger<JobSeekerAPIController> _logger;

        public JobSeekerAPIController(ILogger<JobSeekerAPIController> logger, IJobSeekerRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet(Name = "JobSeeker")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<JobSeekerViewModel>>> Get()
        {
            try
            {
                return await _repository.GetJobSeekers();
            }
            catch (KeyNotFoundException)
            {
                _logger.LogError($"No job seekers found.");
                return StatusCode(404);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Internal server error getting all job seekers - {ex.Message}");
                return StatusCode(500);
            }
        }
    }
}