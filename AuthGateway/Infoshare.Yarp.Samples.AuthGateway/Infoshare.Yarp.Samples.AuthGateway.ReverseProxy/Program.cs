using Infoshare.Yarp.Samples.AuthGateway.ReverseProxy.Auth;
using Infoshare.Yarp.Samples.AuthGateway.ReverseProxy.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"))
    .AddCustomGlobalTransformations();


builder
    .Services
    .AddAuthentication()
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", options => { });

builder
    .Services
    .AddAuthorization(options =>
    {
        options.AddPolicy("BasicAuthentication",
            new AuthorizationPolicyBuilder("BasicAuthentication").RequireAuthenticatedUser().Build());
    });


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

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.MapReverseProxy();

app.Run();