namespace P03;

class Program
{
    static void Main(string[] args)
    {
        List<Thread> threads = new List<Thread>();
        
        for (int i = 1; i <= 5; i++)
        {
            Thread thread = new Thread(PrintNumber);
            threads.Add(thread);
            thread.Start(i);
        }
        
        foreach (Thread thread in threads)
        {
            thread.Join();
        }

        Console.WriteLine("End of my console app");
    }

    static void PrintNumber(object obj)
    {
        int number = (int)obj;
        Console.WriteLine(number);
    }
}