namespace P04;

class Program
{
    static List<int> numbers = new List<int>();
    
    static void Main(string[] args)
    {
        List<Thread> threads = new List<Thread>();
        
        for (int i = 1; i <= 5; i++)
        {
            Thread thread = new Thread(AddRandomNumber);
            threads.Add(thread);
            thread.Start();
        }
        
        foreach (Thread thread in threads)
        {
            thread.Join();
        }

        Console.WriteLine("Sum: " + numbers.Sum());
    }
    
    static void AddRandomNumber()
    {
        Random random = new Random();
        int number = random.Next(1, 501);
        numbers.Add(number);
        Console.WriteLine($"Added: {number}");
    }
}