using ExcelExport.Models.Repository;
using ExcelExport.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace ExcelExport.Controllers
{
    public class ExcelController : ApiController
    {
        IRecordRepository recordRepository;
        IRecordTransform recordTransform;
        public ExcelController()
        {
            //TODO use IOC
            recordTransform = new RecordTransform();
            recordRepository = new RecordRepository();
        }
        [HttpGet]
        public async Task<HttpResponseMessage> GetHtmlExcelAsync()
        {
            var records = await recordRepository.GetAllRecords();
            var htmlVersion = recordTransform.ConvertListToHtml(records);
            byte[] excelData = System.Text.Encoding.UTF8.GetBytes(htmlVersion);
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            var stream = new MemoryStream(excelData);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = $"{Guid.NewGuid()}.xls"
            };
            return result;
        }
    }
}
