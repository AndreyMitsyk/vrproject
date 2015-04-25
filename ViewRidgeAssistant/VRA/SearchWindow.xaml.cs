using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using VRA.BusinessLayer;
using VRA.Dto;

namespace VRA
{
    /// <summary>
    /// Логика взаимодействия для SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow
    {
        private readonly IList<NationDto> AllowNations = ProcessFactory.GetNationProcess().GetList();
        private readonly IList<ArtistDto> AllowArtists = ProcessFactory.GetArtistProcess().GetList();
        private readonly IList<CustomerDto> AllowCustomers = ProcessFactory.GetCustomerProcess().GetList();
        private readonly IList<WorkDto> AllowWorks = ProcessFactory.GetWorkProcess().GetList();
        public IList<CustomerDto> FindedCustomers;
        public IList<ArtistDto> FindedArtists;
        public IList<WorkDto> FindedWorks;
        public IList<InterestsDto> FindedInterests;
        public IList<TransactionDto> FindedTransactions;

        public bool exec;

        public SearchWindow()
        {
            InitializeComponent();
        }

        public SearchWindow(string status)
        {
            InitializeComponent();

            this.cbArtistName.ItemsSource = AllowArtists;
            this.cbArtistCountry.ItemsSource = AllowNations;

            this.cbWorkNameT.ItemsSource = AllowWorks;
            this.cbCustomerNameT.ItemsSource = AllowCustomers;

            switch (status)
            {
                case "Artist":
                    this.SearchTab.SelectedIndex = 1;
                    this.sCustomer.Visibility = Visibility.Collapsed;
                    this.sWork.Visibility = Visibility.Collapsed;
                    this.tiInterests.Visibility = Visibility.Collapsed;
                    this.sTransaction.Visibility = Visibility.Collapsed;
                    break;

                case "Customer":
                    this.SearchTab.SelectedIndex = 0;
                    this.sArtist.Visibility = Visibility.Collapsed;
                    this.sWork.Visibility = Visibility.Collapsed;
                    this.tiInterests.Visibility = Visibility.Collapsed;
                    this.sTransaction.Visibility = Visibility.Collapsed;
                    break;

                case "Work":
                    this.SearchTab.SelectedIndex = 2;
                    this.sCustomer.Visibility = Visibility.Collapsed;
                    this.sArtist.Visibility = Visibility.Collapsed;
                    this.tiInterests.Visibility = Visibility.Collapsed;
                    this.sTransaction.Visibility = Visibility.Collapsed;
                    break;

                case "Interests":
                    this.SearchTab.SelectedIndex = 3;
                    this.sWork.Visibility = Visibility.Collapsed;
                    this.sCustomer.Visibility = Visibility.Collapsed;
                    this.sArtist.Visibility = Visibility.Collapsed;
                    this.sTransaction.Visibility = Visibility.Collapsed;
                    break;

                case "Trans":
                    this.SearchTab.SelectedIndex = 4;
                    this.sWork.Visibility = Visibility.Collapsed;
                    this.sCustomer.Visibility = Visibility.Collapsed;
                    this.sArtist.Visibility = Visibility.Collapsed;
                    this.tiInterests.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void CloseForm(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SearchCustomer(object sender, RoutedEventArgs e)
        {
            this.FindedCustomers = ProcessFactory.GetCustomerProcess().SearchCustomer(this.CustomerName.Text, this.CustomerCountry.Text, this.CustomerCity.Text);
            this.exec = true;
            this.Close();
        }

        private void SearchArtist(object sender, RoutedEventArgs e)
        {
            this.FindedArtists = ProcessFactory.GetArtistProcess().SearchArtist(this.ArtistName.Text, this.cbArtistCountry.Text);
            this.exec = true;
            this.Close();
        }

        private void SearshWork(object sender, RoutedEventArgs e)
        {
            this.FindedWorks = ProcessFactory.GetWorkProcess().SearchWork(this.WorkTitle.Text, this.cbArtistName.Text, this.Copy.Text);
            this.exec = true;
            this.Close();
        }

        private void SearchInterests(object sender, RoutedEventArgs e)
        {
            IEnumerable<InterestsDto> AllInterests = ProcessFactory.GetInterestsProcess().GetList();

            IEnumerable<InterestsDto> interests = from I in AllInterests where (I.Artist.Name.Contains(this.tbIArtistName.Text) && I.Customer.Name.Contains(this.tbICustomerName.Text)) select I;

            this.FindedInterests = interests.ToList();
            this.exec = true;
            this.Close();
        }

        private void SearchTransaction(object sender, RoutedEventArgs e)
        {
            IEnumerable<TransactionDto> AllTransactions = ProcessFactory.GetTransactionProcess().GetList();
            IEnumerable<TransactionDto> transactions = null;

            if (this.RBcustomerSearch.IsChecked == true)
            {
                try
                {
                    CustomerDto D = (CustomerDto)this.cbCustomerNameT.SelectedItem;
                    transactions = from T in AllTransactions where (T.Customer.Id == D.Id) select T;
                }
                catch (Exception)
                {
                    MessageBox.Show("Выберите клиента для поиска!"); return;
                }
            }

            if (this.RBworkSearch.IsChecked == true)
            {
                try
                {
                    WorkDto W = (WorkDto)this.cbWorkNameT.SelectedItem;
                    transactions = from T in AllTransactions where (T.Work.Id == W.Id) select T;
                }
                catch (Exception)
                {
                    MessageBox.Show("Выберите картину для поиска!"); return;
                }
            }

            if (this.RBpriceSearch.IsChecked == true)
            {
                try
                {
                    transactions = from T in AllTransactions where (T.SalesPrice >= Convert.ToDecimal(this.tbSalesPrice.Text)) select T;
                }
                catch (Exception)
                {
                    MessageBox.Show("Введите нижнюю границу цены для поиска!"); return;
                }
            }

            if (this.RBacquiredSearch.IsChecked == true)
            {
                try
                {
                    transactions = from T in AllTransactions where (T.DateAcquired >= this.dpStartDateAcquired.DisplayDate && T.DateAcquired <= this.dpStoptDateAcquired.DisplayDate) select T;
                }
                catch (Exception)
                {
                    MessageBox.Show("Введите пределы для поиска по дате!");
                }
            }

            if (RBsaleSearch.IsChecked == true)
            {
                try
                {
                    transactions = from T in AllTransactions where (T.PurchaseDate >= this.dpStartSaleDate.DisplayDate & T.PurchaseDate <= this.dpStoptSaleDate.DisplayDate) select T;
                }
                catch (Exception)
                {
                    MessageBox.Show("Введите пределы для поиска по дате!");
                }
            }

            if (transactions != null) this.FindedTransactions = transactions.ToList();
            this.exec = true;
            this.Close();

        }

        private void RBcustomerSearch_Checked(object sender, RoutedEventArgs e)
        {
            this.cbCustomerNameT.IsEnabled = true;

            this.cbWorkNameT.IsEnabled = false;
            this.tbSalesPrice.IsEnabled = false;
            this.dpStartDateAcquired.IsEnabled = false;
            this.dpStoptDateAcquired.IsEnabled = false;
            this.dpStartSaleDate.IsEnabled = false;
            this.dpStoptSaleDate.IsEnabled = false;
        }

        private void RBartistSearch_Checked(object sender, RoutedEventArgs e)
        {
            this.cbWorkNameT.IsEnabled = true;

            this.cbCustomerNameT.IsEnabled = false;
            this.tbSalesPrice.IsEnabled = false;
            this.dpStartDateAcquired.IsEnabled = false;
            this.dpStoptDateAcquired.IsEnabled = false;
            this.dpStartSaleDate.IsEnabled = false;
            this.dpStoptSaleDate.IsEnabled = false;
        }

        private void RBpriceSearch_Checked(object sender, RoutedEventArgs e)
        {
            this.tbSalesPrice.IsEnabled = true;

            this.cbCustomerNameT.IsEnabled = false;
            this.cbWorkNameT.IsEnabled = false;
            this.dpStartDateAcquired.IsEnabled = false;
            this.dpStoptDateAcquired.IsEnabled = false;
            this.dpStartSaleDate.IsEnabled = false;
            this.dpStoptSaleDate.IsEnabled = false;
        }

        private void RBsaleSearch_Checked(object sender, RoutedEventArgs e)
        {
            this.dpStartSaleDate.IsEnabled = true;
            this.dpStoptSaleDate.IsEnabled = true;

            this.dpStartDateAcquired.IsEnabled = false;
            this.dpStoptDateAcquired.IsEnabled = false;
            this.cbCustomerNameT.IsEnabled = false;
            this.cbWorkNameT.IsEnabled = false;
            this.tbSalesPrice.IsEnabled = false;
        }

        private void RBacquiredSearch_Checked(object sender, RoutedEventArgs e)
        {
            this.dpStartDateAcquired.IsEnabled = true;
            this.dpStoptDateAcquired.IsEnabled = true;

            this.cbCustomerNameT.IsEnabled = false;
            this.cbWorkNameT.IsEnabled = false;
            this.tbSalesPrice.IsEnabled = false;
            this.dpStartSaleDate.IsEnabled = false;
            this.dpStoptSaleDate.IsEnabled = false;
        }
    }
}
