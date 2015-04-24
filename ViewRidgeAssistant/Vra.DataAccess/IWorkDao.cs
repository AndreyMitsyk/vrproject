using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vra.DataAccess.Entities;

namespace Vra.DataAccess
{
    public interface IWorkDao
    {
        Work Get(int id);
        IList<Work> GetAll();
        IList<Work> GetInGallery();
        void Add(Work work);
        void Update(Work work);
        void Delete(int id);
        IList<Work> SearchWork(string Title, string Artist, string Copy);
    }
}
