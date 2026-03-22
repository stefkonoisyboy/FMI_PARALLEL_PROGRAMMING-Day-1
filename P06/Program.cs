namespace P06;

class Program
{
    static int balance = 1000;
    static object lockObject = new object();
    
    static void Main(string[] args)
    {
        Thread withdrawThread = new Thread(Withdraw);
        Thread depositThread = new Thread(Deposit);

        withdrawThread.Start(100);
        depositThread.Start(200);
        
        withdrawThread.Join();
        depositThread.Join();
        
        // Add as many operations as you want
        
        lock (lockObject)
        {
            Console.WriteLine($"Balance: {balance}");
        }
        
        Console.WriteLine("End of my console app");
    }
    
    static void Withdraw(object obj)
    {
        int amount = (int)obj;

        lock (lockObject)
        {
            balance -= amount;
        }
    }
    
    static void Deposit(object obj)
    {
        int amount = (int)obj;

        lock (lockObject)
        {
            balance += amount;
        }
    }
}