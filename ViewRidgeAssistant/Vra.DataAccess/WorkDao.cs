using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Vra.DataAccess.Entities;
using System.Windows.Forms;

namespace Vra.DataAccess
{
    public class WorkDao : BaseDao,IWorkDao
    {
        private static Work LoadWork(SqlDataReader reader)
        {
            //Создаём пустой объект
            Work work = new Work();
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных
            work.Id = reader.GetInt32(reader.GetOrdinal("WorkID"));
            work.Title = reader.GetString(reader.GetOrdinal("Title"));
            work.ArtistId = reader.GetInt32(reader.GetOrdinal("ArtistID"));
            //остальные строки могут иметь значение NULL
            object tmp = reader["Description"];
            if (tmp != DBNull.Value)
                work.Description = Convert.ToString(tmp);
            tmp = reader["Copy"];
            if (tmp != DBNull.Value)
                work.Copy = Convert.ToString(tmp);
            return work;
        }

        public Work Get(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT WorkID, ArtistID, Title, Copy, Description FROM WORK WHERE WorkID = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var dataReader = cmd.ExecuteReader())
                        return !dataReader.Read() ? null : LoadWork(dataReader);
                }
            }
        }

        public IList<Work> GetAll()
        {
            IList<Work> works = new List<Work>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT WorkID, ArtistID, Title, Copy, Description FROM WORK";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            works.Add(LoadWork(dataReader));
                        }
                    }
                }
            }
            return works;
        }

        // получить выставленные на продажу картины
        public IList<Work> GetInGallery()
        {
            IList<Work> works = new List<Work>();

            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT WorkID, ArtistID, Title, Copy, Description " + "FROM WORK " + "WHERE WorkID in ( " + "SELECT WorkID " + "FROM TRANS " + "WHERE CustomerID is NULL " + ")";

                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            works.Add(LoadWork(dataReader));
                        }
                    }
                }
            }
            return works;
        }

        public void Add(Work work)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText ="INSERT INTO WORK (Title, ArtistID, Copy, Description) VALUES (@Title, @ArtistID, @Copy, @Description)";
                    cmd.Parameters.AddWithValue("@Title", work.Title);
                    cmd.Parameters.AddWithValue("@ArtistID", work.ArtistId);
                    object Copy = (work.Copy != null) ? (object)work.Copy : DBNull.Value;
                    cmd.Parameters.AddWithValue("@Copy", Copy);
                    object Description = (work.Description != null) ?
                      (object)work.Description : DBNull.Value;
                    cmd.Parameters.AddWithValue("@Description", Description);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Work work)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE WORK SET Title = @Title, ArtistID = @ArtistID, Copy = @Copy, Description = @Description WHERE WorkID = @ID";
                    cmd.Parameters.AddWithValue("@Title", work.Title);
                    cmd.Parameters.AddWithValue("@ArtistID", work.ArtistId);
                    cmd.Parameters.AddWithValue("@ID", work.Id);
                    object Copy = (work.Copy != null) ? (object)work.Copy : DBNull.Value;
                    cmd.Parameters.AddWithValue("@Copy", Copy);
                    object Description = (work.Description != null) ?
                        (object)work.Description : DBNull.Value;
                    cmd.Parameters.AddWithValue("@Description", Description);
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
                    cmd.CommandText = "DELETE FROM WORK WHERE WorkID = @ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Исключение базы данных : " + ex.ToString(), "WARNING!");
                    }
                }
            }
        }

        public IList<Work> SearchWork(string Title, string Artist, string Copy)
        {
            IList<Work> works = new List<Work>();

            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT WorkID, Work.ArtistID, Title, Copy, Description FROM WORK JOIN Artist on WORK.ArtistID = Artist.ArtistID Where Title like @Title AND Artist.Name like @Artist AND Copy like @Copy ";
                    cmd.Parameters.AddWithValue("@Title", '%' + Title + '%');
                    cmd.Parameters.AddWithValue("@Artist", '%' + Artist + '%');
                    cmd.Parameters.AddWithValue("@Copy", '%' + Copy + '%');
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            works.Add(LoadWork(dataReader));
                        }
                    }
                }
            }
            return works;
        }
    }
}
