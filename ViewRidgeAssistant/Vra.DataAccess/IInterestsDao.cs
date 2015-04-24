using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vra.DataAccess.Entities;

namespace Vra.DataAccess
{
    public interface IInterestsDao
    {
        IList<Interests> GetAll();

        void Add(Interests interest);

        void Delete(int ArtistID, int CustomerID);
    }
}
