using Me.App.Core.DocumentsAgg;
using Me.App.Core.Security;
using Me.App.Core.UserAgg;
using Me.App.Core.VehicleAggregate;
using Me.App.Infrastructure.Security;
using Me.App.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Me.App.Infrastructure;

public static class ServiceExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "me_vault.db3");

        services.AddSingleton<IDatabaseKeyProvider, SecureKeyProvider>();
        services.AddSingleton<ISecureStorageService, SecureStorageService>();
        services.AddSingleton(sp =>
        {
            var keyProvider = sp.GetRequiredService<IDatabaseKeyProvider>();
            return new MeDataBase(keyProvider, dbPath);
        });
        services.AddSingleton<SecureStorageService>();

        services.AddScoped<IVehicleService, VehicleService>();
        services.AddScoped<IDocumentService, DocumentService>();
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}
