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
using System.Globalization;
using System.Threading;
using VRA.Dto;
using VRA.BusinessLayer;

namespace VRA
{
    /// <summary>
    /// Логика взаимодействия для AddTransactionWindow.xaml
    /// </summary>
    public partial class AddTransactionWindow : Window
    {
        private IList<CustomerDto> Customers = ProcessFactory.GetCustomerProcess().GetList();
        private IList<WorkDto> Works = ProcessFactory.GetWorkProcess().GetList();
        private IList<WorkDto> FreeForSale = ProcessFactory.GetWorkProcess().GetListInGallery(); // выбираем все работы доступные для продаж
        private IList<WorkDto> FreeForPurchase = new List<WorkDto>();

        private int id;
        public string status;

        public void Load(TransactionDto Trans)
        {
            this.Title = "Транзакция: Редактирование";
            this.id = Trans.TransactionID;
            if (Trans.Customer != null)
            {
                this.cbCustomer.Text = Trans.Customer.Name;
            }

            if (Trans.Work.Copy != null)
            {
                this.cbCopy.Text = Trans.Work.Copy;
                this.cbWork.Text = Trans.Work.Title;
            }

            this.tbAcquisitionPrice.Text = Trans.AcquisitionPrice.ToString();
            this.tbAskingPrice.Text = Trans.AskingPrice.ToString();
            this.tbSalesPrice.Text = Trans.SalesPrice.ToString();

            this.dpAcuired.Text = Trans.DateAcquired.ToString();
            this.dpPurchase.Text = Trans.PurchaseDate.ToString();

            this.loadWork(Trans.Work.Title);
        }

        private bool workatGalery(WorkDto work)
        {
            bool result = false;

            foreach (WorkDto w in FreeForSale)
            {
                if (w.Id == work.Id) { result = true; break; }
            }
            return result;
        }

        private void GetWorksWithCustomers()
        {
            foreach (WorkDto w in Works)
            {
                bool inList = false;

                foreach (WorkDto W in FreeForSale)
                {
                    if (W.Id == w.Id)
                    {
                        inList = true; break;
                    }
                }

                if (!inList)
                {
                    this.FreeForPurchase.Add(w);
                }
            }
        }

        private void loadWork(string Title)
        {
            this.cbCopy.Items.Clear();
            foreach (WorkDto work in Works)
            {
                if (work.Title == Title)
                {
                    this.cbCopy.Items.Add(work);
                }
            }
            this.cbCopy.SelectedIndex = 0;
        }

        public AddTransactionWindow()
        {
            //Эти строчки переводят формат даты в удобоваримый вид:
            CultureInfo ci = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
            ci.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";
            Thread.CurrentThread.CurrentCulture = ci;

            InitializeComponent();
            Customers = ProcessFactory.GetCustomerProcess().GetList();
            Works = ProcessFactory.GetWorkProcess().GetList();
            this.cbCustomer.ItemsSource = (from c in Customers orderby c.Name select c);
            this.cbWork.ItemsSource = (from w in Works orderby w.Title select w);
            this.dpAcuired.IsTodayHighlighted = true;
        }

        private WorkDto selectWork()
        {
            WorkDto work = null;
            foreach (WorkDto w in Works)
            {
                if (w.Copy == this.cbCopy.Text && w.Title == this.cbWork.Text)
                { work = w; break; }
            }
            return work;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (status == "sale")
            {
                if (this.cbCustomer.SelectedIndex < 0)
                {
                    MessageBox.Show("Укажите клиента, которому продается картина!"); return;
                }
            }

            TransactionDto transaction = new TransactionDto();
            WorkDto SelectedWork = selectWork();

            if (SelectedWork == null)
            {
                MessageBox.Show("Картина должна быть выбрана!"); return;
            }

            if (status == "sale")
            {
                if (!workatGalery(SelectedWork))
                {
                    MessageBox.Show("Запрашиваемая работа уже продана!"); return;
                }
            }

            if (status == "purchase")
            {
                if (workatGalery(SelectedWork))
                {
                    MessageBox.Show("Запрашиваемая работа уже находится в галерее!"); return;
                }
            }

            transaction.Work = SelectedWork;

            if (!string.IsNullOrEmpty(tbAcquisitionPrice.Text))
            {
                try
                {
                    transaction.AcquisitionPrice = Convert.ToDecimal(tbAcquisitionPrice.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Введите корректную цену приобретения"); return;
                }
            }

            if (!string.IsNullOrEmpty(tbAskingPrice.Text))
            {
                try
                {
                    transaction.AskingPrice = Convert.ToDecimal(tbAskingPrice.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Введите корректную запрашиваемую цену"); return;
                }

            }

            if (!string.IsNullOrEmpty(this.dpAcuired.Text))
            {
                transaction.DateAcquired = Convert.ToDateTime(this.dpAcuired.Text);
            }
            else
            {
                MessageBox.Show("Дата приобретения должна быть указана!"); return;
            }

            if (!string.IsNullOrEmpty(this.dpPurchase.Text))
            {
                if (Convert.ToDateTime(dpPurchase.Text) > Convert.ToDateTime(dpAcuired.Text))
                    transaction.PurchaseDate = Convert.ToDateTime(this.dpPurchase.Text);
                else
                {
                    MessageBox.Show("Нельзя продать работу раньше, чем её купила галерея! Проверьте правильность ввода данных.");
                    return;
                }
            }

            if (!string.IsNullOrEmpty(cbCustomer.Text))
            {
                CustomerDto SelectedCustomer = (CustomerDto)this.cbCustomer.SelectedItem;
                transaction.Customer = SelectedCustomer;
            }

            if (!string.IsNullOrEmpty(tbSalesPrice.Text))
            {

                try
                {
                    if (Convert.ToDecimal(tbSalesPrice.Text) >= 30000 && Convert.ToDecimal(tbSalesPrice.Text) <= 1500000)
                        transaction.SalesPrice = Convert.ToDecimal(tbSalesPrice.Text);
                    else
                    {
                        MessageBox.Show("Продажа может проходить только в пределах от 30 тыс. у.е. до 1,5 млн. у.е.");
                        return;
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Невеный формат данных при операции с ценой продажи"); return;
                }
            }

            ITransactionProcess transProcess = ProcessFactory.GetTransactionProcess();

            if (id == 0)
                transProcess.Add(transaction);
            else
            {
                transaction.TransactionID = id;
                transProcess.Update(transaction);
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cbWork_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.status == "sale")
            {
                WorkDto work = cbWork.SelectedItem as WorkDto;
                this.id = FindTransaction(work.Id);
                loadTransaction(this.id);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (status == "purchase")
            {
                GetWorksWithCustomers();
                this.cbWork.ItemsSource = this.FreeForPurchase;
                this.cbCustomer.IsEnabled = false;
                this.tbSalesPrice.IsEnabled = false;
                this.dpPurchase.IsEnabled = false;
            }

            if (status == "sale")
            {
                this.cbWork.ItemsSource = this.FreeForSale;
            }
        }

        private void loadTransaction(int id)
        {
            TransactionDto trans = ProcessFactory.GetTransactionProcess().Get(id);
            this.dpAcuired.Text = trans.DateAcquired.ToString();
            this.dpAcuired.IsEnabled = false;
            this.tbAcquisitionPrice.Text = trans.AcquisitionPrice.ToString();
            this.tbAcquisitionPrice.IsEnabled = false;
            this.tbAskingPrice.Text = trans.AskingPrice.ToString();
            this.tbAskingPrice.IsEnabled = false;
        }

        private void cbWork_LostFocus(object sender, RoutedEventArgs e)
        {
            this.loadWork(this.cbWork.Text);
        }

        private int FindTransaction(int workId)
        {
            IList<TransactionDto> transes = ProcessFactory.GetTransactionProcess().GetList();
            foreach (TransactionDto t in transes)
            {
                if (t.Work.Id == workId)
                {
                    return t.TransactionID;
                }
            }
            return -1;
        }
    }
}
