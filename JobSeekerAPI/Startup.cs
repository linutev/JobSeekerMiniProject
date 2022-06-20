using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.EntityFrameworkCore;
using JobSeekerMiniProject.Interfaces;
using JobSeekerMiniProject.Repository;
using JobSeekerMiniProject.Domain.Data;
using Microsoft.AspNetCore.Mvc;

namespace JobSeekerAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Versioning
            //services.AddApiVersioning(o =>
            //{
            //    o.ReportApiVersions = true;
            //    o.AssumeDefaultVersionWhenUnspecified = true;
            //    o.DefaultApiVersion = new ApiVersion(1, 0);
            //});

            //services.AddVersionedApiExplorer(options =>
            //{
            //    options.GroupNameFormat = "'v'VVV";
            //    options.SubstituteApiVersionInUrl = true;
            //});

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            //services.AddSwaggerGen(c =>
            //{
            //    // Set the comments path for the Swagger JSON and UI.
            //    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            //    c.IncludeXmlComments(xmlPath);
            //    c.CustomOperationIds(e => $"{e.ActionDescriptor.RouteValues["controller"]}_{ e.HttpMethod}");
            //});

            services.AddSwaggerGen();
            services.AddMvcCore().AddApiExplorer();

            //EF setup
            services.AddDbContext<JobSeekerContext>(options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("JobSeekerConnectionString")));

            //Setup config
            IConfiguration config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", true, true)
               .Build();

            //Setup DI
            services.AddTransient<IJobSeekerRepository, JobSeekerRepository>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            app.UseSwaggerUI();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            //app.UseSwaggerUI(
            //      options =>
            //      {
            //          foreach (var description in provider.ApiVersionDescriptions)
            //          {
            //              options.SwaggerEndpoint(
            //                  $"/swagger/{description.GroupName}/swagger.json",
            //                  description.GroupName.ToUpperInvariant());
            //          }
            //      });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
