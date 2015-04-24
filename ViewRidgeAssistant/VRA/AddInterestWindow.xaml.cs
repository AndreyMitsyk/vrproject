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
using VRA.BusinessLayer;
using VRA.Dto;

namespace VRA
{
    /// <summary>
    /// Логика взаимодействия для AddInterestsWindow.xaml
    /// </summary>
    public partial class AddInterestWindow : Window
    {
        private IList<CustomerDto> CustomerList = ProcessFactory.GetCustomerProcess().GetList();
        private IList<ArtistDto> ArtistList = ProcessFactory.GetArtistProcess().GetList();

        public AddInterestWindow()
        {
            InitializeComponent();
            this.cbArtist.ItemsSource = ArtistList;
            this.cbCustomer.ItemsSource = CustomerList;
        }

        private void btnCancel_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (this.cbArtist.SelectedItem == null)
            {
                MessageBox.Show("Имя художника должно быть указано!"); return;
            }

            if (this.cbCustomer.SelectedItem == null)
            {
                MessageBox.Show("Имя клиента должно быть выбрано!"); return;
            }

            InterestsDto interest = new InterestsDto();

            interest.Artist = this.cbArtist.SelectedItem as ArtistDto;
            interest.Customer = this.cbCustomer.SelectedItem as CustomerDto;

            IInterestsProcess interestProcess = new InterestsProcessDb();

            interestProcess.Add(interest);

            this.Close();
        }
    }
}
