using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Me.App.Core.VehicleAggregate
{
    public class MaintenanceTask
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int VehicleId { get; set; } 

        public string TaskName { get; set; } = string.Empty; 

        public double IntervalDistance { get; set; } 
        public double LastCompletedOdometer { get; set; }

        [Ignore]
        public double NextDueOdometer => LastCompletedOdometer + IntervalDistance;

        public bool IsDue(double currentVehicleOdometer)
        {
            return currentVehicleOdometer >= NextDueOdometer;
        }
    }
}
