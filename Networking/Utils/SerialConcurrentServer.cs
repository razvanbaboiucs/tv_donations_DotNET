using System;
using System.Net.Sockets;
using System.Threading;
using Networking.Protocols;
using Services;

namespace Networking.Utils
{
    public class SerialConcurrentServer : AbstractConcurrentServer
    {
        private IService _serverService;
        private ClientWorker _worker;
        public SerialConcurrentServer(string host, int port, IService serverService) : base(host, port)
        {
            this._serverService = serverService;
            Console.WriteLine("Initializing SerialConcurrentServer with port:" + port + " host: " + host + " ...");
        }

        protected override Thread createWorker(TcpClient client)
        {
            this._worker = new ClientWorker(_serverService, client);
            return new Thread(new ThreadStart(_worker.Run));
        }
        
        
    }
}