using JobSeekerMiniProject.Database;
using JobSeekerMiniProject.Interfaces;
using JobSeekerMiniProject.Repository;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(); 

//builder.Services.AddDbContext<JobSeekerContext>(options =>
//                options.UseSqlite($"Data Source=C:\\Repos\\JobSeekerMiniProject\\Database\\JobSeekerDB;Cache=Shared"));

builder.Services.AddDbContext<JobSeekerContext>(options =>
                options.UseSqlite());

//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new() { Title = "TodoApi", Version = "v1" });
//});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IJobSeekerRepository, JobSeekerRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
var Configuration = builder.Configuration;

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
