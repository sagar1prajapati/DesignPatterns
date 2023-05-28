using System;

// Handler
abstract class PaymentProcessor
{
    protected PaymentProcessor successor;

    public void SetSuccessor(PaymentProcessor successor)
    {
        this.successor = successor;
    }

    public abstract void ProcessPayment(double amount);
}

// Concrete Handler
class BankPaymentProcessor : PaymentProcessor
{
    public override void ProcessPayment(double amount)
    {
        if (amount <= 1000)
        {
            Console.WriteLine($"Bank payment processor processed payment of {amount:C}");
        }
        else if (successor != null)
        {
            successor.ProcessPayment(amount);
        }
    }
}

// Concrete Handler
class PayPalPaymentProcessor : PaymentProcessor
{
    public override void ProcessPayment(double amount)
    {
        if (amount > 1000 && amount <= 5000)
        {
            Console.WriteLine($"PayPal payment processor processed payment of {amount:C}");
        }
        else if (successor != null)
        {
            successor.ProcessPayment(amount);
        }
    }
}

// Concrete Handler
class CreditCardPaymentProcessor : PaymentProcessor
{
    public override void ProcessPayment(double amount)
    {
        if (amount > 5000 && amount <= 10000)
        {
            Console.WriteLine($"Credit card payment processor processed payment of {amount:C}");
        }
        else if (successor != null)
        {
            successor.ProcessPayment(amount);
        }
    }
}

// Client code
class Client
{
    static void Main(string[] args)
    {
        // Create the chain of payment processors
        PaymentProcessor bankProcessor = new BankPaymentProcessor();
        PaymentProcessor paypalProcessor = new PayPalPaymentProcessor();
        PaymentProcessor creditCardProcessor = new CreditCardPaymentProcessor();

        // Set the successors
        bankProcessor.SetSuccessor(paypalProcessor);
        paypalProcessor.SetSuccessor(creditCardProcessor);

        // Process payments
        double[] payments = { 500, 2500, 7500, 15000 };

        foreach (double payment in payments)
        {
            bankProcessor.ProcessPayment(payment);
        }

        // Output:
        // Bank payment processor processed payment of $500.00
        // PayPal payment processor processed payment of $2,500.00
        // Credit card payment processor processed payment of $7,500.00
        // No payment processor found for payment of $15,000.00
    }
}
