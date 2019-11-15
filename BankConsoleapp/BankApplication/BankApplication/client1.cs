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
        public static int UserOption;
        public static string GetOption;
        public static bool Confirm = false;
        public static Task sendTask;
        public static Task recieveTask;
        public static Task updateConvTask;

        public static async Task Main()
        {
            Console.Title = "Client";

            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;


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

            sendTask =Task.Run(() => SendMessage());      //task for sending messages
            recieveTask =Task.Run(() => RecieveMessage(token),token);       //task for recieving messages
            updateConvTask = Task.Run(() => UpdateConversation(token),token);   //task for update console window

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
                       
                        Console.WriteLine("\nTask cancellation requested.");
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
            do
            {
                Console.WriteLine("Please choose a particular scheme");
                Console.WriteLine();

                Console.WriteLine("1. Loan ");
                Console.WriteLine("2. Credit card ");
                Console.WriteLine("3. Provident fund ");
                Console.WriteLine();
      
                GetOption = Console.ReadLine();

                while (!int.TryParse(GetOption, out UserOption))
                {
                    Console.WriteLine("This is not a number!");
                    GetOption = Console.ReadLine();
                }

                if ((UserOption > 0) && (UserOption < 4))
                {
                    Confirm = false;
                    switch (UserOption)
                    {
                        case 1:
                            Console.Clear();
                           
                            break;

                        case 2:
                            Console.Clear();
                           
                            break;

                        case 3:
                            Console.Clear();
   
                            break;

                        default:
                            Console.WriteLine("No match found");
                            break;
                    }
                }
                else
                {
                    Confirm = true;
                    Console.Clear();
                    Console.WriteLine("Re-enter the options");
                }

            } while (Confirm == true);
        }
    

        private static void RecieveMessage(CancellationToken ct)
        {
            // recieveTask = Task.Run(() => RecieveMessage());
          
            try
            {
                while (client.Connected)
                {
                    //Console.Clear();
                    if (ct.IsCancellationRequested)
                    {
                        Console.WriteLine("Task {0} was cancelled before it got started.");
                        ct.ThrowIfCancellationRequested();
                    }

                    int maxiterations = 100;

                    string msg = reader.ReadLine();


                    for (int i = 0; i <= maxiterations; i++)
                    {
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

        private static void UpdateConversation(CancellationToken ct)
        {
            //string conversationTmp = string.Empty;

            try
            {
                while (true)
                {
                    if (ct.IsCancellationRequested)
                    {
                        Console.WriteLine("Task {0} was cancelled before it got started.");
                        ct.ThrowIfCancellationRequested();
                    }

                    int maxiterations = 100;

                    for (int i = 0; i <= maxiterations; i++)
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