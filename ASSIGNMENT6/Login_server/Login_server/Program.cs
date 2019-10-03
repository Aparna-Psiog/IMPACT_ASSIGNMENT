
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
namespace Login_server
{
    public class login
    {
        Socket s;

        public login(Socket valueS)
        {
            s = valueS;
        }

        public void check()
        {
            try
            {

                byte[] uname = new byte[100];
                byte[] pword = new byte[100];
                int sizeuser = s.Receive(uname);
                int sizepword = s.Receive(pword);

                if (sizeuser > 0 && sizepword > 0)
                {
                    Console.WriteLine("Recieved");
                    TextReader objTxtReader = new StreamReader("C:/Users/aparna.j/Documents/GitHub/IMPACT_ASSIGNMENT/ASSIGNMENT6/login.txt");
                    String username = objTxtReader.ReadLine();
                    String password = objTxtReader.ReadLine();
                    String test = ASCIIEncoding.ASCII.GetString(uname);
                    test = test.Substring(0, sizeuser);
                    if (username == (ASCIIEncoding.ASCII.GetString(uname)).Substring(0, sizeuser) && password == (ASCIIEncoding.ASCII.GetString(pword)).Substring(0, sizepword))
                    {

                    }
                    else
                    {
                        ASCIIEncoding asen2 = new ASCIIEncoding();
                        s.Send(asen2.GetBytes("0"));
                    }

                }

            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }

        }

    }


    public class Program
    {

        static void Main(string[] args)
        {
            try
            {
                IPAddress ipAd = IPAddress.Parse("192.168.153.58");
                TcpListener myList = new TcpListener(ipAd, 8002);
                myList.Start();
                Random randDouble = new Random();
                
                Socket s = myList.AcceptSocket();
                login objLogin = new login(s);
                Thread thdLogin = new Thread(new ThreadStart(objLogin.check));
                thdLogin.Start();
                thdLogin.Join();
            
                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
            }
        }
    }
}