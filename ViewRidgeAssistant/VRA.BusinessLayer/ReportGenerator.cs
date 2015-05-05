using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Threading;
using System.Windows;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using VRA.Dto;

namespace VRA.BusinessLayer
{
    public class ReportGenerator : IReportGenerator
    {

        public void fillExcelTableByType(IEnumerable<object> grid, string status, FileInfo xlsxFile)
        {
            if (grid != null)
            {
                ExcelPackage pck = new ExcelPackage(xlsxFile);

                var excel = pck.Workbook.Worksheets.Add(status);

                int x = 1;
                int y = 1;

                // Устанавливает фиксированный десятичный разделитель (нужно для верного распознавания типа данных Excel'ем) 
                CultureInfo cultureInfo = new CultureInfo(Thread.CurrentThread.CurrentCulture.Name);
                Thread.CurrentThread.CurrentCulture = cultureInfo;
                cultureInfo.NumberFormat.NumberDecimalSeparator = ".";

                // первая строка (шапка таблицы) -- жирным стилем
                excel.Cells["A1:Z1"].Style.Font.Bold = true;


                // вырванивание текста в ячейках -- по левому краю
                excel.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                // Устанавливает формат ячеек
                excel.Cells.Style.Numberformat.Format = "General";

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
                    excel.Cells[y, x].Value = prop.Name.Trim();
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
                        object val;

                        if (t == null)
                            val = "";
                        else
                        {
                            val = t.ToString();
                            // Если тип сложный, то вытаскиваем нужное поле.
                            if (t is NationDto)
                                val = ((NationDto) t).Nationality;
                            if (t is ArtistDto)
                                val = ((ArtistDto) t).Name;
                            if (t is CustomerDto)
                                val = ((CustomerDto) t).Name;
                            if (t is WorkDto)
                                val = ((WorkDto) t).Title;
                        }
                        excel.Cells[y, x].Value = val;
                        x++;
                    }
                }
                // Устанавливаем размер колонок по ширине содержимого.
                excel.Cells.AutoFitColumns();

                // Сохраняем файл.
                pck.Save();
            }
            else MessageBox.Show("Данные не загружены!");
        }

        public string genHtmlWorksInGallery(string rep)
        {
            List<object> works = ProcessFactory.GerWorksInGalleryProcess().GetList().Cast<object>().ToList();

            string res_html =
                "<tr><td><b>Код</b></td><td><b>Название</b></td><td><b>Художник</b></td><td><b>Цена</b></td><td><b>Описание</b></td></tr>";

            foreach (var work in works)
            {
                WorksInGalleryDto WorkItem = (WorksInGalleryDto) work;
                res_html += "<tr><td><p>" + WorkItem.Id + "</p></td>";
                // Если заполнено поле "Копия", то дописываем его к имени.
                res_html += WorkItem.Work.Copy != string.Empty
                    ? "<td><p>" + WorkItem.Work.Title + " (" + WorkItem.Work.Copy + ")" + "</p></td>"
                    : "<td><p>" + WorkItem.Work.Title + "</p></td>";

                res_html += "<td><p>" + WorkItem.Artist.Name + "</p></td>";
                res_html += "<td><p>" + WorkItem.AskingPrice + "</p></td>";
                res_html += "<td><p>" + (WorkItem.Work.Description ?? "") + "</p></td></tr>";
            }
            res_html = rep.Replace("[VRA_TABLE_REPORT]", res_html);
            return res_html;
        }
    }
}