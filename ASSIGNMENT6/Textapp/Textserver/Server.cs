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
            Console.WriteLine("Welcome to Chat room");
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

            while (true)
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];
                int byte_count = stream.Read(buffer, 0, buffer.Length);
                string messagedata = Encoding.ASCII.GetString(buffer, 0, byte_count);
                if(messagedata == "message")
                {
                    byte[] buffernew = new byte[1024];
                    int byte_count_new = stream.Read(buffernew, 0, buffernew.Length);
                    if (byte_count_new == 0)
                    {
                        break;
                    }



                    string data = Encoding.ASCII.GetString(buffer, 0, byte_count);
                    broadcast(data);
                    Console.WriteLine(data);
                }
                else
                {
                    try
                    {

                        
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
                            c.Client.Send(clientData);
                            
                        }




                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("File Sending fail." + ex.Message);
                    }
                }
            }


            lock (_lock) list_clients.Remove(id);
            client.Client.Shutdown(SocketShutdown.Both);
            client.Close();
        }

        
    
        public static void broadcast(string data)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(data + Environment.NewLine);
           
            lock (_lock)
            {
                foreach (TcpClient c in list_clients.Values)
                {
                    NetworkStream stream = c.GetStream();
                    stream.Write(buffer, 0, buffer.Length);
                }
            }
        }

       

    }
}