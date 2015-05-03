using System.Collections.Generic;
using VRA.Dto;

namespace VRA.BusinessLayer
{
    public interface ITransactionProcess
    {
        IList<TransactionDto> GetList();
        TransactionDto Get(int id);
        void Add(TransactionDto Trans);
        void Update(TransactionDto Trans);
        void Delete(int id);
    }
}
