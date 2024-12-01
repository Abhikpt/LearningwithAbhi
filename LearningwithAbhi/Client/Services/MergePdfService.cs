using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Drawing;
using PdfSharp.Pdf.IO;
using System.Reflection.Metadata;
using Aspose.Words;

public class PdfService
{
    public void MergePdfs(string[] inputPaths, string outputPath)
    {
        using (PdfDocument outputDocument = new PdfDocument())
        {
            foreach (var file in inputPaths)
            {
                using (PdfDocument inputDocument = PdfReader.Open(file, PdfDocumentOpenMode.Import))
                {
                    int pageCount = inputDocument.PageCount;
                    for (int idx = 0; idx < pageCount; idx++)
                    {
                        PdfPage page = inputDocument.Pages[idx];
                        outputDocument.AddPage(page);
                    }
                }
            }
            outputDocument.Save(outputPath);
        }
    }


    public void MergeImageToPdf(string[] imagesPath, string outputPath)
    {
        using(PdfDocument Pdfdoc = new PdfDocument())
        {
            foreach(var imagepath in imagesPath)
            {
                // Create an Image object.
                using(var image = new Bitmap(imagepath))
                {
                     PdfPage page = Pdfdoc.AddPage();
                    XGraphics gfx = XGraphics.FromPdfPage(page);                    
                    XImage xImage = XImage.FromFile(imagepath);
                    gfx.DrawImage(xImage, 0, 0);
                   

                }

            }
             Pdfdoc.Save(outputPath);
        }
    }
     public void ConvertWordToPdf(string wordFilePath, string pdfFilePath)
    {
        Aspose.Words.Document doc = new Aspose.Words.Document(wordFilePath);
        doc.Save(pdfFilePath, SaveFormat.Pdf);
    }
}

