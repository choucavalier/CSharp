using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MirrorWriting
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteFile("toogy.txt", "Neodyblue est trop intelligent pour moi \r\n en fait non \r\n en fait si");
            ReadFile("toogy.txt");
            MirrorWriting("toogy.txt", "toogymirror.txt");
            ReverseFile("toogy.txt", "toogyreverse.txt");
            Console.Read();
        }

        static void WriteFile(string fileName, string message)
        {
            try
            {
                using (var streamWriter = new StreamWriter(File.Open(fileName, FileMode.Append)))
                    streamWriter.Write(message);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void ReadFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine("Le fichier n'existe pas");
                return;
            }

            try
            {
                using (var streamReader = new StreamReader(fileName))
                    Console.WriteLine(streamReader.ReadToEnd());
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void MirrorWriting(string input, string output)
        {
            if (!File.Exists(input))
            {
                Console.WriteLine("Le fichier \"" + input + "\" n'existe pas");
                return;
            }

            using (var streamReader = new StreamReader(input))
                using (var streamWriter = new StreamWriter(File.Open(output, FileMode.Append)))
                {
                    var lines = streamReader.ReadToEnd().Split(new[] {"\r\n"}, StringSplitOptions.None);

                    foreach (var line in lines)
                    {
                        streamWriter.WriteLine(StringReverse(line).Replace("\n\r", "\r\n"));
                    }
                }
        }

        ////////////////////////////////////////////////////////
        // BONUS
        ////////////////////////////////////////////////////////

        static void ReverseFile(string input, string output)
        {
            if (!File.Exists(input))
            {
                Console.WriteLine("Le fichier \"" + input + "\" n'existe pas");
                return;
            }

            string content;

            using (var streamReader = new StreamReader(input))
            using (var streamWriter = new StreamWriter(File.Open(output, FileMode.Append)))
            {
                var lines = streamReader.ReadToEnd().Split(new[] { "\r\n" }, StringSplitOptions.None);

                for (var i = lines.Length - 1; i >= 0; i--)
                {
                    streamWriter.WriteLine(StringReverse(lines[i]).Replace("\n\r", "\r\n"));
                }
            }
        }

        public static string StringReverse(string s)
        {
            var sr = "";

            if (s.Length == 0)
                return sr;

            for (var i = s.Length - 1; i >= 0; i--)
                sr += s[i];

            return sr;
        }
    }
}
