namespace Infoshare.Yarp.Samples.Swagger.SampleWebApp.Extensions;

using Microsoft.OpenApi.Models;

public static class SwaggerConfigurationExtension
{
    /// <summary>
    /// AddSwaggerDocumentation.
    /// </summary>
    /// <param name="services">Services collection.</param>
    /// <returns>Services collection with configured swagger.</returns>
    public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sample Web App 1", Version = "v1" });
        });
        
        return services;
    }
}