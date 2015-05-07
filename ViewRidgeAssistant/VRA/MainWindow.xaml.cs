using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using VRA.Dto;
using VRA.BusinessLayer;
using Microsoft.Win32;

namespace VRA
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private string status; // устанавливает с какой таблицей в текущий момент работает юзер

        public MainWindow()
        {
            InitializeComponent();
        }

        #region TablesButtonClick

        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "Artist": this.dgArtists.Visibility = Visibility.Hidden;
                    break;
                case "Work": this.dgWork.Visibility = Visibility.Hidden;
                    break;
                case "Trans": this.dgTrans.Visibility = Visibility.Hidden;
                    break;
                case "Interests": this.dgInterests.Visibility = Visibility.Hidden;
                    break;
                case "Nations": this.dgNations.Visibility = Visibility.Hidden;
                    break;
            }

            this.dgCustomers.Visibility = Visibility.Visible;
            status = "Customer";
            this.btnRefresh_Click(sender, e);
            this.statusLabel.Content = "Работа с таблицей: Клиенты";
            this.btnAdd.Visibility = Visibility.Visible;
            this.btnPurchase.Visibility = Visibility.Collapsed;
            this.btnSale.Visibility = Visibility.Collapsed;
            this.btnEdit.Visibility = Visibility.Visible;
            this.btnDelete.Visibility = Visibility.Visible;
            this.btnRefresh.Visibility = Visibility.Visible;
            this.btnSearch.Visibility = Visibility.Visible;
        }

        private void btnArtists_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "Customer": this.dgCustomers.Visibility = Visibility.Hidden;
                    break;
                case "Work": this.dgWork.Visibility = Visibility.Hidden;
                    break;
                case "Trans": this.dgTrans.Visibility = Visibility.Hidden;
                    break;
                case "Interests": this.dgInterests.Visibility = Visibility.Hidden;
                    break;
                case "Nations": this.dgNations.Visibility = Visibility.Hidden;
                    break;
            }

            this.dgArtists.Visibility = Visibility.Visible;//отображаем DateGrid художников
            status = "Artist";//устанавливаем таблицу, с которой работаем в данный момент
            this.btnRefresh_Click(sender, e);//загружаем данные в DateGrid
            this.statusLabel.Content = "Работа с таблицей: Художники";
            //устанавливаем видимость кнопок управления записями таблицы
            this.btnAdd.Visibility = Visibility.Visible;
            this.btnPurchase.Visibility = Visibility.Collapsed;
            this.btnSale.Visibility = Visibility.Collapsed;
            this.btnEdit.Visibility = Visibility.Visible;
            this.btnDelete.Visibility = Visibility.Visible;
            this.btnRefresh.Visibility = Visibility.Visible;
            this.btnSearch.Visibility = Visibility.Visible;
        }

        private void btnWork_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "Artist": this.dgArtists.Visibility = Visibility.Hidden;
                    break;
                case "Customer": this.dgCustomers.Visibility = Visibility.Hidden;
                    break;
                case "Trans": this.dgTrans.Visibility = Visibility.Hidden;
                    break;
                case "Interests": this.dgInterests.Visibility = Visibility.Hidden;
                    break;
                case "Nations": this.dgNations.Visibility = Visibility.Hidden;
                    break;
            }

            this.dgWork.Visibility = Visibility.Visible;
            status = "Work";
            this.btnRefresh_Click(sender, e);
            this.statusLabel.Content = "Работа с таблицей: Работы";
            this.btnAdd.Visibility = Visibility.Visible;
            this.btnPurchase.Visibility = Visibility.Collapsed;
            this.btnSale.Visibility = Visibility.Collapsed;
            this.btnEdit.Visibility = Visibility.Visible;
            this.btnDelete.Visibility = Visibility.Visible;
            this.btnRefresh.Visibility = Visibility.Visible;
            this.btnSearch.Visibility = Visibility.Visible;
        }

        private void btnTrans_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "Artist": this.dgArtists.Visibility = Visibility.Hidden;
                    break;
                case "Customer": this.dgCustomers.Visibility = Visibility.Hidden;
                    break;
                case "Work": this.dgWork.Visibility = Visibility.Hidden;
                    break;
                case "Interests": this.dgInterests.Visibility = Visibility.Hidden;
                    break;
                case "Nations": this.dgNations.Visibility = Visibility.Hidden;
                    break;
            }

            this.dgTrans.Visibility = Visibility.Visible;
            status = "Trans";
            this.btnRefresh_Click(sender, e);
            this.statusLabel.Content = "Работа с таблицей: Транзакции";
            this.btnAdd.Visibility = Visibility.Collapsed;
            this.btnPurchase.Visibility = Visibility.Visible;
            this.btnSale.Visibility = Visibility.Visible;
            this.btnEdit.Visibility = Visibility.Visible;
            this.btnDelete.Visibility = Visibility.Visible;
            this.btnRefresh.Visibility = Visibility.Visible;
            this.btnSearch.Visibility = Visibility.Visible;
        }

        private void btnInterests_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "Artist": this.dgArtists.Visibility = Visibility.Hidden;
                    break;
                case "Customer": this.dgCustomers.Visibility = Visibility.Hidden;
                    break;
                case "Work": this.dgWork.Visibility = Visibility.Hidden;
                    break;
                case "Trans": this.dgTrans.Visibility = Visibility.Hidden;
                    break;
                case "Nations": this.dgNations.Visibility = Visibility.Hidden;
                    break;
            }

            this.dgInterests.Visibility = Visibility.Visible;
            status = "Interests";
            this.btnRefresh_Click(sender, e);
            this.statusLabel.Content = "Работа с таблицей: Интересы";
            this.btnAdd.Visibility = Visibility.Visible;
            this.btnPurchase.Visibility = Visibility.Collapsed;
            this.btnSale.Visibility = Visibility.Collapsed;
            this.btnEdit.Visibility = Visibility.Collapsed;
            this.btnDelete.Visibility = Visibility.Visible;
            this.btnRefresh.Visibility = Visibility.Visible;
            this.btnSearch.Visibility = Visibility.Visible;
        }

        private void btnNations_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "Artist": this.dgArtists.Visibility = Visibility.Hidden;
                    break;
                case "Customer": this.dgCustomers.Visibility = Visibility.Hidden;
                    break;
                case "Work": this.dgWork.Visibility = Visibility.Hidden;
                    break;
                case "Trans": this.dgTrans.Visibility = Visibility.Hidden;
                    break;
                case "Interests": this.dgInterests.Visibility = Visibility.Hidden;
                    break;
            }

            this.dgNations.Visibility = Visibility.Visible;
            status = "Nations";
            this.btnRefresh_Click(sender, e);
            this.statusLabel.Content = "Работа с таблицей: Нации";
            this.btnAdd.Visibility = Visibility.Visible;
            this.btnPurchase.Visibility = Visibility.Collapsed;
            this.btnSale.Visibility = Visibility.Collapsed;
            this.btnEdit.Visibility = Visibility.Collapsed;
            this.btnDelete.Visibility = Visibility.Visible;
            this.btnRefresh.Visibility = Visibility.Visible;
            this.btnSearch.Visibility = Visibility.Collapsed;
        }
        #endregion;

        #region ActionButtonsClick

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "Artist": this.btnAddA_Click();
                    break;
                case "Work": this.btnAddW_Click();
                    break;
                case "Customer": this.btnAddC_Click();
                    break;
                case "Nations": this.btnAddN_Click();
                    break;
                case "Interests": this.btnAddI_Click();
                    break;
                default: MessageBox.Show("Необходимо выбрать таблицу, в которую добавляется элемент!"); return;
            }
        }

        private void btnPurchase_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "Trans":
                    AddTransactionWindow window = new AddTransactionWindow {status = "purchase"};
                    window.ShowDialog();
                    btnRefreshT_Click();
                    break;

                default: MessageBox.Show("Необходимо выбрать таблицу, Транзакции!"); return;
            }
        }

        private void btnSale_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "Trans":
                    AddTransactionWindow window = new AddTransactionWindow {status = "sale"};
                    window.ShowDialog();
                    btnRefreshT_Click();
                    break;

                default: MessageBox.Show("Необходимо выбрать таблицу, Транзакции!"); return;
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "Artist": this.btnEditA_Click();
                    break;
                case "Work": this.btnEditW_Click();
                    break;
                case "Trans": this.btnEditT_Click();
                    break;
                case "Customer": this.btnEditC_Click();
                    break;
                default: MessageBox.Show("Необходимо выбрать таблицу  и элемент для редактирования !"); return;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "Artist": this.btnDeleteA_Click();
                    break;
                case "Work": this.btnDeleteW_Click();
                    break;
                case "Trans": this.btnDeleteT_Click();
                    break;
                case "Customer": this.btnDeleteC_Click();
                    break;
                case "Nations": this.btnDeleteN_Click();
                    break;
                case "Interests": this.btnDeleteI_Click();
                    break;
                default: MessageBox.Show("Необходимо выбрать таблицу  и элемент для удаления !"); return;
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "Artist": this.btnRefreshA_Click();
                    break;
                case "Work": this.btnRefreshW_Click();
                    break;
                case "Trans": this.btnRefreshT_Click();
                    break;
                case "Customer": this.btnRefreshC_Click();
                    break;
                case "Interests": this.btnRefreshI_Click();
                    break;
                case "Nations": this.btnRefreshN_Click();
                    break;
                default: MessageBox.Show("Необходимо выбрать таблицу для обновления !"); return;
            }
        }

        private void btnSearchClick(object sender, RoutedEventArgs e)
        {
            SearchWindow search = new SearchWindow(status);
            {
                switch (status)
                {
                    case "Artist":
                        search.ShowDialog();
                        if (search.exec)
                        {
                            this.dgArtists.Visibility = Visibility.Hidden;
                            this.dgArtists.ItemsSource = search.FindedArtists;
                            this.dgArtists.Visibility = Visibility.Visible;
                        }
                        break;
                    case "Customer":
                        search.ShowDialog();
                        if (search.exec)
                        {
                            this.dgCustomers.Visibility = Visibility.Hidden;
                            this.dgCustomers.ItemsSource = search.FindedCustomers;
                            this.dgCustomers.Visibility = Visibility.Visible;
                        }
                        break;
                    case "Work":
                        search.ShowDialog();
                        if (search.exec)
                        {
                            this.dgWork.Visibility = Visibility.Hidden;
                            this.dgWork.ItemsSource = search.FindedWorks;
                            this.dgWork.Visibility = Visibility.Visible;
                        }
                        break;
                    case "Trans":
                        search.ShowDialog();
                        if (search.exec)
                        {
                            this.dgTrans.Visibility = Visibility.Hidden;
                            this.dgTrans.ItemsSource = search.FindedTransactions;
                            this.dgTrans.Visibility = Visibility.Visible;
                        }
                        break;
                    case "Interests":
                        search.ShowDialog();
                        if (search.exec)
                        {
                            this.dgInterests.Visibility = Visibility.Hidden;
                            this.dgInterests.ItemsSource = search.FindedInterests;
                            this.dgInterests.Visibility = Visibility.Visible;
                        }
                        break;
                    default: MessageBox.Show("Для поиска необходимо выбрать таблицу!"); break;
                }
            }
        }
        #endregion;

        #region Artist

        private void btnAddA_Click()
        {
            AddArtistWindow window = new AddArtistWindow();
            window.ShowDialog();

            //Получаем список художников и передаем его на отображение таблице
            dgArtists.ItemsSource = ProcessFactory.GetArtistProcess().GetList();
        }

        private void btnDeleteA_Click()
        {
            //Получаем выделенную строку с объектом художника
            ArtistDto item = dgArtists.SelectedItem as ArtistDto;
            //если там не художник или пользователь ничего не выбрал сообщаем об этом
            if (item == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Удаление художника");
                return;
            }
            //Просим подтвердить удаление
            MessageBoxResult result = MessageBox.Show("Удалить художника " + item.Name + "?",
                       "Удаление художника", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            //Если пользователь не подтвердил, выходим
            if (result != MessageBoxResult.Yes)
                return;
            //Если все проверки пройдены и подтверждение получено, удаляем художника
            ProcessFactory.GetArtistProcess().Delete(item.Id);
            //И перезагружаем список художников
            btnRefreshA_Click();
        }

        private void btnRefreshA_Click()
        {
            //Получаем список художников и передаем его на отображение таблице
            dgArtists.ItemsSource = ProcessFactory.GetArtistProcess().GetList();
        }

        private void btnEditA_Click()
        {
            //Получаем выделенную строку с объектом художника
            ArtistDto item = dgArtists.SelectedItem as ArtistDto;
            //если там не художник или пользователь ничего не выбрал сообщаем об этом
            if (item == null)
            {
                MessageBox.Show("Выберите запись для редактирования", "Редактирование");
                return;
            }

            //Создаём окно
            AddArtistWindow window = new AddArtistWindow();
            //Передаём объект на редактирование
            window.Load(item);
            //Отображаем окно с данными
            window.ShowDialog();
            //Перезагружаем список объектов
            btnRefreshA_Click();
        }
        #endregion

        #region Customer

        private void btnAddC_Click()
        {
            AddCustomerWindow window = new AddCustomerWindow();
            window.ShowDialog();
            dgCustomers.ItemsSource = ProcessFactory.GetCustomerProcess().GetList();
        }

        private void btnEditC_Click()
        {
            CustomerDto item = dgCustomers.SelectedItem as CustomerDto;

            if (item == null)
            {
                MessageBox.Show("Выберите запись для редактирования", "Редактирование клиента");
                return;
            }

            //Создаём окно
            AddCustomerWindow window = new AddCustomerWindow();
            //Передаём объект на редактирование
            window.Load(item);
            //Отображаем окно с данными
            window.ShowDialog();
            //Перезагружаем список объектов

            btnRefreshC_Click();
        }

        private void btnRefreshC_Click()
        {
            dgCustomers.ItemsSource = ProcessFactory.GetCustomerProcess().GetList();
        }

        private void btnDeleteC_Click()
        {
            CustomerDto item = dgCustomers.SelectedItem as CustomerDto;

            if (item == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Удаление клиента");
                return;
            }

            MessageBoxResult result = MessageBox.Show("Удалить клиента " + item.Name + "?", "Удаление клиента", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            //Если пользователь не подтвердил, выходим
            if (result != MessageBoxResult.Yes)
                return;

            ProcessFactory.GetCustomerProcess().Delete(item.Id);

            btnRefreshC_Click();
        }
        #endregion;

        #region Work

        private void btnAddW_Click()
        {
            AddWorkWindow window = new AddWorkWindow();
            window.ShowDialog();
            dgWork.ItemsSource = ProcessFactory.GetWorkProcess().GetList();
        }

        private void btnEditW_Click()
        {
            WorkDto item = dgWork.SelectedItem as WorkDto;

            if (item == null)
            {
                MessageBox.Show("Выберите запись для редактирования", "Редактирование");
                return;
            }

            AddWorkWindow window = new AddWorkWindow();
            window.Load(item);
            window.ShowDialog();
            btnRefreshW_Click();
        }

        private void btnRefreshW_Click()
        {
            dgWork.ItemsSource = ProcessFactory.GetWorkProcess().GetList();
        }

        private void btnDeleteW_Click()
        {
            //Получаем выделенную строку с объектом 
            WorkDto item = dgWork.SelectedItem as WorkDto;

            if (item == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Удаление картины");
                return;
            }

            //Просим подтвердить удаление
            MessageBoxResult result = MessageBox.Show("Удалить картину " + item.Title + "?", "Удаление картины", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            //Если пользователь не подтвердил, выходим
            if (result != MessageBoxResult.Yes)
                return;

            //Если все проверки пройдены и подтверждение получено, удаляем
            ProcessFactory.GetWorkProcess().Delete(item.Id);

            btnRefreshW_Click();
        }
        #endregion;

        #region Transaction

        private void btnEditT_Click()
        {
            TransactionDto item = this.dgTrans.SelectedItem as TransactionDto;

            if (item == null)
            {
                MessageBox.Show("Выберите запись для редактирования", "Изменение транзакции");
                return;
            }

            AddTransactionWindow window = new AddTransactionWindow();
            window.Load(item);
            window.ShowDialog();
            btnRefreshT_Click();
        }

        private void btnRefreshT_Click()
        {
            dgTrans.ItemsSource = ProcessFactory.GetTransactionProcess().GetList();
        }

        private void btnDeleteT_Click()
        {
            TransactionDto item = this.dgTrans.SelectedItem as TransactionDto;

            if (item == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Удаление транзакции");
                return;
            }

            MessageBoxResult result = MessageBox.Show("Удалить Транзакцию " + item.TransactionID + "?", "Удаление транзакции", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result != MessageBoxResult.Yes)
                return;

            ProcessFactory.GetTransactionProcess().Delete(item.TransactionID);

            btnRefreshT_Click();
        }
        #endregion;

        #region Interest

        private void btnAddI_Click()
        {
            AddInterestWindow window = new AddInterestWindow();
            window.ShowDialog();
            this.dgInterests.ItemsSource = ProcessFactory.GetInterestsProcess().GetList();
        }

        private void btnDeleteI_Click()
        {
            InterestsDto item = this.dgInterests.SelectedItem as InterestsDto;

            if (item == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Удаление интереса");
                return;
            }

            MessageBoxResult result = MessageBox.Show("Удалить интерес к художнику " + item.Artist.Name.TrimEnd(' ') + " клиента " + item.Customer.Name.TrimEnd(' ') + "?", "Удаление интереса", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result != MessageBoxResult.Yes)
                return;

            ProcessFactory.GetInterestsProcess().Delete(item);

            btnRefreshI_Click();
        }

        private void btnRefreshI_Click()
        {
            this.dgInterests.ItemsSource = ProcessFactory.GetInterestsProcess().GetList();
        }
        #endregion

        #region Nation

        private void btnAddN_Click()
        {
            AddNationWindow window = new AddNationWindow();
            window.ShowDialog();
            this.btnRefreshN_Click();
        }

        private void btnRefreshN_Click()
        {
            dgNations.ItemsSource = ProcessFactory.GetNationProcess().GetList();
        }

        private void btnDeleteN_Click()
        {
            NationDto item = this.dgNations.SelectedItem as NationDto;

            if (item == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Удаление нации");
                return;
            }

            MessageBoxResult result = MessageBox.Show("Удалить национальность " + item.Nationality + "?", "Удаление национальности", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result != MessageBoxResult.Yes)
                return;

            ProcessFactory.GetNationProcess().Delete(item.Id);

            btnRefreshN_Click();
        }
        #endregion;

        #region Menu

        private void btnDatabase_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow window = new SettingsWindow();
            window.ShowDialog();
        }

        private void ExcelExporterButton_Click(object sender, RoutedEventArgs e)
        {
            List<object> grid = null;

            switch (status)
            {
                case "Customer":
                    grid = this.dgCustomers.ItemsSource.Cast<object>().ToList();
                    break;
                case "Artist":
                    grid = this.dgArtists.ItemsSource.Cast<object>().ToList();
                    break;
                case "Work":
                    grid = this.dgWork.ItemsSource.Cast<object>().ToList();
                    break;
                case "Trans":
                    grid = this.dgTrans.ItemsSource.Cast<object>().ToList();
                    break;
                case "Interests":
                    grid = this.dgInterests.ItemsSource.Cast<object>().ToList();
                    break;
                case "Nations":
                    grid = this.dgNations.ItemsSource.Cast<object>().ToList();
                    break;
            }

            SaveFileDialog saveXlsxDialog = new SaveFileDialog
            {
                DefaultExt = ".xlsx",
                Filter = "Excel Files (.xlsx)|*.xlsx",
                AddExtension = true,
                FileName = status
            };

            bool? result = saveXlsxDialog.ShowDialog();

            if (result == true)
            {
                FileInfo xlsxFile = new FileInfo(saveXlsxDialog.FileName);

                ProcessFactory.GetReport().fillExcelTableByType(grid, status, xlsxFile);
            }
        }

        private void HtmlWorksInGalleryButton_Click(object sender, RoutedEventArgs e)
        {
            String rep;

            OpenFileDialog dlg = new OpenFileDialog
            {
                DefaultExt = ".vrt",
                Filter = "View Ridge Assistant Template files|*.vrt"
            };

            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                StreamReader sr = new StreamReader(dlg.FileName);
                rep = sr.ReadToEnd();
                sr.Close();
            }
            else
            {
                return;
            }

            string full_rep = ProcessFactory.GetReport().genHtmlWorksInGallery(rep);

            SaveFileDialog sdlg = new SaveFileDialog {DefaultExt = ".html", Filter = "Html Documents (.html)|*.html"};
            if (sdlg.ShowDialog() == true)
            {
                string filename = sdlg.FileName;
                StreamWriter sw = new StreamWriter(filename);
                sw.WriteLine(full_rep);
                sw.Close();
            }
        }

        private void GraphReportButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new ReportWindow();
            window.Show();
        }

        private void QueryButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new QueryWindow();
            window.Show();
        }
        #endregion
    }
}
