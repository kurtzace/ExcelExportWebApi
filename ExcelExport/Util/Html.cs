using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ExcelExport.Util
{
    //see https://stackoverflow.com/a/36476600/5059472
    public static class Html
    {
        public class Table : IDisposable
        {
            private StringBuilder _sb;
            public Table(StringBuilder sb)
            {
                _sb = sb;
                _sb.Append("<table>");
            }
            public void Dispose()
            {
                _sb.Append("</table>");
            }
            public Row AddRow()
            {
                return new Row(_sb);
            }
        }
        public class Row : IDisposable
        {
            private StringBuilder _sb;
            public Row(StringBuilder sb)
            {
                _sb = sb;
                _sb.Append("<tr>");
            }
            public void Dispose()
            {
                _sb.Append("</tr>");
            }
            public void AddCell(string innerText)
            {
                _sb.Append("<td>");
                _sb.Append(innerText);
                _sb.Append("</td>");
            }
        }
    }
}


