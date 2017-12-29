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
        static int count = 0;
        public FlowLayoutPanel flowLayoutPanelSession;
        public TextBox textBoxSession;
        public string userID; // the student ID
        public int orderID; // the order ID is 0, 1, 2 ...

        public UserControlFriend(string uID)
        {
            InitializeComponent();
            orderID = count;
            count++;

            userID = uID;
            labelUserID.Text = userID;

            // the message history
            flowLayoutPanelSession = new FlowLayoutPanel();
            flowLayoutPanelSession.Location = new System.Drawing.Point(206, 20);
            flowLayoutPanelSession.Name = "flowLayoutPanelSession";
            flowLayoutPanelSession.Size = new System.Drawing.Size(400, 200);
            flowLayoutPanelSession.TabIndex = 7;
            flowLayoutPanelSession.AutoScroll = true;
            flowLayoutPanelSession.Parent = FormParlons.PARLONS;
            flowLayoutPanelSession.BringToFront();

            // the current message
            textBoxSession = new TextBox();
            textBoxSession.Location = new System.Drawing.Point(206, 277);
            textBoxSession.Multiline = true;
            textBoxSession.Name = "textBoxSession";
            textBoxSession.Size = new System.Drawing.Size(400, 80);
            textBoxSession.TabIndex = 5;
            textBoxSession.Text = orderID.ToString();
            textBoxSession.Parent = FormParlons.PARLONS;
            textBoxSession.BringToFront();
        }


        private void UserControlFriend_MouseClick(object sender, MouseEventArgs e)
        {
            flowLayoutPanelSession.BringToFront();
            textBoxSession.BringToFront();
            
            // set the orderID for Parlons
            FormParlons.currOrderID = orderID;
            FormParlons.PARLONS.labelDebug.Text = "Clicked.";
        }

        private void labelUserID_MouseClick(object sender, MouseEventArgs e)
        {
            flowLayoutPanelSession.BringToFront();
            textBoxSession.BringToFront();

            // set the orderID for Parlons
            FormParlons.currOrderID = orderID;
            FormParlons.PARLONS.labelDebug.Text = "Clicked.";
        }


    }
}
