using System.Collections.Generic;
using VRA.BusinessLayer.Converters;
using VRA.Dto;
using Vra.DataAccess;

namespace VRA.BusinessLayer
{
    public class NationProcess : INationProcess
    {
        private static readonly INationDao NatDao = new NationDao();

        public IList<NationDto> GetList()
        {
            return DtoConverter.Convert(DaoFactory.GetNationDao().Load());
        }

        public void Add(NationDto n)
        {
            NatDao.Add(DtoConverter.Convert(n));
        }
        public void Delete(int id)
        {
            NatDao.Delete(id);
        }
    }
}
