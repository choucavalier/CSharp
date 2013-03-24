using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Crackme
{
    class Program
    {
        static void Main(string[] args)
        {
            Byte[] bytes = new byte[256];

            while (true)
            {
                try
                {
                    TcpClient client = new TcpClient("127.0.0.1", 4242);

                    NetworkStream stream = client.GetStream();

                    int i;
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        string s = Encoding.ASCII.GetString(bytes, 0, i);

                    }

                    stream.Close();
                    client.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    break;
                }
            }

            Console.Read();
        }
    }
}
