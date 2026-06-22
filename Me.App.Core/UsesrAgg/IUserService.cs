using System;
using System.Collections.Generic;
using System.Text;

namespace Me.App.Core.UserAgg
{
    public interface IUserService
    {
        public Task<User> GetUserAsync(int? userId = null);
        public Task SaveUserAsync(User user);
    }
}
