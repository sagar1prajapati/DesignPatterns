using System;

// Strategy interface
interface IShippingStrategy
{
    double CalculateShippingCost(double weight);
}

// Concrete strategies
class StandardShippingStrategy : IShippingStrategy
{
    public double CalculateShippingCost(double weight)
    {
        return weight * 1.5;
    }
}

class ExpressShippingStrategy : IShippingStrategy
{
    public double CalculateShippingCost(double weight)
    {
        return weight * 3.0;
    }
}

// Context
class ShippingContext
{
    private IShippingStrategy shippingStrategy;

    public void SetShippingStrategy(IShippingStrategy strategy)
    {
        shippingStrategy = strategy;
    }

    public double CalculateShippingCost(double weight)
    {
        return shippingStrategy.CalculateShippingCost(weight);
    }
}

// Client code
class Client
{
    static void Main(string[] args)
    {
        // Create a shipping context
        ShippingContext context = new ShippingContext();

        // Set the shipping strategy to standard shipping
        context.SetShippingStrategy(new StandardShippingStrategy());
        double weight = 2.5;

        // Calculate shipping cost using the current strategy
        double shippingCost = context.CalculateShippingCost(weight);
        Console.WriteLine($"Shipping cost for weight {weight} kg: {shippingCost}");

        // Change the shipping strategy to express shipping
        context.SetShippingStrategy(new ExpressShippingStrategy());

        // Calculate shipping cost again with the new strategy
        shippingCost = context.CalculateShippingCost(weight);
        Console.WriteLine($"Shipping cost for weight {weight} kg: {shippingCost}");
    }
}
