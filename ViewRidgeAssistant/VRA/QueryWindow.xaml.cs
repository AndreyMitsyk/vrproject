using System;
using System.Windows;
using VRA.BusinessLayer;

namespace VRA
{
    /// <summary>
    /// Логика взаимодействия для QueryWindow.xaml
    /// </summary>
    public partial class QueryWindow
    {
        public QueryWindow()
        {
            InitializeComponent();
        }

        private void btnQuery_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dgResult.ItemsSource = ProcessFactory.GetQueryProcess().Query(tbQuery.Text).DefaultView;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
