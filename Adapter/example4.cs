using System;

// Target interface
interface IEmailSender
{
    void SendEmail(string recipient, string subject, string body);
}

// Adaptee (Incompatible class)
class LegacyEmailSender
{
    public void SendPlainTextEmail(string recipient, string subject, string body)
    {
        Console.WriteLine($"Sending plain text email to {recipient}: Subject: {subject}, Body: {body}");
    }
}

// Adapter
class HtmlEmailAdapter : IEmailSender
{
    private LegacyEmailSender legacyEmailSender;

    public HtmlEmailAdapter(LegacyEmailSender legacyEmailSender)
    {
        this.legacyEmailSender = legacyEmailSender;
    }

    public void SendEmail(string recipient, string subject, string body)
    {
        // Convert the email body to plain text format
        string plainTextBody = StripHtmlTags(body);

        // Call the legacy email sender's method
        legacyEmailSender.SendPlainTextEmail(recipient, subject, plainTextBody);
    }

    private string StripHtmlTags(string html)
    {
        // Remove HTML tags using a simple regex or HTML parser
        // This is a simplified implementation for demonstration purposes
        return System.Text.RegularExpressions.Regex.Replace(html, "<.*?>", string.Empty);
    }
}

// Client code
class Client
{
    static void Main(string[] args)
    {
        // Create an instance of the LegacyEmailSender
        LegacyEmailSender legacyEmailSender = new LegacyEmailSender();

        // Create an instance of the HtmlEmailAdapter and pass the LegacyEmailSender to its constructor
        IEmailSender emailSender = new HtmlEmailAdapter(legacyEmailSender);

        // Call the SendEmail method on the email sender
        emailSender.SendEmail("john@example.com", "Test Email", "<h1>Hello, John!</h1><p>This is an HTML email.</p>");
    }
}
