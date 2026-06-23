using System;
using System.Collections.Generic;
using System.Text;

namespace Me.App.Core.VehicleAggregate
{
    public interface IVehicleService
    {
        Task SaveVehicleAsync(Vehicle vehicle);
        Task<List<Vehicle>> GetVehiclesAsync();
        Task<Vehicle?> GetVehicleByIdAsync(int vehicleId);
    }
}
