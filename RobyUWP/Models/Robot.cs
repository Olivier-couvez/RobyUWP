using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.Windows;

namespace RobyUWP.Models
{
    class Robot
    {
        private int Port;
        private string AdrTCP;

        TcpClient SocketClient;
        NetworkStream NetStream;

        public Robot(string AdrTCP, int Port)
        {
            try
            {
                SocketClient = new TcpClient();
                SocketClient.Connect(AdrTCP, Port);
                NetStream = SocketClient.GetStream();
            }

            catch (ArgumentOutOfRangeException err)
            {

            }

            catch (SocketException err)
            {

            }        
        }

        public int Port1 { get => Port; set => Port = value; }
        public string AdrTCP1 { get => AdrTCP; set => AdrTCP = value; }

        public void Commander(Byte[] CommandeRobot)
        {
            NetStream.Write(CommandeRobot, 0, 2);
        }
    }
}
