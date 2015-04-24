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
    public class InterestDao : BaseDao, IInterestsDao
    {
        private static Interests LoadInterest(SqlDataReader reader)
        {
            Interests interests = new Interests();

            interests.Artist = reader.GetInt32(reader.GetOrdinal("ArtistID"));
            interests.Customer = reader.GetInt32(reader.GetOrdinal("CustomerID"));

            return interests;
        }

        public IList<Interests> GetAll()
        {
            IList<Interests> interests = new List<Interests>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT ArtistID, CustomerID FROM CUSTOMER_ARTIST_INT";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            interests.Add(LoadInterest(dataReader));
                        }
                    }
                }
            }

            return interests;
        }

        public void Add(Interests interest)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText =
                             "INSERT INTO CUSTOMER_ARTIST_INT (CustomerID, ArtistID) VALUES (@CustomerId,@ArtistId)";
                    cmd.Parameters.AddWithValue("@CustomerId", interest.Customer);
                    cmd.Parameters.AddWithValue("@ArtistId", interest.Artist);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int ArtistID, int CustomerID)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM CUSTOMER_ARTIST_INT WHERE ArtistID = @ArtistID AND CustomerID = @CustomerId";
                    cmd.Parameters.AddWithValue("@ArtistID", ArtistID);
                    cmd.Parameters.AddWithValue("@CustomerId", CustomerID);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Исключение базы данных: " + ex.ToString(), "WARNING!");
                    }
                }
            }
        }
    }
}
