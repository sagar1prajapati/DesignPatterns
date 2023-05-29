using System;

// Target interface
interface IPaymentProcessor
{
    void ProcessPayment(string paymentDetails);
}

// Adaptee (Incompatible class)
class PaymentService
{
    public void ProcessPaymentGateway(string paymentData)
    {
        Console.WriteLine($"Processing payment with PaymentGateway: {paymentData}");
    }
}

// Adapter
class PaymentGatewayAdapter : IPaymentProcessor
{
    private PaymentService paymentService;

    public PaymentGatewayAdapter(PaymentService paymentService)
    {
        this.paymentService = paymentService;
    }

    public void ProcessPayment(string paymentDetails)
    {
        // Convert the payment details to match the PaymentService's format
        string formattedPaymentData = $"[Application Format]: {paymentDetails}";

        // Call the payment service's method
        paymentService.ProcessPaymentGateway(formattedPaymentData);
    }
}

// Client code
class Client
{
    static void Main(string[] args)
    {
        // Create an instance of the PaymentService
        PaymentService paymentService = new PaymentService();

        // Create an instance of the PaymentGatewayAdapter and pass the PaymentService to its constructor
        IPaymentProcessor paymentProcessor = new PaymentGatewayAdapter(paymentService);

        // Call the ProcessPayment method on the payment processor
        paymentProcessor.ProcessPayment("Payment Details");
    }
}
