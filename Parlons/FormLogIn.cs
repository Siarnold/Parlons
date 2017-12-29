using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parlons
{
    public partial class FormLogIn : Form
    {
        public static FormLogIn LOGIN = null;
        ServerConnection serverConnection;
        public string userID;
        string password;
        public FormLogIn()
        {
            InitializeComponent();
            LOGIN = this;
            serverConnection = new ServerConnection();
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            userID = textBoxUserID.Text.ToString();
            password = textBoxPassword.Text.ToString();
            string logInStr = userID + "_" + password;
            // log in 
            if (serverConnection.ServerQuery(logInStr) == "lol")
            {
                this.Hide();
                FormParlons formParlons = new FormParlons(serverConnection);
                formParlons.Show();
            }
        }

        private void FormLogIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
