using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExcelExport.Models
{
    //https://www.c-sharpcorner.com/UploadFile/2b481f/export-the-excel-file-in-Asp-Net-web-api/
    public class Record
    {
        public string FName { get; set; }

        public string LName { get; set; }

        public string Address { get; set; }
    }
}