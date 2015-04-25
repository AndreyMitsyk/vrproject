using System.Collections.Generic;
using VRA.Dto;

namespace VRA.BusinessLayer
{
    public interface IInterestsProcess
    {
        IEnumerable<InterestsDto> GetList();
        void Add(InterestsDto interest);
        void Delete(InterestsDto interest);
    }
}
