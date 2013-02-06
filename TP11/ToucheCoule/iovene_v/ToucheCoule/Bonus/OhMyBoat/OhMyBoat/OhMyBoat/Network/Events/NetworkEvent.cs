using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OhMyBoat.Network.Events
{
    public abstract class NetworkEvent
    {
        public byte PacketOpCode { get; private set; }

        protected NetworkEvent(byte packetOpCode)
        {
            PacketOpCode = packetOpCode;
        }
    }
}
