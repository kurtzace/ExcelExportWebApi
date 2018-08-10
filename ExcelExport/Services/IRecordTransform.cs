using ExcelExport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelExport.Services
{
    public interface IRecordTransform
    {
         string ConvertListToHtml(IEnumerable<Record> records);
    }
}
