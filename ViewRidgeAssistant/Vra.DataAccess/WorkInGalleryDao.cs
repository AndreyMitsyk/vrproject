using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Vra.DataAccess.Entities;

namespace Vra.DataAccess
{
    public class WorkInGalleryDao : BaseDao,IWorkInGalleryDao
    {
        private static WorkInGallery LoadWork(SqlDataReader reader)
        {
            //Создаём пустой объект
            WorkInGallery work = new WorkInGallery
            {
                Id = reader.GetInt32(reader.GetOrdinal("WorkID")),
                WorkId = reader.GetInt32(reader.GetOrdinal("WorkID")),
                ArtistId = reader.GetInt32(reader.GetOrdinal("ArtistID"))
            };

            object tmp = reader["AskingPrice"];
            if (tmp != DBNull.Value) work.AskingPrice = Convert.ToDecimal(tmp);

            return work;
        }

        public IEnumerable<WorkInGallery> GetAll()
        {
            IList<WorkInGallery> works = new List<WorkInGallery>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT WorkID, ArtistID, AskingPrice FROM WorksInGallery";

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
