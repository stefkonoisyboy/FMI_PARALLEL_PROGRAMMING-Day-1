namespace P05;

class Program
{
    static List<int> maxNumbers = new List<int>();
    
    static void Main(string[] args)
    {
        List<Thread> threads = new List<Thread>();
        
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int partSize = 3;
        double partsCount = Math.Ceiling((double)numbers.Length / partSize);

        for (int i = 0; i < partsCount; i++)
        {
            int[] part = numbers.Skip(i * partSize).Take(partSize).ToArray();
            Thread thread = new Thread(FindMax);
            threads.Add(thread);
            thread.Start(part);  
        }
        
        foreach (Thread thread in threads)
        {
            thread.Join();
        }
        
        int globalMax = maxNumbers.Max();
        Console.WriteLine($"Global Max: {globalMax}");

        Console.WriteLine("End of my console app");
    }
    
    static void FindMax(object obj)
    {
        int[] numbers = (int[])obj;
        int max = numbers.Max();
        Console.WriteLine($"Thread Max: {max}");
        maxNumbers.Add(max);
    }
}