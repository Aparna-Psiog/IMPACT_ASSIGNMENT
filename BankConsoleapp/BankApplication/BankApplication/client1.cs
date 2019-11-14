using System.Net.Sockets;
using System.Net;
using System.IO;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BankApplication
{
    class client1
    {
        private static TcpClient client = new TcpClient();
        private static StreamReader reader;
        private static StreamWriter writer;

        private static bool refresh;
        private static List<string> messages = new List<string>();

        public static void Main()
        {
            Console.Title = "Client";

            do //try to connect
            {
                Console.WriteLine("Connecting to server...");

                try
                {
                    client.Connect(IPAddress.Parse("127.0.0.1"), 8080);
                }
                catch (SocketException) { }

                Thread.Sleep(10);
            } while (!client.Connected);

            // \/ CONNECTED \/

            Console.WriteLine("Connected.");

            reader = new StreamReader(client.GetStream());
            writer = new StreamWriter(client.GetStream());

            var sendTask = Task.Run(() => SendMessage());      //task for sending messages
            var recieveTask = Task.Run(() => RecieveMessage());       //task for recieving messages
            var updateConvTask = Task.Run(() => UpdateConversation());   //task for update console window

            Task.WaitAll(sendTask, recieveTask); //wait for end of all tasks
        }

        private static void SendMessage()
        {
            while (true)
            {
                string msgToSend = string.Empty;
                msgToSend = Console.ReadLine();
                switch (msgToSend)
                {
                    case "E":
                        EndConnection();
                        break;

                    case "M":
                        Menu();
                        break;

                    default:
                        Console.WriteLine("Client request failed");
                        break;
                }
            }
        }

        private static void Menu()
        {
            
        }

        private static void RecieveMessage()
        {
            try
            {
                while (client.Connected)
                {
                    //Console.Clear();
                   
                    string msg = reader.ReadLine();

                    if (msg != string.Empty)
                    {
                        if (msg == "%C") //special message from server, clear messages if recieve it
                        {
                            messages.Clear();
                        }
                        else
                        {
                            messages.Add(msg);
                            refresh = true; //refresh console window
                        }
                    }

 
                   //if(msg==Console.ReadLine())
                   // {

                   //     var sendTask = Task.Run(() => SendMessage());
                       
                   // }
                    //Console.Clear();
                    //Console.WriteLine(msgFromServer);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void UpdateConversation()
        {
            //string conversationTmp = string.Empty;

            try
            {
                while (true)
                {
                    if (refresh) //only if refresh
                    {
                        refresh = false;
                        Console.Clear();
                        messages.ForEach(msg => Console.WriteLine(msg)); //write all messages
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception) { }
        }

        private static void EndConnection()
        {
            reader.Close();
            writer.Close();
            client.Close();
        }

    }
}