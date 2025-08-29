using System;
using System.Collections.Generic;

public enum MeterStatus { Active, Inactive, Fault }

public struct Reading
{
    public DateTime Date { get; set; }
    public int Units { get; set; }

    public Reading(DateTime date, int units)
    {
        Date = date;
        Units = units;
    }
}

public abstract class Notifier
{
    public abstract void SendMessage(string msg);
}

public class SmsNotifier : Notifier
{
    private string phone;
    public SmsNotifier(string phone) => this.phone = phone;
    public override void SendMessage(string msg)
    {
        Console.WriteLine($"[SMS to {phone}] {msg}");
    }
}

public class EmailNotifier : Notifier
{
    private string email;
    public EmailNotifier(string email) => this.email = email;
    public override void SendMessage(string msg)
    {
        Console.WriteLine($"[Email to {email}] {msg}");
    }
}

public static class Tariff
{
    public static int RatePerUnit = 5;
}

public sealed class BillCalculator
{
    public static int CalculateBill(int units)
    {
        return units * Tariff.RatePerUnit;
    }
}

public partial class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; }
}

public partial class Customer
{
    public string? Email { get; set; }
    public string? Phone { get; set; }
}

public class Meter
{
    public int MeterId { get; set; }
    public MeterStatus Status { get; set; }

    public class ReadingHistory
    {
        private List<Reading> readings = new List<Reading>();
        public IEnumerable<Reading> GetReadings() => readings;

        public void AddReading(Reading r)
        {
            readings.Add(r);
            OnReadingAdded?.Invoke(r);
        }

        public event Action<Reading> OnReadingAdded;
    }
}

class Program_Final
{
    static void Main()
    {
        Console.Write("Enter Customer ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Customer Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Email (or press Enter to skip): ");
        string email = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(email)) email = null;

        Console.Write("Enter Phone (or press Enter to skip): ");
        string phone = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(phone)) phone = null;

        Customer customer = new Customer { CustomerId = id, Name = name, Email = email, Phone = phone };

        Console.Write("Enter Meter ID: ");
        int meterId = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Select Meter Status (0=Active, 1=Inactive, 2=Fault): ");
        int statusChoice = Convert.ToInt32(Console.ReadLine());
        Meter meter = new Meter { MeterId = meterId, Status = (MeterStatus)statusChoice };

        Meter.ReadingHistory history = new Meter.ReadingHistory();

        history.OnReadingAdded += (reading) =>
        {
            string message = $"New reading added: {reading.Units} units on {reading.Date.ToShortDateString()}";
            Notifier notifier = (customer.Email != null) ? new EmailNotifier(customer.Email) : new SmsNotifier(customer.Phone!);
            notifier.SendMessage(message);
        };

        Console.Write("How many readings do you want to enter? ");
        int count = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            Console.Write($"Enter units for Reading {i + 1}: ");
            int units = Convert.ToInt32(Console.ReadLine());
            history.AddReading(new Reading(DateTime.Now, units));
        }

        int totalUnits = 0;
        foreach (var r in history.GetReadings())
        {
            totalUnits += r.Units;
        }

        int bill = BillCalculator.CalculateBill(totalUnits);
        Console.WriteLine($"\nFinal Bill for {customer.Name}: {bill} (Units: {totalUnits}, Rate: {Tariff.RatePerUnit})");
    }
}
