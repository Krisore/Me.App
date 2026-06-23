using Me.App.Core.VehicleAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Me.App.Infrastructure.Services
{
    internal sealed class VehicleService(MeDataBase meDataBase) : IVehicleService
    {
        private readonly MeDataBase _meDataBase = meDataBase;
        public async Task SaveVehicleAsync(Vehicle vehicle)
        {
            var db = await _meDataBase.GetConnectionAsync();
            await db.InsertAsync(vehicle);
        }
        public async Task<List<Vehicle>> GetVehiclesAsync()
        {
            var _db = await _meDataBase.GetConnectionAsync();
            return await _db!.Table<Vehicle>()
                             .OrderByDescending(d => d.UpdatedAt)
                             .ToListAsync();
        }



        public async Task<Vehicle?> GetVehicleByIdAsync(int vehicleId)
        {
            var _db = await _meDataBase.GetConnectionAsync();
            return await _db!.Table<Vehicle>()
                             .Where(v => v.Id == vehicleId)
                             .FirstOrDefaultAsync();
        }
    }
}
