using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;
using System.Text;

namespace BankApplication
{
    class server
    {
        static readonly object lockObject = new object();
        private static List<TcpClient> clients = new List<TcpClient>();
       
        private static StreamReader reader = null;
        private static StreamWriter writer = null;
       // private static List<Task> clientTasks = new List<Task>();
        //private static List<string> messages = new List<string>();
        private static List<string> loan = new List<string>();
        private static List<string> creditcard = new List<string>();
        private static List<string> providentfund = new List<string>();
        static readonly object _lock = new object();
        static readonly Dictionary<string, TcpClient> list_clients = new Dictionary<string, TcpClient>();
        readonly object key = new object();


        static void Main(string[] args)
        {
            loan.Add("Loan offer 12%");
            loan.Add("Loan offer 22%!!! avail soon");
            creditcard.Add("credit card offer!!!! 15% discount on abc bank account holders");
            creditcard.Add("credit card offer 70%");
            providentfund.Add("PF offer!!! for you");
            providentfund.Add("This is a pf offer");

            var messages = loan
            .Concat(creditcard)
            .Concat(providentfund)
            .ToList();
            Console.Title = "Server";
            
            TcpListener ServerSocket = new TcpListener(IPAddress.Any, 5000);
            ServerSocket.Start();
            Console.WriteLine("Welcome!!");
            Console.WriteLine("Waiting for incoming client connections...");
            

            while (true)
            {
                TcpClient client = ServerSocket.AcceptTcpClient();
                
                clients.Add(client);
                Console.WriteLine($"Client {clients.Count} connected!!");
                ServerOperation serverOperation = new ServerOperation();
                Thread handle_client = new Thread(() => serverOperation.HandleClient(client, messages)); //start new thread for new client
                Thread sendTask = new Thread(() =>serverOperation.SendScheme(client, messages));
                sendTask.Start();
                handle_client.Start();
                handle_client.Join();
               // handle_client.Start();
               
            }

        }
        

        class ServerOperation
        {
            public static bool locker = false;
            public static readonly object newkey = new object();
            private static StreamWriter writer1 = null;
            public void HandleClient(TcpClient client, List<string> messages)
            {
               // Monitor.Wait(this);

                string option = string.Empty;
                string scheme = string.Empty;
                writer1 = new StreamWriter(client.GetStream());
                reader = new StreamReader(client.GetStream());
                Console.WriteLine("entered server");

                try
                {
                    lock (newkey)
                    {
                        while (!(option = reader.ReadLine()).Equals("Exit") || (option == null))
                        {
                            if (!client.Connected)
                            {
                                Console.WriteLine("Client disconnected.");
                                // clients.Remove(TCPClient);
                            }

                            // messages.Add(TCPClient.clientName + ": " + s); //save new message
                            //Console.WriteLine(s);
                            // Console.WriteLine("From client: " + TCPClient.clientName + " opted for " + option);
                            locker = true;

                            if (option == "1")
                            {
                                Console.WriteLine("Client requested for Loan messages");

                                foreach (string loanmessages in loan)
                                {
                                    writer1.WriteLine(loanmessages);
                                    writer1.Flush();
                                    Thread.Sleep(1000);
                                }
                            }
                            else if (option == "2")
                            {
                                Console.WriteLine("Client requested for credit card messages");
                            }
                            else if (option == "3")
                            {
                                Console.WriteLine("Client requested provident fund messages");
                            }
                            /*foreach (Client c in clients) //refresh all connected clients
                            {
                                foreach (string msg in messages)
                                {
                                    c.writer.WriteLine(msg);
                                    c.writer.Flush();
                                    Task.Delay(5000);
                                }
                            }*/
                        }
                    }
                    CloseServer();
                }
               
                catch (System.IO.IOException) { }
                catch (Exception e) { Console.WriteLine(e); }
            }


            public void SendScheme(TcpClient client, List<string> messages)
            {
                lock (newkey)
                {
                    if (locker == true)
                    {
                        Monitor.Wait(newkey);
                        locker = false;
                    }
                    StreamWriter writer;
                    writer = new StreamWriter(client.GetStream());
                    try
                    {
                        while (locker == false)
                        {
                            foreach (string msg in messages)
                            {
                                writer.WriteLine(msg);
                                writer.Flush();
                                Thread.Sleep(3000);
                            }
                        }
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine(e);
                    }
                    catch (System.IO.IOException) { }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }


            private static void CloseServer()
            {
                reader.Close();
                writer.Close();
                clients.ForEach(tcpClient => tcpClient.Close());
            }
        }
    }
}