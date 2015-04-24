using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vra.DataAccess;
using VRA.BusinessLayer;
using VRA.Dto;
using VRA.BusinessLayer.Converters;

namespace VRA.BusinessLayer
{
    public class InterestsProcessDb : IInterestsProcess
    {
        private readonly IInterestsDao Interests = DaoFactory.GetInterestDao();

        public IList<InterestsDto> GetList()
        {
            return DtoConverter.Convert(Interests.GetAll());
        }

        public void Add(InterestsDto interest)
        {
            Interests.Add(DtoConverter.Convert(interest));
        }

        public void Delete(InterestsDto interest)
        {
            Interests.Delete(interest.Artist.Id, interest.Customer.Id);
        }
    }
}
