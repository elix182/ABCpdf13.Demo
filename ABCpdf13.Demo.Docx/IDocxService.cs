namespace ABCpdf13.Demo.Docx
{
    public interface IDocxService
    {
        Task<byte[]> GenerateDocxFileAsync();
    }
}