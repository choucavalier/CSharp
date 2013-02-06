using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WavReader
{
    class WavHeader
    {
        public string ChunkId;
        public Int32 ChunkSize;
        public string Format;
        public string Subchunk11D;
        public Int32 Subchunk1Size;
        public Int16 AudioFormat;
        public Int16 NumChannels;
        public Int32 ByteRate;
        public Int32 SampleRate;
        public Int16 BlockAlign;
        public Int16 BitsPerSample;
        public string Subchunk2ID;
        public Int32 Subchunk2Size;

        public static WavHeader WavHeaderFromBinaryReader(BinaryReader br)
        {
            var waveHeader = new WavHeader
                {
                    ChunkId = new string(br.ReadChars(4)),
                    ChunkSize = br.ReadInt32(),
                    Format = new string(br.ReadChars(4)),
                    Subchunk11D = new string(br.ReadChars(4)),
                    Subchunk1Size = br.ReadInt32(),
                    AudioFormat = br.ReadInt16(),
                    NumChannels = br.ReadInt16(),
                    ByteRate = br.ReadInt32(),
                    SampleRate = br.ReadInt32(),
                    BlockAlign = br.ReadInt16(),
                    BitsPerSample = br.ReadInt16(),
                    Subchunk2ID = new string(br.ReadChars(4)),
                    Subchunk2Size = br.ReadInt32()
                };

            return waveHeader;
        }
    }
}
