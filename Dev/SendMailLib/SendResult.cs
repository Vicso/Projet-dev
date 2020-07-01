using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;



namespace SendMailLib
{
    public class SendResult
    {
        public SendResult(string decryptedFile, string key)
        {

            PDFGenerator pdfgenerator = new PDFGenerator();
            Mail mail = new Mail();

            pdfgenerator.generation(decryptedFile, key);
            mail.send("cesiprojet69@gmail.com", "Azerty10*", "guillaume.brut@viacesi.fr", "TESTESTESTEST", "TESTESTESTEST"); //string gmailid, string password, string toemail, string subject, string body

        }
           
    }
}
