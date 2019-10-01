using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
namespace Filemultiple1
{
    //FILE TRANSFER USING C#.NET SOCKET - CLIENT
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
            
                    Console.WriteLine("That program can transfer small file. I've test up to 850kb file");
                    IPAddress[] ipAddress = Dns.GetHostAddresses("192.168.153.58");
                    IPEndPoint ipEnd = new IPEndPoint(ipAddress[0], 8100);
                    Socket clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
               
                    clientSock.Connect(ipEnd);


                    Console.WriteLine("Enter the file name to be sent:");
                    string fileName;
                    string filePath =@"C:\Users\aparna.j\Documents\GitHub\IMPACT_ASSIGNMENT\ASSIGNMENT6\fileshare client\fileshare client\Filemultiple1\Filemultiple1\bin\Debug\";//Your File Path;

                    while (!string.IsNullOrEmpty((fileName = Console.ReadLine())))
                    {
                        byte[] fileNameByte = Encoding.ASCII.GetBytes(fileName);

                        byte[] fileData = File.ReadAllBytes(filePath + fileName);
                        byte[] clientData = new byte[4 + fileNameByte.Length + fileData.Length];
                        byte[] fileNameLen = BitConverter.GetBytes(fileNameByte.Length);

                        fileNameLen.CopyTo(clientData, 0);
                        fileNameByte.CopyTo(clientData, 4);
                        fileData.CopyTo(clientData, 4 + fileNameByte.Length);


                        clientSock.Send(clientData);
                        Console.WriteLine("File:{0} has been sent.", fileName);
                    }

                    clientSock.Close();
                    Console.ReadLine();
                    
              
            }
            catch (Exception ex)
            {
                Console.WriteLine("File Receiving fail." + ex.Message);
                
                
            }

        }
    }
}
