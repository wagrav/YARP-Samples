namespace Infoshare.Yarp.Samples.AuthGateway.ReverseProxy.Auth;

using Microsoft.AspNetCore.Authorization;

public class BasicAuthorizationAttribute : AuthorizeAttribute
{
    public BasicAuthorizationAttribute()
    {
        Policy = "BasicAuthentication";
    }
}