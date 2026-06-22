using System;
using System.Collections.Generic;
using System.Text;

namespace Me.App.Core.Security
{
    public interface ISecureStorageService
    {
        Task<string> GetOrSetValueAsync(string key, Func<Task<string>> valueFactoryAsync);
        Task<string> GetOrSetValueAsync(string key, Func<string> valueFactory);
    }
}
