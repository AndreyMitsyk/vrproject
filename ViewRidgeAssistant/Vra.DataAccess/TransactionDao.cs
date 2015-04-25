using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Vra.DataAccess.Entities;
using System.Windows.Forms;

namespace Vra.DataAccess
{
    public class TransactionDao : BaseDao, ITransactionDao
    {
        private static Transaction LoadTransaction(SqlDataReader reader)
        {
            Transaction Trans = new Transaction
            {
                TransID = reader.GetInt32(reader.GetOrdinal("TransactionID")),
                WorkId = reader.GetInt32(reader.GetOrdinal("WorkID"))
            };

            object tmp = reader["CustomerID"];
            if (tmp != DBNull.Value) Trans.CustomerID = Convert.ToInt32(tmp);

            tmp = reader["DateAcquired"];
            if (tmp != DBNull.Value) Trans.DateAcquired = Convert.ToDateTime(tmp);

            tmp = reader["AcquisitionPrice"];
            if (tmp != DBNull.Value) Trans.AcquisitionPrice = Convert.ToDecimal(tmp);

            tmp = reader["PurchaseDate"];
            if (tmp != DBNull.Value) Trans.PurchaseDate = Convert.ToDateTime(tmp);

            tmp = reader["SalesPrice"];
            if (tmp != DBNull.Value) Trans.SalesPrice = Convert.ToDecimal(tmp);

            tmp = reader["AskingPrice"];
            if (tmp != DBNull.Value) Trans.AskingPrice = Convert.ToDecimal(tmp);

            return Trans;
        }

        public IEnumerable<Transaction> GetAll()
        {
            List<Transaction> Transactions = new List<Transaction>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT TransactionID, CustomerID, WorkID, DateAcquired, AcquisitionPrice, PurchaseDate, SalesPrice, AskingPrice FROM TRANS";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Transactions.Add(LoadTransaction(dataReader));
                        }
                    }
                }
            }
            return Transactions;
        }

        public IEnumerable<Transaction> GetInGallery()
        {
            List<Transaction> Transactions = new List<Transaction>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT TransactionID, CustomerID, WorkID, DateAcquired, AcquisitionPrice, PurchaseDate, SalesPrice, AskingPrice FROM TRANS WHERE CustomerID is NULL and SalesPrice is NULL and PurchaseDate is NULL";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Transactions.Add(LoadTransaction(dataReader));
                        }
                    }
                }
            }
            return Transactions;
        }

        public Transaction Get(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT TransactionID, CustomerID, WorkID, DateAcquired, AcquisitionPrice, PurchaseDate, SalesPrice, AskingPrice FROM TRANS WHERE TransactionID = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        return !dataReader.Read() ? null : LoadTransaction(dataReader);
                    }
                }
            }
        }

        public void Add(Transaction Trans)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText =
                             "INSERT INTO TRANS (CustomerID,WorkID,DateAcquired,AcquisitionPrice,PurchaseDate,SalesPrice,AskingPrice) VALUES (@CustomerID,@WorkID,@DateAcquired,@AcquisitionPrice,@PurchaseDate,@SalesPrice,@AskingPrice)";

                    cmd.Parameters.AddWithValue("@WorkID", Trans.WorkId);
                    object CustomerID = Trans.CustomerID.HasValue ? (object)Trans.CustomerID.Value : DBNull.Value;
                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID);

                    object DateAcquired = Trans.DateAcquired.HasValue ? (object)Trans.DateAcquired.Value : DBNull.Value;
                    cmd.Parameters.AddWithValue("@DateAcquired", DateAcquired);

                    object AcquisitionPrice = Trans.AcquisitionPrice.HasValue ? (object)Trans.AcquisitionPrice.Value : DBNull.Value;
                    cmd.Parameters.AddWithValue("@AcquisitionPrice", AcquisitionPrice);

                    object PurchaseDate = Trans.PurchaseDate.HasValue ? (object)Trans.PurchaseDate.Value : DBNull.Value;
                    cmd.Parameters.AddWithValue("@PurchaseDate", PurchaseDate);

                    object SalesPrice = Trans.SalesPrice.HasValue ? (object)Trans.SalesPrice.Value : DBNull.Value;
                    cmd.Parameters.AddWithValue("@SalesPrice", SalesPrice);

                    object AskingPrice = Trans.AskingPrice.HasValue ? (object)Trans.AskingPrice.Value : DBNull.Value;
                    cmd.Parameters.AddWithValue("@AskingPrice", AskingPrice);

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

        public void Update(Transaction Trans)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE TRANS SET CustomerID = @CustomerID, WorkID = @WorkID, DateAcquired = @DateAcquired, AcquisitionPrice = @AcquisitionPrice, PurchaseDate = @PurchaseDate, SalesPrice = @SalesPrice, AskingPrice = @AskingPrice  WHERE TransactionID = @ID";
                    cmd.Parameters.AddWithValue("@ID", Trans.TransID);
                    cmd.Parameters.AddWithValue("@WorkID", Trans.WorkId);
                    object CustomerID = Trans.CustomerID.HasValue ? (object)Trans.CustomerID.Value : DBNull.Value;
                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                    object DateAcquired = Trans.DateAcquired.HasValue ? (object)Trans.DateAcquired.Value : DBNull.Value;
                    cmd.Parameters.AddWithValue("@DateAcquired", DateAcquired);
                    object AcquisitionPrice = Trans.AcquisitionPrice.HasValue ? (object)Trans.AcquisitionPrice.Value : DBNull.Value;
                    cmd.Parameters.AddWithValue("@AcquisitionPrice", AcquisitionPrice);
                    object PurchaseDate = Trans.PurchaseDate.HasValue ? (object)Trans.PurchaseDate.Value : DBNull.Value;
                    cmd.Parameters.AddWithValue("@PurchaseDate", PurchaseDate);
                    object SalesPrice = Trans.SalesPrice.HasValue ? (object)Trans.SalesPrice.Value : DBNull.Value;
                    cmd.Parameters.AddWithValue("@SalesPrice", SalesPrice);
                    object AskingPrice = Trans.AskingPrice.HasValue ? (object)Trans.AskingPrice.Value : DBNull.Value;
                    cmd.Parameters.AddWithValue("@AskingPrice", AskingPrice);

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

        public void Delete(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM TRANS WHERE TransactionID = @ID";
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
    }
}
