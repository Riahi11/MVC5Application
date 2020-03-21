using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.codec;
using MVC5Application.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Application.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [LogFilter]
        public ActionResult GeneratePDF()
        {
            _CreateAndExtratZipFile();

            string appPhysicalPath = Server.MapPath("\\docs");
            //"D:\\Projets\\testItextSharp";


            string filePath = "D:\\Projets\\test_" + DateTime.Now.Ticks.ToString() + ".pdf";


            FileStream fs = new FileStream(filePath, FileMode.CreateNew, FileAccess.ReadWrite);

            Document document = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
            
                document.SetPageSize(PageSize.A4);
                MemoryStream ms = new MemoryStream();

                PdfWriter.GetInstance(document,ms);

                document.Open();
               // document.Add(new Phrase ("Titre du document", new Font(Font.FontFamily.TIMES_ROMAN, Font.BOLD, 14, BaseColor.RED )));
                //document.AddCreationDate();
               // document.AddAuthor("Riahi Hatem");
                Chunk monChunk = new Chunk("Hello World using Chunk ", FontFactory.GetFont(FontFactory.COURIER, 20, Font.ITALIC, BaseColor.BLACK));
                Image image1 = Image.GetInstance("D:\\Projets\\download.png");
               
                document.Add(monChunk);

                List listPuces = new List(List.ALPHABETICAL);
                //listPuces.Symbol = new Chunk('.');
                listPuces.Add("ID par constructeur");
                listPuces.Add("ID par modificateur setter");
                listPuces.Add("ID par interface");
                document.Add(listPuces);

                document.Add(new Phrase("Hello Mr Hatem to ItextSharp library"));

                PdfPTable tableau = new PdfPTable(3);
                PdfPCell cellule = new PdfPCell(new Paragraph("en-tête avec colspan de 3")) ; 
                cellule.Colspan = 3 ;
                cellule.BackgroundColor = BaseColor.BLUE;
                
                tableau.AddCell(cellule);
                tableau.AddCell("1.1"); 
                tableau.AddCell("1.2"); 
                tableau.AddCell("1.3");
                document.Add(tableau);
                document.NewPage();

                document.Add(image1);

            Chunk c1 = new Chunk("A chunk represents an isolated string. ");

            document.Add(c1);
            
            
            byte [] bytes = new byte[fs.Length];
            fs.Read(bytes, 0, bytes.Length);
            //fs.Close();
            //fs.Dispose();
            document.Close();
            FileResult frslt =  File(ms.ToArray(), "application/pdf");
            //File(ms.ToArray(), "application/pdf", "testItextSharp.pdf");
            

            return frslt;

        }

        private void _CreateAndExtratZipFile ()
        {
            string startPath = "D:\\MUTUELLE STORTIC";
            string zipPath = "D:\\result.zip";
            string extractPath = "D:\\extract";

            //ZipFile.CreateFromDirectory(startPath, zipPath);
            //ZipFile.ExtractToDirectory(zipPath, extractPath);

            throw new Exception("exception pour tester le filtre LogFilter");
        }
    }
}