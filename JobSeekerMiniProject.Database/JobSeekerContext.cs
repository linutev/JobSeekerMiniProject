using JobSeekerMiniProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JobSeekerMiniProject.Database
{
    public class JobSeekerContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public JobSeekerContext(DbContextOptions<JobSeekerContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string workingDirectory = Directory.GetParent(Environment.CurrentDirectory).FullName;
            var connectionString = _configuration.GetConnectionString("JobSeekerConnectionString");
            var paths = connectionString.Split('=');
            var exactConnectionString = paths[0] + "=" + workingDirectory + paths[1] + "=" + paths[2];
            //optionsBuilder.UseSqlite(@"Data Source=C:\\Repos\\JobSeekerMiniProject\\Database\\JobSeekerDB;Cache=Shared");
            optionsBuilder.UseSqlite(exactConnectionString);
        }

        public DbSet<JobSeekerViewModel> JobSeekers { get; set; }
    }
}
