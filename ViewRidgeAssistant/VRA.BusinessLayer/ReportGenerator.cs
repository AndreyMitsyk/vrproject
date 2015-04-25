using System;
using System.Collections.Generic;
using System.Linq;
using VRA.Dto;
using Excel = Microsoft.Office.Interop.Excel;

namespace VRA.BusinessLayer
{
    public class ReportGenerator : IReportGenerator
    {

        public void fillExcelTableByType(IEnumerable<object> grid, string status)
        {
            Excel.Application ExcelApp = new Excel.Application();
            Excel.Workbook ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet excel = (Excel.Worksheet)ExcelWorkBook.Worksheets.Item[1];


            int x = 1;
            int y = 1;

            // первая строка (шапка таблицы) -- жирным стилем
            excel.Cells[y, 1].EntireRow.Font.Bold = true;

            // вырванивание ткста в ячейках -- по левому краю
            excel.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            // формат ячеек -- текстовой
            excel.Cells.NumberFormat = "@";

            /* Пример с перебором Properties объекта. Данный пример демонстрирует, как можно
             * перебирая объявленные в данном классе property, записывать их в Excel. 
             * При этом, последовательность полей соответствует последовательности их
             * объявления в соответствующем используемом классе.
             * Данный вариант удобен автоматическим добавлением новых / удалением полей в итоговой таблице 
             * при изменении целевого класса. */

            Object dtObj = new Object(); // пустой объект для получения списка property

            switch (status)
            {
                case "Customer":
                    dtObj = new CustomerDto();
                    break;
                case "Artist":
                    dtObj = new ArtistDto();
                    break;
                case "Work":
                    dtObj = new WorkDto();
                    break;
                case "Trans":
                    dtObj = new TransactionDto();
                    break;
                case "Interests":
                    dtObj = new InterestsDto();
                    break;
                case "Nations":
                    dtObj = new NationDto();
                    break;
            }

            // генерация шапки таблицы
            foreach (var prop in dtObj.GetType().GetProperties())
            {
                excel.Cells[y, x] = prop.Name.Trim();
                x++;
            }

            // генерация строк-записей таблицы
            foreach (var item in grid)
            {
                y++;

                Object itemObj = item; // объект-контейнер для текущего читаемого элемента

                x = 1;
                foreach (var prop in itemObj.GetType().GetProperties())
                {
                    object t = prop.GetValue(itemObj, null);

                    String val;

                    if (t == null)
                        val = "";
                    else
                    {
                        val = t.ToString();
                        // Если тип сложный, то вытаскиваем нужное поле.
                        if (t is NationDto)
                            val = ((NationDto)t).Nationality;
                        if (t is ArtistDto)
                            val = ((ArtistDto)t).Name;
                        if (t is CustomerDto)
                            val = ((CustomerDto)t).Name;
                        if (t is WorkDto)
                            val = ((WorkDto)t).Title;
                    }
                    excel.Cells[y, x] = val.Trim();
                    x++;
                }
            }
            ExcelApp.Visible = true;
        }

        public string genHtmlWorksInGallery(string rep)
        {
            List<object> works = ProcessFactory.GetWorkProcess().GetListInGallery().Cast<object>().ToList();
            List<object> trans = ProcessFactory.GetTransactionProcess().GetListInGallery().Cast<object>().ToList();

            string res_html = "<tr><td><b>Код</b></td><td><b>Название</b></td><td><b>Художник</b></td><td><b>Цена</b></td><td><b>Описание</b></td></tr>";

            foreach (var w_item in works)
            {
                WorkDto WorkItem = (WorkDto)w_item;
                foreach (var t_item in trans)
                {
                    TransactionDto TransItem = (TransactionDto)t_item;
                    if ((WorkItem.Id == TransItem.Work.Id) && (TransItem.Customer == null))
                    {
                        ArtistDto ArtistItem = ProcessFactory.GetArtistProcess().Get(WorkItem.Artist.Id);

                        res_html += "<tr><td><p>" + WorkItem.Id + "</p></td>";
                        res_html += "<td><p>" + WorkItem.Title + "</p></td>";
                        res_html += "<td><p>" + ArtistItem.Name + "</p></td>";
                        res_html += "<td><p>" + TransItem.AskingPrice + "</p></td>";
                        res_html += "<td><p>" + (WorkItem.Description ?? "") + "</p></td></tr>";
                    }
                }
            }
            res_html = rep.Replace("[VRA_TABLE_REPORT]", res_html);
            return res_html;
        }
    }
}