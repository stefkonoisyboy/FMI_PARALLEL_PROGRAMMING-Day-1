namespace P04;

class Program
{
    static List<int> numbers = new List<int>();
    static Random random = new Random();
    
    static object lockObject = new object();
    static object lockRandom = new object();
    
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

        lock (lockObject)
        {
            Console.WriteLine("Sum: " + numbers.Sum());
        }
    }
    
    static void AddRandomNumber()
    {
        int number;
        
        lock (lockRandom)
        {
            number = random.Next(1, 501);
        }
        
        Console.WriteLine($"Added: {number}");
        
        lock (lockObject)
        {
            numbers.Add(number);
        }
    }
}