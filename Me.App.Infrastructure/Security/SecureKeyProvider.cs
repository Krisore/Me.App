using Me.App.Core.Security; // Ensure you have a project reference to Core
using Microsoft.Maui.Storage;
using System.Security.Cryptography;

namespace Me.App.Infrastructure.Security;

public sealed class SecureKeyProvider : IDatabaseKeyProvider
{
    private const string KeyName = "MeVaultDatabaseKey";
    private readonly ISecureStorageService _secureStorageService;

    public SecureKeyProvider(ISecureStorageService secureStorageService)
    {
        _secureStorageService = secureStorageService;
    }

    public async Task<string> GetOrGenerateKeyAsync()
    {
        return await _secureStorageService.GetOrSetValueAsync(KeyName, () =>
        {
            var keyBytes = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(keyBytes);
            }
            return Convert.ToBase64String(keyBytes);
        });
    }
}