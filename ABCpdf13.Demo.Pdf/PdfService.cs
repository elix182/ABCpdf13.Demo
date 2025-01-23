
using WebSupergoo.ABCpdf13;

namespace ABCpdf13.Demo.Pdf;

public class PdfService : IPdfService
{
    public async Task<byte[]> ConvertDocxToPdfAsync(byte[] docx)
    {
        await Task.Delay(0);
        using var doc = new Doc();
        doc.Read(docx, new XReadOptions()
        {
            FileExtension = ".docx",
            ReadModule = ReadModuleType.Default
        });
        return doc.GetData();
    }
}
