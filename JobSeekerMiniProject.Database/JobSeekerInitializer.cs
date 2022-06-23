using System;
namespace JobSeekerMiniProject.Database
{
	public static class DbInitializer
    {
		public static void Initialize(JobSeekerContext context)
		{
            context.Database.EnsureCreated();
        }
	}
}