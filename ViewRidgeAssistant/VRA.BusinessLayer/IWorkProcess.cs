using System.Collections.Generic;
using VRA.Dto;

namespace VRA.BusinessLayer
{
    public interface IWorkProcess
    {
        /// <summary>
        /// returns work list
        /// </summary>
        /// <returns>Work list in data base</returns>
        IList<WorkDto> GetList();
        IList<WorkDto> GetListInGallery();
        void Add(WorkDto work);
        void Update(WorkDto work);

        /// <summary>
        /// delete work with this id
        /// </summary>
        /// <param name="id"> uniq identifier</param>
        void Delete(int id);

        IList<WorkDto> SearchWork(string title, string ArtistName, string Copy);
    }
}
