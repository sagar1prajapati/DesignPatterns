using System;

// Handler
abstract class DocumentHandler
{
    protected DocumentHandler successor;

    public void SetSuccessor(DocumentHandler successor)
    {
        this.successor = successor;
    }

    public abstract void ProcessDocument(string document);
}

// Concrete Handler
class TextDocumentHandler : DocumentHandler
{
    public override void ProcessDocument(string document)
    {
        if (document.EndsWith(".txt"))
        {
            Console.WriteLine($"Text document handler processed document: {document}");
        }
        else if (successor != null)
        {
            successor.ProcessDocument(document);
        }
    }
}

// Concrete Handler
class PDFDocumentHandler : DocumentHandler
{
    public override void ProcessDocument(string document)
    {
        if (document.EndsWith(".pdf"))
        {
            Console.WriteLine($"PDF document handler processed document: {document}");
        }
        else if (successor != null)
        {
            successor.ProcessDocument(document);
        }
    }
}

// Concrete Handler
class WordDocumentHandler : DocumentHandler
{
    public override void ProcessDocument(string document)
    {
        if (document.EndsWith(".docx") || document.EndsWith(".doc"))
        {
            Console.WriteLine($"Word document handler processed document: {document}");
        }
        else if (successor != null)
        {
            successor.ProcessDocument(document);
        }
    }
}

// Client code
class Client
{
    static void Main(string[] args)
    {
        // Create the chain of document handlers
        DocumentHandler textHandler = new TextDocumentHandler();
        DocumentHandler pdfHandler = new PDFDocumentHandler();
        DocumentHandler wordHandler = new WordDocumentHandler();

        // Set the successors
        textHandler.SetSuccessor(pdfHandler);
        pdfHandler.SetSuccessor(wordHandler);

        // Process documents
        string[] documents = { "file1.txt", "file2.pdf", "file3.docx", "file4.jpg" };

        foreach (string document in documents)
        {
            textHandler.ProcessDocument(document);
        }

        // Output:
        // Text document handler processed document: file1.txt
        // PDF document handler processed document: file2.pdf
        // Word document handler processed document: file3.docx
        // No document handler found for document: file4.jpg
    }
}
