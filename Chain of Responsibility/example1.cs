using System;

// Handler
abstract class Handler
{
    protected Handler successor;

    public void SetSuccessor(Handler successor)
    {
        this.successor = successor;
    }

    public abstract void HandleRequest(int request);
}

// Concrete Handler
class ConcreteHandler1 : Handler
{
    public override void HandleRequest(int request)
    {
        if (request >= 0 && request < 10)
        {
            Console.WriteLine($"Request {request} handled by ConcreteHandler1");
        }
        else if (successor != null)
        {
            successor.HandleRequest(request);
        }
    }
}

// Concrete Handler
class ConcreteHandler2 : Handler
{
    public override void HandleRequest(int request)
    {
        if (request >= 10 && request < 20)
        {
            Console.WriteLine($"Request {request} handled by ConcreteHandler2");
        }
        else if (successor != null)
        {
            successor.HandleRequest(request);
        }
    }
}

// Concrete Handler
class ConcreteHandler3 : Handler
{
    public override void HandleRequest(int request)
    {
        if (request >= 20 && request < 30)
        {
            Console.WriteLine($"Request {request} handled by ConcreteHandler3");
        }
        else if (successor != null)
        {
            successor.HandleRequest(request);
        }
    }
}

// Client code
class Client
{
    static void Main(string[] args)
    {
        // Create the chain of handlers
        Handler handler1 = new ConcreteHandler1();
        Handler handler2 = new ConcreteHandler2();
        Handler handler3 = new ConcreteHandler3();

        // Set the successors
        handler1.SetSuccessor(handler2);
        handler2.SetSuccessor(handler3);

        // Process requests
        int[] requests = { 5, 12, 25, 8, 30 };

        foreach (int request in requests)
        {
            handler1.HandleRequest(request);
        }

        // Output:
        // Request 5 handled by ConcreteHandler1
        // Request 12 handled by ConcreteHandler2
        // Request 25 handled by ConcreteHandler3
        // Request 8 handled by ConcreteHandler1
        // No handler found for request 30
    }
}
