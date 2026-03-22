namespace P01;

class Program
{
    static void Main(string[] args)
    {
        Thread thread = new Thread(PrintCurrentTime);
        thread.Start();

        Console.WriteLine("End of my console app");
    }
    
    static void PrintCurrentTime()
    {
        Console.WriteLine(DateTime.UtcNow.ToString("HH:mm:ss"));
    }
}