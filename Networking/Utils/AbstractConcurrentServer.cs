﻿using System.Net.Sockets;
using System.Threading;

namespace Networking.Utils
{
    public abstract class AbstractConcurrentServer : AbstractServer
    {
        public AbstractConcurrentServer(string host, int port) : base(host, port)
        {}

        public override void processRequest(TcpClient client)
        {
                
            Thread t = createWorker(client);
            t.Start();
                
        }

        protected abstract  Thread createWorker(TcpClient client);
    }
}