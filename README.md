![Image](https://github.com/RobinKim-SWEngineer/Images-for-document/blob/master/ITWorld%20(1).jpg)

# Course Enrollment Detail Reporter 

## What is this application about ?

This application can export an Excel file using queried data, which is student`s course enrollment detail from Database.

> DB Setup file is included together. The focus of this app is **to convert** the query result from Database into data table type and further **export it** to an Excel file.

## How this program is made ?

1. MS SQL : Making EnrollmentDetail View using `INNER JOIN` and saving the calling procedure into Stored procedure. 


2. C# : Converting query result, which is a *List of Objects* into *DataTable type* using `System.Reflection` and exporting to an Excel file using `DocumentFormat.OpenXml`
   - Conversion process of a List of objects to a DataTable type is described in my C# snippet repository : [List to DataTable Converter](https://github.com/RobinKim-SWEngineer/C-Sharp-snippet-ListToDataTableConverter)
   - Exporting an Excel file consists of creating a workbookPart -> a worksheetPart -> workwheet and loading data through SheetData. Below is **SpreadSheetDocument component's** diagram, but you don't really need to memorize the process since it`s rather building blocks like LEGOs than some logics behind.
   
     ![Image](https://github.com/RobinKim-SWEngineer/Images-for-document/blob/master/SpreadSheetDocument_Components.png)
   - Once a Excel document is created, we move contents inside DataTable to `SheetData` cell by cell and later by row : `sheetData.AppendChild(new Row(new List<Cell>));`
   - Finally save the Workbook !
