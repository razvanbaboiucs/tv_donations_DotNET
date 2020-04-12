using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using log4net;
using Model.Entities;
using Repositories.Interfaces;

namespace Repositories.Repositories
{
    public class DonorDbRepository : IDonorRepository
    {
        private DbUtils _dbUtils;
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public DonorDbRepository()
        {
            Log.Info("Creating DonorDbRepository");
            _dbUtils = new DbUtils();
        }

        public IEnumerable<Donor> FindBySubstring(string substring)
        {
            IList<Donor> donors = new List<Donor>();
            Log.InfoFormat("Entering find by substring function with value {0}", substring);
            IDbConnection connection = DbUtils.GetConnection();
            {
                Log.Info("DB connection established");
                using (var command = connection.CreateCommand())
                {
                    Log.Info("Creating command");
                    command.CommandText =
                        "select * from Donors where Name like '%" + substring + "%'";
                    using (var dataR = command.ExecuteReader())
                    {
                        while (dataR.Read())
                        {
                            int did = dataR.GetInt32(0);
                            string name = dataR.GetString(1);
                            string address = dataR.GetString(2);
                            string phoneNumber = dataR.GetString(3);
                            Donor donor = new Donor(did, name, address, phoneNumber);
                            donors.Add(donor);
                        }
                    }
                }
            }
            Log.InfoFormat("Exiting with {0} elements in list", donors.Count);
            return donors;
        }

        public int Add(Donor donor)
        {
            Log.InfoFormat("Entering add function with value {0}", donor.ToString());
            IDbConnection connection = DbUtils.GetConnection();
            {
                Log.Info("DB connection established");
                using (var command = connection.CreateCommand())
                {
                    Log.Info("Creating command");
                    command.CommandText =
                        "insert into Donors(Name, Address, PhoneNumber) values (@name, @address, @phoneNumber)";

                    var name = command.CreateParameter();
                    name.ParameterName = "@name";
                    name.Value = donor.Name;
                    command.Parameters.Add(name);

                    var address = command.CreateParameter();
                    address.ParameterName = "@address";
                    address.Value = donor.Address;
                    command.Parameters.Add(address);

                    var phoneNumber = command.CreateParameter();
                    phoneNumber.ParameterName = "@phoneNumber";
                    phoneNumber.Value = donor.PhoneNumber;
                    command.Parameters.Add(phoneNumber);

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
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select * from Donors order by Did desc";
                    using (var dataR = command.ExecuteReader())
                    {
                        if (dataR.Read())
                        {
                            int did = dataR.GetInt32(0);
                            return did;
                        }

                        throw new ValidationException();
                    }
                }
            }
        }

        public void Delete(int id)
        {
            Log.InfoFormat("Entering delete function with value {0}", id.ToString());
            var connection = DbUtils.GetConnection();
            {
                Log.Info("DB connection established");
                using (var command = connection.CreateCommand())
                {
                    Log.Info("Creating command");
                    command.CommandText =
                        "delete from Donors where Did = @did";
                    var did = command.CreateParameter();
                    did.ParameterName = "@did";
                    did.Value = id;
                    command.Parameters.Add(did);
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

        public void Update(Donor donor)
        {
            Log.InfoFormat("Entering update function with value {0}", donor.ToString());
            var connection = DbUtils.GetConnection();
            {
                Log.Info("DB connection established");
                using (var command = connection.CreateCommand())
                {
                    Log.Info("Creating command");
                    command.CommandText =
                        "update Donors set Name = @name, Address = @address, PhoneNumber = @phoneNumber where Did = @did";
                    
                    var did = command.CreateParameter();
                    did.ParameterName = "@did";
                    did.Value = donor.Id;
                    command.Parameters.Add(did);

                    var name = command.CreateParameter();
                    name.ParameterName = "@name";
                    name.Value = donor.Name;
                    command.Parameters.Add(name);

                    var address = command.CreateParameter();
                    address.ParameterName = "@address";
                    address.Value = donor.Address;
                    command.Parameters.Add(address);

                    var phoneNumber = command.CreateParameter();
                    phoneNumber.ParameterName = "@phoneNumber";
                    phoneNumber.Value = donor.PhoneNumber;
                    command.Parameters.Add(phoneNumber);
                    
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
        
        public Donor FindOne(int id)
        {
            Log.InfoFormat("Entering findOne with value {0}", id);
            var connection = DbUtils.GetConnection();
            {
                Log.Info("DB connection established");
                using (var command = connection.CreateCommand())
                {
                    Log.Info("Creating command");
                    command.CommandText = "select * from Donors where Did=@did";
                    IDbDataParameter paramId = command.CreateParameter();
                    paramId.ParameterName = "@did";
                    paramId.Value = id;
                    command.Parameters.Add(paramId);

                    using (var dataR = command.ExecuteReader())
                    {
                        if (dataR.Read())
                        {
                            int did = dataR.GetInt32(0);
                            string name = dataR.GetString(1);
                            string address = dataR.GetString(2);
                            string phoneNumber = dataR.GetString(3);
                            Donor donor = new Donor(did, name, address, phoneNumber);
                            Log.InfoFormat("Exiting findOne with value {0}", donor);
                            return donor;
                        }
                    }
                }
                Log.InfoFormat("Exiting findOne with value {0}", null);
                return null;
            }
        }

        public IEnumerable<Donor> FindAll()
        {
            Log.Info("Entering find all function");
            IList<Donor> donors = new List<Donor>();
            var connection = DbUtils.GetConnection();
            {
                Log.Info("DB connection established");
                using (var command = connection.CreateCommand())
                {
                    Log.Info("Creating command");
                    command.CommandText = "select * from Donors";
                    using (var dataR = command.ExecuteReader())
                    {
                        while (dataR.Read())
                        {
                            int did = dataR.GetInt32(0);
                            string name = dataR.GetString(1);
                            string address = dataR.GetString(2);
                            string phoneNumber = dataR.GetString(3);
                            Donor donor = new Donor(did, name, address, phoneNumber);
                            donors.Add(donor);
                        }
                    }
                }
            }
            Log.InfoFormat("Exiting with {0} elements in list", donors.Count);
            return donors;
        }
    }
}