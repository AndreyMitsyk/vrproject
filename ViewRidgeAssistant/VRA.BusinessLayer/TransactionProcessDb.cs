using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vra.DataAccess;
using VRA.BusinessLayer;
using VRA.Dto;
using VRA.BusinessLayer.Converters;

namespace VRA.BusinessLayer
{
    public class TransactionProcessDb : ITransactionProcess
    {
        private readonly ITransactionDao _TransDao;

        public TransactionProcessDb()
        {
            _TransDao = DaoFactory.GetTransactionDao();
        }

        public IList<TransactionDto> GetList()
        {
            return DtoConverter.Convert(_TransDao.GetAll());
        }

        public IList<TransactionDto> GetListInGallery()
        {
            return DtoConverter.Convert(_TransDao.GetInGallery());
        }

        public TransactionDto Get(int id)
        {
            return DtoConverter.Convert(_TransDao.Get(id));
        }

        public TransactionDto GetLast()
        {
            return DtoConverter.Convert(_TransDao.GetLast());
        }

        public void Add(TransactionDto Trans)
        {
            _TransDao.Add(DtoConverter.Convert(Trans));
        }

        public void Update(TransactionDto Trans)
        {
            _TransDao.Update(DtoConverter.Convert(Trans));
        }

        public void Delete(int id)
        {
            _TransDao.Delete(id);
        }
    }
}
