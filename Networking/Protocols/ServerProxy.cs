using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using Model.Entities;
using Networking.Requests;
using Networking.Responses;
using Networking.Responses.UpdateResponses;
using Services;

namespace Networking.Protocols
{
    public class ServerProxy : IService
    {
        private string _host;

        
        private int _port;
        
        private NetworkStream _stream;
        private IObserver _client;

        public IObserver Client
        {
            get => _client;
            set => _client = value;
        }

        private IFormatter _formatter;
        private TcpClient _connection;

        private Queue<IResponse> _responses;
        private volatile bool _finished;
        private EventWaitHandle _waitHandle;

        private string Host
        {
            get => _host;
            set => _host = value;
        }

        private int Port
        {
            get => _port;
            set => _port = value;
        }

        private NetworkStream Stream
        {
            get => _stream;
            set => _stream = value;
        }

        private IFormatter Formatter
        {
            get => _formatter;
            set => _formatter = value;
        }

        private TcpClient Connection
        {
            get => _connection;
            set => _connection = value;
        }

        private Queue<IResponse> Responses
        {
            get => _responses;
            set => _responses = value;
        }

        private bool Finished
        {
            get => _finished;
            set => _finished = value;
        }

        private EventWaitHandle WaitHandle
        {
            get => _waitHandle;
            set => _waitHandle = value;
        }

        public ServerProxy(string host, int port)
        {
            _host = host;
            _port = port;
            Responses = new Queue<IResponse>();
        }


        public void NotifyObserversDonationAdded()
        {
            SendRequest(new AddingNewDonation());
        }

        public void Logout(IObserver client)
        {
            SendRequest(new LogoutRequest());
            IResponse response = ReadResponse();
            CloseConnection();
            if (response is ErrorResponse)
            {
                ErrorResponse errorResponse = (ErrorResponse) response;
                throw new Exception(errorResponse.Message);
            }
        }

        public Volunteer FindVolunteer(string username, string password, IObserver client)
        {
            initializeConnection();
            Volunteer volunteer = new Volunteer(0, username, password);
            SendRequest(new LoginRequest(volunteer));
            IResponse response = ReadResponse();
            if (response is OkResponse)
            {
                Client = client;
                return volunteer;
            }
            else
            {
                ErrorResponse errorResponse = (ErrorResponse) response;
                CloseConnection();
                throw new Exception(errorResponse.Message);
            }
        }

        public int AddDonor(string name, string address, string phoneNumber)
        {
            SendRequest(new AddDonorRequest(name, address, phoneNumber));
            IResponse response = ReadResponse();
            if (response is AddDonorResponse)
            {
                AddDonorResponse addDonorResponse = (AddDonorResponse) response;
                int id = addDonorResponse.Did;
                return id;
            }
            if (response is ErrorResponse)
            {
                ErrorResponse errorResponse = (ErrorResponse) response;
                throw new Exception(errorResponse.Message);
            }
            return -1;
        }

        public IEnumerable<Donor> FindAllDonors()
        {
            SendRequest(new GetAllDonorsRequest());
            IResponse response = ReadResponse();
            if (response is GetAllDonorsResponse)
            {
                GetAllDonorsResponse getAllDonorsResponse = (GetAllDonorsResponse) response;
                IEnumerable<Donor> donors = getAllDonorsResponse.Donors;
                return donors;
            }

            if (response is ErrorResponse)
            {
                ErrorResponse errorResponse = (ErrorResponse) response;
                throw new Exception(errorResponse.Message);
            }

            return null;
        }

        public IEnumerable<Donor> FindAllDonorsBySubstring(string substring)
        {
            SendRequest(new GetAllDonorsBySubstringRequest(substring));
            IResponse response = ReadResponse();
            if (response is GetAllDonorsBySubstringResponse)
            {
                GetAllDonorsBySubstringResponse getAllDonorsBySubstringResponse =
                    (GetAllDonorsBySubstringResponse) response;
                IEnumerable<Donor> donors = getAllDonorsBySubstringResponse.Donors;
                return donors;
            }

            if (response is ErrorResponse)
            {
                ErrorResponse errorResponse = (ErrorResponse) response;
                throw new Exception(errorResponse.Message);
            }
            return null;
        }

        public IEnumerable<Case> FindAllCases()
        {
            SendRequest(new GetAllCasesRequest());
            IResponse response = ReadResponse();
            if (response is GetAllCasesResponse)
            {
                GetAllCasesResponse getAllCasesResponse = (GetAllCasesResponse) response;
                IEnumerable<Case> cases = getAllCasesResponse.Cases;
                return cases;
            }
            if (response is ErrorResponse)
            {
                ErrorResponse errorResponse = (ErrorResponse) response;
                throw new Exception(errorResponse.Message);
            }

            return null;
        }

        public void AddDonation(int did, int cid, double sumDonated)
        {
            SendRequest(new AddDonationRequest(did, cid, sumDonated));
            IResponse response = ReadResponse();
            if (response is ErrorResponse)
            {
                ErrorResponse errorResponse = (ErrorResponse) response;
                throw new Exception(errorResponse.Message);
            }
            
            NotifyObserversDonationAdded();
        }

        public void UpdateCase(int caseId, double sumToAdd)
        {
            
        }

        private void CloseConnection()
        {
            Finished = true;
            try
            {
                Stream.Close();
                Connection.Close();
                WaitHandle.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        
        private IResponse ReadResponse()
        {
            IResponse response = null;
            try
            {
                _waitHandle.WaitOne();
                lock (Responses)
                {
                    //Monitor.Wait(responses); 
                    response = Responses.Dequeue();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return response;
        }
        
        private void SendRequest(IRequest request)
        {
            try
            {
                Formatter.Serialize(Stream, request);
                Stream.Flush();
            }
            catch (Exception e)
            {
                throw new Exception("Error sending object "+e);
            }
        }
        
        private void initializeConnection()
        {
            try
            {
                Connection=new TcpClient(Host, Port);
                Stream=Connection.GetStream();
                Formatter = new BinaryFormatter();
                Finished=false;
                _waitHandle = new AutoResetEvent(false);
                StartReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        private void StartReader()
        {
            Thread tw =new Thread(Run); 
            tw.Start();
        }

        public virtual void Run()
        {
            while(!Finished)
            {
                try
                {
                    object response = Formatter.Deserialize(Stream);
                    Console.WriteLine("response received "+response);
                    if (response is IUpdateResponse)
                    {
                        HandleUpdate((IUpdateResponse)response);
                    }
                    else
                    {
                        lock (Responses)
                        {
                            Responses.Enqueue((IResponse)response);
                        }
                        _waitHandle.Set();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Reading error "+e);
                }
            }
        }

        private void HandleUpdate(IUpdateResponse response)
        {
            if (response is NewDonationAddedUpdate)
            {
                try
                {
                    NewDonationAddedUpdate update = (NewDonationAddedUpdate) response;
                    IEnumerable<Donor> donors = update.Donors;
                    IEnumerable<Case> cases = update.Cases;
                    Client.DonationAdded(donors, cases);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
        }
    }
}