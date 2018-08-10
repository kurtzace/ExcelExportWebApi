using ExcelExport.Models.Repository;
using ExcelExport.Services;
using FluentScheduler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ExcelExport.Controllers
{
    [RoutePrefix("api/excel")]
    public class ExcelController : ApiController
    {
        private const string PATH = "~/App_Data";
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


        [HttpGet]
        [Route("startbackground")]
        public IHttpActionResult StartHtmlExcelBackground()
        {
            var guid = Guid.NewGuid();
            string serverPath = HttpContext.Current.Server.MapPath(PATH);
            JobManager.AddJob(async () =>
            {
                var records = await recordRepository.GetAllRecords();
                var htmlVersion = recordTransform.ConvertListToHtml(records);
                byte[] excelData = System.Text.Encoding.UTF8.GetBytes(htmlVersion);
                if (!Directory.Exists(serverPath))
                {
                    Directory.CreateDirectory(serverPath);
                }
                string _FileName = $"{guid}.xls";
                string _path = Path.Combine(serverPath, _FileName);
                File.WriteAllBytes(_path, excelData);
            }, s => s.ToRunNow());
            return Ok(guid);
        }

        [Route("getbackgroundfile")]
        public HttpResponseMessage GetHtmlExcelBackgroundFile(string fileId)
        {
            if(string.IsNullOrEmpty(fileId))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            string _FileName = $"{fileId}.xls";
            string _path = Path.Combine(HttpContext.Current.Server.MapPath(PATH), _FileName);
            if (!File.Exists(_path))
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            byte[] excelData = File.ReadAllBytes(_path);
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
