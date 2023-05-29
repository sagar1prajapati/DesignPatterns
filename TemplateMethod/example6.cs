using System;

// Abstract class defining the template method
abstract class JobApplicationProcessor
{
    public void ProcessApplication()
    {
        ValidateApplication();
        EvaluateApplication();
        NotifyApplicant();
    }

    protected abstract void ValidateApplication();
    protected abstract void EvaluateApplication();
    protected abstract void NotifyApplicant();
}

// Concrete class for processing software developer job applications
class SoftwareDeveloperApplicationProcessor : JobApplicationProcessor
{
    protected override void ValidateApplication()
    {
        Console.WriteLine("Validating software developer application...");
        // Validation logic for software developer applications
    }

    protected override void EvaluateApplication()
    {
        Console.WriteLine("Evaluating software developer application...");
        // Evaluation logic for software developer applications
    }

    protected override void NotifyApplicant()
    {
        Console.WriteLine("Sending notification to software developer applicant...");
        // Notification logic for software developer applicants
    }
}

// Concrete class for processing marketing specialist job applications
class MarketingSpecialistApplicationProcessor : JobApplicationProcessor
{
    protected override void ValidateApplication()
    {
        Console.WriteLine("Validating marketing specialist application...");
        // Validation logic for marketing specialist applications
    }

    protected override void EvaluateApplication()
    {
        Console.WriteLine("Evaluating marketing specialist application...");
        // Evaluation logic for marketing specialist applications
    }

    protected override void NotifyApplicant()
    {
        Console.WriteLine("Sending notification to marketing specialist applicant...");
        // Notification logic for marketing specialist applicants
    }
}

// Client code
class Client
{
    static void Main(string[] args)
    {
        JobApplicationProcessor processor = new SoftwareDeveloperApplicationProcessor();
        processor.ProcessApplication();

        Console.WriteLine();

        processor = new MarketingSpecialistApplicationProcessor();
        processor.ProcessApplication();

        // Output:
        // Validating software developer application...
        // Evaluating software developer application...
        // Sending notification to software developer applicant...
        //
        // Validating marketing specialist application...
        // Evaluating marketing specialist application...
        // Sending notification to marketing specialist applicant...
    }
}
