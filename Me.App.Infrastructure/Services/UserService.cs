using Me.App.Core.UserAgg;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Me.App.Infrastructure.Services
{
    internal sealed class UserService(MeDataBase meDataBase) : IUserService
    {
        private readonly MeDataBase _meDataBase = meDataBase;

        public async Task<User> GetUserAsync(int? userId = null)
        {
            var db = await _meDataBase.GetConnectionAsync();

            if (userId.HasValue)
            {
                return await db.Table<User>().FirstOrDefaultAsync(u => u.Id == userId.Value);
            }
            return await db.Table<User>().FirstOrDefaultAsync();
        }

        public async Task SaveUserAsync(User user)
        {
            var db = await _meDataBase.GetConnectionAsync();
            var existingProfile = await GetUserAsync(user.Id);

            if (existingProfile == null)
            {
                user.CreatedAt = DateTime.UtcNow;
                user.UpdatedAt = DateTime.UtcNow;
                await db.InsertAsync(user);
            }
            else
            {
                user.Id = existingProfile.Id;
                user.UpdatedAt = DateTime.UtcNow;
                await db.UpdateAsync(user);
            }
        }
    }
}
