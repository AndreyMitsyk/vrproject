using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRA.Dto;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace VRA.BusinessLayer
{
    public class ReportGenerator
    {
        public void fillExcelTableByType(List<object> grid, string status)
        {
            Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook ExcelWorkBook;
            Excel.Worksheet excel;
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            excel = (Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);

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
             * Данный вариант удобен автоматическим добавлением новых / удалением полей
             * в итоговой таблице при изменении целевого класса. */

            Object dtObj = new Object(); // пустой объект для получения списка property
            Object itemObj = new Object(); // объект-контейнер для текущего читаемого элемента

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
            }

            // генерация шапки таблицы
            foreach (var prop in dtObj.GetType().GetProperties())
            {
                x++;
                excel.Cells[y, x] = prop.Name.Trim();
            }

            // генерация строк-записей таблицы
            foreach (var item in grid)
            {
                y++;
                switch (status)
                {
                    case "Customer":
                        itemObj = (CustomerDto)item;
                        break;
                    case "Artist":
                        itemObj = (ArtistDto)item;
                        break;
                    case "Work":
                        itemObj = (WorkDto)item;
                        break;
                    case "Trans":
                        itemObj = (TransactionDto)item;
                        break;
                    case "Interests":
                        itemObj = (InterestsDto)item;
                        break;
                }

                x = 1;
                String val = "";
                foreach (var prop in itemObj.GetType().GetProperties())
                {
                    x++;
                    object t = prop.GetValue(itemObj, null);

                    if (t != null && t.GetType() == typeof(NationDto)) // здесь начинается
                    {
                        NationDto temp = (NationDto)t; // Костыль, который подпирает национальность художника
                        val = temp.Nationality.ToString(); // Костыль поставил @MrAnderson
                    }
                    else
                    {
                        val = (t == null) ? "" : t.ToString();
                    }
                    excel.Cells[y, x] = val.Trim();
                }
            }
            ExcelApp.Visible = true;
        }

        public string genHtmlWorksInGallery(string rep)
        {
            string res_html = "";

            List<object> works = ProcessFactory.GetWorkProcess().GetListInGallery().Cast<object>().ToList();
            List<object> trans = ProcessFactory.GetTransactionProcess().GetListInGallery().Cast<object>().ToList();

            WorkDto WorkItem = null;
            TransactionDto TransItem = null;
            ArtistDto ArtistItem = null;

            res_html = "<tr><td><b>Код</b></td><td><b>Название</b></td><td><b>Художник</b></td><td><b>Цена</b></td><td><b>Описание</b></td></tr>";

            foreach (var w_item in works)
            {
                WorkItem = (WorkDto)w_item;
                foreach (var t_item in trans)
                {
                    TransItem = (TransactionDto)t_item;
                    if ((WorkItem.Id == TransItem.Work.Id) && (TransItem.Customer == null))
                    {
                        ArtistItem = ProcessFactory.GetArtistProcess().Get(WorkItem.Artist.Id);

                        res_html += "<tr><td>" + WorkItem.Id.ToString() + "</td>";
                        res_html += "<td>" + WorkItem.Title.ToString() + "</td>";
                        res_html += "<td>" + ArtistItem.Name.ToString() + "</td>";
                        res_html += "<td>" + TransItem.AskingPrice.ToString() + "</td>";
                        res_html += "<td>" + ((WorkItem.Description != null) ? WorkItem.Description.ToString() : "") + "</td></tr>";
                    }
                }
            }
            res_html = rep.Replace("[VRA_TABLE_REPORT]", res_html);
            return res_html;
        }
    }
}
