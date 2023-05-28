using System;
using System.Collections.Generic;

// Subject (Publisher)
class NewsPublisher
{
    private List<INewsSubscriber> subscribers = new List<INewsSubscriber>();

    public void Subscribe(INewsSubscriber subscriber)
    {
        subscribers.Add(subscriber);
        Console.WriteLine($"{subscriber.Name} subscribed to the news.");
    }

    public void Unsubscribe(INewsSubscriber subscriber)
    {
        subscribers.Remove(subscriber);
        Console.WriteLine($"{subscriber.Name} unsubscribed from the news.");
    }

    public void PublishNews(string news)
    {
        Console.WriteLine($"Breaking news: {news}");
        NotifySubscribers(news);
    }

    private void NotifySubscribers(string news)
    {
        foreach (var subscriber in subscribers)
        {
            subscriber.ReceiveNews(news);
        }
    }
}

// Observer (Subscriber)
interface INewsSubscriber
{
    string Name { get; }
    void ReceiveNews(string news);
}

// Concrete Observer (Concrete Subscriber)
class NewsSubscriber : INewsSubscriber
{
    public string Name { get; }

    public NewsSubscriber(string name)
    {
        Name = name;
    }

    public void ReceiveNews(string news)
    {
        Console.WriteLine($"{Name} received the news: {news}");
    }
}

// Client code
class Client
{
    static void Main(string[] args)
    {
        // Create a news publisher
        NewsPublisher publisher = new NewsPublisher();

        // Create subscribers
        NewsSubscriber subscriber1 = new NewsSubscriber("Subscriber 1");
        NewsSubscriber subscriber2 = new NewsSubscriber("Subscriber 2");

        // Subscribe the subscribers to the publisher
        publisher.Subscribe(subscriber1);
        publisher.Subscribe(subscriber2);

        // Publish news
        publisher.PublishNews("New product launched!");

        // Unsubscribe a subscriber
        publisher.Unsubscribe(subscriber1);

        // Publish news again
        publisher.PublishNews("Breaking news: Weather update!");

        // Output:
        // Subscriber 1 subscribed to the news.
        // Subscriber 2 subscribed to the news.
        // Breaking news: New product launched!
        // Subscriber 1 received the news: New product launched!
        // Subscriber 2 received the news: New product launched!
        // Subscriber 1 unsubscribed from the news.
        // Breaking news: Weather update!
        // Subscriber 2 received the news: Weather update!
    }
}
