using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using OfficeOpenXml;
using SMGBitTransportadora.Servico.Interfaces;
using System.Data;

namespace SMGBitTransportadora.Servico.Servicos
{
    public class BaixarTabelaServico : IBaixarTabelaServico
    {
        public BaixarTabelaServico()
        {
        }

        public async Task<DataTable> BaixarTabela(IFormFile file)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var dataTable = new DataTable();
            using (var stream = file.OpenReadStream())
            {
                using (var package = new ExcelPackage(stream))
                {
                    var workbook = package.Workbook;
                    if (workbook != null)
                    {
                        if (workbook.Worksheets.Count > 0)
                        {
                            var worksheet = workbook.Worksheets[0];
                            foreach (var firstRowCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
                            {
                                dataTable.Columns.Add(firstRowCell.Text);
                            }
                            for (var rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
                            {
                                var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                                if (row.Text == "") continue;
                                var newRow = dataTable.NewRow();
                                foreach (var cell in row)
                                {
                                    newRow[cell.Start.Column - 1] = cell.Text;
                                }
                                dataTable.Rows.Add(newRow);
                            }

                        }
                    }
                }
            }
            return dataTable;
        }
    }
}
