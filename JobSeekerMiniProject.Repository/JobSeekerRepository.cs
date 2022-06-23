using JobSeekerMiniProject.Database;
using JobSeekerMiniProject.Interfaces;
using JobSeekerMiniProject.Models;
using Microsoft.EntityFrameworkCore;

namespace JobSeekerMiniProject.Repository
{
    public class JobSeekerRepository : IJobSeekerRepository
    {
        //JobSeekerContext _jobSeekerContext = new JobSeekerContext(new DbContextOptions<JobSeekerContext>());
        private readonly JobSeekerContext _jobSeekerContext;

        public JobSeekerRepository(JobSeekerContext jobSeekerContext)
        {
            _jobSeekerContext = jobSeekerContext;
        }

        public async Task<List<JobSeekerViewModel>> GetJobSeekers()
        {
            var result = await _jobSeekerContext.JobSeekers.ToListAsync();
            if (result.Any())
            {
                return result;
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public async Task AddJobSeeker(JobSeekerViewModel model)
        {
            await _jobSeekerContext.JobSeekers.AddAsync(model);
            _jobSeekerContext.SaveChanges();
        }
    }
}