using JobSeekerMiniProject.Domain.Data;
using JobSeekerMiniProject.Interfaces;
using JobSeekerMiniProject.Models;
using Microsoft.EntityFrameworkCore;

namespace JobSeekerMiniProject.Repository
{
    public class JobSeekerRepository : IJobSeekerRepository
    {
        private readonly JobSeekerContext _jobSeekerContext;

        public JobSeekerRepository (JobSeekerContext jobSeekerContext)
        {
            _jobSeekerContext = jobSeekerContext;   
        }

        public async Task<List<JobSeekerViewModel>> GetJobSeekers()
        {
            var result = await _jobSeekerContext.JobSeekers.ToListAsync();
            if (result.Any())
            {
                return await _jobSeekerContext.JobSeekers.ToListAsync();
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }
    }
}