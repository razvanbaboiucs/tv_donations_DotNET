using System.Data;
using System.Data.SQLite;

namespace Repositories.Repositories
{
    public class DbUtils
    {

        public DbUtils()
        {
        }

        private static IDbConnection _instance = null;

        public static IDbConnection GetConnection()
        {
            string url = @"URI=" + System.Configuration.ConfigurationSettings.AppSettings["db.url"];
            if (_instance == null)
            {
                _instance = new SQLiteConnection(url);
                _instance.Open();
            }

            return _instance;
        }
    }
}