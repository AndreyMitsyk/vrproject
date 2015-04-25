using System.Collections.Generic;
using Vra.DataAccess.Entities;

namespace Vra.DataAccess
{
    public interface IInterestsDao
    {
        IEnumerable<Interests> GetAll();

        void Add(Interests interest);

        void Delete(int ArtistID, int CustomerID);
    }
}
