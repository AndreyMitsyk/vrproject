namespace Vra.DataAccess
{
    public static class DaoFactory
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

        public static IWorkInGalleryDao GetWorkInGalleryDao()
        {
            return new WorkInGalleryDao();
        }

        public static ITransactionDao GetTransactionDao()
        {
            return new TransactionDao();
        }

        public static IQueryDao GetQueryDao()
        {
            return new QueryDao();
        }
    }
}
