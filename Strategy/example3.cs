using System;

// Strategy interface
interface IDiscountStrategy
{
    double ApplyDiscount(double amount);
}

// Concrete strategies
class NoDiscountStrategy : IDiscountStrategy
{
    public double ApplyDiscount(double amount)
    {
        return amount;
    }
}

class PercentageDiscountStrategy : IDiscountStrategy
{
    private double percentage;

    public PercentageDiscountStrategy(double percentage)
    {
        this.percentage = percentage;
    }

    public double ApplyDiscount(double amount)
    {
        double discountAmount = amount * (percentage / 100);
        return amount - discountAmount;
    }
}

class FixedAmountDiscountStrategy : IDiscountStrategy
{
    private double discountAmount;

    public FixedAmountDiscountStrategy(double discountAmount)
    {
        this.discountAmount = discountAmount;
    }

    public double ApplyDiscount(double amount)
    {
        return amount - discountAmount;
    }
}

// Context
class ShoppingCart
{
    private IDiscountStrategy discountStrategy;

    public void SetDiscountStrategy(IDiscountStrategy strategy)
    {
        discountStrategy = strategy;
    }

    public double CalculateTotal(double amount)
    {
        return discountStrategy.ApplyDiscount(amount);
    }
}

// Client code
class Client
{
    static void Main(string[] args)
    {
        // Create a shopping cart
        ShoppingCart cart = new ShoppingCart();

        // Calculate the total amount
        double totalAmount = 100.0;

        // Choose a discount strategy
        IDiscountStrategy discountStrategy = new NoDiscountStrategy();
        cart.SetDiscountStrategy(discountStrategy);

        // Calculate the total amount with the chosen strategy
        double discountedAmount = cart.CalculateTotal(totalAmount);
        Console.WriteLine($"Total amount: {totalAmount:C}, Discounted amount: {discountedAmount:C}");

        // Change the discount strategy
        discountStrategy = new PercentageDiscountStrategy(20);
        cart.SetDiscountStrategy(discountStrategy);

        // Calculate the total amount with the new strategy
        discountedAmount = cart.CalculateTotal(totalAmount);
        Console.WriteLine($"Total amount: {totalAmount:C}, Discounted amount: {discountedAmount:C}");
    }
}



// In this example, we have a shopping cart application where customers can apply different discount strategies to their total amount. The Strategy design pattern is used to encapsulate different discount strategies (NoDiscountStrategy, PercentageDiscountStrategy, FixedAmountDiscountStrategy) and allow the client to choose the strategy dynamically.

// The IDiscountStrategy interface defines the contract for different discount strategies, specifying the ApplyDiscount method. Each concrete strategy implements this interface and provides its own implementation of the method.

// The ShoppingCart class represents the context in which the discount strategies are used. It has a reference to the current discount strategy, which can be set using the SetDiscountStrategy method. The CalculateTotal method applies the discount strategy to the total amount.

// In the client code, we create a shopping cart and set the initial discount strategy to NoDiscountStrategy. We then calculate the total amount with the chosen strategy. Next, we change the discount strategy to PercentageDiscountStrategy and calculate the total amount again with the new strategy.

// The Strategy design pattern allows us to add new discount strategies without modifying the existing code. It provides flexibility in applying different discounts to the total amount at runtime and decouples the client from the specific discount implementation.