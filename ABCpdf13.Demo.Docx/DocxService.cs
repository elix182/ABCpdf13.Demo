
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace ABCpdf13.Demo.Docx;

public class DocxService : IDocxService
{
    public async Task<byte[]> GenerateDocxFileAsync()
    {
        await Task.Delay(0);
        using var stream = new MemoryStream();
        using var doc = WordprocessingDocument.Create(stream, WordprocessingDocumentType.Document, false);
        
        var mainPart = doc.AddMainDocumentPart();
        mainPart.Document = new Document();
        var document = mainPart.Document;

        var body = new Body();
        var paragraph = new Paragraph();
        var run = new Run(new Text()
        {
            Text = "This is a \"quick\" demo made on January 23 2025 at 11:19 am\nRight the current execution date is "+DateTime.Now.ToString("MM/dd/yyyy hh:mm t")
        });
        body.AppendChild(paragraph);
        document.AppendChild(body);
        
        doc.Save();
        return stream.ToArray();
    }
}
