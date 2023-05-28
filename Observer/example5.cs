using System;
using System.Collections.Generic;

// Subject (Publisher)
class NewsAgency
{
    private List<IObserver> observers = new List<IObserver>();
    private string latestNews;

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
        Console.WriteLine($"{observer.Name} subscribed to news updates.");
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
        Console.WriteLine($"{observer.Name} unsubscribed from news updates.");
    }

    public void PublishNews(string news)
    {
        latestNews = news;
        NotifyObservers();
    }

    private void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(latestNews);
        }
    }
}

// Observer
interface IObserver
{
    string Name { get; }
    void Update(string news);
}

// Concrete Observer
class NewsSubscriber : IObserver
{
    public string Name { get; }

    public NewsSubscriber(string name)
    {
        Name = name;
    }

    public void Update(string news)
    {
        Console.WriteLine($"{Name} received news update: {news}");
    }
}

// Client code
class Client
{
    static void Main(string[] args)
    {
        // Create a news agency
        NewsAgency newsAgency = new NewsAgency();

        // Create news subscribers (observers)
        NewsSubscriber subscriber1 = new NewsSubscriber("Subscriber 1");
        NewsSubscriber subscriber2 = new NewsSubscriber("Subscriber 2");

        // Attach subscribers to the news agency
        newsAgency.Attach(subscriber1);
        newsAgency.Attach(subscriber2);

        // Publish news
        newsAgency.PublishNews("Breaking News: New product launch!");

        // Detach a subscriber
        newsAgency.Detach(subscriber1);

        // Publish another news
        newsAgency.PublishNews("Sports Update: Team wins championship!");

        // Output:
        // Subscriber 1 subscribed to news updates.
        // Subscriber 2 subscribed to news updates.
        // Subscriber 1 received news update: Breaking News: New product launch!
        // Subscriber 2 received news update: Breaking News: New product launch!
        // Subscriber 1 unsubscribed from news updates.
        // Subscriber 2 received news update: Sports Update: Team wins championship!
    }
}
