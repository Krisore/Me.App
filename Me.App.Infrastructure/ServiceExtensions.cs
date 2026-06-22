using Microsoft.Extensions.DependencyInjection;

namespace Me.App.Infrastructure;

public static class ServiceExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Add your infrastructure services here
        return services;
    }
}
