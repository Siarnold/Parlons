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
using System.Runtime.InteropServices;


namespace Parlons
{

    public partial class FormParlons : Form
    {
        public static FormParlons PARLONS = null;
        public bool isGroup = false;
        public int currOrderID = -1;
        public int currGroupOrderID = -1;
        public int formatLength = 11;
        public ServerConnection serverConnection;
        P2PConnection p2pConnection;
        public List<UserControlFriend> friends;
        Dictionary<string, int> friendsDict; // dict from userID to order ID
        public List<UserControlGroup> groups;
        Dictionary<string, int> groupsDict; // dict from groupName to group order ID
        Thread threadListening, threadMonitoring;
        bool listening = false;

        // text, file
        public enum MessageType { TEXT, FILE };
        // Emoji Directory
        // string EmojiDirectory = @".\Emoji";
        string EmojiDirectory = @"..\..\Resources";
        
        string myUserID;
        string myIPStr; 

        public FormParlons(ServerConnection sC)
        {
            InitializeComponent();
            PARLONS = this;
            serverConnection = sC;

            // group settings
            groups = new List<UserControlGroup>();
            groupsDict = new Dictionary<string, int>();
            pictureBoxGroupConfirm.Hide();
            pictureBoxGroupCancel.Hide();
            textBoxGroupName.Hide();
            checkedListBoxGroup.Hide();
            checkedListBoxGroup.Parent = this;
            checkedListBoxGroup.Location = new System.Drawing.Point(218, 16);
            checkedListBoxGroup.Size = new System.Drawing.Size(440 - 218, 405 - 16);

            // friend settings
            friends = new List<UserControlFriend>();
            friendsDict = new Dictionary<string, int>();

            // information maintenance
            myUserID = FormLogIn.FORMLOGIN.userID;
            myIPStr = serverConnection.ServerQuery("q" + myUserID);
            p2pConnection = new P2PConnection(myIPStr);

            // start listening and processing new message with 2 threads
            StartListening();
            AddFriend(myUserID);
            panelEmoji.Hide();
            AddEmoji();
        }


        /****************************************************
         * Let the window move when mouse dragging
         * **************************************************/

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        public void FormParlons_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x0112, 0xF012, 0);
            }
        }

        // let the scoll go with mouse wheel
        private void flowLayoutPanelFriends_Paint(object sender, PaintEventArgs e)
        {
            flowLayoutPanelFriends.Focus();
        }

        /*******************************************************
         ******************************************************/


        /*******************************************************
         * The events relevent to the close of the window
         ********************************************************/

        private void buttonChangeUser_Click(object sender, EventArgs e)
        {
            // stop listening
            StopListening();
            while (threadListening.IsAlive) ;
            while (threadMonitoring.IsAlive) ;

            // log out
            string logOutStr = "logout" + myUserID;
            serverConnection.ServerQuery(logOutStr);
            MessageBox.Show("您已经下线了哦！", "温馨提示");

            this.Close();
            UserControlFriend.count = 0;
            UserControlGroup.count = 0;
            FormLogIn.FORMLOGIN.Show();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定退出?", "Parlons", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                // stop listening
                StopListening();
                while (threadListening.IsAlive) ;
                while (threadMonitoring.IsAlive) ;

                // log out
                string logOutStr = "logout" + myUserID;
                serverConnection.ServerQuery(logOutStr);
                MessageBox.Show("您已经下线了哦！", "温馨提示");

                this.Close();
                FormLogIn.FORMLOGIN.Close();
                Application.Exit();
            }
        }

        /***********************************************************
         ***********************************************************/


        /************************************************************
         * Deal with the listening and processing of coming messages
         ************************************************************/
        public void StartListening()
        {
            threadListening = new Thread(new ThreadStart(p2pConnection.Listen));
            threadListening.Start();

            listening = true;
            
            // invoke another thread to process the new message
            threadMonitoring = new Thread(MonitorNewMessage);
            threadMonitoring.Start();
        }

        public void StopListening()
        {
            listening = false;

            byte[] stopSignal = new byte[1];
            stopSignal[0] = 0;
            p2pConnection.P2PSend(myIPStr, stopSignal);
        }

        public void MonitorNewMessage()
        {
            while (listening)
            {
                if (p2pConnection.newMessage)
                {
                    // labelDebug.Text = "Eurika!";
                    this.Invoke(new ProcessNewMessageDelegate(ProcessNewMessage));
                }
            }
        }

        public delegate void ProcessNewMessageDelegate();

        public void PanelAutoScroll()
        {
            if (currOrderID >= 0)
            {
                friends[currOrderID].flowLayoutPanelSession.AutoScrollPosition = new Point(0, friends[currOrderID].flowLayoutPanelSession.Height - friends[currOrderID].flowLayoutPanelSession.AutoScrollPosition.Y);
            }

            if (currGroupOrderID >= 0)
            {
                groups[currGroupOrderID].flowLayoutPanelSession.AutoScrollPosition = new Point(0, groups[currGroupOrderID].flowLayoutPanelSession.Height - groups[currGroupOrderID].flowLayoutPanelSession.AutoScrollPosition.Y);
            }
        }

        public void ProcessNewMessage()
        {
            p2pConnection.newMessage = false;
            string userID = System.Text.Encoding.UTF8.GetString(p2pConnection.receiveBuffer, 0, formatLength - 1);
            

            if (p2pConnection.receiveBuffer[formatLength - 1] < 2)
            {
                // friend talk
                // if not in the list, then add to the friend list
                if (!friendsDict.Keys.Contains(userID))
                {
                    AddFriend(userID);
                }
                else
                {
                    currOrderID = friendsDict[userID];
                    friends[currOrderID].HighlightCurrent();
                }

                switch (p2pConnection.receiveBuffer[formatLength - 1])
                {
                    case 0: // TEXT
                        {
                            string message = System.Text.Encoding.UTF8.GetString(p2pConnection.receiveBuffer, formatLength,
                                p2pConnection.receiveLength - formatLength);
                            UserControlReceiveSession userControlSession = new UserControlReceiveSession(message, userID);
                            friends[currOrderID].flowLayoutPanelSession.Controls.Add(userControlSession);
                            PanelAutoScroll();
                            break;
                        }
                    case 1: // FILE
                        if (p2pConnection.receiveBuffer[formatLength] == 0)
                        {
                            // an emoji
                            string emojiName = System.Text.Encoding.UTF8.GetString(p2pConnection.receiveBuffer, formatLength + 1,
                                p2pConnection.receiveLength - formatLength - 1);

                            UserControlReceiveImage userControlReceiveImage = new UserControlReceiveImage(Image.FromFile(emojiName));
                            friends[currOrderID].flowLayoutPanelSession.Controls.Add(userControlReceiveImage);
                            PanelAutoScroll();
                        }
                        else
                        {
                            // really a file
                            // write file when permitted
                            if (MessageBox.Show("是否接收呀?", "文件来啦", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                            {
                                WriteFile();
                            }
                            else
                            {
                                string session = string.Format(
                               "我在 {0:yyyy-MM-dd H:mm:ss} 拒绝了文件接收",
                               DateTime.Now
                               );
                                // show in the session panel
                                UserControlReceiveSession userControlSession = new UserControlReceiveSession(session);
                                friends[currOrderID].flowLayoutPanelSession.Controls.Add(userControlSession);
                                PanelAutoScroll();
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            { 
                // group talk
                int N = p2pConnection.receiveBuffer[formatLength - 1];
                string groupID = System.Text.Encoding.UTF8.GetString(p2pConnection.receiveBuffer, formatLength, 10 * N);
                int lenGroupName = p2pConnection.receiveBuffer[formatLength + 10 * N];
                string groupName = System.Text.Encoding.UTF8.GetString(p2pConnection.receiveBuffer, formatLength + 10 * N + 1, lenGroupName); 
                string message = System.Text.Encoding.UTF8.GetString(p2pConnection.receiveBuffer, formatLength + 10 * N + 1 + lenGroupName,
                                p2pConnection.receiveLength - formatLength - 10 * N - 1 - lenGroupName);

                // if not in the list, then add to the group list
                if (!groupsDict.Keys.Contains(groupID))
                {
                    AddGroup(groupID, groupName);
                }
                else
                {
                    currGroupOrderID = groupsDict[groupID];
                    groups[currGroupOrderID].HighlightCurrent();
                }

                UserControlReceiveSession userControlSession = new UserControlReceiveSession(message, userID);
                groups[currGroupOrderID].flowLayoutPanelSession.Controls.Add(userControlSession);
                PanelAutoScroll();

            }

        }

        public void WriteFile()
        {
            try
            {
                byte fileNameByteLength = p2pConnection.receiveBuffer[formatLength];
                byte[] fileNameByte = new byte[fileNameByteLength];
                byte[] fileByte = new byte[p2pConnection.receiveLength - formatLength - 1 - fileNameByteLength];
                Array.Copy(p2pConnection.receiveBuffer, formatLength + 1, fileNameByte, 0, fileNameByteLength);
                Array.Copy(p2pConnection.receiveBuffer, formatLength + 1 + fileNameByteLength,
                    fileByte, 0, fileByte.Length);
                string fileName = System.Text.Encoding.UTF8.GetString(fileNameByte);

                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.Description = "选择文件保存的位置啦";
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = folderBrowserDialog.SelectedPath + @"\" + fileName;
                    File.WriteAllBytes(filePath, fileByte);

                    string session = string.Format(
                           "我在 {0:yyyy-MM-dd H:mm:ss} 成功接收了文件{1}",
                           DateTime.Now, fileName
                           );

                    string extensionName = fileName.Substring(fileName.Length - 4).ToLower();
                    if (extensionName == ".jpg" || extensionName == ".png")
                    {
                        try
                        {
                            UserControlReceiveImage userControlReceiveImage = new UserControlReceiveImage(Image.FromFile(filePath), session);
                            friends[currOrderID].flowLayoutPanelSession.Controls.Add(userControlReceiveImage);
                            PanelAutoScroll();
                        }
                        catch (System.Exception e)
                        {
                            MessageBox.Show(e.Message, "温馨提示");
                        }
                    }
                    else
                    {
                        // show in the session panel
                        UserControlReceiveSession userControlSession = new UserControlReceiveSession(session);
                        friends[currOrderID].flowLayoutPanelSession.Controls.Add(userControlSession);
                    }
                    PanelAutoScroll();
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message, "温馨提示");
            }
        }

        /***********************************************************
         ***********************************************************/

        /***********************************************************
         * The events relevant to a friend
         ***********************************************************/

        public void AddFriend(string userID)
        {
            // build a new instance of friend
            UserControlFriend friend = new UserControlFriend(userID);

            // add this friend to the list and dict in FormParlons
            friends.Add(friend);
            friendsDict.Add(userID, friend.orderID);

            // add this friend to the UI
            flowLayoutPanelFriends.Controls.Add(friend);
            // let this friend be in the current session
            currOrderID = friend.orderID;

            if (userID != myUserID)
            {
                // let this friend be groupable
                checkedListBoxGroup.Items.Add(userID);
            }
            else
            {
                // change avatar
                friend.pictureBoxAvatar.Image = global::Parlons.Properties.Resources.LOGO;
            }
        }

        private void buttonQuery_Click(object sender, EventArgs e)
        {
            string queryUserID = textBoxQuery.Text.ToString();
            string queryStr = "q" + queryUserID;
            string queryIPStr = serverConnection.ServerQuery(queryStr);

            if (queryIPStr == "Please send the correct message." || queryIPStr == "Incorrect No.")
            {
                MessageBox.Show("您查找的用户不存在哦！", "温馨提示");
            }
            else
            {
                if (friendsDict.Keys.Contains(queryUserID))
                {
                    MessageBox.Show("您查找的用户已在列表里哦！", "温馨提示");
                }
                else
                    AddFriend(queryUserID);
            }
        }

        /********************************************************
         * The events relevant to a group 
         ********************************************************/

        public void AddGroup(List<string> userIDs, string groupName)
        {
            // build a new instance of a group
            UserControlGroup group = new UserControlGroup(userIDs, groupName);

            // add this group to the list and dict in the FormParlons
            groups.Add(group);
            groupsDict.Add(group.groupID, group.groupOrderID);

            // add this group to the UI
            flowLayoutPanelFriends.Controls.Add(group);
            // let this group be in the current session
            currGroupOrderID = group.groupOrderID;
        }

        public void AddGroup(string groupID, string groupName)
        {
            // build a new instance of a group
            UserControlGroup group = new UserControlGroup(groupID, groupName);

            // add this group to the list and dict in the FormParlons
            groups.Add(group);
            groupsDict.Add(group.groupID, group.groupOrderID);

            // add this group to the UI
            flowLayoutPanelFriends.Controls.Add(group);
            // let this group be in the current session
            currGroupOrderID = group.groupOrderID;
        }

        private void pictureBoxGroup_Click(object sender, EventArgs e)
        {
            checkedListBoxGroup.BringToFront();
            checkedListBoxGroup.Show();
            pictureBoxGroupConfirm.Show();
            pictureBoxGroupCancel.Show();
            textBoxGroupName.Show();
        }

        private void pictureBoxGroupConfirm_Click(object sender, EventArgs e)
        {
            List<string> userIDs = new List<string>();

            // ensure that myUserID is in the first of every group I set up
            userIDs.Add(myUserID);
            for (int i = 0; i < checkedListBoxGroup.Items.Count; i++)
            {
                if (checkedListBoxGroup.GetItemChecked(i))
                {
                    userIDs.Add(checkedListBoxGroup.GetItemText(checkedListBoxGroup.Items[i]));
                }

            }

            if (userIDs.Count < 2)
            {
                MessageBox.Show("一定要选择至少一人哦！", "温馨提示");
            }
            else
            {
                string groupID = userIDs[0];
                string groupName = textBoxGroupName.Text;
                for (int i = 1; i < userIDs.Count(); i++)
                {
                    groupID += userIDs[i];
                }

                // add group
                if (groupsDict.Keys.Contains(groupID))
                {
                    MessageBox.Show("该群聊已存在哦！", "温馨提示");
                }
                else
                {
                    AddGroup(userIDs, groupName);
                    pictureBoxGroupConfirm.Hide();
                    pictureBoxGroupCancel.Hide();
                    textBoxGroupName.Hide();
                    checkedListBoxGroup.Hide();
                }
            }
        }

        private void pictureBoxGroupCancel_Click(object sender, EventArgs e)
        {
            checkedListBoxGroup.Hide();
            pictureBoxGroupConfirm.Hide();
            pictureBoxGroupCancel.Hide();
            textBoxGroupName.Hide();
        }

        /*********************************************************
         *********************************************************/


        /**********************************************************
         * Send a message or file or emoji
         **********************************************************/

        public byte[] GenerateFormat(MessageType messageType)
        {
            string formatStr = myUserID;
            byte[] formatByte = new byte[formatLength];
            System.Text.Encoding.UTF8.GetBytes(formatStr).CopyTo(formatByte, 0);

            // format the session string
            // "0" refers to TEXT message
            // "1" refers tp FILE message
            switch (messageType)
            {
                case MessageType.TEXT:
                    formatByte[formatLength - 1] = 0;
                    break;
                case MessageType.FILE:
                    formatByte[formatLength - 1] = 1;
                    break;
                default:
                    MessageBox.Show("不支持的类型哦！", "温馨提示");
                    break;
            }

            return formatByte;
        }

        public void SendToFriend()
        {
            if (currOrderID < 0)
            {
                MessageBox.Show("请指定一个好友再发送呀！", "温馨提示");
            }
            else
            {
                string peerUserID = friends[currOrderID].userID;
                string peerIPStr = serverConnection.ServerQuery("q" + peerUserID);

                // send a message
                if (peerIPStr == "Please send the correct message." || peerIPStr == "n")
                {
                    MessageBox.Show("该好友已下线了呢！", "温馨提示");
                }
                else
                {
                    string session = friends[currOrderID].textBoxSession.Text.ToString();
                    byte[] sessionByte = System.Text.Encoding.UTF8.GetBytes(session);
                    byte[] formatByte = GenerateFormat(MessageType.TEXT); // 11 bytes of format
                    byte[] sendByte = new byte[formatLength + sessionByte.Length];
                    formatByte.CopyTo(sendByte, 0);
                    sessionByte.CopyTo(sendByte, formatLength);

                    p2pConnection.P2PSend(peerIPStr, sendByte);
                    // peerIPStr = "127.0.0.1";
                    UserControlSendSession userControlSession = new UserControlSendSession(session, myUserID);
                    friends[currOrderID].flowLayoutPanelSession.Controls.Add(userControlSession);
                    PanelAutoScroll();

                    // clear the textBox
                    friends[currOrderID].textBoxSession.Text = "";
                }
            }
        }

        public void SendToGroup()
        {
            if (currGroupOrderID < 0)
            {
                MessageBox.Show("请指定一个群再发送呀！", "温馨提示");
            }
            else
            {
                List<string> peerUserIDs = groups[currGroupOrderID].userIDs;
                string groupName = groups[currGroupOrderID].groupName;

                // generate sendByte
                // generate format
                byte[] formatByte = GenerateFormat(MessageType.TEXT); // 11 bytes of format
                formatByte[formatLength - 1] = (byte)peerUserIDs.Count; // the last byte of format represents the number of people in this group

                // generate groupID
                byte[] groupIDByte = System.Text.Encoding.UTF8.GetBytes(groups[currGroupOrderID].groupID);
                // generate groupName
                byte[] groupNameByte = System.Text.Encoding.UTF8.GetBytes(groupName);

                // generate session
                string session = groups[currGroupOrderID].textBoxSession.Text.ToString();
                byte[] sessionByte = System.Text.Encoding.UTF8.GetBytes(session);
                byte[] sendByte = new byte[formatByte.Length + groupIDByte.Length + 1 + groupNameByte.Length + sessionByte.Length];
          
                // combine the 5 parts: format + groupID + len_groupName + groupName + session to form the sendByte
                formatByte.CopyTo(sendByte, 0);
                groupIDByte.CopyTo(sendByte, formatLength);
                sendByte[formatLength + groupIDByte.Length] = (byte) groupNameByte.Length;
                groupNameByte.CopyTo(sendByte, formatLength + groupIDByte.Length + 1);
                sessionByte.CopyTo(sendByte, formatByte.Length + groupIDByte.Length + 1 + groupNameByte.Length);

                // add this operation to the session box
                UserControlSendSession userControlSession = new UserControlSendSession(session, myUserID);
                groups[currGroupOrderID].flowLayoutPanelSession.Controls.Add(userControlSession);
                PanelAutoScroll();

                // clear the textBox
                groups[currGroupOrderID].textBoxSession.Text = "";

                // send the message to everyone in the group
                for (int i = 0; i < peerUserIDs.Count; i++)
                {
                    string peerUserID = peerUserIDs[i];
                    string peerIPStr = serverConnection.ServerQuery("q" + peerUserID);

                    // no need to send back one message
                    if (peerUserID == myUserID)
                        continue;

                    // send a message
                    if (peerIPStr == "Please send the correct message." || peerIPStr == "n")
                    {
                        UserControlReceiveSession uCS = new UserControlReceiveSession(peerUserID + " is not online.");
                        groups[currGroupOrderID].flowLayoutPanelSession.Controls.Add(uCS);
                        PanelAutoScroll();
                    }
                    else
                    {
                        p2pConnection.P2PSend(peerIPStr, sendByte);
                    }
                }
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (isGroup)
                SendToGroup();
            else
                SendToFriend();
        }

        private void pictureBoxSendFile_Click(object sender, EventArgs e)
        {

            // temporarily not support the group file funciton
            if (isGroup)
            {
                MessageBox.Show("该功能尚不支持哦！", "温馨提示");
                return;
            }
            if (currOrderID < 0)
            {
                MessageBox.Show("请指定一个好友再发送呀！", "温馨提示");
            }
            else
            {
                string peerUserID = friends[currOrderID].userID;
                string peerIPStr = serverConnection.ServerQuery("q" + peerUserID);

                // send a message
                if (peerIPStr == "Please send the correct message." || peerIPStr == "n")
                {
                    MessageBox.Show("该好友已下线了呢！", "温馨提示");
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
                        string fileName = Path.GetFileName(localFilePath);
                        try
                        {
                            byte[] formatByte = GenerateFormat(MessageType.FILE);

                            byte[] fileNameByte = System.Text.Encoding.UTF8.GetBytes(fileName);
                            byte[] fileByte = File.ReadAllBytes(localFilePath);

                            byte[] sendByte = new byte[formatLength + 1 + fileNameByte.Length + fileByte.Length];
                            formatByte.CopyTo(sendByte, 0);
                            sendByte[formatLength] = (byte)fileNameByte.Length;
                            fileNameByte.CopyTo(sendByte, 1 + formatLength);
                            fileByte.CopyTo(sendByte, 1 + formatLength + fileNameByte.Length);

                            // actually send
                            // peerIPStr = "127.0.0.1";
                            p2pConnection.P2PSend(peerIPStr, sendByte);

                            string session = string.Format(
                                "{0} 在 {1:MM-dd H:mm:ss} 分享了文件{2}",
                                myUserID, DateTime.Now, fileName
                                );

                            string extensionName = fileName.Substring(fileName.Length - 4).ToLower();
                            if (extensionName == ".jpg" || extensionName == ".png")
                            {
                                try
                                {
                                    UserControlSendImage userControlSendImage = new UserControlSendImage(Image.FromFile(localFilePath), session);
                                    friends[currOrderID].flowLayoutPanelSession.Controls.Add(userControlSendImage);
                                }
                                catch (System.Exception se)
                                {
                                    MessageBox.Show(se.Message, "温馨提示");
                                }
                            }
                            else
                            {
                                // show in the session panel
                                UserControlSendSession userControlSession = new UserControlSendSession(session);
                                friends[currOrderID].flowLayoutPanelSession.Controls.Add(userControlSession);
                            }
                            PanelAutoScroll();

                        }
                        catch (System.Exception se)
                        {
                            MessageBox.Show(se.Message, "温馨提示");
                        }
                    }
                }

            }
        }

        // Add Emoji to the list
        public void AddEmoji()
        {
            Image emoji;
            UserControlEmoji userControlEmoji;
            FileStream fileStream;
            int count = 0, width = 0, height = -28;
            var emojiFiles = Directory.GetFiles(EmojiDirectory, "*.png");
            foreach (var emojiFile in emojiFiles)
            {
                if (count % 12 == 0)
                {
                    width = 0;
                    height += 28;
                }
                fileStream = new FileStream(emojiFile, FileMode.Open, FileAccess.Read);
                emoji = Image.FromStream(fileStream);
                userControlEmoji = new UserControlEmoji(emojiFile);
                userControlEmoji.Image = emoji;
                userControlEmoji.Size = new System.Drawing.Size(28, 28);
                userControlEmoji.SizeMode = PictureBoxSizeMode.Zoom;
                panelEmoji.Controls.Add(userControlEmoji);
                userControlEmoji.Location = new System.Drawing.Point(width, height);
                width += 28;
                count++;

            }
        }

        private void pictureBoxSendEmoji_Click(object sender, EventArgs e)
        {
            if (panelEmoji.Visible)
            {
                panelEmoji.Hide();
            }
            else
            {
                panelEmoji.Show();
                panelEmoji.BringToFront();
                panelEmoji.Focus();
            }
        }

        public void sendEmoji(string emojiName)
        {
            if (currOrderID < 0)
            {
                MessageBox.Show("请指定一个好友再发送呀！", "温馨提示");
            }
            else
            {
                string peerUserID = friends[currOrderID].userID;
                string peerIPStr = serverConnection.ServerQuery("q" + peerUserID);

                // send a message
                if (peerIPStr == "Please send the correct message." || peerIPStr == "n")
                {
                    MessageBox.Show("该好友已下线了呢！", "温馨提示");
                }
                else
                {
                    string session = emojiName;
                    byte[] sessionByte = System.Text.Encoding.UTF8.GetBytes(session);
                    // emoji uses 'FILE' format but the file_length is 0
                    byte[] formatByte = GenerateFormat(MessageType.FILE); // 11 bytes of format
                    byte[] sendByte = new byte[formatLength + 1 + sessionByte.Length];
                    formatByte.CopyTo(sendByte, 0);
                    sendByte[formatLength] = 0;
                    sessionByte.CopyTo(sendByte, formatLength + 1);

                    p2pConnection.P2PSend(peerIPStr, sendByte);
                    
                    UserControlSendImage userControlSendImage = new UserControlSendImage(Image.FromFile(emojiName));
                    friends[currOrderID].flowLayoutPanelSession.Controls.Add(userControlSendImage);
                    PanelAutoScroll();
                }
            }
        }


        /**********************************************************
         **********************************************************/


        /*********************************************************
         * For debugging
         **********************************************************/


        /**********************************************************
         **********************************************************/

    }
}
