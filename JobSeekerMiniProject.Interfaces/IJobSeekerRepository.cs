using JobSeekerMiniProject.Models;

namespace JobSeekerMiniProject.Interfaces
{
    public interface IJobSeekerRepository
    {
        Task<List<JobSeekerViewModel>> GetJobSeekers();
    }
}