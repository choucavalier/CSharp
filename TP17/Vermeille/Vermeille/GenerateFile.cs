using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Vermeille
{
    static class GenerateFile
    {
        public static void WriteRandomShit(string filePath)
        {
            List<string> shits = new List<string> {"a", "b", "c", "d", "e", "f"};
            Random random = new Random();
            using (var streamWriter = new StreamWriter(File.Open(filePath, FileMode.Append)))
                for (int x = 0; x < 200000000; x++)
                    streamWriter.Write(shits[random.Next(shits.Count)] + " ");
        }
    }
}
