using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace BankApplication
{
    class server
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome!!");
            Console.WriteLine("Waiting for incoming client connections...");
           

            ServerOperation serverOperation = new ServerOperation();

            Thread connectClient = new Thread(() => serverOperation.ConnectClients());

            connectClient.Start();

        }

    }
    public class ServerOperation
    {
      
        private static List<TcpClient> clients = new List<TcpClient>();

        private StreamReader reader = null;
        private StreamWriter writer = null;
       
       
        readonly object _lock = new object();
        readonly Dictionary<string, TcpClient> list_clients = new Dictionary<string, TcpClient>();
        readonly object key = new object();
        public bool locker = false;
    
        

            public void ConnectClients()
            {
            
                TcpListener ServerSocket = new TcpListener(IPAddress.Any, 5000);
                ServerSocket.Start();
                try
                {
                Thread handle_client = new Thread(HandleClient);

                Thread sendTask = new Thread(SendScheme);
                while (true)
                    {

                   
                        TcpClient client = ServerSocket.AcceptTcpClient();
                        Console.WriteLine("New client connected");
                        clients.Add(client);
                        sendTask.Start(client);
                      
                        handle_client.Start(client);
 
                    }
                    

                }
                catch (ThreadStartException) { }

            }
            public void HandleClient(object o)
            {
            List<string> loan = new List<string>();
            List<string> creditcard = new List<string>();
            List<string> providentfund = new List<string>();
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
                // Monitor.Wait(this);
                TcpClient client = (TcpClient)o;
                string option = string.Empty;
                string scheme = string.Empty;
                writer = new StreamWriter(client.GetStream());
                reader = new StreamReader(client.GetStream());
                Console.WriteLine("entered server");

                try
                {
                   
                        while (!(option = reader.ReadLine()).Equals("Exit") || (option == null))
                        {
                            if (!client.Connected)
                            {
                                Console.WriteLine("Client disconnected.");
                              
                            }

                         
                            locker = true;

                            if (option == "1")
                            {
                                Console.WriteLine("Client requested for Loan messages");

                                foreach (string loanmessages in loan)
                                {
                                    writer.WriteLine(loanmessages);
                                    writer.Flush();
                                    Thread.Sleep(1000);
                                }
                            }
                            else if (option == "2")
                            {
                                Console.WriteLine("Client requested for credit card messages");
                                foreach (string creditmsg in creditcard)
                                {
                                writer.WriteLine(creditmsg);
                                writer.Flush();
                                Thread.Sleep(1000);
                                }
                            }
                            else if (option == "3")
                            {
                                Console.WriteLine("Client requested provident fund messages");
                            foreach (string providentmsg in providentfund)
                            {
                            writer.WriteLine(providentmsg);
                            writer.Flush();
                            Thread.Sleep(1000);
                            }
                        }
                        
                    }
                
                    CloseServer(reader,writer);
                }
               
                catch (System.IO.IOException) { }
                catch (Exception e) { Console.WriteLine(e); }
            }


            public void SendScheme(object o)
            {
            List<string> loan = new List<string>();
            List<string> creditcard = new List<string>();
            List<string> providentfund = new List<string>();
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
                TcpClient client = (TcpClient)o;
                
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


            private static void CloseServer(StreamReader reader, StreamWriter writer)
            {
                reader.Close();
                writer.Close();
                clients.ForEach(tcpClient => tcpClient.Close());
            }
        }
    }
