using System.Collections.Generic;
using Vra.DataAccess.Entities;

namespace Vra.DataAccess
{
    public interface ITransactionDao
    {
        IEnumerable<Transaction> GetAll();
        Transaction Get(int id);
        void Add(Transaction Trans);
        void Update(Transaction Trans);
        void Delete(int id);
    }
}
