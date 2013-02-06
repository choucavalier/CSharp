using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace OhMyBoat.Network
{
    public class Server
    {
        private readonly TcpListener _listener;

        public Server()
        {
            _listener = new TcpListener(IPAddress.Any, 4242);
        }

        public Client AcceptClient()
        {
            _listener.Start();
            var c =  new Client(_listener.AcceptTcpClient());
            _listener.Stop();
            return c;
        }
    }
}
