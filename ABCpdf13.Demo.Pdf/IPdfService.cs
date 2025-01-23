namespace ABCpdf13.Demo.Pdf
{
    public interface IPdfService 
    {
        Task<byte[]> ConvertDocxToPdfAsync(byte[] docx);
    }
}