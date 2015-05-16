using System.Data;

namespace VRA.BusinessLayer
{
    public interface IQueryProcess
    {
        DataTable Query(string query);
    }
}
