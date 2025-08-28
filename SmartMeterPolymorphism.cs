using System;

public abstract class MeterReading
{
    public int Units { get; set; }
    public abstract int CalculateBill();
}

public class ResidentialReading : MeterReading
{
    public override int CalculateBill()
    {
        return Units * 5;
    }
}

public class CommercialReading : MeterReading
{
    public override int CalculateBill()
    {
        return Units * 8;
    }
}

class Program_Q3
{
    static void Main()
    {
        Console.Write("Enter Residential units: ");
        int rUnits = Convert.ToInt32(Console.ReadLine());
        ResidentialReading r = new ResidentialReading { Units = rUnits };
        Console.WriteLine("Residential Bill = " + r.CalculateBill());

        Console.Write("Enter Commercial units: ");
        int cUnits = Convert.ToInt32(Console.ReadLine());
        CommercialReading c = new CommercialReading { Units = cUnits };
        Console.WriteLine("Commercial Bill = " + c.CalculateBill());
    }
}
