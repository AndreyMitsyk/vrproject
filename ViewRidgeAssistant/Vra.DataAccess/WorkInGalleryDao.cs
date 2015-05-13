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
            //Создаём пустой объект.
            WorkInGallery work = new WorkInGallery
            {
                Id = reader.GetInt32(reader.GetOrdinal("WorkID")),
                Title = reader.GetString(reader.GetOrdinal("Title")),
                Name = reader.GetString(reader.GetOrdinal("Name")),
            };
            // Параметры, которые могут быть NULL.
            object tmp = reader["AskingPrice"];
            if (tmp != DBNull.Value) work.AskingPrice = Convert.ToDecimal(tmp);

            tmp = reader["Copy"];
            if (tmp != DBNull.Value) work.Copy = Convert.ToString(tmp);

            tmp = reader["Description"];
            if (tmp != DBNull.Value) work.Description = Convert.ToString(tmp);

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
                    cmd.CommandText = "SELECT WorkID, Title, Copy, Name, AskingPrice, Description FROM WorksInGallery";

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
