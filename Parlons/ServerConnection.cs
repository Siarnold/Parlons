using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Parlons
{
    public class ServerConnection
    {
        IPAddress serverIP;
        IPEndPoint serverEndPoint;
        Socket serverSocket;

        public ServerConnection()
        {
            serverIP = IPAddress.Parse("166.111.140.14");
            serverEndPoint = new IPEndPoint(serverIP, 8000);
        }

        public string ServerQuery(string queryStr)
        {
            string resultStr = "0";
            byte[] queryByte = System.Text.Encoding.UTF8.GetBytes(queryStr);
            byte[] resultByte = new byte[1024 * 1024 * 2];
            int length;

            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // set up connection
            try
            {
                serverSocket.Connect(serverEndPoint);
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
                return resultStr;
            }

            serverSocket.Send(queryByte);

            // receive from server
            try
            {
                length = serverSocket.Receive(resultByte);
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
                serverSocket.Close();
                return resultStr;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                serverSocket.Close();
                return resultStr;
            }

            resultStr = System.Text.Encoding.UTF8.GetString(resultByte, 0, length);
            serverSocket.Close();
            return resultStr;
        }

    }
}
