using System;
using System.Collections.Generic;
using System.Windows;
using System.Collections.ObjectModel;
using VRA.Dto;
using VRA.BusinessLayer;
using System.Windows.Forms.DataVisualization.Charting;

namespace VRA
{
    /// <summary>
    /// Логика взаимодействия для ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow
    {
        private ObservableCollection<ReportItemDto> collection = new ObservableCollection<ReportItemDto>();

        private readonly List<decimal> axisYDataSales = new List<decimal>();
        private readonly List<decimal> axisYDataPurchase = new List<decimal>();
        private readonly List<string> axisXData = new List<string>();

        private void DateCompare()
        {
            if ((Convert.ToDateTime(datePicker1.Text)) >= Convert.ToDateTime(datePicker2.Text))
            {
                MessageBox.Show("Дата окончания интервала запроса \n меньше либо равна дате начала");
            }
        }

        /// <summary>
        /// Действия при загрузке формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Т.к. все графики находятся в пределах области построения, создадим ее.
            chart.ChartAreas.Add(new ChartArea("Default"));

            // Добавим график, и назначим его в ранее созданную область "Default".
            chart.Series.Add(new Series("Проданные"));
            chart.Series["Проданные"].ChartArea = "Default";
            chart.Series.Add(new Series("Купленные"));
            chart.Series["Купленные"].ChartArea = "Default";

            // Определяем легенду.
            chart.Legends.Add(new Legend("Legend"));
            chart.Legends["Legend"].DockedToChartArea = "Default";
            chart.Series["Проданные"].Legend = "Legend";
            chart.Series["Купленные"].Legend = "Legend";
            chart.Series["Купленные"].IsVisibleInLegend = false;
            chart.Series["Проданные"].IsVisibleInLegend = false;

            // Загрузка данных по умолчанию.
            IList<TransactionDto> transaction = ProcessFactory.GetTransactionProcess().GetList();
            datePicker1.Text = transaction[0].DateAcquired.ToString();
            datePicker2.Text = transaction[transaction.Count - 1].DateAcquired.ToString();
            btn_accept_Click(sender, e);
        }

        /// <summary>
        /// Выбор типа графика.
        /// </summary>
        private void GraphType()
        {
            if (radioGist.IsChecked != null && radioGist.IsChecked.Value)
            {
                // Определяем вид графиков.
                chart.Series["Проданные"].ChartType = SeriesChartType.Column;
                chart.Series["Купленные"].ChartType = SeriesChartType.Column;
            }

            if (radioSpline.IsChecked != null && radioSpline.IsChecked.Value)
            {
                // Определяем вид графиков.
                chart.Series["Проданные"].ChartType = SeriesChartType.Line;
                chart.Series["Купленные"].ChartType = SeriesChartType.Line;
            }
        }

        /// <summary>
        /// Построение графиков.
        /// </summary>
        private void DrawGraph()
        {
            // Очищаем старые данные.
            axisXData.Clear();
            chart.Series["Проданные"].Points.Clear();
            chart.Series["Купленные"].Points.Clear();

            // Добавляем подписи по оси X.
            foreach (var item in collection)
            {
                axisXData.Add(item.date);
            }

            // Настраиваем легенду.
            if ((axisYDataSales.Count != 0) & (axisYDataPurchase.Count != 0))
            {
                chart.Series["Купленные"].IsVisibleInLegend = true;
                chart.Series["Проданные"].IsVisibleInLegend = true;
            }
            else
            {
                chart.Series["Купленные"].IsVisibleInLegend = false;
                chart.Series["Проданные"].IsVisibleInLegend = false;
            }

            // Строим графики.
            if (axisYDataSales.Count != 0)
                chart.Series["Проданные"].Points.DataBindXY(axisXData, axisYDataSales);

            if (axisYDataPurchase.Count != 0)
                chart.Series["Купленные"].Points.DataBindXY(axisXData, axisYDataPurchase);
        }

        private void FillCollection()
        {
            axisYDataSales.Clear();
            axisYDataPurchase.Clear();
            if (radioSales.IsChecked != null && radioSales.IsChecked.Value)
            {
                // если запрошена статистика по проданным

                if (radioDay.IsChecked != null && radioDay.IsChecked.Value)
                {
                    TimeSpan ts = (Convert.ToDateTime(datePicker2.Text)).Subtract(Convert.ToDateTime(datePicker1.Text));

                    if (ts.Days > 30)
                    {
                        MessageBox.Show(
                            "Выбранный Вами период времени слишком велик! \n Максимальная длинна периода - 30 дней ");
                        datePicker2.Text = Convert.ToDateTime(datePicker1.Text).Date.AddDays(30).ToString();
                    }

                    collection.Clear();
                    collection = ProcessFactory.GetReportProcess()
                        .GetSaled("day", Convert.ToDateTime(datePicker1.Text), Convert.ToDateTime(datePicker2.Text));
                }

                if (radioMounth.IsChecked != null && radioMounth.IsChecked.Value)
                {
                    TimeSpan ts = (Convert.ToDateTime(datePicker2.Text)).Subtract(Convert.ToDateTime(datePicker1.Text));

                    if (ts.Days/30 > 12)
                    {
                        MessageBox.Show(
                            "Выбранный Вами период времени слишком велик! \n Максимальная длинна периода - 12 месяцев ");
                        datePicker2.Text = Convert.ToDateTime(datePicker1.Text).Date.AddMonths(12).ToString();
                    }

                    collection.Clear();
                    collection = ProcessFactory.GetReportProcess()
                        .GetSaled("month", Convert.ToDateTime(datePicker1.Text), Convert.ToDateTime(datePicker2.Text));
                }

                if (radioYear.IsChecked != null && radioYear.IsChecked.Value)
                {
                    TimeSpan ts = (Convert.ToDateTime(datePicker2.Text)).Subtract(Convert.ToDateTime(datePicker1.Text));

                    if (ts.Days/(30*12) > 10)
                    {
                        MessageBox.Show(
                            "Выбранный Вами период времени слишком велик! \n Максимальная длинна периода - 10 лет ");
                        datePicker2.Text = Convert.ToDateTime(datePicker1.Text).Date.AddYears(10).ToString();
                    }


                    collection.Clear();
                    collection = ProcessFactory.GetReportProcess()
                        .GetSaled("year", Convert.ToDateTime(datePicker1.Text), Convert.ToDateTime(datePicker2.Text));

                }

                // Заполнение коллекции проданных
                foreach (var item in collection)
                {
                    axisYDataSales.Add(item.price);
                }
            }
            if (radioPurchase.IsChecked != null && radioPurchase.IsChecked.Value)
            {
                // если запрашивают статистику по купленным

                if (radioDay.IsChecked != null && radioDay.IsChecked.Value)
                {
                    TimeSpan ts = (Convert.ToDateTime(datePicker2.Text)).Subtract(Convert.ToDateTime(datePicker1.Text));

                    if (ts.Days > 30)
                    {
                        MessageBox.Show(
                            "Выбранный Вами период времени слишком велик! \n Максимальная длинна периода - 30 дней ");
                        datePicker2.Text = Convert.ToDateTime(datePicker1.Text).Date.AddDays(30).ToString();
                    }

                    collection.Clear();
                    collection = ProcessFactory.GetReportProcess()
                        .GetPurchased("day", Convert.ToDateTime(datePicker1.Text), Convert.ToDateTime(datePicker2.Text));
                }

                if (radioMounth.IsChecked != null && radioMounth.IsChecked.Value)
                {
                    TimeSpan ts = (Convert.ToDateTime(datePicker2.Text)).Subtract(Convert.ToDateTime(datePicker1.Text));

                    if (ts.Days/30 > 12)
                    {
                        MessageBox.Show(
                            "Выбранный Вами период времени слишком велик! \n Максимальная длинна периода - 12 месяцев ");
                        datePicker2.Text = Convert.ToDateTime(datePicker1.Text).Date.AddMonths(12).ToString();
                    }

                    collection.Clear();
                    collection = ProcessFactory.GetReportProcess()
                        .GetPurchased("month", Convert.ToDateTime(datePicker1.Text),
                            Convert.ToDateTime(datePicker2.Text));
                }

                if (radioYear.IsChecked != null && radioYear.IsChecked.Value)
                {
                    TimeSpan ts = (Convert.ToDateTime(datePicker2.Text)).Subtract(Convert.ToDateTime(datePicker1.Text));

                    if (ts.Days/(30*12) > 10)
                    {
                        MessageBox.Show(
                            "Выбранный Вами период времени слишком велик! \n Максимальная длинна периода - 10 лет ");
                        datePicker2.Text = Convert.ToDateTime(datePicker1.Text).Date.AddYears(10).ToString();
                    }


                    collection.Clear();
                    collection = ProcessFactory.GetReportProcess()
                        .GetPurchased("year", Convert.ToDateTime(datePicker1.Text), Convert.ToDateTime(datePicker2.Text));
                }

                // Заполнение коллекции купленных
                foreach (var item in collection)
                {
                    axisYDataPurchase.Add(item.price);
                }
            }
        }

        public ReportWindow()
        {
            InitializeComponent();
        }

        private void btn_accept_Click(object sender, RoutedEventArgs e)
        {
            DateCompare();
            FillCollection();
            GraphType();
            DrawGraph();
        }

    }
}
