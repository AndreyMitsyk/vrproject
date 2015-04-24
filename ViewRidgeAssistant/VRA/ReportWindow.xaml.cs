using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using VRA.Dto;
using VRA.BusinessLayer;
using System.Windows.Controls.DataVisualization.Charting;

namespace VRA
{
    /// <summary>
    /// Логика взаимодействия для ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        public ObservableCollection<ReportItemDto> collection = new ObservableCollection<ReportItemDto>();

        private void DateCompare()
        {
            if ((Convert.ToDateTime(datePicker1.Text)) >= Convert.ToDateTime(datePicker2.Text))
            {
                MessageBox.Show("Дата окончания интервала запроса \n меньше либо равна дате начала"); return;
            }
        }

        private void GraphDraw()
        {
            if (radioGist.IsChecked.Value)
            {
                LineChart.Visibility = Visibility.Hidden;
                ColumnChart.ItemsSource = collection;
                ColumnChart.Visibility = Visibility.Visible;
            }

            if (radioSpline.IsChecked.Value)
            {
                ColumnChart.Visibility = Visibility.Hidden;
                LineChart.ItemsSource = collection;
                LineChart.Visibility = Visibility.Visible;
            }
        }

        private void FillCollection()
        {
            if (radioSales.IsChecked.Value)
            {
                // если запрошена статистика по проданным
                if (radioDay.IsChecked.Value)
                {
                    TimeSpan ts = datePicker2.DisplayDate.Subtract(Convert.ToDateTime(datePicker1.Text));

                    if (ts.Days > 10)
                    {
                        MessageBox.Show("Выбранный Вами период времени слишком велик! \n Максимальная длинна периода - 10 дней "); return;
                    }

                    collection.Clear();
                    collection = ProcessFactory.GetReportProcess().GetSaled("day", Convert.ToDateTime(datePicker1.Text), Convert.ToDateTime(datePicker2.Text));
                }

                if (radioMounth.IsChecked.Value)
                {
                    int month = (datePicker1.DisplayDate - Convert.ToDateTime(datePicker1.Text)).Days / 30;

                    if (month > 10)
                    {
                        MessageBox.Show("Выбранный Вами период времени слишком велик! \n Максимальная длинна периода - 10 дней "); return;
                    }

                    collection.Clear();
                    collection = ProcessFactory.GetReportProcess().GetSaled("month", Convert.ToDateTime(datePicker1.Text), Convert.ToDateTime(datePicker2.Text));
                }

                if (radioYear.IsChecked.Value)
                {
                    int year = (datePicker1.DisplayDate - Convert.ToDateTime(datePicker1.Text)).Days / (30 * 12);
                    {
                        if (year > 10)
                        {
                            MessageBox.Show("Выбранный Вами период времени слишком велик! \n Максимальная длинна периода - 10 дней "); return;
                        }
                    }

                    collection.Clear();
                    collection = ProcessFactory.GetReportProcess().GetSaled("year", Convert.ToDateTime(datePicker1.Text), Convert.ToDateTime(datePicker2.Text));
                }
            }
            else
            {
                // если запрашивают статистику по купленным

                // если запрошена статистика по проданным
                if (radioDay.IsChecked.Value)
                {
                    TimeSpan ts = datePicker2.DisplayDate.Subtract(Convert.ToDateTime(datePicker1.Text));

                    if (ts.Days > 10)
                    {
                        MessageBox.Show("Выбранный Вами период времени слишком велик! \n Максимальная длинна периода - 10 дней "); return;
                    }

                    collection.Clear();
                    collection = ProcessFactory.GetReportProcess().GetPurchased("day", Convert.ToDateTime(datePicker1.Text), Convert.ToDateTime(datePicker2.Text));
                }

                if (radioMounth.IsChecked.Value)
                {
                    int month = (datePicker1.DisplayDate - Convert.ToDateTime(datePicker1.Text)).Days / 30;

                    if (month > 10)
                    {
                        MessageBox.Show("Выбранный Вами период времени слишком велик! \n Максимальная длинна периода - 10 дней "); return;
                    }

                    collection.Clear();
                    collection = ProcessFactory.GetReportProcess().GetPurchased("month", Convert.ToDateTime(datePicker1.Text), Convert.ToDateTime(datePicker2.Text));
                }

                if (radioYear.IsChecked.Value)
                {
                    int year = (datePicker1.DisplayDate - Convert.ToDateTime(datePicker1.Text)).Days / (30 * 12);

                    {
                        if (year > 10)
                        {
                            MessageBox.Show("Выбранный Вами период времени слишком велик! \n Максимальная длинна периода - 10 дней "); return;
                        }
                    }

                    collection.Clear();
                    collection = ProcessFactory.GetReportProcess().GetPurchased("year", Convert.ToDateTime(datePicker1.Text), Convert.ToDateTime(datePicker2.Text));
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
            GraphDraw();
        }
    }
}
