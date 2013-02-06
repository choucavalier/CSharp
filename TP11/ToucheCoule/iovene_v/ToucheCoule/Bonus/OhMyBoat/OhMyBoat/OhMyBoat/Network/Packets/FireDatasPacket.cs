using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Text;
using OhMyBoat.Network.Events;

namespace OhMyBoat.Network.Packets
{
    public class FireDatasPacket : BasePacket
    {
        public override byte OpCode
        {
            get { return 2; }
        }

        public override void Unpack(Client client, Packet packet)
        {
            byte x = packet.Reader.ReadByte();
            byte y = packet.Reader.ReadByte();

            EventCallBackMethod.BeginInvoke(new FireDatasEvent {Coordinates = new Point(x, y)}, null, null);
        }

        public override void Pack(Client client, object data)
        {
            var p = (Point) data;
            var packet = new Packet(new PacketHeader(OpCode, 0));

            packet.Writer.Write((byte)p.X);
            packet.Writer.Write((byte)p.Y);

            packet.WritePacket(client.Writer);
        }
    }
}
