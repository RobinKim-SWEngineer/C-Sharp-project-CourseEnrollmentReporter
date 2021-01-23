using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using System.Data;

namespace CourseEnrollmentDetailReporter.Worker
{
    static class ExcelDocumentExporter
    {
        public static Text Text { get; private set; }

        public static void Export(DataTable dataTable, string filePath)
        {
            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = spreadsheetDocument.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                SheetData sheetData = new SheetData();
                worksheetPart.Worksheet = new Worksheet(sheetData);

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                Sheet singleSheet = new Sheet()
                {
                    Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart),
                    SheetId = 1,
                    Name = "Course enrollment detail"
                };
                sheets.Append(singleSheet);

                MoveColumnNameToSheet(dataTable, sheetData);

                MoveDataToSheet(dataTable, sheetData);

                workbookPart.Workbook.Save();
            }
        }

        private static void MoveColumnNameToSheet(DataTable dataTable, SheetData sheetData)
        {
            Row row = new Row();
            foreach (DataColumn dataCoulmn in dataTable.Columns)
            {
                Cell cell = new Cell();
                cell.DataType = CellValues.String;
                cell.CellValue = new CellValue(dataCoulmn.ColumnName);
                row.Append(cell);
            }
            sheetData.AppendChild(row);
        }

        private static void MoveDataToSheet(DataTable dataTable, SheetData sheetData)
        {
            foreach (DataRow dataRow in dataTable.Rows)
            {
                Row row = new Row();
                foreach (DataColumn column in dataTable.Columns)
                {
                    Cell cell = new Cell();
                    cell.DataType = CellValues.String;
                    cell.CellValue = new CellValue(dataRow[column.ColumnName].ToString());
                    row.Append(cell);
                }
                sheetData.AppendChild(row);
            }
        }
    }
}
