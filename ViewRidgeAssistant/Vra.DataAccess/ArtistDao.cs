using System;
using System.Collections.Generic;
using Vra.DataAccess.Entities;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Vra.DataAccess
{
    public class ArtistDao : BaseDao, IArtistDao
    {
        private static Artist LoadArtist(SqlDataReader reader)
        {
            //Создаём пустой объект
            Artist artist = new Artist {ArtistId = reader.GetInt32(reader.GetOrdinal("ArtistID"))};
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных
            object birth = reader["BirthYear"];
            if (birth != DBNull.Value)
                artist.BirthYear = Convert.ToInt32(birth);
            //Помните, что у нас поле DeceaseYear может иметь значение NULL?
            //Следующие 3 строки корректно обрабатывают этот случай
            object decease = reader["DeceaseYear"];
            if (decease != DBNull.Value)
                artist.DeceaseYear = Convert.ToInt32(decease);
            artist.Name = reader.GetString(reader.GetOrdinal("Name"));
            int pos = reader.GetOrdinal("NatID");
            artist.NationId = reader[pos] == DBNull.Value ? -1 : reader.GetInt32(pos);
            return artist;
        }

        public Artist Get(int id)
        {
            //Получаем объект подключения к базе
            using (var conn = GetConnection())
            {
                //Открываем соединение
                conn.Open();
                //Создаем sql команду
                using (var cmd = conn.CreateCommand())
                {
                    //Задаём текст команды
                    cmd.CommandText = "SELECT ArtistID, Name, BirthYear, DeceaseYear, NatID FROM ARTIST WHERE ArtistID = @id";
                    //Добавляем значение параметра
                    cmd.Parameters.AddWithValue("@id", id);
                    //Открываем SqlDataReader для чтения полученных в результате
                    // выполнения запроса данных
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        return !dataReader.Read() ? null : LoadArtist(dataReader);
                    }
                }
            }
        }

        public IEnumerable<Artist> GetAll()
        {
            IList<Artist> artists = new List<Artist>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT ArtistID, Name, BirthYear, DeceaseYear, NatID FROM ARTIST";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            artists.Add(LoadArtist(dataReader));
                        }
                    }
                }
                return artists;
            }
        }

        public void Add(Artist artist)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO ARTIST (Name,BirthYear,DeceaseYear,NatID) VALUES (@Name,@BirthYear,@DeceaseYear,@Nationality)";
                    cmd.Parameters.AddWithValue("@Name", artist.Name);
                    cmd.Parameters.AddWithValue("@BirthYear", artist.BirthYear);
                    cmd.Parameters.AddWithValue("@Nationality", artist.NationId);
                    object decease = artist.DeceaseYear.HasValue ?
                          (object)artist.DeceaseYear.Value : DBNull.Value;
                    cmd.Parameters.AddWithValue("@DeceaseYear", decease);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Artist artist)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE ARTIST SET Name = @Name, BirthYear = @BirthYear, DeceaseYear = @DeceaseYear, NatID = @Nationality WHERE ArtistID = @ID";
                    cmd.Parameters.AddWithValue("@Name", artist.Name);
                    cmd.Parameters.AddWithValue("@BirthYear", artist.BirthYear);
                    cmd.Parameters.AddWithValue("@ID", artist.ArtistId);
                    cmd.Parameters.AddWithValue("@Nationality", artist.NationId);
                    object decease = artist.DeceaseYear.HasValue ?
                        (object)artist.DeceaseYear.Value : DBNull.Value;
                    cmd.Parameters.AddWithValue("@DeceaseYear", decease);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM ARTIST WHERE ArtistID = @ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Исключение базы данных: " + ex.Message, "WARNING!");
                    }
                }
            }
        }

        public IEnumerable<Artist> SearchArtists(string Name, string Nation)
        {
            IList<Artist> artists = new List<Artist>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT ArtistID, Name, BirthYear, DeceaseYear, Artist.NatID FROM ARTIST JOIN Nation on Artist.NatID = Nation.NatID WHERE Name like @Name AND Value like @Nation";
                    cmd.Parameters.AddWithValue("@Name", "%" + Name + "%");
                    cmd.Parameters.AddWithValue("@Nation", "%" + Nation);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            artists.Add(LoadArtist(dataReader));
                        }
                    }
                }
            }
            return artists;
        }
    }
}
