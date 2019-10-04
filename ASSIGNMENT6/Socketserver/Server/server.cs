using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerData;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Net;


namespace Server
{
    class server
    {
        static Socket listenersocket;
        static List<ClientData> _clients;
        static void Main(string[] args)//start server
        {
            Console.WriteLine("Starting server on" + Packet.Getipaddress());
            listenersocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _clients = new List<ClientData>();

            IPEndPoint ip = new IPEndPoint(IPAddress.Parse(Packet.Getipaddress()),4242);
            listenersocket.Bind(ip);

            Thread listenthread = new Thread(Listenthread);
            listenthread.Start();


        }

        static void Listenthread()
        {
            for (; ;)
            {
                listenersocket.Listen(0);
                _clients.Add(new ClientData(listenersocket.Accept()));
            }
        }

        public static void DATA_IN(object cSocket)
        {
            Socket clientSocket = (Socket)cSocket;

            byte[] buffer;
            int readbytes;

            for (; ;)
            {
                buffer = new byte[clientSocket.SendBufferSize];

                readbytes = clientSocket.Receive(buffer);

                if (readbytes > 0)
                {
                    Packet packet = new Packet(buffer);
                    DataManager(packet);
                }
            }
        }

        public static void DataManager(Packet p)
        {
            switch(p.packettype)
            {
                case Packet.PacketType.Chat:
                    foreach(ClientData c in _clients)
                    
                        c.clientSocket.Send(p.ToBytes());
                        break;
                    
            }
        }
    }
        //clientdata thread-which recevies client data individually
        //datamanager
        class ClientData
    {
        public Socket clientSocket;
        public Thread clientThread;
       
        public string id;

        public ClientData()
        {
            id = Guid.NewGuid().ToString();
            clientThread = new Thread(server.DATA_IN);
            clientThread.Start();
            sendregistrationpacket();
        }

        public ClientData(Socket clientSocket)
        {
            this.clientSocket = clientSocket;
            id = Guid.NewGuid().ToString();
            clientThread = new Thread(server.DATA_IN);
            clientThread.Start(clientSocket);
            sendregistrationpacket();
            }

        public void sendregistrationpacket()
        {
            Packet p = new Packet(Packet.PacketType.Registration, "server");
            p.GData.Add(id);
            clientSocket.Send(p.ToBytes());
        }
    }
}
