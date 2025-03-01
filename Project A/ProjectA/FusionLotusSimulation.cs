using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

class LotusFusionRestaurant
{
    static ConcurrentQueue<string> ordersQueue = new ConcurrentQueue<string>(); // Shared queue for orders

    // Phase 2: Resource Protection
    static object lockObject = new object(); // Mutex for order processing
    static object loggingLock = new object(); // Mutex for logging operations
    
    static SemaphoreSlim semaphore = new SemaphoreSlim(5); // Control concurrent chefs

    static int completedOrders = 0; // Counter for completed orders
    static int totalThreadsRun = 0; // Counter for total threads run

    static async Task Main()
    {
        // Phase 1: Basic Thread Operations
        PrintRestaurantIntroduction();
        Stopwatch stopwatch = Stopwatch.StartNew();

        // Creating orders based on randomly assigned dishes
        for (int i = 1; i <= 100; i++)
        {
            ordersQueue.Enqueue($"Order {i}: {GetRandomDish()}");
        }

        // Create and manage threads
        Task[] chefTasks = new Task[15]; 
        for (int i = 0; i < 15; i++)
        {
            int chefNumber = i + 1; // Capture unique chef number
            chefTasks[i] = Task.Run(() => ProcessOrders($"Chef {chefNumber}"));
            Interlocked.Increment(ref totalThreadsRun);
        }

        await Task.WhenAll(chefTasks); // Ensure all chefs complete their work

        stopwatch.Stop();
        PrintRestaurantEnd(stopwatch.Elapsed); // Track order preparation times
    }

    static void PrintRestaurantIntroduction()
    {
        string[] menuItems = { "Dumplings", "Ramen", "Kung Pao Chicken", "Sushi Platter", "Pad Thai", "Bibimbap" };
        Console.WriteLine("==============================================================================================");
        Console.WriteLine("                                    WELCOME TO LOTUS FUSION             ");
        Console.WriteLine("                                A Fine Asian Fusion Experience          ");
        Console.WriteLine("==============================================================================================");
        Console.WriteLine("                                           MENU                           ");
        foreach (string item in menuItems)
        {
            Console.WriteLine($"                                      - {item}                            ");
        }
        Console.WriteLine("\n==============================================================================================\n");
        Console.WriteLine($"                                    RESTAURANT SIMULATION:                            ");
    }

    static void PrintRestaurantEnd(TimeSpan elapsedTime) // Print sinulation results
    {
        Console.WriteLine("\n==============================================================================================\n");
        Console.WriteLine($"                               Number of Orders Completed: {completedOrders}                     ");
        Console.WriteLine($"                                     Number of Chefs: 15                                         ");
        Console.WriteLine($"                                   Total Threads Run: {totalThreadsRun}                          ");
        Console.WriteLine($"                            Total Execution Time: {elapsedTime.TotalSeconds:F2} seconds          ");
        Console.WriteLine("\n                                    SIMULATION COMPLETE.                                        ");
        Console.WriteLine("\n==============================================================================================\n");
    }


    static void ProcessOrders(string chefName)
    {
        // Check if queue is empty before continuing 
        while (!ordersQueue.IsEmpty)
        {
            bool lock1Taken = false, lock2Taken = false;
            try
            {
                // Phase 2: Resource Protection
                semaphore.Wait(); // Limit concurrent chefs to 5 at a time

                // Phase 3: Deadlock Creation 
                lock1Taken = Monitor.TryEnter(lockObject, TimeSpan.FromSeconds(2)); // First lock
                lock2Taken = Monitor.TryEnter(loggingLock, TimeSpan.FromSeconds(2)); // Second lock

                if (lock1Taken && lock2Taken)
                {
                    if (ordersQueue.TryDequeue(out string order))
                    {
                        Console.WriteLine("\n==============================================================================================");
                        Console.WriteLine($"\n   IN THE KITCHEN:    {chefName} is preparing {order}...\n");
                        Thread.Sleep(new Random().Next(1000, 3000)); // Simulate cooking time to mimic chefs "cooking" different meals at different times
                        Console.WriteLine($"                      {chefName} has completed {order}!\n");
                        Console.WriteLine("==============================================================================================\n");

                        LogOrderCompletion(order, chefName);
                        Interlocked.Increment(ref completedOrders);
                    }
                }
                else
                {
                    // Phase 4: Deadlock Resolution
                    Console.WriteLine($"      + {chefName} encountered a potential deadlock and will retry."); // Detect deadlock and recover
                }
            }
            finally
            {
                //Properly releasing locks
                if (lock1Taken) Monitor.Exit(lockObject); 
                if (lock2Taken) Monitor.Exit(loggingLock);
                semaphore.Release(); // Free semaphore slot

                if (lock1Taken && lock2Taken)
                {
                    Console.WriteLine($"      - {chefName} successfully acquired and released locks.");
                }
            }
        }
    }

    static string GetRandomDish()
    {
        string[] dishes = { "Sushi Platter", "Kung Pao Chicken", "Pad Thai", "Ramen Bowl", "Bibimbap" }; // Randomly generated dish options
        return dishes[new Random().Next(dishes.Length)];
    }

    static void LogOrderCompletion(string order, string chef){
        Console.WriteLine($"              LOG:    {chef} has completed {order} at {DateTime.Now}\n");
    }
}

