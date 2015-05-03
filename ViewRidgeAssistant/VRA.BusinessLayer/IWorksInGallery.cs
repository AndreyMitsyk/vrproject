using System.Collections.Generic;
using VRA.Dto;

namespace VRA.BusinessLayer
{
    public interface IWorksInGallery
    {
        IList<WorksInGalleryDto> GetList();
    }
}
