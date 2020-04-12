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
    public class ClientWorker : IObserver
    {
        private IService _serverService;
        private TcpClient _connection;
        
        private NetworkStream _stream;
        private IFormatter _formatter;
        private volatile bool _connected;

        private IService ServerService
        {
            get => _serverService;
            set => _serverService = value;
        }

        private TcpClient Connection
        {
            get => _connection;
            set => _connection = value;
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

        private bool Connected
        {
            get => _connected;
            set => _connected = value;
        }

        public ClientWorker(IService serverService, TcpClient connection)
        {
            _serverService = serverService;
            _connection = connection;
            try
            {
                _stream = connection.GetStream();
                _formatter = new BinaryFormatter();
                _connected = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        
        public virtual void Run()
        {
            while(_connected)
            {
                try
                {
                    object request = _formatter.Deserialize(_stream);
                    object response = HandleRequest((IRequest)request);
                    if (response!=null)
                    {
                        SendResponse((IResponse) response);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
				
                try
                {
                    Thread.Sleep(1000);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
            try
            {
                _stream.Close();
                _connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e);
            }
        }

        private void SendResponse(IResponse response)
        {
            Console.WriteLine("sending response "+response);
            Formatter.Serialize(Stream, response);
            Stream.Flush();
        }

        private object HandleRequest(IRequest request)
        {
            IResponse response = null;
            if (request is LoginRequest)
            {
                Console.WriteLine("Login request ...");
                LoginRequest loginRequest = (LoginRequest) request;
                Volunteer volunteer = loginRequest.Volunteer;
                try
                {
                    lock (ServerService)
                    {
                        ServerService.FindVolunteer(volunteer.Username, volunteer.Password, this);
                    }
                    return new OkResponse();
                }
                catch (Exception e)
                {
                    Connected = false;
                    return new ErrorResponse(e.Message);
                }
            }

            if (request is GetAllCasesRequest)
            {
                Console.WriteLine("Get all cases request ...");
                try
                {
                    IEnumerable<Case> cases = null;
                    lock (ServerService)
                    {
                        cases = ServerService.FindAllCases();
                    }

                    return new GetAllCasesResponse(cases);
                }
                catch(Exception e)
                {
                    return new ErrorResponse(e.Message);
                }
            }
            if (request is GetAllDonorsRequest)
            {
                Console.WriteLine("Get all donors request ...");
                try
                {
                    IEnumerable<Donor> donors = null;
                    lock (ServerService)
                    {
                        donors = ServerService.FindAllDonors();
                    }

                    return new GetAllDonorsResponse(donors);
                }
                catch(Exception e)
                {
                    return new ErrorResponse(e.Message);
                }
            }
            if (request is GetAllDonorsBySubstringRequest)
            {
                Console.WriteLine("Get all donors by substring request ...");
                GetAllDonorsBySubstringRequest getAllDonorsBySubstringRequest =
                    (GetAllDonorsBySubstringRequest) request;
                string substring = getAllDonorsBySubstringRequest.Substring;
                try
                {
                    IEnumerable<Donor> donors = null;
                    lock (ServerService)
                    {
                        donors = ServerService.FindAllDonorsBySubstring(substring);
                    }

                    return new GetAllDonorsBySubstringResponse(donors);
                }
                catch (Exception e)
                {
                    return new ErrorResponse(e.Message);
                }

            }

            if (request is AddDonorRequest)
            {
                Console.WriteLine("Add donor request ...");
                AddDonorRequest addDonorRequest = (AddDonorRequest) request;
                string name = addDonorRequest.Name;
                string address = addDonorRequest.Address;
                string phoneNumber = addDonorRequest.PhoneNumber;
                try
                {
                    int id = -1;
                    lock (ServerService)
                    {
                        id = ServerService.AddDonor(name, address, phoneNumber);
                    }

                    return new AddDonorResponse(id);
                }
                catch (Exception e)
                {
                    return new ErrorResponse(e.Message);
                }
            }

            if (request is AddDonationRequest)
            {
                Console.WriteLine("Add donation request ...");
                AddDonationRequest addDonationRequest = (AddDonationRequest) request;
                int did = addDonationRequest.Did;
                int cid = addDonationRequest.Cid;
                double sum = addDonationRequest.Sum;
                try
                {
                    lock (ServerService)
                    {
                        ServerService.AddDonation(did, cid, sum);
                    }

                    return new AddDonationResponse();
                }
                catch (Exception e)
                {
                    return new ErrorResponse(e.Message);
                }
            }

            if (request is AddingNewDonation)
            {
                Console.WriteLine("Adding new donation notification request ...");
                try
                {
                    lock (ServerService)
                    {
                        ServerService.NotifyObserversDonationAdded();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }

            if (request is LogoutRequest)
            {
                Console.WriteLine("Logout request ...");
                try
                {
                    lock (ServerService)
                    {
                        _connected = false;
                        ServerService.Logout(this);
                        return new OkResponse();
                        
                    }
                }
                catch (Exception e)
                {
                    return new ErrorResponse(e.Message);
                }
            }
            return response;
        }

        public void DonationAdded(IEnumerable<Donor> donors, IEnumerable<Case> cases)
        {
            Console.WriteLine("Donation added event ...");
            try
            {
                SendResponse(new NewDonationAddedUpdate(donors, cases));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}