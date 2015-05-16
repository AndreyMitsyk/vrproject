using System.Data;

namespace Vra.DataAccess
{
    public interface IQueryDao
    {
        DataTable Query(string query);
    }
}
