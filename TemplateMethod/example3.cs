using System;

// Abstract class defining the template method
abstract class OrderProcessor
{
    public void ProcessOrder()
    {
        ValidateOrder();
        ProcessPayment();
        FulfillOrder();
        SendConfirmation();
    }

    protected abstract void ValidateOrder();
    protected abstract void ProcessPayment();
    protected abstract void FulfillOrder();
    protected abstract void SendConfirmation();
}

// Concrete class for processing online orders
class OnlineOrderProcessor : OrderProcessor
{
    protected override void ValidateOrder()
    {
        Console.WriteLine("Validating online order...");
        // Validation logic for online orders
    }

    protected override void ProcessPayment()
    {
        Console.WriteLine("Processing payment for online order...");
        // Payment processing logic for online orders
    }

    protected override void FulfillOrder()
    {
        Console.WriteLine("Fulfilling online order...");
        // Fulfillment logic for online orders
    }

    protected override void SendConfirmation()
    {
        Console.WriteLine("Sending order confirmation to online customer...");
        // Sending confirmation logic for online orders
    }
}

// Concrete class for processing phone orders
class PhoneOrderProcessor : OrderProcessor
{
    protected override void ValidateOrder()
    {
        Console.WriteLine("Validating phone order...");
        // Validation logic for phone orders
    }

    protected override void ProcessPayment()
    {
        Console.WriteLine("Processing payment for phone order...");
        // Payment processing logic for phone orders
    }

    protected override void FulfillOrder()
    {
        Console.WriteLine("Fulfilling phone order...");
        // Fulfillment logic for phone orders
    }

    protected override void SendConfirmation()
    {
        Console.WriteLine("Sending order confirmation to phone customer...");
        // Sending confirmation logic for phone orders
    }
}

// Client code
class Client
{
    static void Main(string[] args)
    {
        OrderProcessor processor = new OnlineOrderProcessor();
        processor.ProcessOrder();

        Console.WriteLine();

        processor = new PhoneOrderProcessor();
        processor.ProcessOrder();

        // Output:
        // Validating online order...
        // Processing payment for online order...
        // Fulfilling online order...
        // Sending order confirmation to online customer...
        //
        // Validating phone order...
        // Processing payment for phone order...
        // Fulfilling phone order...
        // Sending order confirmation to phone customer...
    }
}
