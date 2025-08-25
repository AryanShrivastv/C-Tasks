using System;

enum Days { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }

class SmartMeterStats
{
    static void Main()
    {
        int[] units = new int[7];
        Console.WriteLine("Enter units consumed for 7 days (Mon-Sun):");

        for (int i = 0; i < 7; i++)
        {
            Console.Write($"{(Days)i}: ");
            units[i] = Convert.ToInt32(Console.ReadLine());
        }

        int total = 0, max = units[0], maxDayIndex = 0;

        for (int i = 0; i < 7; i++)
        {
            total += units[i];
            if (units[i] > max)
            {
                max = units[i];
                maxDayIndex = i;
            }
        }

        double average = (double)total / 7;

        Console.WriteLine("\n--- Weekly Consumption Report ---");
        Console.WriteLine("Total units: " + total);
        Console.WriteLine("Average units/day: " + average.ToString("0.00"));
        Console.WriteLine($"Highest consumption: {(Days)maxDayIndex} ({max} units)");
    }
}
