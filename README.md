# Operating Systems Projects: Multi-Threading & Inter-Process Communication (IPC)

## **Overview**
This repository contains two projects that demonstrate key operating system concepts:  
1. **Multi-Threading Implementation (LotusFusionRestaurant)** – A restaurant simulation using C# that showcases threading concepts, including resource protection, deadlocks, and synchronization.  
2. **Inter-Process Communication (IPC) Project** – A C# program using named pipes to enable communication between separate processes (ChefLogger and LogReader).  

Both projects emphasize **process and thread management**, **data synchronization**, and **efficient inter-process communication**.

---

## **Project A: Multi-Threading Implementation (LotusFusionRestaurant)**  
### **Description**  
The multi-threading project simulates a restaurant kitchen where multiple chefs prepare orders concurrently. The project includes four phases:  
1. **Basic Thread Operations** – Creates multiple threads to process orders.  
2. **Resource Protection** – Uses mutex locks and semaphores to prevent race conditions.  
3. **Deadlock Creation** – Introduces a deadlock scenario to demonstrate thread contention.  
4. **Deadlock Resolution** – Implements deadlock prevention techniques, such as lock ordering and timeouts.  

### **How It Works**  
- A queue holds 100 customer orders.
- 15 chef threads process orders concurrently.
- Synchronization mechanisms like **locks and semaphores** ensure proper order execution.
- Deadlocks are intentionally created and then resolved.

### **Building & Running**  
#### **Prerequisites**  
- .NET SDK (version 6.0 or later)  

#### **Steps to Run**  
1. Clone this repository:  
   ```sh
   git clone https://github.com/your-repo/OS-Projects.git
   cd OS-Projects/LotusFusionRestaurant

## **Project B: Inter-Process Communication (IPC)**  
### **Description**  
The IPC project consists of two separate C# programs that communicate using named pipes:
1. **ChefLogger – Writes simulated restaurant order logs.
2. **LogReader – Reads and displays logs in real time.

### **How It Works**  
- ChefLogger continuously writes logs to a named pipe.
- LogReader reads logs from the named pipe and displays them.
- This simulates real-time communication between two independent processes.

### **Building & Running**  
#### **Prerequisites**  
- .NET SDK (version 6.0 or later)
- Windows Subsystem for Linux (WSL) if running on Linux

#### **Steps to Run**  
1. Clone this repository:  
   ```sh
   git clone https://github.com/your-repo/OS-Projects.git
   cd OS-Projects/IPC_Project
    
2. Open two separate terminals and run the following commands:
- Terminal 1 (ChefLogger)
   ```sh
   cd ChefLogger
   dotnet run
- Terminal 1 (LogReader)
   ```sh
   cd LogReader
   dotnet run

3. Expected Output:
- Terminal 1 (ChefLogger) should print:
   ```makefile
   ChefLogger: Waiting for LogReader...
- Terminal 2 (LogReader) should print:
   ```vbnet
   LogReader: Connecting to ChefLogger...
- Once connected, ChefLogger will start logging orders, and LogReader will display them.

### **Dependencies & Installation**  
#### **Required Software**  
- .NET SDK (version 6.0 or later)
- Windows Subsystem for Linux (WSL) (For running in a Linux-like environment)
- A Git client for version control

#### **Installation Steps**  
1. Install the .NET SDK:  
   ```sh
   sudo apt install dotnet-sdk-8.0
2. Verify the installation:
   ```sh
      dotnet --version

### **Known Issues**  
#### **Issue 1: Named Pipe Connection Delay**  
- The LogReader may take a few seconds to connect to ChefLogger due to system delays.
- If connection issues persist, restart both programs.

#### **Issue 2: WSL File Access (Windows Users)**  
1. If accessing WSL files from Windows Explorer gives an error (\\wsl$\Ubuntu\home\your-username\IPC_Project not found), try restarting WSL: 
   ```sh
   wsl --shutdown
   wsl

#### **Issue 3: Deadlock in Threading Project**
- The LotusFusionRestaurant simulation intentionally creates deadlocks before resolving them.
- If the simulation appears stuck, it's simulating a deadlock—wait for the program to resolve it.

#### **Repository Structure**  
1. Install the .NET SDK:  
   ```bash
   OS-Projects/
   │── LotusFusionRestaurant/  # Multi-threading project
   │   ├── Program.cs          # Main restaurant simulation
   │   ├── LotusFusion.csproj  # Project file
   │   └── README.md
   │
   │── IPC_Project/            # Inter-Process Communication project
   │   ├── ChefLogger/
   │   │   ├── Program.cs      # Logging process
   │   │   ├── ChefLogger.csproj
   │   │
   │   ├── LogReader/
   │   │   ├── Program.cs      # Reading process
   │   │   ├── LogReader.csproj
   │   │
   │   ├── README.md
   │
   └── README.md               # Main project documentation

#### **Contributors**  
- Caroline Varner
- Course: CS 3502 - Operating Systems
- Instructor: Chris Regan
- University: Kennesaw State University


