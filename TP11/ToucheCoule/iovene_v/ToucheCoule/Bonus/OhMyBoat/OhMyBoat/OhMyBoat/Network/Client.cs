using System;
using System.Collections.Generic;
using System.IO;
using OhMyBoat.IO;
using System.Threading;
using System.Net.Sockets;

namespace OhMyBoat.Network
{
    public class Client
    {
        private readonly TcpClient _client;
        public bool Connected { get; private set; }
        public Writer Writer { get; private set; }
        public Reader Reader { get; private set; }

        public Stream Stream
        {
            get 
            {
                return Connected ? _client.GetStream() : Stream.Null;
            }
        }

        public Client(TcpClient client)
        {
            _client = client;
            Connected = true;

            Writer = new Writer(Stream);
            Reader = new Reader(Stream);

            new System.Threading.Tasks.Task(Receive).Start();
        }

        void Receive()
        {
            while (Connected)
            {
                Thread.Sleep(20);

                if (_client.Client.Poll(1, SelectMode.SelectRead) && _client.Available == 0)
                {
                    Connected = false;
                    return;
                }

                if (Parser.Packets.Count == 0) continue;

                if (_client.Available <= PacketHeader.HeaderSize) continue;
                
                var header = Packet.GetHeader(Reader);

                while (Connected && _client.Available < header.DataSize)
                {
                    Thread.Sleep(20);

                    if (!_client.Client.Poll(1, SelectMode.SelectRead) || _client.Available != 0) continue;

                    Connected = false;
                    return;
                }

                if (!Connected) return; // deconnexion sauvage

                var packet = new Packet(header, Reader.ReadBytes(header.DataSize));

                Parser.Parse(this, packet);
            }
        }


    }
}
