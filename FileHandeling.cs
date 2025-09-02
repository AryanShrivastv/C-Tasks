using System;
using System.IO;

class FileHandling
{
    public static void Main(string[] args)
    {
        string PathF = @"C:\Users\AryanShrivastva\Desktop\Task1.txt";

        if (!File.Exists(PathF))
        {
            File.Create(PathF).Close();
        }

        Console.WriteLine("Enter the number of entries you want to make: ");
        int entries = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"Enter {entries} lines of text:");

        for (int i = 0; i < entries; i++)
        {
            string input = Console.ReadLine();
            File.AppendAllText(PathF, input + Environment.NewLine);
        }

        Console.WriteLine("Data written successfully to " + PathF);
        Console.WriteLine("\nReading file content:\n");

        using (StreamReader sr = new StreamReader(PathF))
        {
            string colours;
            while ((colours = sr.ReadLine()) != null)
            {
                Console.WriteLine(colours);
            }
        }
    }
}
