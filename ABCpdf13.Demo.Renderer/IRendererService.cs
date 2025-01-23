namespace ABCpdf13.Demo.Renderer
{
    public interface IRendererService
    {
        Task<byte[]> GenerateDocxDocumentAsPDFAsync();
    }
}