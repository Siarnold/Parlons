using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows;
using System.Windows.Forms;

namespace Parlons
{
    public class P2PConnection
    {
        IPAddress listenIP, peerIP;
        EndPoint listenEndPoint, peerEndPoint;
        Socket listenSocket, receiveSocket, peerSocket;
        int port = 50766;
        int backlog = 10;
        Byte[] receiveByte;
        public static bool listening = false;
        public static bool newMessage = false;
        public static int length;
        public static string receiveStr = "0";
        public static IPEndPoint remoteEndPoint;
        public static IPAddress remoteIP;

        public P2PConnection(string myIPString)
        {
            listenIP = IPAddress.Parse(myIPString);
            listenEndPoint = new IPEndPoint(listenIP, port);
            // listenEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
        }

        // send bytes to a peer
        public void P2PSend(IPAddress peerIP, byte[] sendByte)
        {
            peerEndPoint = new IPEndPoint(peerIP, port);
            peerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // set up connection
            try
            {
                peerSocket.Connect(peerEndPoint);
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
                return;
            }

            // send the bytes
            peerSocket.Send(sendByte);
            peerSocket.Close();
        }

        // overload: send bytes to a peer
        public void P2PSend(string peerIPString, byte[] sendByte)
        {
            peerIP = IPAddress.Parse(peerIPString);
            P2PSend(peerIP, sendByte);
        }

        // overload: send string to a peer
        public void P2PSend(IPAddress peerIP, string sendStr)
        {
            Byte[] sendByte = System.Text.Encoding.UTF8.GetBytes(sendStr);
            P2PSend(peerIP, sendByte);
        }

        // overload: set string to a peer
        public void P2PSend(string peerIPString, string sendStr)
        {
            peerIP = IPAddress.Parse(peerIPString);
            P2PSend(peerIP, sendStr);
        }

        public void Listen()
        {
            listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                listenSocket.Bind(listenEndPoint);
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
                listening = false;
                return;
            }

            listenSocket.Listen(backlog);

            while (listening)
            {
                receiveSocket = listenSocket.Accept();
                receiveByte = new Byte[1024];
                length = receiveSocket.Receive(receiveByte);
                receiveStr = System.Text.Encoding.UTF8.GetString(receiveByte, 0, length);
                remoteEndPoint = (IPEndPoint) receiveSocket.RemoteEndPoint;
                remoteIP = remoteEndPoint.Address;

                // set flag to remind the FormParlons
                newMessage = true;
            }

            listenSocket.Close();
        }


    }
}
