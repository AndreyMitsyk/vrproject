using System.Collections.Generic;
using Vra.DataAccess;
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

        public TransactionDto Get(int id)
        {
            return DtoConverter.Convert(_TransDao.Get(id));
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
