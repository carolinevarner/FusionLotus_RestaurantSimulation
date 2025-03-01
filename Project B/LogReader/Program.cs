using System;
using System.IO;
using System.IO.Pipes;

// 
class LogReader
{
    static void Main()
    {
        Console.WriteLine("LogReader: Connecting to ChefLogger...");

        using (NamedPipeClientStream pipeClient = new NamedPipeClientStream(".", "OrderPipe", PipeDirection.In))
        {
            pipeClient.Connect();
            using (StreamReader reader = new StreamReader(pipeClient))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine($"LogReader received: {line}");
                }
            }
        }
    }
}

