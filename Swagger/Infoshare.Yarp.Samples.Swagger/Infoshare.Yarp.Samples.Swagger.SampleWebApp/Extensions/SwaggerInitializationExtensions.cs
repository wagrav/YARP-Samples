namespace Infoshare.Yarp.Samples.Swagger.SampleWebApp.Extensions;

using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

public static class SwaggerInitializationExtensions
{
    /// <summary>
    /// Register the Swagger middleware with optional setup action for DI-injected options.
    /// </summary>
    /// <param name="app">Application builder.</param>
    /// <param name="logger">Logger.</param>
    public static void UseCustomizedSwagger(this IApplicationBuilder app)
    {
        app.UseSwagger(c =>
        {
            c.AddReverseProxySupport();
        });
    }

    private static void AddReverseProxySupport(this SwaggerOptions c)
    {
        c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
        {
            try
            {
                if (httpReq.Headers.ContainsKey("X-Forwarded-Host"))
                {
                    var serverUrl =
                        $"{httpReq.Headers["X-Forwarded-Proto"]}://" +
                        $"{httpReq.Headers["X-Forwarded-Host"]}/" +
                        $"{httpReq.Headers["X-Forwarded-BasePath"]}/";
                    swaggerDoc.Servers.Add(new OpenApiServer { Url = serverUrl });
                }
            }
            catch (Exception e)
            {
                // handle exception here
                throw;
            }
        });
    }
}