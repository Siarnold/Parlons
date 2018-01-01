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
        public Socket listenSocket, receiveSocket, peerSocket;
        int port = 50766;
        int backlog = 10;
        byte[] receiveByte = new byte[1024 * 1024];
        public byte[] receiveBuffer = new byte[1024 * 1024 * 15];
        public int receiveLength;
        public IPEndPoint remoteEndPoint;
        public IPAddress remoteIP;
        public bool newMessage = false;

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
                MessageBox.Show(se.Message, "温馨提示");
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
                MessageBox.Show(se.Message, "温馨提示");
                return;
            }

            listenSocket.Listen(backlog);

            while (true)
            {
                int length;
                
                receiveSocket = listenSocket.Accept();
                length = receiveSocket.Receive(receiveByte);
                receiveLength = 0;
                Array.Copy(receiveByte, 0, receiveBuffer, receiveLength, length);
                receiveLength += length;

                remoteEndPoint = (IPEndPoint)receiveSocket.RemoteEndPoint;
                remoteIP = remoteEndPoint.Address;

                while (length > 0)
                {
                    length  = receiveSocket.Receive(receiveByte);
                    Array.Copy(receiveByte, 0, receiveBuffer, receiveLength, length);
                    receiveLength += length;
                }

                // 1 byte of 0 is defined as the terminating signal
                if (receiveLength == 1 && receiveBuffer[0] == 0)
                    break;

                receiveSocket.Close();
                // set flag to remind the FormParlons
                newMessage = true;
            }

            listenSocket.Close();
        }


    }
}
