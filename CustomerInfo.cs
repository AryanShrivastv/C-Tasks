using System;

public class Customer
{
    public int CustomerID { get; set; }
    public string Name { get; set; }
    public int UnitsConsumed { get; set; }

    
    public Customer(int id, string name, int units)
    {
        CustomerID = id;
        Name = name;
        UnitsConsumed = units;
    }

   
    public int CalculateBill()
    {
        return UnitsConsumed * 5;
    }

    public void ShowBill()
    {
        Console.WriteLine($"Customer: {Name} (ID: {CustomerID})");
        Console.WriteLine($"Units Consumed: {UnitsConsumed}");
        Console.WriteLine($"Total Bill: ${CalculateBill()}");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter Customer ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Units Consumed: ");
        int units = Convert.ToInt32(Console.ReadLine());

        Customer c = new Customer(id, name, units);
        c.ShowBill();
    }
}
