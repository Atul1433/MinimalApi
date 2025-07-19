using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace UserManagementAPI.Extensions;

public static class SwaggerExtension
{
    public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Minimal API",
                Version = "v1",
                Description = "Showing how you can build minimal API with .NET"
            });
        });

        return services;
    }
}
