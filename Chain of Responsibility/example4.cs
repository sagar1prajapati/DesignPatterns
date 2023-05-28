using System;

// Handler
abstract class LeaveApprover
{
    protected LeaveApprover successor;

    public void SetSuccessor(LeaveApprover successor)
    {
        this.successor = successor;
    }

    public abstract void ProcessLeaveApplication(LeaveApplication application);
}

// Concrete Handler
class Supervisor : LeaveApprover
{
    public override void ProcessLeaveApplication(LeaveApplication application)
    {
        if (application.LeaveDays <= 2)
        {
            Console.WriteLine($"Leave application for {application.Employee} approved by Supervisor");
        }
        else if (successor != null)
        {
            successor.ProcessLeaveApplication(application);
        }
    }
}

// Concrete Handler
class Manager : LeaveApprover
{
    public override void ProcessLeaveApplication(LeaveApplication application)
    {
        if (application.LeaveDays <= 5)
        {
            Console.WriteLine($"Leave application for {application.Employee} approved by Manager");
        }
        else if (successor != null)
        {
            successor.ProcessLeaveApplication(application);
        }
    }
}

// Concrete Handler
class Director : LeaveApprover
{
    public override void ProcessLeaveApplication(LeaveApplication application)
    {
        if (application.LeaveDays <= 10)
        {
            Console.WriteLine($"Leave application for {application.Employee} approved by Director");
        }
        else
        {
            Console.WriteLine($"Leave application for {application.Employee} denied by Director");
        }
    }
}

// Leave Application
class LeaveApplication
{
    public string Employee { get; set; }
    public int LeaveDays { get; set; }
}

// Client code
class Client
{
    static void Main(string[] args)
    {
        // Create the chain of leave approvers
        LeaveApprover supervisor = new Supervisor();
        LeaveApprover manager = new Manager();
        LeaveApprover director = new Director();

        // Set the successors
        supervisor.SetSuccessor(manager);
        manager.SetSuccessor(director);

        // Process leave applications
        LeaveApplication[] applications =
        {
            new LeaveApplication { Employee = "John", LeaveDays = 1 },
            new LeaveApplication { Employee = "Alice", LeaveDays = 3 },
            new LeaveApplication { Employee = "Bob", LeaveDays = 7 },
            new LeaveApplication { Employee = "Emily", LeaveDays = 12 }
        };

        foreach (LeaveApplication application in applications)
        {
            supervisor.ProcessLeaveApplication(application);
        }

        // Output:
        // Leave application for John approved by Supervisor
        // Leave application for Alice approved by Supervisor
        // Leave application for Bob approved by Manager
        // Leave application for Emily denied by Director
    }
}
