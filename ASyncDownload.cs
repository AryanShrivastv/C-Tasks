using System;
using System.Threading.Tasks;

class ASyncDownload
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Downloading task,Sit tight!!");
        await Download();
        Console.WriteLine("Downloaded");
    }

    static async Task Download()
    {
        await Task.Delay(5000);
        
    }
}
