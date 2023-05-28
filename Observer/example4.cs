using System;
using System.Collections.Generic;

// Subject (Publisher)
class JobBoard
{
    private List<IObserver> observers = new List<IObserver>();
    private List<string> jobPostings = new List<string>();

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
        Console.WriteLine($"{observer.Name} subscribed to job postings.");
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
        Console.WriteLine($"{observer.Name} unsubscribed from job postings.");
    }

    public void AddJobPosting(string jobPosting)
    {
        jobPostings.Add(jobPosting);
        NotifyObservers(jobPosting);
    }

    private void NotifyObservers(string jobPosting)
    {
        foreach (var observer in observers)
        {
            observer.Update(jobPosting);
        }
    }
}

// Observer
interface IObserver
{
    string Name { get; }
    void Update(string jobPosting);
}

// Concrete Observer
class JobSeeker : IObserver
{
    public string Name { get; }

    public JobSeeker(string name)
    {
        Name = name;
    }

    public void Update(string jobPosting)
    {
        Console.WriteLine($"{Name} received new job posting: {jobPosting}");
    }
}

// Client code
class Client
{
    static void Main(string[] args)
    {
        // Create a job board
        JobBoard jobBoard = new JobBoard();

        // Create observers (job seekers)
        JobSeeker seeker1 = new JobSeeker("Job Seeker 1");
        JobSeeker seeker2 = new JobSeeker("Job Seeker 2");

        // Attach observers to the job board
        jobBoard.Attach(seeker1);
        jobBoard.Attach(seeker2);

        // Add job postings
        jobBoard.AddJobPosting("Software Engineer");
        jobBoard.AddJobPosting("Web Developer");

        // Detach an observer
        jobBoard.Detach(seeker1);

        // Add another job posting
        jobBoard.AddJobPosting("Data Analyst");

        // Output:
        // Job Seeker 1 subscribed to job postings.
        // Job Seeker 2 subscribed to job postings.
        // Job Seeker 1 received new job posting: Software Engineer
        // Job Seeker 2 received new job posting: Software Engineer
        // Job Seeker 1 received new job posting: Web Developer
        // Job Seeker 2 received new job posting: Web Developer
        // Job Seeker 1 unsubscribed from job postings.
        // Job Seeker 2 received new job posting: Data Analyst
    }
}
