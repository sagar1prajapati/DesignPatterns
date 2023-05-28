using System;

// Handler
abstract class Approver
{
    protected Approver successor;

    public void SetSuccessor(Approver successor)
    {
        this.successor = successor;
    }

    public abstract void ApprovePurchaseOrder(PurchaseOrder purchaseOrder);
}

// Concrete Handler
class Manager : Approver
{
    public override void ApprovePurchaseOrder(PurchaseOrder purchaseOrder)
    {
        if (purchaseOrder.Amount <= 10000)
        {
            Console.WriteLine($"Manager approves purchase order #{purchaseOrder.OrderNumber}");
        }
        else if (successor != null)
        {
            successor.ApprovePurchaseOrder(purchaseOrder);
        }
    }
}

// Concrete Handler
class Director : Approver
{
    public override void ApprovePurchaseOrder(PurchaseOrder purchaseOrder)
    {
        if (purchaseOrder.Amount <= 50000)
        {
            Console.WriteLine($"Director approves purchase order #{purchaseOrder.OrderNumber}");
        }
        else if (successor != null)
        {
            successor.ApprovePurchaseOrder(purchaseOrder);
        }
    }
}

// Concrete Handler
class CEO : Approver
{
    public override void ApprovePurchaseOrder(PurchaseOrder purchaseOrder)
    {
        if (purchaseOrder.Amount <= 100000)
        {
            Console.WriteLine($"CEO approves purchase order #{purchaseOrder.OrderNumber}");
        }
        else
        {
            Console.WriteLine($"Purchase order #{purchaseOrder.OrderNumber} requires board approval.");
        }
    }
}

// Purchase Order
class PurchaseOrder
{
    public int OrderNumber { get; set; }
    public decimal Amount { get; set; }
}

// Client code
class Client
{
    static void Main(string[] args)
    {
        // Create the chain of approvers
        Approver manager = new Manager();
        Approver director = new Director();
        Approver ceo = new CEO();

        // Set the successors
        manager.SetSuccessor(director);
        director.SetSuccessor(ceo);

        // Process purchase orders
        PurchaseOrder[] purchaseOrders =
        {
            new PurchaseOrder { OrderNumber = 1, Amount = 5000 },
            new PurchaseOrder { OrderNumber = 2, Amount = 15000 },
            new PurchaseOrder { OrderNumber = 3, Amount = 70000 },
            new PurchaseOrder { OrderNumber = 4, Amount = 200000 }
        };

        foreach (PurchaseOrder purchaseOrder in purchaseOrders)
        {
            manager.ApprovePurchaseOrder(purchaseOrder);
        }

        // Output:
        // Manager approves purchase order #1
        // Manager approves purchase order #2
        // Director approves purchase order #3
        // Purchase order #4 requires board approval.
    }
}
