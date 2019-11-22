using System.Net.Sockets;
using System.Net;
using System.IO;
using System;
using System.Collections.Generic;
using System.Threading;



namespace BankApplication
{
    class client1
    {
        private static TcpClient client = new TcpClient();
       
        public static void Main()
        {
            Console.Title = "Client";
            StreamWriter writer;
            bool pass = false;
            do
            {
                Console.WriteLine("Connecting to server...");

                try
                {
                    Console.WriteLine("Enter the ip address:");
                    IPAddress ip = IPAddress.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the port number:");
                    int port = Convert.ToInt32(Console.ReadLine());

                    TcpClient client = new TcpClient();
                    client.Connect(ip, port);
                    writer = new StreamWriter(client.GetStream());

                    Console.WriteLine("Connected.");
                    Console.WriteLine("Press Enter to proceed");
                    writer.WriteLine(Console.ReadLine());
                    

                  
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


         

           
        }

    }
    public class Operation
    {
        private TcpClient client = new TcpClient();
       
     
        private List<string> messages = new List<string>();
        
        readonly object key = new object();
        
        static bool Waitcheck = false;
        public void SendMessage(TcpClient client, bool pass)
        {
            Waitcheck = true;
            Thread.Sleep(5000);
            Console.WriteLine("Enter pressed");
            StreamReader reader = null;
            StreamWriter writer = null;
            writer = new StreamWriter(client.GetStream());
            reader = new StreamReader(client.GetStream());

            lock (key)
                {
                    if (pass == true)
                    {
                        Console.WriteLine("Enter M for menu and E to exit");
                       
                        string msgToSend = string.Empty;

                        msgToSend = Console.ReadLine();

                        switch (msgToSend)
                        {
                            case "E":
                                EndConnection(reader,writer,client);
                                break;
                            case "M":
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
            StreamReader reader = null;
            StreamWriter writer = null;
            writer = new StreamWriter(client.GetStream());
            reader = new StreamReader(client.GetStream());
            int UserOption;
            string GetOption;
            bool Confirm = false;
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
                while (Waitcheck==false)
                {
                  
                    StreamReader reader;
                    reader = new StreamReader(client.GetStream());
                    string msg = reader.ReadLine();

                    Console.WriteLine(msg);
                }

            }
        }
      
        private static void EndConnection(StreamReader reader,StreamWriter writer,TcpClient client)
        {
           
            reader.Close();
            writer.Close();
            client.Close();
        }
    }
}



 