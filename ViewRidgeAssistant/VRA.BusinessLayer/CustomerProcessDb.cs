using System.Collections.Generic;
using Vra.DataAccess;
using VRA.Dto;
using VRA.BusinessLayer.Converters;

namespace VRA.BusinessLayer
{
    public class CustomerProcessDb : ICustomerProcess
    {
        private readonly ICustomerDao _customerDao;

        public CustomerProcessDb()
        {

            _customerDao = DaoFactory.GetCustomerDao();
        }

        public IList<CustomerDto> GetList()
        {
            return DtoConverter.Convert(_customerDao.GetAll());
        }

        public IList<CustomerDto> SearchCustomer(string name, string country, string city)
        {
            return DtoConverter.Convert(_customerDao.SearchCustomer(name, country, city));
        }

        public void Add(CustomerDto customer)
        {
            _customerDao.Add(DtoConverter.Convert(customer));
        }

        public void Update(CustomerDto customer)
        {
            _customerDao.Update(DtoConverter.Convert(customer));
        }

        public void Delete(int id)
        {
            _customerDao.Delete(id);
        }
    }
}
