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
        Console.Write("Enter Residential Meter ID: ");
        int rId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Residential Customer Name: ");
        string rName = Console.ReadLine();

        Console.Write("Enter House Type: ");
        string houseType = Console.ReadLine();

        ResidentialMeter r = new ResidentialMeter { MeterId = rId, CustomerName = rName, HouseType = houseType };

        Console.Write("Enter Commercial Meter ID: ");
        int cId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Commercial Customer Name: ");
        string cName = Console.ReadLine();

        Console.Write("Enter Business Type: ");
        string businessType = Console.ReadLine();

        CommercialMeter c = new CommercialMeter { MeterId = cId, CustomerName = cName, BusinessType = businessType };

        r.ShowDetails();
        c.ShowDetails();
    }
}
