using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientNetworkProject
{
    class FirstNetworkClass
    {
        static Socket sck;
        static void Main(string[] args)
        {
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
            try
            {
                sck.Connect(localEndPoint);
                Console.WriteLine("Connected");
            }
            catch
            {
                Console.WriteLine("unable to connect to the end point!\r\n");
                Main(args);
            }
            Console.Write("Enter text: ");
            string text = Console.ReadLine();
            byte[] data = Encoding.ASCII.GetBytes(text);
            sck.Send(data);
            Console.WriteLine("Data Sent!\r\n");
            Console.WriteLine("Press any key to continue...");
            sck.Close();
            Console.Read();
        }
    }
}
