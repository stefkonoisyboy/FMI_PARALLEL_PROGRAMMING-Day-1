namespace P02;

class Program
{
    static void Main(string[] args)
    {
        Thread thread = new Thread(PrintName);
        thread.Start("John");
        
        Console.WriteLine("End of my console app");
    }

    static void PrintName(object obj)
    {
        string name = (string)obj;
        Console.WriteLine($"Hello, {name}");
    }
}