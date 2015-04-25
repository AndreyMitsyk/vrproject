using System.Collections.Generic;
using Vra.DataAccess.Entities;

namespace Vra.DataAccess
{
    public interface ICustomerDao
    {

        Customer Get(int? id);

        IEnumerable<Customer> GetAll();

        IEnumerable<Customer> SearchCustomer(string Name, string Country, string City);

        void Add(Customer customer);

        void Update(Customer customer);

        void Delete(int id);
    }
}
