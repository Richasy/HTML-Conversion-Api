using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;
using HtmlConversionApi.Models;
using HtmlConversionApi.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HtmlConversionApi.Controllers
{
    [Route("pdf")]
    [ApiController]
    public class PdfController : ControllerBase
    {
        private SynchronizedConverter PdfConverter;
        public PdfController(IConverter converter)
        {
            PdfConverter = converter as SynchronizedConverter;
        }

        [HttpPost]
        public async Task<ActionResult> ConvertHtmlToPdf()
        {
            var postData = AppTools.GetRequestBodyEntity<ExportModel>(HttpContext);
            string htmlContent = postData.Content;
            string title = postData.Title;
            try
            {
                return await Task.Run(() =>
                {
                    var doc = new HtmlToPdfDocument()
                    {
                        GlobalSettings = {
                        ColorMode = ColorMode.Color,
                        Orientation = Orientation.Portrait,
                        PaperSize = PaperKind.A4Plus,
                    },
                        Objects = {
                        new ObjectSettings() {
                            PagesCount = true,
                            HtmlContent = htmlContent,
                            WebSettings = { DefaultEncoding = "utf-8" },
                        }
                    }
                    };
                    byte[] pdf = PdfConverter.Convert(doc);
                    var f = File(pdf, "application/pdf", title, true);
                    return f;
                });
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}