using System.Collections.Generic;
using System.Windows;
using System.Text.RegularExpressions;
using VRA.Dto;
using VRA.BusinessLayer;

namespace VRA
{
    /// <summary>
    /// Логика взаимодействия для AddCustomerWindow.xaml
    /// </summary>
    public partial class AddCustomerWindow
    {
        private int _id;

        public void Load(CustomerDto Customer)
        {

            if (Customer == null)
            {
                return;
            }

            _id = Customer.Id;

            tbName.Text = Customer.Name;
            tbE_mail.Text = Customer.Email;
            tbAreaCode.Text = Customer.AreaCode;
            tbTelephone.Text = Customer.PhoneNumber;
            tbStreet.Text = Customer.Street;
            tbCity.Text = Customer.City;
            tbRegion.Text = Customer.Region;
            tbZip.Text = Customer.ZipPostalCode;
            tbCountry.Text = Customer.Country;
            tbHouse.Text = Customer.HouseNumber;

            IEnumerable<InterestsDto> Interests = ProcessFactory.GetInterestsProcess().GetList();

            IList<ArtistDto> Artist = ProcessFactory.GetArtistProcess().GetList();

            foreach (InterestsDto c in Interests)
            {
                if (c.Customer.Id == Customer.Id)
                {
                    foreach (ArtistDto artist in Artist)
                    {
                        if (artist.Id == c.Artist.Id)
                        {
                            this.interestsList.Items.Add(artist.Name);
                        }
                    }
                }
            }
            this.ClientInterests.Visibility = Visibility.Visible;
        }

        public AddCustomerWindow()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            CustomerDto Customer = new CustomerDto();

            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Имя клиента должно быть заполнено!");
                return;
            }

            Customer.Name = tbName.Text;

            if (string.IsNullOrEmpty(tbE_mail.Text))
            {
                MessageBox.Show("Электронная почта клиента должна быть указана!");
                return;
            }


            Customer.Email = tbE_mail.Text;

            if (!string.IsNullOrEmpty(tbZip.Text))
            {
                uint zip;
                if (!uint.TryParse(this.tbZip.Text, out zip))
                {
                    MessageBox.Show("Почтовый индекс введен некорректно!"); return;
                }

                if (zip < 100000 || zip > 999999)
                {
                    MessageBox.Show("Почтовый индекс должен быть шестизначным числом!"); return;
                }
            }

            Customer.ZipPostalCode = tbZip.Text;

            Customer.Country = tbCountry.Text;

            Customer.City = tbCity.Text;

            Customer.Street = tbStreet.Text;

            if (!string.IsNullOrEmpty(this.tbHouse.Text))
            {
                int houseNum;

                if (!int.TryParse(this.tbHouse.Text, out houseNum))
                {
                    MessageBox.Show("Ошибка формата ввода дома клиента"); return;
                }
            }
            Customer.HouseNumber = tbHouse.Text;

            Customer.Region = tbRegion.Text;

            if (!string.IsNullOrEmpty(this.tbAreaCode.Text))
            {
                int AreaCode;

                if (!int.TryParse(this.tbAreaCode.Text, out AreaCode))
                {
                    MessageBox.Show("Введите код региона!"); return;
                }
                if (AreaCode < 100 || AreaCode > 9999)
                {
                    MessageBox.Show("Ошибка формата ввода кода региона"); return;
                }
            }
            Customer.AreaCode = tbAreaCode.Text;

            if (!string.IsNullOrEmpty(this.tbTelephone.Text))
            {
                if (string.IsNullOrEmpty(this.tbTelephone.Text))
                {
                    MessageBox.Show("Телефон клиента должен быть указан!"); return;
                }
            }
            Customer.PhoneNumber = Regex.Replace(tbTelephone.Text, @"[^\w]", "");

            ICustomerProcess CustomerProcess = ProcessFactory.GetCustomerProcess();

            if (_id == 0)
            {
                CustomerProcess.Add(Customer);
            }
            else
            {
                Customer.Id = _id;
                CustomerProcess.Update(Customer);
            }

            this.Close();
        }
    }
}
