using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace SendMailLib
{
    class PDFGenerator
    {
        public void generation(string decryptedFile, string key)
        {

            // Create a new PDF document
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Created with PDFsharp";

            // Create an empty page
            PdfPage page = document.AddPage();

            // Get an XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont font = new XFont("Times New Roman", 10, XFontStyle.Bold);

            XTextFormatter tfKey = new XTextFormatter(gfx);

            XRect rect = new XRect(40, 0, 40, 100);

            gfx.DrawRectangle(XBrushes.SeaShell, rect);

            //tf.Alignment = ParagraphAlignment.Left;

            tfKey.DrawString(key, font, XBrushes.Black, rect, XStringFormats.TopLeft);

            float pageNumberF = (decryptedFile.Length) / 10000f;

            int pageNumber = (int)Math.Ceiling(pageNumberF);

            string tempString;

            for (int i = 0; i < pageNumber; i++)
            {
                int maxLength;

                if (decryptedFile.Length < i * 10000 + 10000)
                {
                    maxLength = decryptedFile.Length - (i * 10000);
                }
                else
                {
                    maxLength = 10000;
                }
                tempString = (decryptedFile.Substring(i * 10000, maxLength));

                PdfPage page2 = document.AddPage();

                XGraphics gfx2 = XGraphics.FromPdfPage(page2);

                XTextFormatter tf = new XTextFormatter(gfx2);

                XRect rect2 = new XRect(40, 100, 500, 1000);

                gfx2.DrawRectangle(XBrushes.SeaShell, rect2);

                //tf.Alignment = ParagraphAlignment.Left;

                tf.DrawString(tempString, font, XBrushes.Black, rect2, XStringFormats.TopLeft);
            }






            // Save the document...
            const string filename = "C:/Users/guill/Desktop/Crypt.pdf";
            document.Save(filename);
            Console.WriteLine("PDF GENERE");

            // ...and start a viewer.
            //Process.Start(filename);
        }

    }
}
