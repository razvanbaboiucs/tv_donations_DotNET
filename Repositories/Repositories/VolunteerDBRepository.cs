using log4net;
using Model.Entities;
using Repositories.Interfaces;

namespace Repositories.Repositories
{
    public class VolunteerDbRepository : IVolunteerRepository
    {
        private DbUtils _dbUtils;
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        public VolunteerDbRepository()
        {
            Log.Info("Creating VolunteerDbRepository");
            _dbUtils = new DbUtils();
        }

        public Volunteer FindOne(string username, string password)
        {
            Log.InfoFormat("Entering function find with values {0}, {1}", username, password);
            var connection = DbUtils.GetConnection();
            {
                Log.Info("Connection established");
                using (var command = connection.CreateCommand())
                {
                    Log.Info("Creating command");
                    command.CommandText =
                        "select * from Volunteers where Username = @username and Password = @password";
                    
                    var usernameParam = command.CreateParameter();
                    usernameParam.ParameterName = "@username";
                    usernameParam.Value = username;
                    command.Parameters.Add(usernameParam);
                    
                    var passwordParam = command.CreateParameter();
                    passwordParam.ParameterName = "@password";
                    passwordParam.Value = password;
                    command.Parameters.Add(passwordParam);

                    using (var dataR = command.ExecuteReader())
                    {
                        Log.Info("Command executed");
                        if (dataR.Read())
                        {
                            int id = dataR.GetInt32(0);
                            Log.InfoFormat("Id read : {0}", id);
                            Volunteer volunteer = new Volunteer(id, username, password);
                            Log.InfoFormat("Exited with value {0}", volunteer);
                            return volunteer;
                        }
                    }
                }
            }
            Log.Info("Exiting findOne with value null");
            return null;
        }
    }
}