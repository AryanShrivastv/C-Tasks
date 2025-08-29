using System;
using System.Collections.Generic;

class Program_Collections
{
    static void Main()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\n MENU ");
            Console.WriteLine("1 Nested List ,Print Night reading of Day 3");
            Console.WriteLine("2 Nested Dictionary  , Print readings of a house");
            Console.WriteLine("3 Dictionary with List ,Print meters in an area");
            Console.WriteLine("4 List of Dictionary - Print all complaints");
            Console.WriteLine("5 Exit");
            Console.Write("Choose an option  ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    NestedListTask();
                    break;
                case 2:
                    NestedDictionaryTask();
                    break;
                case 3:
                    DictionaryWithListTask();
                    break;
                case 4:
                    ListOfDictionaryTask();
                    break;
                case 5:
                    exit = true;
                    Console.WriteLine("Exiting program...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    // 1. Nested List

    static void NestedListTask()
    {
        List<List<int>> meterReadings = new List<List<int>>();
        Console.WriteLine("\nEnter readings for 7 days (Morning, Afternoon, Night):");
        for (int day = 0; day < 7; day++)
        {
            List<int> dayReadings = new List<int>();
            Console.WriteLine($"Day {day + 1}:");
            Console.Write(" Morning: ");
            dayReadings.Add(Convert.ToInt32(Console.ReadLine()));
            Console.Write(" Afternoon: ");
            dayReadings.Add(Convert.ToInt32(Console.ReadLine()));
            Console.Write(" Night: ");
            dayReadings.Add(Convert.ToInt32(Console.ReadLine()));
            meterReadings.Add(dayReadings);
        }
        Console.WriteLine("Night reading of Day 3: " + meterReadings[2][2]);
    }

    // 2. Nested Dictionary


    static void NestedDictionaryTask()
    {
        Dictionary<string, Dictionary<string, List<int>>> areaData = new Dictionary<string, Dictionary<string, List<int>>>();

        Console.Write("\nHow many areas? ");
        int areaCount = Convert.ToInt32(Console.ReadLine());

        for (int a = 0; a < areaCount; a++)
        {
            Console.Write($"Enter Area Name {a + 1}: ");
            string areaName = Console.ReadLine();
            areaData[areaName] = new Dictionary<string, List<int>>();

            Console.Write($"How many houses in {areaName}? ");
            int houseCount = Convert.ToInt32(Console.ReadLine());

            for (int h = 0; h < houseCount; h++)
            {
                Console.Write($"Enter House Name {h + 1}: ");
                string houseName = Console.ReadLine();
                areaData[areaName][houseName] = new List<int>();

                Console.WriteLine($"Enter 7 daily readings for {houseName}:");
                for (int d = 0; d < 7; d++)
                {
                    Console.Write($" Day {d + 1}: ");
                    areaData[areaName][houseName].Add(Convert.ToInt32(Console.ReadLine()));
                }
            }
        }

        Console.Write("\nEnter Area to fetch readings: ");
        string selArea = Console.ReadLine();
        Console.Write("Enter House in that area: ");
        string selHouse = Console.ReadLine();

        Console.WriteLine($"Readings for {selHouse} in {selArea}:");
        foreach (var r in areaData[selArea][selHouse])
        {
            Console.Write(r + " ");
        }
        Console.WriteLine();
    }

    // 3. Dictionary with List


    static void DictionaryWithListTask()
    {
        Dictionary<string, List<string>> areaMeters = new Dictionary<string, List<string>>();

        Console.Write("\nHow many areas to enter meters for? ");
        int meterAreaCount = Convert.ToInt32(Console.ReadLine());

        for (int a = 0; a < meterAreaCount; a++)
        {
            Console.Write($"Enter Area Name {a + 1}: ");
            string area = Console.ReadLine();
            areaMeters[area] = new List<string>();

            Console.Write($"How many meters in {area}? ");
            int mCount = Convert.ToInt32(Console.ReadLine());

            for (int m = 0; m < mCount; m++)
            {
                Console.Write($" Enter Meter {m + 1} ID: ");
                areaMeters[area].Add(Console.ReadLine());
            }
        }

        Console.Write("\nEnter Area to list meters: ");
        string selMeterArea = Console.ReadLine();

        Console.WriteLine($"Meters in {selMeterArea}:");
        foreach (var meter in areaMeters[selMeterArea])
        {
            Console.WriteLine(meter);
        }
    }

    // 4. List of Dictionary


    static void ListOfDictionaryTask()
    {
        List<Dictionary<string, string>> complaints = new List<Dictionary<string, string>>();

        Console.Write("\nHow many complaints do you want to enter? ");
        int complaintCount = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < complaintCount; i++)
        {
            Dictionary<string, string> comp = new Dictionary<string, string>();
            Console.WriteLine($"Enter details for Complaint {i + 1}:");

            Console.Write(" House Number: ");
            comp["HouseNumber"] = Console.ReadLine();

            Console.Write(" Meter Number: ");
            comp["MeterNumber"] = Console.ReadLine();

            Console.Write(" Issue: ");
            comp["Issue"] = Console.ReadLine();

            Console.Write(" Date (YYYY-MM-DD): ");
            comp["Date"] = Console.ReadLine();

            complaints.Add(comp);
        }

        Console.WriteLine("\nComplaints List:");
        foreach (var complaint in complaints)
        {
            Console.WriteLine($"House: {complaint["HouseNumber"]}, Meter: {complaint["MeterNumber"]}, Issue: {complaint["Issue"]}, Date: {complaint["Date"]}");
        }
    }
}
