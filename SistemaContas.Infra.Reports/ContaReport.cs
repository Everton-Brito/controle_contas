using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using OfficeOpenXml;
using SistemaContas.Domain.Entities;
using SistemaContas.Domain.Interfaces.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace SistemaContas.Infra.Reports
{
    public class ContaReport : IContaReport
    {
        public byte[] CreateExcel(List<Conta> contas)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var excelPackage = new ExcelPackage())
            {
                var planilha = excelPackage.Workbook.Worksheets.Add("Contas");

                planilha.Cells["A1"].Value = "Relatório de Contas";
                planilha.Cells["A2"].Value = $"Gerado em:{DateTime.Now.ToString("dd/MM/yyyy")}";
                planilha.Cells["A4"].Value = "Nome da Conta";
                planilha.Cells["B4"].Value = "Data";
                planilha.Cells["C4"].Value = "Valor";
                planilha.Cells["D4"].Value = "Tipo";

                var linha = 5;
                foreach (var item in contas)
                {
                    planilha.Cells[$"A{linha}"].Value = item.Nome;
                    planilha.Cells[$"B{linha}"].Value = item.Data.ToString("dd/MM/yyyy");
                    planilha.Cells[$"C{linha}"].Value = item.Valor.ToString("c");
                    planilha.Cells[$"D{linha}"].Value = item.Tipo.ToString();

                    linha++;
                }
                planilha.Cells["A:D"].AutoFitColumns();
                return excelPackage.GetAsByteArray();
            }




        }

        public byte[] CreatePdf(List<Conta> contas)
        {
            var memoryStream = new MemoryStream();
            var pdf = new PdfDocument(new PdfWriter(memoryStream));

            using (var document = new Document(pdf))
            {
                document.Add(new Paragraph("Relatório de Contas"));
                document.Add(new Paragraph($"Gerado em:{DateTime.Now.ToString("dd/MM/yyyy")}"));
                document.Add(new Paragraph("\n"));

                var table = new Table(4);
                table.SetWidth(UnitValue.CreatePercentValue(100));
                table.AddHeaderCell(new Paragraph("Nome da Conta"));
                table.AddHeaderCell(new Paragraph("Data"));
                table.AddHeaderCell(new Paragraph("Valor"));
                table.AddHeaderCell(new Paragraph("Tipo"));

                foreach (var item in contas)
                {
                    table.AddCell(new Paragraph(item.Nome));
                    table.AddCell(new Paragraph(item.Data.ToString("dd/MM/yyyy")));
                    table.AddCell(new Paragraph(item.Valor.ToString("c")));
                    table.AddCell(new Paragraph(item.Tipo.ToString()));

                }
                document.Add(table);
                document.Add(new Paragraph($"Quantidade de contas: {contas.Count}"));

            }
            return memoryStream.ToArray();

        }
    }
}
