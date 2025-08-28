using System;

public class SmartMeter
{
    public int MeterId { get; set; }
    public string CustomerName { get; set; }
}

public class ResidentialMeter : SmartMeter
{
    public string HouseType { get; set; }

    public void ShowDetails()
    {
        Console.WriteLine($"Residential Meter -> ID: {MeterId}, Name: {CustomerName}, HouseType: {HouseType}");
    }
}

public class CommercialMeter : SmartMeter
{
    public string BusinessType { get; set; }

    public void ShowDetails()
    {
        Console.WriteLine($"Commercial Meter -> ID: {MeterId}, Name: {CustomerName}, BusinessType: {BusinessType}");
    }
}

class Program_Q1
{
    static void Main()
    {
        ResidentialMeter r = new ResidentialMeter { MeterId = 201, CustomerName = "Alice", HouseType = "Apartment" };
        CommercialMeter c = new CommercialMeter { MeterId = 301, CustomerName = "Bob", BusinessType = "Shop" };

        r.ShowDetails();
        c.ShowDetails();
    }
}
