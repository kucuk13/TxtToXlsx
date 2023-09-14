using OfficeOpenXml;

class Program
{
    static string fileName = "test";

    static void Main()
    {
        ExcelPackage.LicenseContext = LicenseContext.Commercial;

        string[] lines = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\" + fileName + ".txt");

        using (var package = new ExcelPackage())
        {
            var worksheet = package.Workbook.Worksheets.Add("Sheet1");

            for (int i = 0; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(';');
                for (int j = 0; j < values.Length; j++)
                {
                    worksheet.Cells[i + 1, j + 1].Value = values[j];
                }
            }

            package.SaveAs(new FileInfo(Directory.GetCurrentDirectory() + "\\" + fileName + ".xlsx"));
        }
    }
}
