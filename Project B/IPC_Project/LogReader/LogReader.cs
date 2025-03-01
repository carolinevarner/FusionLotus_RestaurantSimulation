using System;
using System.IO;
using System.IO.Pipes;

class LogReader
{
    static void Main()
    {
        string pipeName = "OrderPipe";

        using (NamedPipeClientStream pipeClient = new NamedPipeClientStream(".", pipeName, PipeDirection.In))
        {
            Console.WriteLine("LogReader: Connecting to ChefLogger...");
            pipeClient.Connect(); // Connect to ChefLogger
            Console.WriteLine("LogReader: Connected. Reading logs...");

            StreamReader reader = new StreamReader(pipeClient);
            using (StreamWriter fileWriter = new StreamWriter("restaurant_log.txt", true))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine($"[LogReader] Received log: {line}");
                    fileWriter.WriteLine(line); // Save log to file
                }
            }
        }
        Console.WriteLine("LogReader: Finished reading logs. Exiting...");
    }
}
