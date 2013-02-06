using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using OhMyBoat.Maps;

namespace OhMyBoat.IO
{
    public class Reader : BinaryReader
    {
        public Reader(Stream stream) : base(stream)
        {
        }

        public Map ReadMap()
        {
            var size = ReadInt16();
            var map = new byte[size, size];

            for (byte y = 0; y < size; y++)
                for (byte x = 0; x < size; x++)
                    map[x, y] = ReadByte();

            return new Map(map);
        }

        public Player ReadPlayer()
        {
            string name = ReadString();
            Map map = ReadMap();

            return new Player(name, map);
        }
    }
}
