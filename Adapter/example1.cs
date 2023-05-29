using System;

// Target interface
interface ITarget
{
    void Request();
}

// Adaptee (Incompatible class)
class Adaptee
{
    public void SpecificRequest()
    {
        Console.WriteLine("Adaptee's specific request");
    }
}

// Adapter
class Adapter : ITarget
{
    private Adaptee adaptee;

    public Adapter(Adaptee adaptee)
    {
        this.adaptee = adaptee;
    }

    public void Request()
    {
        adaptee.SpecificRequest();
    }
}

// Client code
class Client
{
    static void Main(string[] args)
    {
        // Create an instance of the Adaptee
        Adaptee adaptee = new Adaptee();

        // Create an instance of the Adapter and pass the Adaptee to its constructor
        ITarget adapter = new Adapter(adaptee);

        // Call the Request method on the adapter
        adapter.Request();
    }
}
