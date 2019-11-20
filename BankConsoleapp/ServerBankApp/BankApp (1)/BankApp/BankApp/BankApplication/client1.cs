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

        public static bool pass = false;

        public static void Main()
        {
            Console.Title = "Client";
            

            do //try to connect
            {
                Console.WriteLine("Connecting to server...");

                try
                {

                    IPAddress ip = IPAddress.Parse("192.168.112.103");
                    int port = 5000;

                    TcpClient client = new TcpClient();
                    client.Connect(ip, port);

                    
                    Console.WriteLine("Connected.");
                    Console.WriteLine("Press Enter to proceed");
                    Console.ReadLine();
                    Console.Clear();
                   
                    reader = new StreamReader(client.GetStream());
                    writer = new StreamWriter(client.GetStream());
                    //Running task for cancellation
                    Operation op = new Operation();
                    Thread sendTask = new Thread(() => op.SendMessage(client, pass));      //task for sending messages
                    Thread receiveTask = new Thread(() => op.ReceiveMessage(client));       //task for recieving messages
                    receiveTask.Start();
                    
                   
                    Console.ReadLine();
                    
                    
                    pass = true;
                    
                    sendTask.Start();
                    sendTask.Join();
                    break;

                    // updateConvTask.Start();
                    // receiveTask.Join();

                    //sendTask.Join();
                    

                   
                }
                catch (SocketException)
                {
                }
               
                Thread.Sleep(10);
            } while (!client.Connected);


            // \/ CONNECTED \/

           
        }






    }
    public class Operation
    {
        private static TcpClient client = new TcpClient();
        private static StreamReader reader = null;
        private static StreamWriter writer = null;
       // private static bool refresh;
        private static List<string> messages = new List<string>();
        public static int UserOption;
        public static string GetOption;
        public static bool Confirm = false;
        public static readonly object key = new object();
        
        static bool Waitcheck = false;
        public void SendMessage(TcpClient client, bool pass)
        {
            Waitcheck = true;
            Thread.Sleep(5000);
            Console.WriteLine("Enter pressed");
            
                
                lock (key)
                {
                    if (pass == true)
                    {
                        Console.WriteLine("1 for menu and 2 to exit");
                       // Waitcheck = true;


                        //pass = false;




                        //Console.WriteLine("You pressed enter. Press 1 for menu and 2 to exit");

                       // Monitor.Wait(key);

                        string msgToSend = string.Empty;

                        msgToSend = Console.ReadLine();

                        switch (msgToSend)
                        {
                            case "2":
                                EndConnection(client);
                                break;
                            case "1":
                                Menu(client, pass);
                                break;
                            
                            default:
                                Console.WriteLine("No input");
                                break;
                        }
                    }
                }
                
            
        }

        public static void Menu(TcpClient client, bool pass)
        {

            writer = new StreamWriter(client.GetStream());
            reader = new StreamReader(client.GetStream());
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

                // writer.WriteLine(UserOption);
                
                if ((UserOption > 0) && (UserOption < 4))
                {
                    Confirm = false;

                    switch (UserOption)
                    {
                        case 1:
                            //Console.Clear();
                            Console.WriteLine("You requested for Loan messages");
                            
                            writer.WriteLine("1");
                            writer.Flush();
                            break;

                        case 2:
                            //Console.Clear();
                            Console.WriteLine("You requested for credit card messages");
                            writer.WriteLine("2");
                            writer.Flush();
                            break;

                        case 3:
                            //Console.Clear();
                            Console.WriteLine("You requested for provident fund");
                            writer.WriteLine("3");
                            writer.Flush();
                            break;

                        default:
                            Console.WriteLine("No match found");
                            break;
                    }
                    Console.Clear();
                    while (pass == true)
                    {
                        string msg = reader.ReadLine();
                        
                        Console.WriteLine(msg);
                    }
                    // Task.WaitAll(updateConvTask, recieveTask);
                }
                else
                {
                    Confirm = true;
                    Console.Clear();
                    Console.WriteLine("Re-enter the options");
                }

            } while (Confirm == true);
        }
        public void ReceiveMessage(TcpClient client)
        {
            lock (key)
            {
                
                if (Waitcheck == true)
                {
                    //Monitor.Pulse(key);
                   
                    Monitor.Wait(key);
                    Waitcheck = false;

                }
                while (!Waitcheck)
                {
                   // Console.WriteLine(Waitcheck);
                    StreamReader reader;
                    reader = new StreamReader(client.GetStream());
                    string msg = reader.ReadLine();

                    Console.WriteLine(msg);
                }

                
            }
        }
      
        private static void EndConnection(TcpClient client)
        {
            reader = new StreamReader(client.GetStream());
            writer = new StreamWriter(client.GetStream());
            reader.Close();
            writer.Close();
            client.Close();
        }
    }
}



 