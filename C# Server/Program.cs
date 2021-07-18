using System;
using System.Text;
using System.Net;
using System.Net.Sockets;


namespace server
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] data = new byte[1024];

            IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 65535);

            Socket newSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            newSocket.Bind(endpoint);

            Console.WriteLine("Waiting for the client...");

            while (true)
            {
                IPEndPoint client = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 65535);
                EndPoint addressClient = (EndPoint)client;
                newSocket.ReceiveFrom(data, ref addressClient);
                
                string strData = Encoding.Default.GetString(data);
                Console.WriteLine("Data: " + strData);
 
                string message = "The server receive the data";
                data = Encoding.ASCII.GetBytes(message);
                newSocket.SendTo(data, addressClient);
                
                if (strData == "close")
                    Console.WriteLine("Server disconnected");
                    break;
        
            }
        }
    }
}
