using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WavMixer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var br = new BinaryReader(File.Open("sample.wav", FileMode.Open)))
                {
                    using (var bw = new BinaryWriter(File.Create("first_output.wav")))
                    {
                        InitializeHeader(br, bw);
                        MuteRightSpeaker(br, bw);

                        Console.WriteLine("Speaker Droit correctement supprimé. Le résultat est dans first_output.wav");
                    }

                    Console.WriteLine();

                    br.BaseStream.Position = 0;

                    using (var bw = new BinaryWriter(File.Create("second_output.wav")))
                    {
                        InitializeHeader(br, bw);
                        MuteAlternate(br, bw);

                        Console.WriteLine("Speakers correctement alternés. Le résultat est dans second_output.wav");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.Read();
        }

        static void InitializeHeader(BinaryReader br, BinaryWriter bw)
        {
            bw.Seek(0, SeekOrigin.Begin);

            for (var i = 0; i < 36; i++)
                bw.Write(br.ReadByte());

            const string compare = "data";

            try
            {
                for (var i = 0; i < 4; i++)
                {
                    var b = br.ReadByte();
                    if (b != compare[i])
                        throw  new Exception("ERROR Subchunk2ID");
                    bw.Write(b);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            for (var i = 0; i < 4; i++)
                bw.Write(br.ReadByte());
        }

        static void MuteRightSpeaker(BinaryReader br, BinaryWriter bw)
        {
            var rightSpeaker = false;
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                var i = br.ReadInt16();

                if (br.BaseStream.Position % 10000 == 0)
                    Console.WriteLine(br.BaseStream.Position);

                if (rightSpeaker)
                    bw.Write(i);
                else
                    bw.Write((short)0);

                rightSpeaker = !rightSpeaker;
            }
        }

        ////////////////////////////////////////////////////////
        // BONUS
        ////////////////////////////////////////////////////////

        static void MuteRightSpeaker(BinaryReader br, BinaryWriter bw, long interval)
        {
            var rightSpeaker = false;
            while (br.BaseStream.Position < interval)
            {
                var i = br.ReadInt16();

                if (rightSpeaker)
                    bw.Write(i);
                else
                    bw.Write((short)0);

                rightSpeaker = !rightSpeaker;
            }
        }

        static void MuteLeftSpeaker(BinaryReader br, BinaryWriter bw, long interval)
        {
            var rightSpeaker = true;
            while (br.BaseStream.Position < interval)
            {
                var i = br.ReadInt16();

                if (rightSpeaker)
                    bw.Write(i);
                else
                    bw.Write((short)0);

                rightSpeaker = !rightSpeaker;
            }
        }

        static void MuteAlternate(BinaryReader br, BinaryWriter bw)
        {
            var startingPosition = br.BaseStream.Position;
            var alternations = (int) (br.BaseStream.Length - startingPosition - 1)/5000;
            for (var i = 0; i < alternations; i++)
            {
                if (i%2 == 0)
                    MuteRightSpeaker(br, bw, (i + 1)*5000 + startingPosition);
                else
                    MuteLeftSpeaker(br, bw, (i + 1)*5000 + startingPosition);
            }

            if (alternations%2 == 0)
                MuteRightSpeaker(br, bw, br.BaseStream.Length);
            else
                MuteLeftSpeaker(br, bw, br.BaseStream.Length);
        }
    }
}
