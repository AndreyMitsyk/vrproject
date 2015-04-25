using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vra.DataAccess
{
    public interface ISettingsDao
    {
        string GetSettings();
        bool SetSettings(string path);//************ лишний метод?
        bool SetSettings(string server, string db, string user, string password);
    }
}
