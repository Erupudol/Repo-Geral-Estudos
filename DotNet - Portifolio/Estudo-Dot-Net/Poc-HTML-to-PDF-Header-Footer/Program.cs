using System;
using System.IO;
using iText.Html2pdf;
using iText.StyledXmlParser.Css.Media;

class Program
{
    static void Main(string[] args)
    {

        string htmlPath = "./Poc-HTML-to-PDF-Header-Footer/Report.html";
        string pdfPath = "Poc-HTML-to-PDF-Header-Footer/Report.pdf";
        var backPath = @"..\..\..\..\";
        htmlPath =  Path.Combine(backPath, htmlPath);
        pdfPath = Path.Combine(backPath, pdfPath);

        Console.WriteLine($"Convertendo HTML para PDF: {htmlPath} -> {pdfPath}");
        ConvertHtmlToPdf(htmlPath, pdfPath);
    }

    static void ConvertHtmlToPdf(string htmlPath, string pdfPath)
    {
        try
        {
            using (FileStream htmlSource = File.Open(htmlPath, FileMode.Open))
            using (FileStream pdfDest = File.Open(pdfPath, FileMode.Create))
            {
                ConverterProperties properties = new ConverterProperties();
                MediaDeviceDescription mediaDeviceDescription = new MediaDeviceDescription(MediaType.PRINT);
                properties.SetMediaDeviceDescription(mediaDeviceDescription);
                HtmlConverter.ConvertToPdf(htmlSource, pdfDest);
            }

            Console.WriteLine("PDF criado com sucesso em: " + pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao criar PDF: " + ex.Message);
        }
    }
}
