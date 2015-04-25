using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using VRA.Dto;
using VRA.BusinessLayer;

namespace VRA
{
    /// <summary>
    /// Логика взаимодействия для AddArtistWindow.xaml
    /// </summary>
    public partial class AddArtistWindow
    {
        public AddArtistWindow()
        {
            InitializeComponent();
            //Передаем допустимые значения
            cbNationality.ItemsSource = (from N in Nationalities orderby N.Nationality select N);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Список допустимых национальностей
        /// </summary>
        private readonly IList<NationDto> Nationalities = ProcessFactory.GetNationProcess().GetList();

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            int? birth;
            int? death = null;

            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Имя художника не должно быть пустым", "Проверка");
                return;
            }

            if (tbBirth.Text != "")
            {
                try
                {
                    birth = int.Parse(this.tbBirth.Text);
                }

                catch
                {
                    MessageBox.Show("Год рождения должен быть целым числом", "Проверка");
                    return;
                }

                if (birth < 1000 || birth > DateTime.Today.Year)
                {
                    MessageBox.Show("Галерея занимается продажей только произведений художников прошлого тысячелетия", "Проверка");
                    return;
                }
            }
            else
            {
                birth = null;
            }

            if (!string.IsNullOrEmpty(tbDeath.Text))
            {
                int intDeath;

                if (!int.TryParse(tbDeath.Text, out intDeath))
                {
                    MessageBox.Show("Год смерти должен быть целым числом", "Проверка");
                    return;
                }

                if (intDeath < 1000 || intDeath > DateTime.Today.Year)
                {
                    MessageBox.Show("Год смерти введен неверно", "Проверка");
                    return;
                }

                if (intDeath < birth)
                {
                    MessageBox.Show("Год смерти должен быть больше года рождения", "Проверка");
                    return;
                }
                death = intDeath;
            }

            //Создаем объект для передачи данных
            ArtistDto artist = new ArtistDto
            {
                Name = tbName.Text,
                BirthYear = birth,
                DeceaseYear = death,
                Nation = cbNationality.SelectedItem as NationDto
            };

            //Заполняем объект данными

            //Именно тут запрашиваем реализованную ранее задачу по работе с художниками
            IArtistProcess artistProcess = ProcessFactory.GetArtistProcess();

            //Сохраняем художника
            //если это новый объект - сохраняем его
            if (_id == 0)
            {
                //Сохраняем художника
                artistProcess.Add(artist);
            }
            else //иначе обновляем
            {
                //копируем обратно идентификатор объекта
                artist.Id = _id;
                //обновляем
                artistProcess.Update(artist);
            }

            //и закрываем форму
            this.Close();
        }

        /// <summary>
        /// Поле хранит идентификатор художника
        /// </summary>
        private int _id;

        /// <summary>
        /// Метод загружает объект художника для редактирования
        /// </summary>
        /// <param name="artist">редактируемый объект художника</param>
        public void Load(ArtistDto artist)
        {
            //если объект не существует выходим
            if (artist == null)
                return;

            //сохраняем id художника
            _id = artist.Id;

            //заполняем визуальные компоненты для отображения данных
            tbName.Text = artist.Name;
            tbBirth.Text = artist.BirthYear.ToString();
            if (artist.DeceaseYear.HasValue)
                tbDeath.Text = artist.DeceaseYear.Value.ToString();

            if (artist.Nation != null)
            {
                foreach (NationDto Nat in Nationalities)
                {
                    if (artist.Nation.Id == Nat.Id)
                    {
                        this.cbNationality.SelectedItem = Nat;
                        break;
                    }
                }
            }
        }
    }
}
