using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OhMyBoat.Maps;
using OhMyBoat.Network.Events;

namespace OhMyBoat.Network.Packets
{
    public class BasicsDatasPacket : BasePacket
    {
        public override byte OpCode
        {
            get { return 1; }
        }

        public override void Unpack(Client client, Packet packet)
        {
            string enemyName = packet.Reader.ReadString();
            Map enemyMap = packet.Reader.ReadMap();

            EventCallBackMethod.BeginInvoke(new BasicsDatasEvent {Enemy = enemyName, EnemyMap = enemyMap}, null, null);
        }

        public override void Pack(Client client, object data)
        {
            throw new NotImplementedException();
        }

        public void Pack(Client client, Map map, string playerName)
        {
            var packet = new Packet(new PacketHeader(OpCode, 0));

            packet.Writer.Write(playerName);
            packet.Writer.WriteMap(map);

            packet.WritePacket(client.Writer);
        }
    }
}
