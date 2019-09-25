using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
namespace beginSocketServer
{
    //FILE TRANSFER USING C#.NET SOCKET - SERVER
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("That program can transfer small file. I've test up to 850kb file");
                IPEndPoint ipEnd = new IPEndPoint(IPAddress.Any, 8100);
                Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                sock.Bind(ipEnd);
                sock.Listen(100);
                //clientSock is the socket object of client, so we can use it now to transfer data to client
                Socket clientSock = sock.Accept();


                string fileName = "flow chart book.pdf";// "Your File Name";
                string filePath = @"C:\Users\aparna.j\Documents\GitHub\IMPACT_ASSIGNMENT\ASSIGNMENT6\Filemultiple\Filemultiple\bin\Debug\";//Your File Path;
                byte[] fileNameByte = Encoding.ASCII.GetBytes(fileName);

                byte[] fileData = File.ReadAllBytes(filePath + fileName);
                byte[] clientData = new byte[4 + fileNameByte.Length + fileData.Length];
                byte[] fileNameLen = BitConverter.GetBytes(fileNameByte.Length);

                fileNameLen.CopyTo(clientData, 0);
                fileNameByte.CopyTo(clientData, 4);
                fileData.CopyTo(clientData, 4 + fileNameByte.Length);


                clientSock.Send(clientData);
                Console.WriteLine("File:{0} has been sent.", fileName);


                clientSock.Close();
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("File Receiving fail." + ex.Message);
                Console.ReadKey();
            }
        }
    }
}
