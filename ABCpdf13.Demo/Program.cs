using ABCpdf13.Demo;
using ABCpdf13.Demo.Renderer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Console.WriteLine("Hello, World!");
var builder = Host.CreateApplicationBuilder();
builder.Configuration.AddJsonFile("appsettings.json", true);
builder.Services.AddDemoServices(builder.Configuration);
using var app = builder.Build();
var rendererService = app.Services.GetRequiredService<IRendererService>();
await rendererService.GenerateDocxDocumentAsPDFAsync();