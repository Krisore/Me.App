using Me.App.Core.DocumentsAgg;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Me.App.Core.VehicleAggregate;

public class Vehicle
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;

    public string Name { get; set; }
    public string Nickname { get; set; } = string.Empty;
    public string PlateNumber { get; set; } = string.Empty;
    public string SerialOrVinNumber { get; set; } = string.Empty;
    public double CurrentOdometer { get; set; }
    public string DistanceUnit { get; set; } = "km";


    public DateTime BoughtDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public string PrimaryColor { get; set; } = "#000000"; // default black 
    public string SecondaryColor { get; set; } = "#FFFFFF"; // default white
    public string AccentColor { get; set; } = "#FF0000"; // default red

    public Vehicle()
    {

    }
    public Vehicle(string brand, string name, string nickname, string plateNumber, string serialOrVinNumber, double currentOdometer, DateTime boughtDate)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException("Name cannot be null or empty if nickname is not provided.");


        Brand = brand;
        Name = name;

        Nickname = nickname;
        PlateNumber = plateNumber;
        SerialOrVinNumber = serialOrVinNumber;
        CurrentOdometer = currentOdometer;
        CreatedAt = DateTime.UtcNow;
        BoughtDate = boughtDate;
    }

    [Ignore]
    public List<MaintenanceTask> Tasks { get; set; } = [];

    [Ignore]
    public List<Document> Documents { get; set; } = []; // for OR/CR and other vehicle-related documents

    public void UpdateColorScheme(string primaryColor, string secondaryColor, string accentColor)
    {
        PrimaryColor = primaryColor;
        SecondaryColor = secondaryColor;
        AccentColor = accentColor;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateNickname(string newNickname)
    {
        Nickname = newNickname;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdatePlateNumber(string newPlateNumber)
    {
        PlateNumber = newPlateNumber;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateSerialOrVinNumber(string newSerialOrVinNumber)
    {
        SerialOrVinNumber = newSerialOrVinNumber;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateDistanceUnit(string newDistanceUnit)
    {
        DistanceUnit = newDistanceUnit;
        UpdatedAt = DateTime.UtcNow;
    }


    public void UpdateBoughtDate(DateTime newBoughtDate)
    {
        BoughtDate = newBoughtDate;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateOdometer(double newOdometer, bool overrideOdometer = false)
    {
        if (!overrideOdometer && newOdometer < CurrentOdometer)
            throw new ArgumentException("New odometer reading cannot be less than the current reading.");


        CurrentOdometer = newOdometer;
        UpdatedAt = DateTime.UtcNow;
    }


    public void AddMaintenanceTask(MaintenanceTask task)
    {
        Tasks.Add(task);
    }

    public void RemoveMaintenanceTask(MaintenanceTask task)
    {
        Tasks.Remove(task);
    }

    public void AttachDocument(Document document)
    {
        Documents.Add(document);
    }

    public void RemoveDocument(Document document)
    {
        Documents.Remove(document);
    }
}
