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
using VRA.Dto;
using VRA.BusinessLayer;

namespace VRA
{
    /// <summary>
    /// Логика взаимодействия для AddNationWindow.xaml
    /// </summary>
    public partial class AddNationWindow : Window
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

            NationDto Nation = new NationDto();
            Nation.Nationality = this.tbNation.Text;

            INationProcess Process = new NationProcess();
            Process.Add(Nation);
            this.Close();
        }
    }
}
