using System;
using System.Collections.Generic;

// Subject (Publisher)
class WeatherStation
{
    private List<IObserver> observers = new List<IObserver>();
    private int temperature;

    public int Temperature
    {
        get { return temperature; }
        set
        {
            temperature = value;
            NotifyObservers();
        }
    }

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
        Console.WriteLine($"{observer.Name} subscribed to weather updates.");
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
        Console.WriteLine($"{observer.Name} unsubscribed from weather updates.");
    }

    private void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(temperature);
        }
    }
}

// Observer
interface IObserver
{
    string Name { get; }
    void Update(int temperature);
}

// Concrete Observer
class WeatherObserver : IObserver
{
    public string Name { get; }

    public WeatherObserver(string name)
    {
        Name = name;
    }

    public void Update(int temperature)
    {
        Console.WriteLine($"{Name} received weather update: Temperature is {temperature}°C");
    }
}

// Client code
class Client
{
    static void Main(string[] args)
    {
        // Create a weather station
        WeatherStation weatherStation = new WeatherStation();

        // Create observers
        WeatherObserver observer1 = new WeatherObserver("Observer 1");
        WeatherObserver observer2 = new WeatherObserver("Observer 2");

        // Attach observers to the weather station
        weatherStation.Attach(observer1);
        weatherStation.Attach(observer2);

        // Update temperature
        weatherStation.Temperature = 25;

        // Detach an observer
        weatherStation.Detach(observer1);

        // Update temperature again
        weatherStation.Temperature = 30;

        // Output:
        // Observer 1 subscribed to weather updates.
        // Observer 2 subscribed to weather updates.
        // Observer 1 received weather update: Temperature is 25°C
        // Observer 2 received weather update: Temperature is 25°C
        // Observer 1 unsubscribed from weather updates.
        // Observer 2 received weather update: Temperature is 30°C
    }
}
