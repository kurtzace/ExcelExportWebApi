using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ExcelExport.Models.Repository
{
    public class RecordRepository : IRecordRepository
    {
        public Task<List<Record>> GetAllRecords()
        {
            //fake data from https://www.c-sharpcorner.com/UploadFile/2b481f/export-the-excel-file-in-Asp-Net-web-api/
            List<Record> recordobj = new List<Record>();

            recordobj.Add(new Record { FName = "Smith", LName = "Singh", Address = "Knpur" });

            recordobj.Add(new Record { FName = "John", LName = "Kumar", Address = "Lucknow" });

            recordobj.Add(new Record { FName = "Vikram", LName = "Kapoor", Address = "Delhi" });

            recordobj.Add(new Record { FName = "Tanya", LName = "Shrma", Address = "Banaras" });

            recordobj.Add(new Record { FName = "Malini", LName = "Ahuja", Address = "Gujrat" });

            recordobj.Add(new Record { FName = "Varun", LName = "Katiyar", Address = "Rajasthan" });

            recordobj.Add(new Record { FName = "Arun  ", LName = "Singh", Address = "Jaipur" });

            recordobj.Add(new Record { FName = "Ram", LName = "Kapoor", Address = "Panjab" });

            recordobj.Add(new Record { FName = "Vishakha", LName = "Singh", Address = "Banglor" });

            recordobj.Add(new Record { FName = "Tarun", LName = "Singh", Address = "Kannauj" });

            recordobj.Add(new Record { FName = "Mayank", LName = "Dubey", Address = "Farrukhabad" });

            return Task.Run(()=> recordobj);
        }
    }
}