using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;


namespace Textclient
{
    class Client
    {
        
        public static string id;
        static void Main(string[] args)
        {

            IPAddress ip = IPAddress.Parse("192.168.153.58");
            int port = 5000;
            TcpClient client = new TcpClient();
            client.Connect(ip, port); Console.WriteLine("client connected!!");
            NetworkStream ns = client.GetStream();
            Thread thread = new Thread(o => ReceiveData((TcpClient)o));
            thread.Start(client);
            string s;
            string name;
            Console.WriteLine("Enter the username:");
            //Console.WriteLine("Enter the password:");

            name = Console.ReadLine();
           
            while (!string.IsNullOrEmpty((s = Console.ReadLine())))
            {
       
                byte[] buffer1 = Encoding.ASCII.GetBytes(name+":");
                byte[] buffer = Encoding.ASCII.GetBytes(s);
                byte[] buffer2 = new byte[buffer1.Length + buffer.Length];
                buffer1.CopyTo(buffer2, 0);
                buffer.CopyTo(buffer2, buffer1.Length);
                ns.Write(buffer2, 0, buffer2.Length);
              
               
            }

            client.Client.Shutdown(SocketShutdown.Send);
            thread.Join();
            ns.Close();
            client.Close();
            Console.WriteLine("disconnect from server!!");
            Console.ReadKey();
        }

        static void ReceiveData(TcpClient client) {

          
            NetworkStream ns = client.GetStream();
            byte[] receivedBytes = new byte[1024];
            int byte_count;
            while ((byte_count = ns.Read(receivedBytes, 0, receivedBytes.Length)) > 0)
            {
                Console.Write(Encoding.ASCII.GetString(receivedBytes, 0, byte_count));
            }
        }
    }


}

