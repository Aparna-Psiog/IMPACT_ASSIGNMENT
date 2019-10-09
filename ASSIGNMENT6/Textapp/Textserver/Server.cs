using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Textserver
{
    class Server
    {
       
        static readonly object _lock = new object();
        static readonly Dictionary<int, TcpClient> list_clients = new Dictionary<int, TcpClient>();
     

        static void Main(string[] args)
        {
          
            int count = 1;
            TcpListener ServerSocket = new TcpListener(IPAddress.Any, 5000);
            ServerSocket.Start();
            Console.WriteLine("Welcome to Chat room!!");

            while (true)
            {
                TcpClient client = ServerSocket.AcceptTcpClient();
                lock (_lock) list_clients.Add(count, client);
                Console.WriteLine($"Client {count} connected!!");



                Thread t = new Thread(handle_clients);
                t.Start(count);

                


                Console.WriteLine($"Number of clients connected {count}");
                count++;
            }
        }
       
        public static void handle_clients(object o)
        {
            int id = (int)o;
           
            TcpClient client;
            lock (_lock) client = list_clients[id];

          

                try
                {

                byte[] buffer = new byte[1024];
                int byte_count = client.Client.Receive(buffer);
                string messagedata = Encoding.ASCII.GetString(buffer, 0, byte_count);
                Console.WriteLine(messagedata);

                    if (messagedata == "message")
                    {
                    while (true)
                    {
                        NetworkStream stream = client.GetStream();
                        byte[] buffernew = new byte[1024];
                        int byte_count_new = stream.Read(buffernew, 0, buffernew.Length);
                        if (byte_count_new == 0)
                        {
                            break;
                        }



                        string data = Encoding.ASCII.GetString(buffernew, 0, byte_count_new);
                        broadcast(data, messagedata);
                        Console.WriteLine(data);


                    }
                    }

                    else if (messagedata == "file")
                    {
                    while (true)
                    {

                        Console.WriteLine("It is a file........");
                        byte[] clientData = new byte[1024 * 5000];



                        int receivedBytesLen = client.Client.Receive(clientData);
                        Console.WriteLine(receivedBytesLen);
                        if (receivedBytesLen == 0)
                        {
                            break;
                        }

                        foreach (TcpClient c in list_clients.Values)
                        {
                            //stream.Write(clientData, 0, clientData.Length);
                            byte[] messageByte = Encoding.ASCII.GetBytes(messagedata);
                            byte[] messageBuffer = new byte[messageByte.Length];
                            messageByte.CopyTo(messageBuffer, 0);

                            c.Client.Send(messageBuffer);


                            c.Client.Send(clientData);

                        }

                    }
                    }

                    
                   
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            


            lock (_lock) list_clients.Remove(id);
            client.Client.Shutdown(SocketShutdown.Both);
            client.Close();
        }

        
    
        public static void broadcast(string data,string messagedata)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(data + Environment.NewLine);
           
            lock (_lock)
            {
                foreach (TcpClient c in list_clients.Values)
                {
                    byte[] messageByte = Encoding.ASCII.GetBytes(messagedata);
                    byte[] messageBuffer = new byte[messageByte.Length];
                    messageByte.CopyTo(messageBuffer, 0);
                    c.Client.Send(messageBuffer);

                    NetworkStream stream = c.GetStream();
                    stream.Write(buffer, 0, buffer.Length);
                }
            }
        }

       

    }
}