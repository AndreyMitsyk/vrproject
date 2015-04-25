namespace Vra.DataAccess
{
    public interface ISettingsDao
    {
        string GetSettings();
        bool SetSettings(string server, string db, string user, string password);
    }
}
