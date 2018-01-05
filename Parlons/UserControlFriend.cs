using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parlons
{
    public partial class UserControlFriend : UserControl
    {
        public static int count = 0;
        public FlowLayoutPanel flowLayoutPanelSession;
        public TextBox textBoxSession;
        public string userID; // the student ID
        public int orderID; // the order ID is 0, 1, 2 ...

        public UserControlFriend(string uID)
        {
            InitializeComponent();

            // get an order ID
            orderID = count;
            count++;

            userID = uID;
            labelUserID.Text = userID;

            // the message history
            flowLayoutPanelSession = new FlowLayoutPanel();
            flowLayoutPanelSession.Parent = FormParlons.PARLONS;
            flowLayoutPanelSession.Location = new System.Drawing.Point(218, 33);
            flowLayoutPanelSession.Name = "flowLayoutPanelSession";
            flowLayoutPanelSession.Size = new System.Drawing.Size(766 - 218, 405 - 33);
            flowLayoutPanelSession.TabIndex = 7;
            flowLayoutPanelSession.AutoScroll = true;
            flowLayoutPanelSession.MouseDown += new System.Windows.Forms.MouseEventHandler(FormParlons.PARLONS.FormParlons_MouseDown);
            flowLayoutPanelSession.Click += new System.EventHandler(flowLayoutPanelSession_Click);

            // the current message
            textBoxSession = new TextBox();
            textBoxSession.Parent = FormParlons.PARLONS;
            textBoxSession.Location = new System.Drawing.Point(223, 442);
            textBoxSession.Multiline = true;
            textBoxSession.Name = "textBoxSession";
            textBoxSession.Size = new System.Drawing.Size(768 - 223, 558 - 446);
            textBoxSession.TabIndex = 5;
            textBoxSession.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBoxSession.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBoxSession.KeyPress += new KeyPressEventHandler(textBoxSession_KeyPress);

            string queryStr = "q" + userID;
            string queryIPStr = FormParlons.PARLONS.serverConnection.ServerQuery(queryStr);
            if (queryIPStr == "n")
            {
                labelStatus.Text = "离线";
            }

            HighlightCurrent();
        }

        private void UserControlFriend_MouseClick(object sender, MouseEventArgs e)
        {
            HighlightCurrent();
        }

        public void HighlightCurrent()
        {
            // set the last panel to be dark
            if (FormParlons.PARLONS.isGroup)
            {
                if (FormParlons.PARLONS.currGroupOrderID > -1)
                {
                    FormParlons.PARLONS.groups[FormParlons.PARLONS.currGroupOrderID].BackColor = System.Drawing.SystemColors.Control;
                }
                FormParlons.PARLONS.isGroup = false;
            }
            else
            {
                if (FormParlons.PARLONS.currOrderID > -1)
                {
                    FormParlons.PARLONS.friends[FormParlons.PARLONS.currOrderID].BackColor = System.Drawing.SystemColors.Control;

                    // hide the last friend labelStatus
                    FormParlons.PARLONS.friends[FormParlons.PARLONS.currOrderID].labelStatus.Text = "";
                }
            }

            // set this panel to be dark
            this.BackColor = System.Drawing.SystemColors.ControlDark;

            // set the orderID for Parlons
            FormParlons.PARLONS.currOrderID = orderID;

            // renew the current state
            string queryStr = "q" + userID;
            string queryIPStr = FormParlons.PARLONS.serverConnection.ServerQuery(queryStr);
            if (queryIPStr == "n")
            {
                labelStatus.Text = "离线";
            }
            else
            {
                labelStatus.Text = "在线";
            }

            flowLayoutPanelSession.BringToFront();
            textBoxSession.BringToFront();
            FormParlons.PARLONS.buttonSend.BringToFront();
        }

        private void flowLayoutPanelSession_Click(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void textBoxSession_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // Press 'Enter'
            {
                if (FormParlons.PARLONS.isGroup)
                    FormParlons.PARLONS.SendToGroup();
                else
                    FormParlons.PARLONS.SendToFriend();
            }
        }

    }
}
