using System;

// Target interface
interface IPrinter
{
    void Print(string document);
}

// Adaptee (Incompatible class)
class LegacyPrinter
{
    public void PrintLegacy(string document)
    {
        Console.WriteLine($"LegacyPrinter: {document}");
    }
}

// Adapter
class PrinterAdapter : IPrinter
{
    private LegacyPrinter legacyPrinter;

    public PrinterAdapter(LegacyPrinter legacyPrinter)
    {
        this.legacyPrinter = legacyPrinter;
    }

    public void Print(string document)
    {
        // Convert the document format to match the LegacyPrinter's format
        string formattedDocument = $"[Modern Printer Format]: {document}";

        // Call the legacy printer's method
        legacyPrinter.PrintLegacy(formattedDocument);
    }
}

// Client code
class Client
{
    static void Main(string[] args)
    {
        // Create an instance of the LegacyPrinter
        LegacyPrinter legacyPrinter = new LegacyPrinter();

        // Create an instance of the PrinterAdapter and pass the LegacyPrinter to its constructor
        IPrinter printerAdapter = new PrinterAdapter(legacyPrinter);

        // Call the Print method on the printer adapter
        printerAdapter.Print("Sample Document");
    }
}
