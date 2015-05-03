using System.Collections.Generic;
using VRA.BusinessLayer.Converters;
using Vra.DataAccess;
using VRA.Dto;

namespace VRA.BusinessLayer
{
    class WorksInGalleryProcessDb : IWorksInGallery
    {
        private readonly IWorkInGalleryDao _worksInGallery;
        public WorksInGalleryProcessDb()
        {
            _worksInGallery = DaoFactory.GetWorkInGalleryDao();
        }
        public IList<WorksInGalleryDto> GetList()
        {
            return DtoConverter.Convert(_worksInGallery.GetAll());
        }
    }
}
