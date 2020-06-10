
using Spire.Pdf;
using System.IO;

namespace TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\atahar2380\Downloads\CRJune2020.pdf";
            string dest = @"C:\Users\atahar2380\Downloads\output";
            PefToJpeg(path, dest);
        }

        static void PefToJpeg(string filePath, string destDir)
        {
            PdfDocument pdfdocument = new PdfDocument(filePath);
            
            for (int i = 0; i < pdfdocument.Pages.Count; i++)
            {
                System.Drawing.Image image = pdfdocument.SaveAsImage(i, 96, 96);
                image.Save(Path.Combine(destDir,string.Format("ImagePage{0}.png", i)), System.Drawing.Imaging.ImageFormat.Png);
            }
        }
    }
}
