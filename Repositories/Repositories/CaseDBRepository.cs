using System.Collections.Generic;
using log4net;
using Model.Entities;
using Repositories.Interfaces;

namespace Repositories.Repositories
{
    public class CaseDbRepository : ICaseRepository
    {
        private DbUtils _dbUtils;
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        public CaseDbRepository()
        {
            Log.Info("Creating CaseDbRepository");
            _dbUtils = new DbUtils();
        }

        public void Update(int caseId, double sumToAdd)
        {
            Log.InfoFormat("Entering update function with value {0} and {1}", caseId, sumToAdd);
            var connection = DbUtils.GetConnection();
            {
                Log.Info("DB connection established");
                using (var command = connection.CreateCommand())
                {
                    Log.Info("Creating command");
                    command.CommandText =
                        "update Cases set TotalSumDonated = @sum where Cid = @cid";

                    var cid = command.CreateParameter();
                    cid.ParameterName = "@cid";
                    cid.Value = caseId;
                    command.Parameters.Add(cid);

                    var sum = command.CreateParameter();
                    sum.ParameterName = "@sum";
                    sum.Value = sumToAdd;
                    command.Parameters.Add(sum);
                    int result = command.ExecuteNonQuery();
                    if (result == 0)
                    {
                        Log.InfoFormat("NOT EXECUTED: {0}", command.CommandText);
                    }
                    else
                    {
                        Log.InfoFormat("Executed command: {0}", command.CommandText);
                    }
                }
            }
        }

        public Case FindOne(int id)
        {
            Log.InfoFormat("Entering function find with values {0}", id);
            var connection = DbUtils.GetConnection();
            {
                Log.Info("Connection established");
                using (var command = connection.CreateCommand())
                {
                    Log.Info("Creating command");
                    command.CommandText = "select * from Cases where Cid = @cid";
                    
                    var cid = command.CreateParameter();
                    cid.ParameterName = "@cid";
                    cid.Value = id;
                    command.Parameters.Add(cid);

                    using (var dataR = command.ExecuteReader())
                    {
                        if (dataR.Read())
                        {
                            string name = dataR.GetString(1);
                            double totalSum = dataR.GetDouble(2);
                            Case givenCase = new Case(id, name, totalSum);
                            Log.InfoFormat("Exiting findOne with value : {0}", givenCase.ToString());
                            return givenCase;
                        }
                    }
                }
                Log.InfoFormat("Exiting findOne with value : {0}", null);
                return null;
            }
        }
        
        public IEnumerable<Case> FindAll()
        {
            Log.Info("Entering function findAll");
            IList<Case> cases = new List<Case>();
            var connection = DbUtils.GetConnection();
            {
                Log.Info("Connection established");
                using (var command = connection.CreateCommand())
                {
                    Log.Info("Creating command");
                    command.CommandText = "select * from Cases";
                    
                    using (var dataR = command.ExecuteReader())
                    {
                        while (dataR.Read())
                        {
                            int id = dataR.GetInt32(0);
                            string name = dataR.GetString(1);
                            double totalSum = dataR.GetDouble(2);
                            Case givenCase = new Case(id, name, totalSum);
                            cases.Add(givenCase);
                        }
                    }
                }
                Log.InfoFormat("Exiting findAll with {0} elements in list", cases.Count);
                return cases;
            }
        }
    }
}