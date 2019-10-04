using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;

namespace ServerData
{
    public class Packet
    {

        public List<string> GData;
        public int packetint;
        public bool packetbool;
        public string senderID;
        public PacketType packettype;

        public Packet(PacketType type,string senderID)
        {
            GData = new List<string>();
            this.senderID = senderID;
            this.packettype = type;
        }

        public Packet(byte[] packetbytes)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(packetbytes);

            Packet p = (Packet)bf.Deserialize(ms);
            ms.Close();
            this.GData = p.GData;
            this.packetint = p.packetint;
            this.packetbool = p.packetbool;
            this.senderID = p.senderID;
            this.packettype = p.packettype;

        }

        public byte[] ToBytes()
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, this);
            byte[] bytes = ms.ToArray();
            ms.Close();
            return bytes;

        }
        

        public static string Getipaddress()
        {
            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());

            foreach(IPAddress i in ips)
            {
                if(i.AddressFamily==System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return i.ToString();
                }
              
            }
            return "127.0.0.1";
        }

        public enum PacketType
        {
            Registration,
            Chat

        }
    }
}
