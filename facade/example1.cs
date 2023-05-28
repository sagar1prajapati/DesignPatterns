// Complex subsystem classes
class SubsystemA
{
    public void OperationA()
    {
        Console.WriteLine("SubsystemA: OperationA");
    }
}

class SubsystemB
{
    public void OperationB()
    {
        Console.WriteLine("SubsystemB: OperationB");
    }
}

class SubsystemC
{
    public void OperationC()
    {
        Console.WriteLine("SubsystemC: OperationC");
    }
}

// Facade class
class Facade
{
    private SubsystemA subsystemA;
    private SubsystemB subsystemB;
    private SubsystemC subsystemC;

    public Facade()
    {
        subsystemA = new SubsystemA();
        subsystemB = new SubsystemB();
        subsystemC = new SubsystemC();
    }

    public void Operation()
    {
        Console.WriteLine("Facade: Operation");
        subsystemA.OperationA();
        subsystemB.OperationB();
        subsystemC.OperationC();
    }
}

// Client code
class Client
{
    static void Main(string[] args)
    {
        Facade facade = new Facade();
        facade.Operation();
    }
}
