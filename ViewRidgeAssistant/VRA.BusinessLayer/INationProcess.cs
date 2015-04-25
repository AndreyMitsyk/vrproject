using System.Collections.Generic;
using VRA.Dto;

namespace VRA.BusinessLayer
{
    public interface INationProcess
    {
        IList<NationDto> GetList();
        void Add(NationDto n);
        void Delete(int id);
    }
}
