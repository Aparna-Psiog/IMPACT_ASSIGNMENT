using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerData;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;


namespace Client
{
    class client
    {
        public static Socket master;
        public static string name;
        public static string id;
        static void Main(string[] args)
        {

            Console.WriteLine("Enter the username:");
            name = Console.ReadLine();



        A: Console.Clear();
            Console.WriteLine("Enter host Ip address:");
            string ip = Console.ReadLine();

            master = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint _ip= new IPEndPoint(IPAddress.Parse(ip), 4242);
            try
            {
                master.Connect(_ip);
            }
            catch
            {
                Console.WriteLine("Could not connect to the host!");
                Thread.Sleep(1000);
                goto A;
            }

            Thread t = new Thread(Data_IN);
            t.Start();

            for(; ;)
            {
                Console.Write("::>");
                string input = Console.ReadLine();

                Packet p = new Packet(Packet.PacketType.Chat, id);
                p.GData.Add(name);
                p.GData.Add(input);
                master.Send(p.ToBytes());
            }
        }

        static void Data_IN()
        {
            byte[] Buffer;
            int Readbytes;

            for(; ;)
            {
                Buffer = new byte[master.SendBufferSize];

                Readbytes = master.Receive(Buffer);
                if(Readbytes > 0)
                {
                    DataManager(new Packet(Buffer));
                }
            }
        }

        static void DataManager(Packet p)
        {

            switch(p.packettype)
            {
                case Packet.PacketType.Registration:
                    Console.WriteLine("Received a packet for registration:");
                    id = p.GData[0];
                    break;

                case Packet.PacketType.Chat:
                    ConsoleColor c = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Cyan;

                    Console.Write(p.GData[0]+":"+p.GData[1]);
                    Console.ForegroundColor = c;
                    break;
            }
        } 
    }
}
