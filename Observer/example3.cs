using System;
using System.Collections.Generic;

// Subject (Publisher)
class StockMarket
{
    private List<IObserver> observers = new List<IObserver>();
    private decimal stockPrice;

    public decimal StockPrice
    {
        get { return stockPrice; }
        set
        {
            stockPrice = value;
            NotifyObservers();
        }
    }

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
        Console.WriteLine($"{observer.Name} subscribed to stock price updates.");
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
        Console.WriteLine($"{observer.Name} unsubscribed from stock price updates.");
    }

    private void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(stockPrice);
        }
    }
}

// Observer
interface IObserver
{
    string Name { get; }
    void Update(decimal stockPrice);
}

// Concrete Observer
class StockTrader : IObserver
{
    public string Name { get; }

    public StockTrader(string name)
    {
        Name = name;
    }

    public void Update(decimal stockPrice)
    {
        Console.WriteLine($"{Name} received stock price update: Price is {stockPrice:C}");
    }
}

// Client code
class Client
{
    static void Main(string[] args)
    {
        // Create a stock market
        StockMarket stockMarket = new StockMarket();

        // Create observers
        StockTrader trader1 = new StockTrader("Trader 1");
        StockTrader trader2 = new StockTrader("Trader 2");

        // Attach observers to the stock market
        stockMarket.Attach(trader1);
        stockMarket.Attach(trader2);

        // Update stock price
        stockMarket.StockPrice = 100.50m;

        // Detach an observer
        stockMarket.Detach(trader1);

        // Update stock price again
        stockMarket.StockPrice = 95.75m;

        // Output:
        // Trader 1 subscribed to stock price updates.
        // Trader 2 subscribed to stock price updates.
        // Trader 1 received stock price update: Price is $100.50
        // Trader 2 received stock price update: Price is $100.50
        // Trader 1 unsubscribed from stock price updates.
        // Trader 2 received stock price update: Price is $95.75
    }
}
