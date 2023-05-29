using System;

// Abstract class defining the template method
abstract class NotificationSender
{
    public void SendNotification()
    {
        Authenticate();
        PrepareNotificationContent();
        Send();
        LogNotification();
    }

    protected abstract void Authenticate();
    protected abstract void PrepareNotificationContent();
    protected abstract void Send();
    protected virtual void LogNotification()
    {
        Console.WriteLine("Notification logged.");
    }
}

// Concrete class for sending email notifications
class EmailNotificationSender : NotificationSender
{
    protected override void Authenticate()
    {
        Console.WriteLine("Authenticating email notification sender...");
        // Authentication logic for email notifications
    }

    protected override void PrepareNotificationContent()
    {
        Console.WriteLine("Preparing email notification content...");
        // Content preparation logic for email notifications
    }

    protected override void Send()
    {
        Console.WriteLine("Sending email notification...");
        // Sending logic for email notifications
    }
}

// Concrete class for sending SMS notifications
class SmsNotificationSender : NotificationSender
{
    protected override void Authenticate()
    {
        Console.WriteLine("Authenticating SMS notification sender...");
        // Authentication logic for SMS notifications
    }

    protected override void PrepareNotificationContent()
    {
        Console.WriteLine("Preparing SMS notification content...");
        // Content preparation logic for SMS notifications
    }

    protected override void Send()
    {
        Console.WriteLine("Sending SMS notification...");
        // Sending logic for SMS notifications
    }
}

// Client code
class Client
{
    static void Main(string[] args)
    {
        NotificationSender sender = new EmailNotificationSender();
        sender.SendNotification();

        Console.WriteLine();

        sender = new SmsNotificationSender();
        sender.SendNotification();

        // Output:
        // Authenticating email notification sender...
        // Preparing email notification content...
        // Sending email notification...
        // Notification logged.
        //
        // Authenticating SMS notification sender...
        // Preparing SMS notification content...
        // Sending SMS notification...
        // Notification logged.
    }
}
