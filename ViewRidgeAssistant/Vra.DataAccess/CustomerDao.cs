using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Vra.DataAccess.Entities;

namespace Vra.DataAccess
{
    public class CustomerDao : BaseDao, ICustomerDao
    {
        private static Customer LoadCustomer(SqlDataReader reader)
        {
            //Создаём пустой объект
            Customer customer = new Customer();
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных

            customer.CustomerId = reader.GetInt32(reader.GetOrdinal("CustomerID"));
            customer.Name = reader.GetString(reader.GetOrdinal("Name"));
            customer.Email = reader.GetString(reader.GetOrdinal("Email"));

            //остальные строки могут иметь значение NULL

            object tmp = reader["AreaCode"];

            if (tmp != DBNull.Value)
                customer.AreaCode = Convert.ToString(tmp);

            tmp = reader["PhoneNumber"];
            if (tmp != DBNull.Value)
                customer.PhoneNumber = Convert.ToString(tmp);

            tmp = reader["Street"];
            if (tmp != DBNull.Value)
                customer.Street = Convert.ToString(tmp);

            tmp = reader["City"];
            if (tmp != DBNull.Value)
                customer.City = Convert.ToString(tmp);

            tmp = reader["Region"];
            if (tmp != DBNull.Value)
                customer.Region = Convert.ToString(tmp);

            tmp = reader["ZipPostalCode"];
            if (tmp != DBNull.Value)
                customer.ZipPostalCode = Convert.ToString(tmp);

            tmp = reader["Country"];
            if (tmp != DBNull.Value)
                customer.Country = Convert.ToString(tmp);

            tmp = reader["HouseNumber"];
            if (tmp != DBNull.Value)
                customer.HouseNumber = Convert.ToString(tmp);

            return customer;
        }

        public Customer Get(int? id)
        {
            if (id == null) return null;

            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT CustomerID, Name, Email, AreaCode, PhoneNumber, Street, City, Region, ZipPostalCode, Country, HouseNumber FROM CUSTOMER WHERE CustomerID = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    using (var dataReader = cmd.ExecuteReader())
                        return !dataReader.Read() ? null : LoadCustomer(dataReader);
                }
            }
        }

        public IList<Customer> GetAll()
        {
            IList<Customer> customers = new List<Customer>();
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT CustomerID, Name, Email, AreaCode, PhoneNumber, Street, City, Region, ZipPostalCode, Country, HouseNumber FROM CUSTOMER";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            customers.Add(LoadCustomer(dataReader));
                        }
                    }
                }
            }
            return customers;
        }

        public IList<Customer> SearchCustomer(string Name, string Country, string City)
        {
            IList<Customer> customers = new List<Customer>();
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT CustomerID, Name, Email, AreaCode, PhoneNumber, Street, City, Region, ZipPostalCode, Country, HouseNumber FROM CUSTOMER WHERE Name like @Name AND Country like @Country AND City like @City";
                    cmd.Parameters.AddWithValue("@Name", "%" + Name + "%");
                    cmd.Parameters.AddWithValue("@Country", "%" + Country + "%");
                    cmd.Parameters.AddWithValue("@City", "%" + City + "%");
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            customers.Add(LoadCustomer(dataReader));
                        }
                    }
                }
            }
            return customers;
        }

        public void Add(Customer customer)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO CUSTOMER (Name, Email, AreaCode, PhoneNumber, Street, City, Region, ZipPostalCode, Country, HouseNumber) VALUES (@Name, @Email, @AreaCode, @PhoneNumber, @Street, @City, @Region, @ZipPostalCode, @Country, @HouseNumber)";

                    cmd.Parameters.AddWithValue("@Name", customer.Name);
                    cmd.Parameters.AddWithValue("@Email", customer.Email);

                    object tmp = customer.AreaCode != null ? (object)customer.AreaCode : DBNull.Value;
                    cmd.Parameters.AddWithValue("@AreaCode", tmp);

                    tmp = customer.PhoneNumber != null ? (object)customer.PhoneNumber : DBNull.Value;
                    cmd.Parameters.AddWithValue("@PhoneNumber", tmp);

                    tmp = customer.Street != null ? (object)customer.Street : DBNull.Value;
                    cmd.Parameters.AddWithValue("@Street", tmp);

                    tmp = customer.City != null ? (object)customer.City : DBNull.Value;
                    cmd.Parameters.AddWithValue("@City", tmp);

                    tmp = customer.Region != null ? (object)customer.Region : DBNull.Value;
                    cmd.Parameters.AddWithValue("@Region", tmp);

                    tmp = customer.ZipPostalCode != null ? (object)customer.ZipPostalCode : DBNull.Value;
                    cmd.Parameters.AddWithValue("@ZipPostalCode", tmp);

                    tmp = customer.Country != null ? (object)customer.Country : DBNull.Value;
                    cmd.Parameters.AddWithValue("@Country", tmp);

                    tmp = customer.HouseNumber != null ? (object)customer.HouseNumber : DBNull.Value;
                    cmd.Parameters.AddWithValue("@HouseNumber", tmp);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Customer customer)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE CUSTOMER  SET Name = @Name, Email = @Email, AreaCode = @AreaCode, PhoneNumber=@PhoneNumber, Street = @Street, City = @City, Region = @Region, ZipPostalCode=@ZipPostalCode, Country = @Country, HouseNumber = @HouseNumber WHERE CustomerID = @ID";

                    cmd.Parameters.AddWithValue("@Name", customer.Name);
                    cmd.Parameters.AddWithValue("@Email", customer.Email);

                    object tmp = customer.AreaCode != null ? (object)customer.AreaCode : DBNull.Value;
                    cmd.Parameters.AddWithValue("@AreaCode", tmp);

                    tmp = customer.PhoneNumber != null ? (object)customer.PhoneNumber : DBNull.Value;
                    cmd.Parameters.AddWithValue("@PhoneNumber", tmp);

                    tmp = customer.Street != null ? (object)customer.Street : DBNull.Value;
                    cmd.Parameters.AddWithValue("@Street", tmp);

                    tmp = customer.City != null ? (object)customer.City : DBNull.Value;
                    cmd.Parameters.AddWithValue("@City", tmp);

                    tmp = customer.Region != null ? (object)customer.Region : DBNull.Value;
                    cmd.Parameters.AddWithValue("@Region", tmp); // баг

                    tmp = customer.ZipPostalCode != null ? (object)customer.ZipPostalCode : DBNull.Value;
                    cmd.Parameters.AddWithValue("@ZipPostalCode", tmp);

                    tmp = customer.Country != null ? (object)customer.Country : DBNull.Value;
                    cmd.Parameters.AddWithValue("@Country", tmp);

                    tmp = customer.HouseNumber != null ? (object)customer.HouseNumber : DBNull.Value;
                    cmd.Parameters.AddWithValue("@HouseNumber", tmp);

                    cmd.Parameters.AddWithValue("@ID", customer.CustomerId);

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
                    cmd.CommandText = "DELETE FROM CUSTOMER WHERE CustomerID = @ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
