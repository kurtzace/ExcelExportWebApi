# ExcelExportWebApi
Excel Export Web Api Asp Net


- Has two methods of excel export
1. Foreground : http://localhost:51160/api/Excel - 
2. Background: a. http://localhost:51160/api/excel/startbackground (it will reply with fileId) 

      b. followed by api/excel/getbackgroundfile?fileId={fileId}
