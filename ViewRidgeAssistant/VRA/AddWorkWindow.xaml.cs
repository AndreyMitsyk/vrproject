using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using VRA.Dto;
using VRA.BusinessLayer;

namespace VRA
{
    /// <summary>
    /// Логика взаимодействия для AddWorkWindow.xaml
    /// </summary>
    public partial class AddWorkWindow
    {
        /// <summary>
        /// Возвращает список художников, имена которых есть в базе.
        /// </summary>
        private readonly IList<ArtistDto> Artists = ProcessFactory.GetArtistProcess().GetList();

        private IList<WorkDto> FreeForSale = ProcessFactory.GetWorkProcess().GetList();

        private int _id; // Хранит идентификатор, редактируемой работы

        public void Load(WorkDto work)
        {
            if (work == null)
                return;

            this._id = work.Id;

            //заполняем визуальные компоненты для отображения данных
            tbTitle.Text = work.Title;

            tbCopy.Text = work.Copy ?? "";

            tbDescription.Text = work.Description ?? "";

            foreach (ArtistDto artist in Artists)
            {
                if (artist.Id == work.Artist.Id)
                {
                    this.cbArtist.SelectedItem = artist;
                    return;
                }
            }
        }

        public AddWorkWindow()
        {
            InitializeComponent();

            this.cbArtist.ItemsSource = (from a in Artists orderby a.Name select a).ToList<ArtistDto>();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbTitle.Text))
            {
                MessageBox.Show("Название работы не может быть пустым!");
                return;
            }

            if (string.IsNullOrEmpty(tbCopy.Text))
            {
                MessageBox.Show("Укажите копию работы!");
                return;
            }

            if (string.IsNullOrEmpty(cbArtist.Text))
            {
                MessageBox.Show("Укажите автора работы!");
                return;
            }

            if (string.IsNullOrEmpty(dpAcuired.Text))
            {
                MessageBox.Show("Укажите дату приобретения работы!");
                return;
            }

            if (string.IsNullOrEmpty(tbAcquisitionPrice.Text))
            {
                MessageBox.Show("Укажите цену приобретения работы!");
                return;
            }

            WorkDto work = new WorkDto
            {
                Title = tbTitle.Text,
                Copy = tbCopy.Text,
                Description = tbDescription.Text,
                Artist = (ArtistDto) this.cbArtist.SelectedItem
            };

            TransactionDto transaction = new TransactionDto
            {
                AcquisitionPrice = Convert.ToDecimal(tbAcquisitionPrice.Text),
                DateAcquired = Convert.ToDateTime(this.dpAcuired.Text)
            };

            IWorkProcess workProcess = ProcessFactory.GetWorkProcess();
            ITransactionProcess transProcess = ProcessFactory.GetTransactionProcess();

            if (_id == 0)
            {
                workProcess.Add(work);
                FreeForSale = ProcessFactory.GetWorkProcess().GetList();
                transaction.Work = FreeForSale.Last();
                transProcess.Update(transaction);
            }
            else
            {
                work.Id = _id;
                workProcess.Update(work);
            }
            this.Close();
        }
    }
}
