using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OhMyBoat.Network.Packets;

namespace OhMyBoat.Network
{
    static class Parser
    {
        public static readonly Dictionary<byte, BasePacket> Packets = new Dictionary<byte, BasePacket>();

        public static void RegisterPackets(BasePacket.CallBackMethod callBackMethod)
        {
            var pcks = new List<BasePacket> {new BasicsDatasPacket(), new FireDatasPacket()};

            foreach (var basePacket in pcks.Where(basePacket => !Packets.ContainsKey(basePacket.OpCode)))
            {
                basePacket.SetEventCallBack(callBackMethod);
                Packets.Add(basePacket.OpCode, basePacket);
            }
        }

        public static void Parse(Client client, Packet packet)
        {
            if(Packets.ContainsKey(packet.Header.OpCode))
                Packets[packet.Header.OpCode].Unpack(client, packet);
            else
                throw new Exception("Packet inconnu: " + packet.Header.OpCode);
        }
    }
}
