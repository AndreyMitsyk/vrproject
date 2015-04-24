using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vra.DataAccess.Entities;

namespace Vra.DataAccess
{
    public interface ITransactionDao
    {
        IList<Transaction> GetAll();
        IList<Transaction> GetInGallery();
        Transaction Get(int id);
        Transaction GetLast();
        void Add(Transaction Trans);
        void Update(Transaction Trans);
        void Delete(int id);
    }
}
