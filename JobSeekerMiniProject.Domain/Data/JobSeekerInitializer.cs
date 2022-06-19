using System;
namespace JobSeekerMiniProject.Domain.Data
{
	public static class DbInitializer
    {
		public static void Initialize(JobSeekerContext context)
		{
            context.Database.EnsureCreated();
        }
	}
}