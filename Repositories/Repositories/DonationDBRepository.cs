using System.Data;
using log4net;
using Model.Entities;
using Repositories.Interfaces;

namespace Repositories.Repositories
{
    public class DonationDbRepository : IDonationRepository
    {
        private DbUtils _dbUtils;
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        public DonationDbRepository()
        {
            Log.Info("Creating DonationDbRepository");
            _dbUtils = new DbUtils();
        }
        
        public void Add(Donation donation)
        {
            Log.InfoFormat("Entering add function with value {0}", donation.ToString());
            IDbConnection connection = DbUtils.GetConnection();
            {
                Log.Info("DB connection established");
                using (var command = connection.CreateCommand())
                {
                    Log.Info("Creating command");
                    command.CommandText =
                        "insert into Donations(Did, Cid, SumDonated) values (@did, @cid, @sumDonated)";

                    var did = command.CreateParameter();
                    did.ParameterName = "@did";
                    did.Value = donation.DonorId;
                    command.Parameters.Add(did);

                    var cid = command.CreateParameter();
                    cid.ParameterName = "@cid";
                    cid.Value = donation.CaseId;
                    command.Parameters.Add(cid);

                    var sumDonated = command.CreateParameter();
                    sumDonated.ParameterName = "@sumDonated";
                    sumDonated.Value = donation.SumDonated;
                    command.Parameters.Add(sumDonated);
                    
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
        
        
    }
}