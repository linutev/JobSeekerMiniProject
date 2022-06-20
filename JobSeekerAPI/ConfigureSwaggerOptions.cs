using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace JobSeekerAPI
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiVersionDescriptionProvider provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) =>
          this.provider = provider;

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(
                  description.GroupName, new OpenApiInfo
                  {
                      Title = $"Job Seeker API {description.ApiVersion}", // Name of your API
                      Version = description.ApiVersion.ToString(),
                      Description = "This API is used to retrieve job seeker data", //Add the description of your API here
                      Contact = new OpenApiContact
                      {
                          Name = "Your team name", // Your team name
                          Email = "" //Your team email address
                      }
                  });
            }
        }
    }
}
