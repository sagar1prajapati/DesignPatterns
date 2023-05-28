using System;

// Strategy interface
interface IPaymentStrategy
{
    void ProcessPayment(double amount);
}

// Concrete strategies
class CreditCardPaymentStrategy : IPaymentStrategy
{
    private string cardNumber;
    private string expirationDate;
    private string cvv;

    public CreditCardPaymentStrategy(string cardNumber, string expirationDate, string cvv)
    {
        this.cardNumber = cardNumber;
        this.expirationDate = expirationDate;
        this.cvv = cvv;
    }

    public void ProcessPayment(double amount)
    {
        Console.WriteLine($"Processing credit card payment of {amount:C} with Card Number: {cardNumber}, Expiration Date: {expirationDate}, CVV: {cvv}");
        // Logic to process credit card payment
    }
}

class PayPalPaymentStrategy : IPaymentStrategy
{
    private string email;
    private string password;

    public PayPalPaymentStrategy(string email, string password)
    {
        this.email = email;
        this.password = password;
    }

    public void ProcessPayment(double amount)
    {
        Console.WriteLine($"Processing PayPal payment of {amount:C} with Email: {email}, Password: {password}");
        // Logic to process PayPal payment
    }
}

// Context
class ShoppingCart
{
    private IPaymentStrategy paymentStrategy;

    public void SetPaymentStrategy(IPaymentStrategy strategy)
    {
        paymentStrategy = strategy;
    }

    public void Checkout(double totalAmount)
    {
        Console.WriteLine("Checking out the shopping cart...");
        paymentStrategy.ProcessPayment(totalAmount);
        // Additional checkout logic
    }
}

// Client code
class Client
{
    static void Main(string[] args)
    {
        // Create a shopping cart
        ShoppingCart cart = new ShoppingCart();

        // Add items to the cart and calculate the total amount
        double totalAmount = 250.0;

        // Choose a payment strategy
        IPaymentStrategy paymentStrategy = new CreditCardPaymentStrategy("1234567890123456", "12/2024", "123");
        cart.SetPaymentStrategy(paymentStrategy);

        // Checkout using the chosen strategy
        cart.Checkout(totalAmount);

        // Change the payment strategy
        paymentStrategy = new PayPalPaymentStrategy("example@example.com", "password");
        cart.SetPaymentStrategy(paymentStrategy);

        // Checkout again with the new strategy
        cart.Checkout(totalAmount);
    }
}

// In this example, we have a shopping cart application where customers can choose their preferred payment method during the checkout process. The Strategy design pattern is used to encapsulate different payment strategies (CreditCardPaymentStrategy and PayPalPaymentStrategy) and allow the client to choose the strategy dynamically.

// The IPaymentStrategy interface defines the contract for different payment strategies, specifying the ProcessPayment method. Each concrete strategy implements this interface and provides its own implementation of the method.

// The ShoppingCart class represents the context in which the payment strategies are used. It has a reference to the current payment strategy, which can be set using the SetPaymentStrategy method. The Checkout method delegates the payment processing to the current strategy.

// In the client code, we create a shopping cart and set the initial payment strategy to CreditCardPaymentStrategy. We then perform the checkout process with a given total amount, and the payment is processed using the current strategy. Next, we change the payment strategy to PayPalPaymentStrategy and perform the checkout process again with the new strategy.

// The Strategy design pattern allows us to add new payment strategies without modifying the existing code. It provides flexibility in choosing different payment methods at runtime and decouples the client from the specific payment implementation.