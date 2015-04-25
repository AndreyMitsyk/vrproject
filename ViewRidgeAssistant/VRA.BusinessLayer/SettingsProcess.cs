using Vra.DataAccess;

namespace VRA.BusinessLayer
{
    public class SettingsProcess : ISettingsProcess
    {
        private readonly ISettingsDao _settingsdao;

        public SettingsProcess()
        {
            _settingsdao = new SettingsDao();
        }

        public string GetSettings()
        {
            return _settingsdao.GetSettings();
        }

        public bool SetSettings(string server, string db, string user, string password)
        {
            return _settingsdao.SetSettings(server, db, user, password);
        }
    }
}
