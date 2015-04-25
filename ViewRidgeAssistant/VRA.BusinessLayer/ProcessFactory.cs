namespace VRA.BusinessLayer
{
    /// <summary>
    /// Фабрика классов бизнес-логики
    /// </summary>
    public static class ProcessFactory
    {
        /// <summary>
        /// Возвращает объект, реализующий <seealso cref="IArtistProcess"/>
        /// </summary>
        /// <returns></returns>
        public static IArtistProcess GetArtistProcess()
        {
            return new ArtistProcessDb();
        }

        /// <summary>
        /// Возвращает объект, реализующий <seealso cref="ICustomerProcess"/>
        /// </summary>
        /// <returns></returns>
        public static ICustomerProcess GetCustomerProcess()
        {
            return new CustomerProcessDb();
        }

        public static ISettingsProcess GetSettingsProcess()
        {
            return new SettingsProcess();
        }

        public static INationProcess GetNationProcess()
        {
            return new NationProcess();
        }

        public static IInterestsProcess GetInterestsProcess()
        {
            return new InterestsProcessDb();
        }

        public static IWorkProcess GetWorkProcess()
        {
            return new WorkProcessDb();
        }

        public static ITransactionProcess GetTransactionProcess()
        {
            return new TransactionProcessDb();
        }

        public static ReportGenerator GetReport()
        {
            return new ReportGenerator();
        }

        /// <summary>
        /// Возвращает объект реализующий <seealso cref="IReportItemProcess"/>
        /// </summary>
        /// <returns></returns>
        public static IReportItemProcess GetReportProcess()
        {
            return new ReportItemProcess();
        }
    }
}
