using System.Data;
using Vra.DataAccess;

namespace VRA.BusinessLayer
{
    public class QueryProcess : IQueryProcess
    {
        private readonly IQueryDao _queryDao;

        public QueryProcess()
        {
            _queryDao = DaoFactory.GetQueryDao();
        }

        public DataTable Query(string query)
        {
            return _queryDao.Query(query);
        }
    }
}
