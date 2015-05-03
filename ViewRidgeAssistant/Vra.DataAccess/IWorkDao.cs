using System.Collections.Generic;
using Vra.DataAccess.Entities;

namespace Vra.DataAccess
{
    public interface IWorkDao
    {
        Work Get(int id);
        IEnumerable<Work> GetAll();
        void Add(Work work);
        void Update(Work work);
        void Delete(int id);
        IEnumerable<Work> SearchWork(string Title, string Artist, string Copy);
    }
}
