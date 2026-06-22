using System;
using System.Collections.Generic;
using System.Text;

using System;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;
using Me.App.Core.Security;

namespace Me.App.Infrastructure.Security
{
    // Keeping it internal sealed as requested, but make sure your DI container can register it!
    internal sealed class SecureStorageService : ISecureStorageService
    {
        /// <summary>
        /// Retrieves a value from SecureStorage. If it doesn't exist, executes the async factory, 
        /// saves the result, and returns it.
        /// </summary>
        public async Task<string> GetOrSetValueAsync(string key, Func<Task<string>> valueFactoryAsync)
        {
            var existingValue = await SecureStorage.Default.GetAsync(key);

            if (!string.IsNullOrEmpty(existingValue))
            {
                return existingValue; 
            }

            var newValue = await valueFactoryAsync();
            await SecureStorage.Default.SetAsync(key, newValue);

            return newValue;
        }

        /// <summary>
        /// Retrieves a value from SecureStorage. If it doesn't exist, executes the synchronous factory, 
        /// saves the result, and returns it.
        /// </summary>
        public async Task<string> GetOrSetValueAsync(string key, Func<string> valueFactory)
        {
            var existingValue = await SecureStorage.Default.GetAsync(key);

            if (!string.IsNullOrEmpty(existingValue))
            {
                return existingValue;
            }

            var newValue = valueFactory();

            await SecureStorage.Default.SetAsync(key, newValue);

            return newValue;
        }
    }
}
