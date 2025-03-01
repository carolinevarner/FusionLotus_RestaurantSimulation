using System;
using System.IO;
using System.IO.Pipes;
using System.Threading;

class ChefLogger
{
    static void Main()
    {
        Console.WriteLine("ChefLogger: Waiting for LogReader...");

        using (NamedPipeServerStream pipeServer = new NamedPipeServerStream("OrderPipe", PipeDirection.Out))
        {
            pipeServer.WaitForConnection();
            using (StreamWriter writer = new StreamWriter(pipeServer) { AutoFlush = true })
            {
                string[] orders = { "Sushi Platter", "Kung Pao Chicken", "Pad  Thai", "Ramen Bowl", "Bibimbap" };
                foreach (string order in orders)
                {
                    Console.WriteLine($"ChefLogger: Logging {order}");
                    writer.WriteLine(order);
                    Thread.Sleep(1000);
                }
            }
        }
    }
}

