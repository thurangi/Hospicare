using DocumentFormat.OpenXml.Packaging;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace HC.Web.Controllers;

public class UploadController : Controller
{
    [HttpGet]
    public ActionResult Upload()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Upload(IFormFile file)
    {
        if (file != null && file.Length > 0 && Path.GetExtension(file.FileName).ToLower() == ".docx")
        {
            string content;
            using (var stream = file.OpenReadStream())
            {
                content = ReadWordDocument(stream);
            }
            ViewBag.DocumentContent = content;
        }
        else
        {
            ViewBag.DocumentContent = "Please upload a valid .docx file.";
        }

        return View();
    }
    private string ReadWordDocument(Stream stream)
    {
        StringBuilder sb = new StringBuilder();

        using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(stream, false))
        {
            var body = wordDoc.MainDocumentPart.Document.Body;
            sb.Append(body.InnerText);
        }

        return sb.ToString();
    }
}
