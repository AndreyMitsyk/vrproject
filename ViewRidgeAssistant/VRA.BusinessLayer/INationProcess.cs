using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
