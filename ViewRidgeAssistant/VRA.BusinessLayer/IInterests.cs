using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRA.Dto;

namespace VRA.BusinessLayer
{
    public interface IInterestsProcess
    {
        IList<InterestsDto> GetList();
        void Add(InterestsDto interest);
        void Delete(InterestsDto interest);
    }
}
