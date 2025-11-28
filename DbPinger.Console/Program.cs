using System;
using System.Threading.Tasks;
using DBConnector;
using DbPinger.ConsoleApp.Adapters;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=== MongoDB Pinger REPL ===");
        Console.WriteLine("Type 'exit' at any time to quit.");
        Console.WriteLine();

        while (true)
        {
            Console.Write("Enter MongoDB connection string: ");
            string conn = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(conn) || conn.ToLower() == "exit")
                break;

            var pinger = new MongoPinger();

            Console.WriteLine("Attempting ping...");

            var (success, message) = await pinger.PingAsync(conn);

            Console.WriteLine(success ? $"✅ SUCCESS: {message}" : $"❌ FAILURE: {message}");
            Console.WriteLine();
        }

        Console.WriteLine("Goodbye!");
    }
}
