using System;

// Handler
abstract class PaymentHandler
{
    protected PaymentHandler successor;

    public void SetSuccessor(PaymentHandler successor)
    {
        this.successor = successor;
    }

    public abstract void ProcessPayment(Order order);
}

// Concrete Handler
class CreditCardPaymentHandler : PaymentHandler
{
    public override void ProcessPayment(Order order)
    {
        if (order.PaymentMethod == PaymentMethod.CreditCard)
        {
            Console.WriteLine("Processing credit card payment...");
            // Logic to process credit card payment
        }
        else if (successor != null)
        {
            successor.ProcessPayment(order);
        }
    }
}

// Concrete Handler
class PayPalPaymentHandler : PaymentHandler
{
    public override void ProcessPayment(Order order)
    {
        if (order.PaymentMethod == PaymentMethod.PayPal)
        {
            Console.WriteLine("Processing PayPal payment...");
            // Logic to process PayPal payment
        }
        else if (successor != null)
        {
            successor.ProcessPayment(order);
        }
    }
}

// Concrete Handler
class BankTransferPaymentHandler : PaymentHandler
{
    public override void ProcessPayment(Order order)
    {
        if (order.PaymentMethod == PaymentMethod.BankTransfer)
        {
            Console.WriteLine("Processing bank transfer payment...");
            // Logic to process bank transfer payment
        }
        else if (successor != null)
        {
            successor.ProcessPayment(order);
        }
    }
}

// Order
class Order
{
    public string OrderId { get; set; }
    public decimal TotalAmount { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
}

// Payment Method
enum PaymentMethod
{
    CreditCard,
    PayPal,
    BankTransfer
}

// Client code
class Client
{
    static void Main(string[] args)
    {
        // Create the chain of payment handlers
        PaymentHandler creditCardHandler = new CreditCardPaymentHandler();
        PaymentHandler payPalHandler = new PayPalPaymentHandler();
        PaymentHandler bankTransferHandler = new BankTransferPaymentHandler();

        // Set the successors
        creditCardHandler.SetSuccessor(payPalHandler);
        payPalHandler.SetSuccessor(bankTransferHandler);

        // Process orders
        Order[] orders =
        {
            new Order { OrderId = "001", TotalAmount = 100.00m, PaymentMethod = PaymentMethod.PayPal },
            new Order { OrderId = "002", TotalAmount = 250.00m, PaymentMethod = PaymentMethod.CreditCard },
            new Order { OrderId = "003", TotalAmount = 500.00m, PaymentMethod = PaymentMethod.BankTransfer },
            new Order { OrderId = "004", TotalAmount = 1000.00m, PaymentMethod = PaymentMethod.CreditCard }
        };

        foreach (Order order in orders)
        {
            creditCardHandler.ProcessPayment(order);
            Console.WriteLine("----------------------------------");
        }

        // Output:
        // Processing PayPal payment...
        // ----------------------------------
        // Processing credit card payment...
        // ----------------------------------
        // Processing bank transfer payment...
        // ----------------------------------
        // Processing credit card payment...
        // ----------------------------------
    }
}
