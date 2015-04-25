using System.Configuration;
using System.Data.SqlClient;

namespace Vra.DataAccess
{
    public class SettingsDao : ISettingsDao
    {
        public string GetSettings()
        {
            try
            {
                return ConfigurationManager.ConnectionStrings["vradb"].ConnectionString;
            }
            catch
            {
                return null;
            }
        }

        public bool SetSettings(string server, string db, string user, string password)
        {
            SqlConnectionStringBuilder conStr = new SqlConnectionStringBuilder
            {
                DataSource = server,
                InitialCatalog = db
            };

            if (user == "")
            {
                conStr.IntegratedSecurity = true;
            }
            else
            {
                conStr.UserID = user;
                conStr.Password = password;
            }
            try
            {
                SqlConnection con = new SqlConnection(conStr.ConnectionString);
                con.Open();
            }
            catch
            {
                return false;
            }

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings["vradb"].ConnectionString = conStr.ConnectionString;
            config.Save();
            ConfigurationManager.RefreshSection("connectionStrings");
            config = ConfigurationManager.OpenExeConfiguration("VRA.exe");
            config.ConnectionStrings.ConnectionStrings["vradb"].ConnectionString = conStr.ConnectionString;
            config.Save();
            ConfigurationManager.RefreshSection("connectionStrings");

            return true;
        }
    }
}
