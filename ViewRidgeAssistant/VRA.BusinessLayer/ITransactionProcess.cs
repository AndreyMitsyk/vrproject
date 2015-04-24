using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRA.Dto;

namespace VRA.BusinessLayer
{
    public interface ITransactionProcess
    {
        IList<TransactionDto> GetList();
        IList<TransactionDto> GetListInGallery();
        TransactionDto Get(int id);
        TransactionDto GetLast();
        void Add(TransactionDto Trans);
        void Update(TransactionDto Trans);
        void Delete(int id);
    }
}
