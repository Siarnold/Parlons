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
    public partial class UserControlGroup : UserControl
    {
        public static int count = 0;
        public FlowLayoutPanel flowLayoutPanelSession;
        public TextBox textBoxSession;
        public List<string> userIDs; // the student ID
        public int groupOrderID; // the order ID is 0, 1, 2 ...
        public string groupID; // the identifier of a group 
        public string groupName;
        
        public UserControlGroup(List<string> uIDs, string gName)
        {
            InitializeComponent();
            userIDs = uIDs;

            // get an order ID
            groupOrderID = count;
            count++;

            // generate group ID
            groupID = userIDs[0];
            for (int i = 1; i < userIDs.Count(); i++)
            {
                groupID += userIDs[i];
            }

            groupName = gName;
            labelGroupName.Text = groupName;

            UISetUp();
            HighlightCurrent();
        }

        public UserControlGroup(string gID, string gName)
        {
            InitializeComponent();
            if (gID.Length < 10 && gID.Length % 10 != 0)
            {
                MessageBox.Show("您的群组ID非法哦！");
                return;
            }
            groupID = gID;

            FormParlons.PARLONS.isGroup = true;
            // get an order ID
            groupOrderID = count;
            count++;

            int N = groupID.Length / 10;
            userIDs = new List<string>(N);
            for (int i = 0; i < N; i++)
            {
                // add to the list
                userIDs.Add(groupID.Substring(10 * i, 10));
            }
            groupName = gName;
            labelGroupName.Text = groupName;

            UISetUp();
            HighlightCurrent();
        }

        public void UISetUp()
        {
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
            }
            else
            {
                if (FormParlons.PARLONS.currOrderID > -1)
                {
                    FormParlons.PARLONS.friends[FormParlons.PARLONS.currOrderID].BackColor = System.Drawing.SystemColors.Control;
                }
                FormParlons.PARLONS.isGroup = true;
            }

            // set this panel to be dark
            this.BackColor = System.Drawing.SystemColors.ControlDark;

            // bring to front the controls
            flowLayoutPanelSession.BringToFront();
            textBoxSession.BringToFront();
            FormParlons.PARLONS.buttonSend.BringToFront();
            FormParlons.PARLONS.isGroup = true;

            // set the orderID for Parlons
            FormParlons.PARLONS.currGroupOrderID = groupOrderID;
            

        }

        private void UserControlGroup_MouseClick(object sender, MouseEventArgs e)
        {
            HighlightCurrent();
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
