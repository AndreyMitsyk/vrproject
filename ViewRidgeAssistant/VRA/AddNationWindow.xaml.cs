using System.Windows;
using VRA.Dto;
using VRA.BusinessLayer;

namespace VRA
{
    /// <summary>
    /// Логика взаимодействия для AddNationWindow.xaml
    /// </summary>
    public partial class AddNationWindow
    {
        public AddNationWindow()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.tbNation.Text))
            {
                MessageBox.Show("Введите национальность!"); return;
            }

            NationDto Nation = new NationDto {Nationality = this.tbNation.Text};

            INationProcess Process = new NationProcess();
            Process.Add(Nation);
            this.Close();
        }
    }
}
