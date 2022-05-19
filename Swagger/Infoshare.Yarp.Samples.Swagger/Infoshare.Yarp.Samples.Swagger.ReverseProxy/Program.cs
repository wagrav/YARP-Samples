using Infoshare.Yarp.Samples.Swagger.ReverseProxy.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"))
    .AddCustomGlobalTransformations();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    // app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.RoutePrefix = "";
        options.SwaggerEndpoint("/sample-web-app-1/swagger/v1/swagger.json", "#1 Sample Web API");
        options.SwaggerEndpoint("/sample-web-app-2/swagger/v1/swagger.json", "#2 Sample Web API");
    });
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapReverseProxy();

app.Run();