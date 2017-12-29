using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace Parlons
{

    public partial class FormParlons : Form
    {
        public static FormParlons PARLONS = null;
        public static int currOrderID = -1;
        ServerConnection serverConnection;
        P2PConnection p2pConnection;
        List<UserControlFriend> friends;
        Dictionary<string, int> friendsDict;
        public enum MessageType { TEXT, FILE };

        string myUserID;
        string myIPStr;

        public FormParlons(ServerConnection sC)
        {
            InitializeComponent();
            PARLONS = this;

            serverConnection = sC;
            friends = new List<UserControlFriend>();
            friendsDict = new Dictionary<string, int>();

            myUserID = FormLogIn.LOGIN.userID;
            myIPStr = serverConnection.ServerQuery("q" + myUserID);
            p2pConnection = new P2PConnection(myIPStr);

            // start listening and processing new message with 2 threads
            StartListening();
        }

        public void StartListening()
        {
            Thread threadListening = new Thread(new ThreadStart(p2pConnection.Listen));
            threadListening.Start();
            P2PConnection.listening = true;

            // invoke another thread to process the new message
            Thread threadMonitoring = new Thread(MonitorNewMessage);
            threadMonitoring.Start();
        }

        public void StopListening()
        {
            P2PConnection.listening = false;
        }

        public void MonitorNewMessage()
        {
            while (P2PConnection.listening)
            {
                if (P2PConnection.newMessage)
                {
                    // labelDebug.Text = "Eurika!";
                    this.Invoke(new ProcessNewMessageDelegate(ProcessNewMessage));
                }
            }
        }

        public delegate void ProcessNewMessageDelegate();

        public void ProcessNewMessage()
        {
            P2PConnection.newMessage = false;
            string userID = P2PConnection.receiveStr.Substring(0, 10);

            // if not in the list, then add to the friend list
            if (!friendsDict.Keys.Contains(userID))
            {
                AddFriend(userID);
            }

            

            string message ="R" + P2PConnection.receiveStr.Substring(11);
            UserControlSession userControlSession = new UserControlSession(
                            message);
            friends[currOrderID].flowLayoutPanelSession.Controls.Add(
                    userControlSession);

        }

        public void AddFriend(string userID)
        {
            // build a new instance of friend
            UserControlFriend friend = new UserControlFriend(userID);
            // add this friend to the list and dict in FormParlons
            friends.Add(friend);
            friendsDict.Add(userID, friend.orderID);
            labelDebug.Text = friends.Count().ToString();
            // add this friend to the UI
            flowLayoutPanelFriends.Controls.Add(friend);
            // let this friend be in the current session
            currOrderID = friend.orderID;
        }

        private void buttonQuery_Click(object sender, EventArgs e)
        {
            string queryUserID = textBoxQuery.Text.ToString();
            string queryStr = "q" + queryUserID;
            string queryIPStr = serverConnection.ServerQuery(queryStr);

            if (queryIPStr == "Please send the correct message.")
            {
                MessageBox.Show("您查找的用户不存在哦！");
            }
            else
            {
                if (queryIPStr == "n")
                {
                    MessageBox.Show("您查找的用户正处于离线状态哦！");
                }
                else
                {
                    labelDebug.Text = queryIPStr;
                    MessageBox.Show("您查找的用户正在线上哦！");
                }

                AddFriend(queryUserID);
            }
        }

        private void FormParlons_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确定退出?", "Parlons", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void FormParlons_FormClosed(object sender, FormClosedEventArgs e)
        {
            string logOutStr = "logout" + FormLogIn.LOGIN.userID;
            // log out
            serverConnection.ServerQuery(logOutStr);
            MessageBox.Show("您已经下线了哦！");
            // stop listening
            StopListening();

            FormLogIn.LOGIN.Show();
        }

        public byte[] GenerateFormat(MessageType messageType)
        {
            string formatStr = myUserID;

            // format the session string
            // "0" refers to TEXT message
            // "1" refers tp FILE message
            switch (messageType)
            {
                case MessageType.TEXT:
                    formatStr += "0";
                    break;
                case MessageType.FILE:
                    formatStr += "1";
                    break;
                default:
                    MessageBox.Show("不支持的类型哦！");
                    break;
            }

            return System.Text.Encoding.UTF8.GetBytes(formatStr);
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (currOrderID < 0)
            {
                MessageBox.Show("请指定一个好友再发送呀！");
            }
            else
            {
                string peerUserID = friends[currOrderID].userID;
                string peerIPStr = serverConnection.ServerQuery("q" + peerUserID);

                // send a message
                if (peerIPStr == "Please send the correct message." || peerIPStr == "n")
                {
                    MessageBox.Show("该好友已下线了呢！");
                }
                else
                {
                    string session = friends[currOrderID].textBoxSession.Text.ToString();
                    byte[] sessionByte = System.Text.Encoding.UTF8.GetBytes(session);
                    byte[] formatByte = GenerateFormat(MessageType.TEXT);
                    byte[] sendByte = new byte[formatByte.Length + sessionByte.Length];
                    formatByte.CopyTo(sendByte, 0);
                    sessionByte.CopyTo(sendByte, formatByte.Length);

                    // peerIPStr = "127.0.0.1";
                    UserControlSession userControlSession = new UserControlSession(session);
                    friends[currOrderID].flowLayoutPanelSession.Controls.Add(userControlSession);
                    p2pConnection.P2PSend(peerIPStr, sendByte);

                }
            }

        }

        private void FormParlons_MouseMove(object sender, MouseEventArgs e)
        {
            labelDebug.Text = e.Location.X.ToString() + ", " + e.Location.Y.ToString();
        }

        private void buttonSendFile_Click(object sender, EventArgs e)
        {
            if (currOrderID < 0)
            {
                MessageBox.Show("请指定一个好友再发送呀！");
            }
            else
            {
                string peerUserID = friends[currOrderID].userID;
                string peerIPStr = serverConnection.ServerQuery("q" + peerUserID);

                // send a message
                if (peerIPStr == "Please send the correct message." || peerIPStr == "n")
                {
                    MessageBox.Show("该好友已下线了呢！");
                }
                else
                {
                    string localFilePath;
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "所有文件(*.*)|*.*";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.Title = "请选择要传的文件哦";
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        localFilePath = openFileDialog.FileName.ToString();
                        string filename = Path.GetFileName(localFilePath);
                        try
                        {
                            byte[] fileByte = File.ReadAllBytes(localFilePath);
                            byte[] formatByte = GenerateFormat(MessageType.FILE);
                            byte[] sendByte = new byte[formatByte.Length + fileByte.Length];
                            formatByte.CopyTo(sendByte, 0);
                            fileByte.CopyTo(sendByte, formatByte.Length);

                            // actually send
                            // peerIPStr = "127.0.0.1";
                            p2pConnection.P2PSend(peerIPStr, sendByte);

                            string session = string.Format(
                                "{0} 在 {1:MM-dd H:mm:ss} 分享了文件{2}",
                                myUserID, DateTime.Now, filename
                                );

                            // show in the session panel
                            UserControlSession userControlSession = new UserControlSession(session);
                            friends[currOrderID].flowLayoutPanelSession.Controls.Add(userControlSession);

                        }
                        catch (SystemException se)
                        {
                            MessageBox.Show(se.Message);
                        }
                    }
                }

            }
        }
    }
}
