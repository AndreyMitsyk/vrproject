using System.Collections.Generic;
using Vra.DataAccess.Entities;

namespace Vra.DataAccess
{
    public interface IWorkInGalleryDao
    {
        IEnumerable<WorkInGallery> GetAll();
    }
}
