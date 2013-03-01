using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace MyNetcat
{
    internal class Program
    {
        public const int BufferSize = 1024;
        private static bool _isServer;
        private static IPAddress _ipAddress;
        private static Int32 _port;

        private static string _output = null;

        private static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                WriteMan("You need to precise some arguments. Please read the man.");
                Environment.Exit(0);
            }

            _isServer = args[0] == "-l";

            if (args.Length == 3)
                _output = args[2];

            if (_isServer && Int32.TryParse(args[1], out _port) && _port <= IPEndPoint.MaxPort &&
                _port >= IPEndPoint.MinPort)
            {
                _ipAddress = IPAddress.Parse("127.0.0.1");
                RunServer();
            }

            else if (!_isServer && args.Length > 1 && IPAddress.TryParse(args[0], out _ipAddress) &&
                     Int32.TryParse(args[1], out _port) && _port <= IPEndPoint.MaxPort && _port >= IPEndPoint.MinPort)
                RunClient();

            else
                WriteMan("Error, incorrect arguments... (P.S: you suck)");

            Console.Read();
        }

        private static void RunServer()
        {
            try
            {
                TcpListener server = new TcpListener(_ipAddress, _port);
                server.Start();

                Console.WriteLine("Listening on port " + _port);

                Byte[] bytes = new byte[256];

                while (true)
                {
                    try
                    {
                        TcpClient client = server.AcceptTcpClient();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("New client connected :D");

                        NetworkStream stream = client.GetStream();

                        bool isOutput = stream.ReadByte() == 1;

                        if (!isOutput)
                        {
                            Console.WriteLine("He wants to talk! :O");
                            Console.ForegroundColor = ConsoleColor.White;
                            int i;
                            while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                            {
                                Console.WriteLine(Encoding.ASCII.GetString(bytes, 0, i));
                                stream.WriteByte(1);
                            }
                        }

                        #region file

                        else
                        {
                            Console.WriteLine("He's sending a file :O");
                            Console.ForegroundColor = ConsoleColor.White;

                            int allBytesRead = 0;

                            byte[] length = new byte[4];
                            int bytesRead = stream.Read(length, 0, 4);
                            int dataLength = BitConverter.ToInt32(length, 0);

                            int bytesLeft = dataLength;
                            byte[] data = new byte[dataLength];

                            while (bytesLeft > 0)
                            {
                                int nextPacketSize = (bytesLeft > BufferSize) ? BufferSize : bytesLeft;

                                bytesRead = stream.Read(data, allBytesRead, nextPacketSize);
                                allBytesRead += bytesRead;
                                bytesLeft -= bytesRead;
                            }

                            stream.WriteByte(1);

                            if (String.IsNullOrEmpty(_output))
                            {
                                Console.WriteLine("Content of the file: ");
                                Console.WriteLine(Encoding.ASCII.GetString(data, 0, dataLength));
                            }

                            else
                            {
                                Console.WriteLine("File saved in " + _output);
                                File.WriteAllBytes(_output, data);
                            }
                        }

                        #endregion

                        stream.Close();
                        client.Close();
                    }
                    catch (Exception)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("Client leaved :(");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Hit enter to continue");
            Console.Read();
        }

        private static void RunClient()
        {
            try
            {
                TcpClient client = new TcpClient(_ipAddress.ToString(), _port);

                #region chat

                if (String.IsNullOrEmpty(_output))
                {
                    NetworkStream stream = client.GetStream();
                    stream.WriteByte(0);
                    while (true)
                    {
                        Console.Write("Type your message >  ");
                        String message = Console.ReadLine();
                        if (String.IsNullOrEmpty(message))
                            continue;
                        Byte[] data = Encoding.ASCII.GetBytes(message);

                        try
                        {
                            stream.Write(data, 0, data.Length);

                            if (stream.ReadByte() != 1)
                                throw new Exception("The serveur returned nothing");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write("-> Sent \n");
                            Console.ForegroundColor = ConsoleColor.White;

                        }
                        catch (Exception e)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.Write("-> Fail sending message :/ You probably are disconnected from the server \n");
                            Console.WriteLine(e.Message);
                            Console.ForegroundColor = ConsoleColor.White;
                            stream.Close();
                        }
                    }
                }

                #endregion

                #region file
                else
                {
                    Console.Write("Transfering your file " + _output + " ...");

                    Byte[] data = File.ReadAllBytes(_output);

                    try
                    {
                        NetworkStream stream = client.GetStream();

                        stream.WriteByte(1);

                        byte[] dataLength = BitConverter.GetBytes(data.Length);
                        byte[] package = new byte[4 + data.Length];
                        dataLength.CopyTo(package, 0);
                        data.CopyTo(package, 4);

                        int bytesSent = 0;
                        int bytesLeft = package.Length;

                        while (bytesLeft > 0)
                        {
                            int nextPacketSize = (bytesLeft > BufferSize) ? BufferSize : bytesLeft;

                            stream.Write(package, bytesSent, nextPacketSize);
                            bytesSent += nextPacketSize;
                            bytesLeft -= nextPacketSize;
                        }

                        int x = stream.ReadByte();

                        if (x != 1)
                            throw new Exception("Error while transfering the file");

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("-> Sent \n");
                        Console.ForegroundColor = ConsoleColor.White;

                        stream.Close();
                        client.Close();
                    }
                    catch (Exception)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("-> Fail :/ You probably are disconnected from the server \n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }

                #endregion
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void WriteMan(string error)
        {
            Console.WriteLine(error);
            Console.WriteLine();
            Console.WriteLine("  MAN for MyNetcat.exe");
            Console.WriteLine("  ....................");
            Console.WriteLine();
            Console.WriteLine("    -l [port] : listen a port (run script as a server)");
            Console.WriteLine(
                "    [ip] [port] : connect to a server throughout its ip address (run the script as a client)");
            Console.WriteLine();
        }
    }
}
