
using ABCpdf13.Demo.Docx;
using ABCpdf13.Demo.Pdf;

namespace ABCpdf13.Demo.Renderer;

public class RendererService : IRendererService
{
    private readonly IDocxService _docxService;
    private readonly IPdfService _pdfService;

    public RendererService(IDocxService docxService, IPdfService pdfService)
    {
        _docxService = docxService;
        _pdfService = pdfService;
    }

    public async Task<byte[]> GenerateDocxDocumentAsPDFAsync()
    {
        string Input = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) ?? Environment.CurrentDirectory, "Original.docx");
        string Output = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) ?? Environment.CurrentDirectory, "Converted.pdf");
        var docx = await _docxService.GenerateDocxFileAsync();
        if(File.Exists(Input))
        {
            File.Delete(Input);
        }
        await File.WriteAllBytesAsync(Input, docx);
        var pdf = await _pdfService.ConvertDocxToPdfAsync(docx);
        if(File.Exists(Output))
        {
            File.Delete(Output);
        }
        await File.WriteAllBytesAsync(Output, pdf);
        return pdf;
    }
}
