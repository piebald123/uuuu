using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VDOLPZZZ.AppData;
using Excel = Microsoft.Office.Interop.Excel;

namespace VDOLPZZZ.Pages
{
    /// <summary>
    /// Логика взаимодействия для otchetExcel.xaml
    /// </summary>
    public partial class otchetExcel : Page
    {
        public otchetExcel()
        {
            InitializeComponent();
        }

        private void EXBtn_Click(object sender, RoutedEventArgs e)
        {
            var acc = Class1.context.Ychetnai.ToList();
            var inf = Class1.context.Spravochnaya.ToList();
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add(Type.Missing);
            Excel.Worksheet ws = (Excel.Worksheet)app.Worksheets.get_Item(1);
            ws.Name = "Учётная  таблица";
            Excel.Range r = ws.Range["A1", "F2"];
            r.Merge();
            r.Value = "Ведомость отгрузки продукции предприятием";
            r.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            r.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            ws.Cells.Font.Name = "Times New Roman";
            ws.Cells[3, 1].Value = "Наименование продукции";
            ws.Cells[3, 2].Value = "Наименование предприятия";
            ws.Cells[3, 3].Value = "ФИО директора";
            ws.Cells[3, 4].Value = "Количество";
            ws.Cells[3, 5].Value = "Цена";
            ws.Cells[3, 6].Value = "Стоимость";
            var curRow = 4;
            int sum = 0;
            foreach (var item in acc)
            {
                ws.Cells[curRow, 1].Value = item.Naimenovanit_Prodykcie;
                ws.Cells[curRow, 2].Value = item.Spravochnaya.Naimenovani;
                ws.Cells[curRow, 3].Value = item.Spravochnaya.FIO;
                ws.Cells[curRow, 4].Value = item.Kolichestvo;
                ws.Cells[curRow, 5].Value = item.Cena;
                ws.Cells[curRow, 6].Value = item.Cena * item.Kolichestvo;
                sum += item.Kolichestvo * item.Cena;

                curRow++;
            }
            ws.Cells[curRow, 1].Value = "Итого: ";
            ws.Cells[curRow, 6].Value = sum;
            Excel.Range range = ws.Range[ws.Cells[curRow, 1], ws.Cells[curRow, 5]];
            range.Merge();
            Excel.Range ran = ws.Range[ws.Cells[3, 1], ws.Cells[curRow, 6]];
            ran.Borders.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
            ws.Columns.AutoFit();
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = System.IO.Path.Combine(desktopPath, "Ведомость отгрузки продукции предприятием");
            wb.SaveAs(filePath);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
        }

        private void PDFBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Document doc = new Document();
                PdfWriter.GetInstance(doc, new FileStream("Ведомость.pdf", FileMode.Create));
                doc.Open();
                BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);
                PdfPTable table = new PdfPTable(6);
                PdfPCell cell = new PdfPCell(new Phrase("Ведомость поставки товаров", font));
                cell.Colspan = 6;
                cell.HorizontalAlignment = 1;
                cell.Border = 0;
                table.AddCell(cell);
                table.AddCell(new PdfPCell(new Phrase(new Phrase("Наименование продукции", font))));
                table.AddCell(new PdfPCell(new Phrase(new Phrase("Наименование предприятия", font))));
                table.AddCell(new PdfPCell(new Phrase(new Phrase("ФИО директора", font))));
                table.AddCell(new PdfPCell(new Phrase(new Phrase("Кол-во", font))));
                table.AddCell(new PdfPCell(new Phrase(new Phrase("Цена", font))));
                table.AddCell(new PdfPCell(new Phrase(new Phrase("Стоимость", font))));
                int sum = 0;
                foreach (var item in Class1.context.Ychetnai.ToList())
                {
                    table.AddCell(new Phrase(item.Naimenovanit_Prodykcie.ToString(), font));
                    table.AddCell(new Phrase(item.Spravochnaya.Naimenovani.ToString(), font));
                    table.AddCell(new Phrase(item.Spravochnaya.FIO.ToString(), font));
                    table.AddCell(new Phrase(item.Kolichestvo.ToString(), font));
                    table.AddCell(new Phrase(item.Cena.ToString(), font));
                    table.AddCell(new Phrase((item.Cena * item.Kolichestvo).ToString(), font));
                    sum += item.Cena * item.Kolichestvo;
                }
                table.AddCell(new PdfPCell(new Phrase("Итого: ", font)) { Colspan = 5 });
                table.AddCell(new Phrase(sum.ToString(), font));
                doc.Add(table);
                doc.Close();
                MessageBox.Show("PDF-документ сохранён");
            }
            catch
            {
                MessageBox.Show("PDF-документ не сохранён", "Ошибка");
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            nav.MainPage.GoBack();
        }
    }
    }

