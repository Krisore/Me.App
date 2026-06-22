using Me.App.Core.DocumentsAgg;
using Me.App.Core.Security;
using Me.App.Core.UserAgg;
using Me.App.Infrastructure.Security;
using Me.App.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Me.App.Infrastructure;

public static class ServiceExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        string dbPath = Path.Combine(Microsoft.Maui.Storage.FileSystem.AppDataDirectory, "me_vault.db3");



        services.AddSingleton<IDatabaseKeyProvider, SecureKeyProvider>();
        services.AddSingleton<ISecureStorageService, SecureStorageService>();
        services.AddSingleton<MeDataBase>(sp =>
        {
            var keyProvider = sp.GetRequiredService<IDatabaseKeyProvider>();
            return new MeDataBase(keyProvider, dbPath);
        });
        services.AddSingleton<Security.SecureStorageService>();


        services.AddScoped<IDocumentService, DocumentService>();
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}
