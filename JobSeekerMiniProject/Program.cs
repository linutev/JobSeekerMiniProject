using JobSeekerMiniProject.Database;
using JobSeekerMiniProject.Interfaces;
using JobSeekerMiniProject.Repository;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IJobSeekerRepository, JobSeekerRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//builder.Services.AddDbContext<JobSeekerContext>(options =>
//                options.UseSqlite("Data Source = C:\\Repos\\JobSeekerMiniProject\\Database\\JobSeekerDB; Cache = Shared"));

builder.Services.AddDbContext<JobSeekerContext>(options =>
                options.UseSqlite());

var app = builder.Build();
var Configuration = builder.Configuration;

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<JobSeekerContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred creating the DB.");
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=JobSeeker}/{action=Index}/{id?}");

app.Run();

