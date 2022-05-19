namespace Infoshare.Yarp.Samples.AuthGateway.SampleWebApp.Auth;

using Microsoft.AspNetCore.Authorization;

public class BasicAuthorizationAttribute : AuthorizeAttribute
{
    public BasicAuthorizationAttribute()
    {
        Policy = "BasicAuthentication";
    }
}