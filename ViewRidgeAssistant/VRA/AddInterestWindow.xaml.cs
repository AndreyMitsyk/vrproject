using System.Collections.Generic;
using System.Windows;
using VRA.BusinessLayer;
using VRA.Dto;

namespace VRA
{
    /// <summary>
    /// Логика взаимодействия для AddInterestsWindow.xaml
    /// </summary>
    public partial class AddInterestWindow
    {
        private readonly IList<CustomerDto> CustomerList = ProcessFactory.GetCustomerProcess().GetList();
        private readonly IList<ArtistDto> ArtistList = ProcessFactory.GetArtistProcess().GetList();

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

            InterestsDto interest = new InterestsDto
            {
                Artist = this.cbArtist.SelectedItem as ArtistDto,
                Customer = this.cbCustomer.SelectedItem as CustomerDto
            };

            IInterestsProcess interestProcess = new InterestsProcessDb();

            interestProcess.Add(interest);

            this.Close();
        }
    }
}
