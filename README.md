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
