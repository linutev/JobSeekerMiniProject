using JobSeekerMiniProject.Domain.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;

namespace JobSeekerMiniProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<JobSeekerContext>(options => options.UseSqlite(Configuration.GetConnectionString("JobSeekerConnectionString")));
            services.AddControllersWithViews();
        }
    }
}
