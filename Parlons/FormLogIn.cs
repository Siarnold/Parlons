using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace Parlons
{
    public partial class FormLogIn : Form
    {
        public static FormLogIn FORMLOGIN = null; // the pointer to this instance
        ServerConnection serverConnection;
        public string userID;
        string password;
        public FormLogIn()
        {
            InitializeComponent();
            FORMLOGIN = this;
            serverConnection = new ServerConnection();
        }

        // let the window move as the mouse moves
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        private void FormLogIn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x0112, 0xF012, 0);
            }
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            // get the information in the text boxes
            userID = textBoxUserID.Text.ToString();
            password = textBoxPassword.Text.ToString();
            // form a log-in string
            string logInStr = userID + "_" + password;
            
            // log in 
            if (serverConnection.ServerQuery(logInStr) == "lol")
            {
                this.Hide();
                FormParlons formParlons = new FormParlons(serverConnection);
                formParlons.Show();
            }
            else
            {
                MessageBox.Show("用户名或密码有误哦！", "温馨提示");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void pictureBoxMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }




    }
}
