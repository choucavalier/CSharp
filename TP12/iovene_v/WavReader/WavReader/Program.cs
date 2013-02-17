using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace WavReader
{
    class Program
    {
        private static Stream _stream;

        static void Main(string[] args)
        {
            ReadHeader("testwav2.wav");
            Console.Read();
        }

        static bool CheckWav(string fileName)
        {
            WavHeader wh = null;

            try
            {
                using (var br = new BinaryReader(File.Open(fileName, FileMode.Open)))
                    wh = WavHeader.WavHeaderFromBinaryReader(br);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return wh.ChunkId == "RIFF" && wh.Format == "WAVE" && wh.Subchunk11D == "fmt " && wh.Subchunk2ID == "data";
        }

        static void PrintInfos(string fileName)
        {
            if (!CheckWav(fileName))
            {
                Console.WriteLine("Ce fichier n'est pas un fichier .wav");
                return;
            }

            WavHeader wh;

            using (var br = new BinaryReader(File.Open(fileName, FileMode.Open)))
                wh = WavHeader.WavHeaderFromBinaryReader(br);

            Console.WriteLine("Nom : " + fileName);
            Console.WriteLine("Taille : " + wh.ChunkSize);
            Console.WriteLine("Compression : " + (wh.AudioFormat == 1 ? "Compressé" : "Non compressé"));
            Console.WriteLine("Canaux : " + wh.NumChannels);
            Console.WriteLine("Fréquence d'échantillonnage : " + wh.SampleRate);
        }

        ////////////////////////////////////////////////////////
        // BONUS
        ////////////////////////////////////////////////////////

        static void ReadHeader(string fileName)
        {
            if (!CheckWav(fileName))
            {
                Console.WriteLine("Ce fichier n'est pas un fichier .wav");
                return;
            }

            WavHeader wh;

            using (var br = new BinaryReader(File.Open(fileName, FileMode.Open)))
                wh = WavHeader.WavHeaderFromBinaryReader(br);

            foreach (var f in Assembly.GetExecutingAssembly().GetType(typeof(WavHeader).ToString()).GetFields())
                Console.WriteLine(f.Name + " : " + f.GetValue(wh));
        }
    }
}
