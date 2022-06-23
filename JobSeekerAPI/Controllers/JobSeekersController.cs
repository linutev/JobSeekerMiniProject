using JobSeekerAPI.Models;
using JobSeekerMiniProject.Database;
using JobSeekerMiniProject.Interfaces;
using JobSeekerMiniProject.Models;
using JobSeekerMiniProject.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobSeekerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobSeekersController : ControllerBase
    {
        private readonly ILogger<JobSeekersController> _logger;
        private readonly IJobSeekerRepository _jobSeekerRepository;

        public JobSeekersController(ILogger<JobSeekersController> logger, IJobSeekerRepository jobSeekerRepository)
        {
            _logger = logger;
            _jobSeekerRepository = jobSeekerRepository;
        }

        [HttpGet(Name = "GetJobSeekers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<JobSeekerViewModel>>> Get()
        {
            try
            {
                return await _jobSeekerRepository.GetJobSeekers();
            }
            catch (KeyNotFoundException)
            {
                _logger.LogError("No job seekers found.");
                return StatusCode(404);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Server error getting job seekers - {ex.Message}");
                return StatusCode(500);
            }
        }
    }
}