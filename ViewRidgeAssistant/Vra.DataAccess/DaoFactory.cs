using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vra.DataAccess
{
    public class DaoFactory
    {
        public static IArtistDao GetArtistDao()
        {
            return new ArtistDao();
        }

        public static INationDao GetNationDao()
        {
            return new NationDao();
        }

        public static IInterestsDao GetInterestDao()
        {
            return new InterestDao();
        }

        public static ICustomerDao GetCustomerDao()
        {
            return new CustomerDao();
        }

        public static IWorkDao GetWorkDao()
        {
            return new WorkDao();
        }

        public static ITransactionDao GetTransactionDao()
        {
            return new TransactionDao();
        }

        public static SettingsDao GetSettingsDao()
        {
            return new SettingsDao();
        }
    }
}
