using System;
using System.Collections.Generic;
using System.Text;

namespace Me.App.Core.Security;

public interface IDatabaseKeyProvider
{
    Task<string> GetOrGenerateKeyAsync();
}
