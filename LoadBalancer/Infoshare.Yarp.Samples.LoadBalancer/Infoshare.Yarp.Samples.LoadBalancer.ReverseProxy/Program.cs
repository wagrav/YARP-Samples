using Infoshare.Yarp.Samples.LoadBalancer.ReverseProxy.Extensions;

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
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapReverseProxy();

app.Run();