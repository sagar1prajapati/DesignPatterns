// Complex subsystem classes
class UserManager
{
    public void CreateUser(string username)
    {
        // Logic to create a new user
        Console.WriteLine($"Creating user {username}");
    }

    public void DeleteUser(string username)
    {
        // Logic to delete a user
        Console.WriteLine($"Deleting user {username}");
    }
}

class MessageHandler
{
    public void SendMessage(string sender, string recipient, string message)
    {
        // Logic to send a message from sender to recipient
        Console.WriteLine($"Sending message from {sender} to {recipient}: {message}");
    }

    public void ReceiveMessage(string recipient, string message)
    {
        // Logic to receive a message for the recipient
        Console.WriteLine($"Received message for {recipient}: {message}");
    }
}

class NotificationService
{
    public void SendNotification(string recipient, string notification)
    {
        // Logic to send a notification to the recipient
        Console.WriteLine($"Sending notification to {recipient}: {notification}");
    }
}

// Facade class
class ChatFacade
{
    private UserManager userManager;
    private MessageHandler messageHandler;
    private NotificationService notificationService;

    public ChatFacade()
    {
        userManager = new UserManager();
        messageHandler = new MessageHandler();
        notificationService = new NotificationService();
    }

    public void RegisterUser(string username)
    {
        // Create a new user
        userManager.CreateUser(username);

        Console.WriteLine($"User {username} registered successfully.");
    }

    public void SendMessage(string sender, string recipient, string message)
    {
        // Send message from sender to recipient
        messageHandler.SendMessage(sender, recipient, message);

        Console.WriteLine($"Message sent from {sender} to {recipient}.");
    }

    public void ReceiveMessage(string recipient, string message)
    {
        // Receive message for the recipient
        messageHandler.ReceiveMessage(recipient, message);

        Console.WriteLine($"Message received for {recipient}.");
    }

    public void SendNotification(string recipient, string notification)
    {
        // Send notification to the recipient
        notificationService.SendNotification(recipient, notification);

        Console.WriteLine($"Notification sent to {recipient}.");
    }
}

// Client code
class Client
{
    static void Main(string[] args)
    {
        ChatFacade chatFacade = new ChatFacade();

        // Register a new user
        chatFacade.RegisterUser("JohnDoe");

        // Send a message
        chatFacade.SendMessage("JohnDoe", "JaneSmith", "Hello Jane!");

        // Receive a message
        chatFacade.ReceiveMessage("JaneSmith", "Hi John!");

        // Send a notification
        chatFacade.SendNotification("JohnDoe", "New message received.");
    }
}
