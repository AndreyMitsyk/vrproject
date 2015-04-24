using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRA.Dto;

namespace VRA.BusinessLayer
{
    public class CustomerProcess : ICustomerProcess
    {
        private static readonly IDictionary<int, CustomerDto> Customers = new Dictionary<int, CustomerDto>();

        public IList<CustomerDto> GetList()
        {
            return new List<CustomerDto>(Customers.Values);
        }

        public CustomerDto Get(int id)
        {
            if (Customers.ContainsKey(id))
                return Customers[id];
            else return null;
        }

        public void Add(CustomerDto Customer)
        {
            int max = Customers.Keys.Count + 1;
            Customer.Id = max;
            Customers.Add(max, Customer);

        }

        public void Update(CustomerDto Customer)
        {
            if (Customers.ContainsKey(Customer.Id)) Customers[Customer.Id] = Customer;
        }

        public void Delete(int id)
        {
            if (Customers.ContainsKey(id)) Customers.Remove(id);
        }

        public IList<CustomerDto> SearchCustomer(string name, string country, string city)
        {
            throw new NotImplementedException();
        }
    }
}
