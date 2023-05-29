using System;

// Abstract class defining the template method
abstract class PaymentGateway
{
    public void ProcessPayment()
    {
        ValidateCredentials();
        SetApiCredentials();
        PreparePaymentData();
        SendPaymentRequest();
        GetPaymentResponse();
        ProcessPaymentResponse();
    }

    protected abstract void ValidateCredentials();
    protected abstract void SetApiCredentials();
    protected abstract void PreparePaymentData();
    protected abstract void SendPaymentRequest();
    protected abstract void GetPaymentResponse();
    protected abstract void ProcessPaymentResponse();
}

// Concrete class for PayPal payment gateway
class PayPalGateway : PaymentGateway
{
    protected override void ValidateCredentials()
    {
        Console.WriteLine("Validating PayPal credentials...");
        // Validation logic for PayPal credentials
    }

    protected override void SetApiCredentials()
    {
        Console.WriteLine("Setting PayPal API credentials...");
        // Setting API credentials for PayPal
    }

    protected override void PreparePaymentData()
    {
        Console.WriteLine("Preparing payment data for PayPal...");
        // Payment data preparation for PayPal
    }

    protected override void SendPaymentRequest()
    {
        Console.WriteLine("Sending payment request to PayPal...");
        // Sending payment request to PayPal API
    }

    protected override void GetPaymentResponse()
    {
        Console.WriteLine("Getting payment response from PayPal...");
        // Retrieving payment response from PayPal API
    }

    protected override void ProcessPaymentResponse()
    {
        Console.WriteLine("Processing PayPal payment response...");
        // Processing payment response from PayPal
    }
}

// Concrete class for Stripe payment gateway
class StripeGateway : PaymentGateway
{
    protected override void ValidateCredentials()
    {
        Console.WriteLine("Validating Stripe credentials...");
        // Validation logic for Stripe credentials
    }

    protected override void SetApiCredentials()
    {
        Console.WriteLine("Setting Stripe API credentials...");
        // Setting API credentials for Stripe
    }

    protected override void PreparePaymentData()
    {
        Console.WriteLine("Preparing payment data for Stripe...");
        // Payment data preparation for Stripe
    }

    protected override void SendPaymentRequest()
    {
        Console.WriteLine("Sending payment request to Stripe...");
        // Sending payment request to Stripe API
    }

    protected override void GetPaymentResponse()
    {
        Console.WriteLine("Getting payment response from Stripe...");
        // Retrieving payment response from Stripe API
    }

    protected override void ProcessPaymentResponse()
    {
        Console.WriteLine("Processing Stripe payment response...");
        // Processing payment response from Stripe
    }
}

// Client code
class Client
{
    static void Main(string[] args)
    {
        PaymentGateway gateway = new PayPalGateway();
        gateway.ProcessPayment();

        Console.WriteLine();

        gateway = new StripeGateway();
        gateway.ProcessPayment();

        // Output:
        // Validating PayPal credentials...
        // Setting PayPal API credentials...
        // Preparing payment data for PayPal...
        // Sending payment request to PayPal...
        // Getting payment response from PayPal...
        // Processing PayPal payment response...
        //
        // Validating Stripe credentials...
        // Setting Stripe API credentials...
        // Preparing payment data for Stripe...
        // Sending payment request to Stripe...
        // Getting payment response from Stripe...
        // Processing Stripe payment response...
    }
}
