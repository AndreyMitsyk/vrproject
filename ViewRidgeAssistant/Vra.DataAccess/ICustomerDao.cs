using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vra.DataAccess.Entities;

namespace Vra.DataAccess
{
    public interface ICustomerDao
    {

        Customer Get(int? id);

        IList<Customer> GetAll();

        IList<Customer> SearchCustomer(string Name, string Country, string City);

        void Add(Customer customer);

        void Update(Customer customer);

        void Delete(int id);
    }
}
