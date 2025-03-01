using System;
using System.IO;
using System.IO.Pipes;
using System.Threading;

class ChefLogger
{
    static void Main()
    {
        string pipeName = "OrderPipe";

        using (NamedPipeServerStream pipeServer = new NamedPipeServerStream(pipeName, PipeDirection.Out))
        {
            Console.WriteLine("ChefLogger: Waiting for log reader to connect...");
            pipeServer.WaitForConnection(); // Wait for LogReader to connec 
            Console.WriteLine("ChefLogger: Connected to log reader. Writing logs...");

            StreamWriter writer = new StreamWriter(pipeServer);
            writer.AutoFlush = true;

            string[] orders = { "Sushi Platter", "Kung Pao Chicken", "Pad Thai", "Ramen Bowl", "Bibimbap" };
            Random rand = new Random();

            for (int i = 1; i <= 10; i++) // Simulating 10 orders
            {
                string logMessage = $"Order {i} completed: {orders[rand.Next(orders.Length)]}\n";
                Console.WriteLine($"[ChefLogger] Sending log: {logMessage}");
                writer.WriteLine(logMessage);
                Thread.Sleep(1000); // Simulating time between order completions
            }
        }
        Console.WriteLine("ChefLogger: Finished writing logs. Exiting...");
    }
}
