using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OhMyBoat.Network
{
    public class PacketHeader
    {
        public const byte HeaderSize = 2; // un byte opcode et un byte de taille

        public byte OpCode { get; private set; }
        public byte DataSize { get; set; }
        public byte TotalSize { get { return (byte) (DataSize + HeaderSize); } }

        public PacketHeader(byte opcode, byte datasize)
        {
            OpCode = opcode;
            DataSize = datasize;
        }
    }
}
