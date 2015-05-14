using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Vra.DataAccess
{
    public class QueryDao : BaseDao, IQueryDao
    {
        private SqlDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();

        public DataTable Query(string query)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                if (!query.ToLower().Contains("select"))
                    throw new Exception("Запрос не начинается с 'select'!");
                DB = new SqlDataAdapter(query, conn);
                DS.Reset();
                DB.Fill(DS);
                DT = DS.Tables[0];
            }
            return DT;
        }
    }
}
