using System;

// Abstract class defining the template method
abstract class AbstractClass
{
    public void TemplateMethod()
    {
        Console.WriteLine("Executing common steps...");
        Step1();
        Step2();
        Step3();
        Console.WriteLine("Template method execution completed.");
    }

    protected abstract void Step1();
    protected abstract void Step2();

    protected virtual void Step3()
    {
        Console.WriteLine("Default implementation of Step3.");
    }
}

// Concrete class implementing the template method
class ConcreteClass : AbstractClass
{
    protected override void Step1()
    {
        Console.WriteLine("Executing Step1 in ConcreteClass.");
    }

    protected override void Step2()
    {
        Console.WriteLine("Executing Step2 in ConcreteClass.");
    }

    protected override void Step3()
    {
        Console.WriteLine("Executing Step3 in ConcreteClass.");
    }
}

// Client code
class Client
{
    static void Main(string[] args)
    {
        AbstractClass abstractClass = new ConcreteClass();
        abstractClass.TemplateMethod();

        // Output:
        // Executing common steps...
        // Executing Step1 in ConcreteClass.
        // Executing Step2 in ConcreteClass.
        // Executing Step3 in ConcreteClass.
        // Template method execution completed.
    }
}
