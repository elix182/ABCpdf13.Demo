using ABCpdf13.Demo.Docx;
using ABCpdf13.Demo.Pdf;
using ABCpdf13.Demo.Renderer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ABCpdf13.Demo 
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDemoServices(this IServiceCollection services, IConfiguration configuration)
        {
            string abcpdfLicenseKey = configuration["ABCpdf_LicenseKey"] ?? string.Empty;
            if(!string.IsNullOrWhiteSpace(abcpdfLicenseKey))
            {
                bool validLicense = WebSupergoo.ABCpdf13.XSettings.InstallRedistributionLicense(abcpdfLicenseKey);
                if(!validLicense)
                {
                    throw new InvalidDataException("ABCpdf License is not valid.");
                }
            }
            services.AddScoped<IDocxService, DocxService>();
            services.AddScoped<IPdfService, PdfService>();
            services.AddScoped<IRendererService, RendererService>();
            return services;
        }
    }
}