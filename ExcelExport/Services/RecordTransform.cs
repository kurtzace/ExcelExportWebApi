using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using ExcelExport.Models;
using ExcelExport.Util;

namespace ExcelExport.Services
{
    public class RecordTransform : IRecordTransform
    {
        public string ConvertListToHtml(IEnumerable<Record> records)
        {
            StringBuilder sb = new StringBuilder();

            using (Html.Table table = new Html.Table(sb))
            {
                foreach (var record in records)
                {
                    using (Html.Row row = table.AddRow())
                    {
                        row.AddCell(record.FName);
                        row.AddCell(record.LName);
                        row.AddCell(record.Address);
                    }
                }
            }

            return sb.ToString();
        }
    }
}