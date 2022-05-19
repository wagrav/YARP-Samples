namespace Infoshare.Yarp.Samples.Swagger.ReverseProxy.Extensions;

using global::Yarp.ReverseProxy.Transforms;

public static class YarpBuilderExtensions
{
    public static void AddCustomGlobalTransformations(this IReverseProxyBuilder builder)
    {
        builder.AddTransforms(x =>
        {
            // without this transformation YARP redirects from /x/y/z to %252fx%252f%252fz
            // https://github.com/microsoft/reverse-proxy/issues/1419
            // https://github.com/dotnet/aspnetcore/issues/30655
            // task #228172 was created to investigate
            x.AddRequestTransform(transformContext =>
            {
                transformContext.Path = transformContext.Path.Value.Replace("%2F", "/");
                return default(System.Threading.Tasks.ValueTask);
            });
        });
    }
}