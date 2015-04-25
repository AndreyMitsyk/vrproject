using System;
using System.Windows;
using VRA.BusinessLayer;
using System.Data.SqlClient;

namespace VRA
{
    /// <summary>
    /// Логика взаимодействия для SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow
    {
        private bool recstatus;
        private bool applySettings;

        private void LoadSettings()
        {
            if (ProcessFactory.GetSettingsProcess().GetSettings() != null)
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    ConnectionString = ProcessFactory.GetSettingsProcess().GetSettings()
                };

                this.tbServer.Text = builder.DataSource;
                this.tbDataBase.Text = builder.InitialCatalog;

                if (builder.IntegratedSecurity & !recstatus)
                {
                    this.cbAuth.IsChecked = true;
                }
                else
                {
                    this.tbPassword.Text = builder.Password;
                    this.tbUser.Text = builder.UserID;
                }
            }
            else
            {
                this.tbServer.Text = "127.0.0.1";
                this.tbDataBase.Text = "vra_db";
                this.cbAuth.IsChecked = true;
            }
        }

        public SettingsWindow()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cbAuth_Checked(object sender, RoutedEventArgs e)
        {
            this.tbUser.Text = "";
            this.tbPassword.Text = "";
            this.tbUser.IsEnabled = false;
            this.tbPassword.IsEnabled = false;
        }

        private void cbAuth_Uncheked(object sender, RoutedEventArgs e)
        {
            this.tbUser.IsEnabled = true;
            this.tbPassword.IsEnabled = true;
            this.recstatus = true;
            LoadSettings();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ProcessFactory.GetSettingsProcess().SetSettings(this.tbServer.Text, this.tbDataBase.Text, this.tbUser.Text, this.tbPassword.Text))
            {
                this.applySettings = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Не удалось записать настройки! Что-то пошло не так");
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!this.applySettings)
            {
                MessageBoxResult result = MessageBox.Show("Сохранить изменения?", "Изменение настроек подключения", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result != MessageBoxResult.Yes) return;

                if (!ProcessFactory.GetSettingsProcess().SetSettings(this.tbServer.Text, this.tbDataBase.Text, this.tbUser.Text, this.tbPassword.Text))
                {
                }
            }
        }
    }
}
