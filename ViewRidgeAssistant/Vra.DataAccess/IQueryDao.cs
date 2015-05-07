using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Vra.DataAccess
{
    public interface IQueryDao
    {
        DataTable Query(string query);
    }
}
