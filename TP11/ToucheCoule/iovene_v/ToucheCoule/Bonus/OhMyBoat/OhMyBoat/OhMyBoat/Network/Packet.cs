using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using OhMyBoat.IO;

namespace OhMyBoat.Network
{
    public class Packet
    {
        public Reader Reader { get; private set; }
        public Writer Writer { get; private set; }
        public MemoryStream Stream { get; private set; }
        public PacketHeader Header { get; private set; }

        public Packet(PacketHeader header, MemoryStream memoryStream)
        {
            Header = header;
            Stream = memoryStream;
            Reader = new Reader(Stream);
            Writer = new Writer(Stream);
        }

        public Packet(PacketHeader header, byte[] datas) : this(header, new MemoryStream(datas))
        {
        }

        public Packet(PacketHeader header) : this(header, new MemoryStream())
        {
        }

        public static PacketHeader GetHeader(Reader r)
        {
            return new PacketHeader(r.ReadByte(), r.ReadByte());
        }

        public void UpdateHeaders()
        {
            if (Header.DataSize != Stream.Length)
                Header.DataSize = (byte) Stream.Length;
        }

        public byte[] GetDatasBytes()
        {
            return Stream.ToArray();
        }

        public void WritePacket(Writer w)
        {
            WriteHeaders(w);
            w.Write(GetDatasBytes());
        }

        private void WriteHeaders(Writer w)
        {
            UpdateHeaders();

            w.Write(Header.OpCode);
            w.Write(Header.DataSize);
        }
    }
}
