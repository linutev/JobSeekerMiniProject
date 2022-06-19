using System;
using JobSeekerMiniProject.Models;
using Microsoft.EntityFrameworkCore;

namespace JobSeekerMiniProject.Domain.Data
{
	public class JobSeekerContext : DbContext
	{
		public DbSet<JobSeekerViewModel> JobSeekers { get; set; }

		public JobSeekerContext(DbContextOptions<JobSeekerContext> options) : base(options)
        {
			Database.EnsureCreated();
        }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite(@"Data Source=JobSeekerDB;Cache=Shared");
		}
	}
}

