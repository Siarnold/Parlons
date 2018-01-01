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
    public partial class UserControlSendSession : UserControl
    {
        public UserControlSendSession(string session, string userID)
        {
            InitializeComponent();
            labelSession.Text = session;
            labelUserID.Text = userID;
            labelTime.Text = string.Format(
                           "{0:yyyy-MM-dd H:mm:ss}", DateTime.Now
                           );
        }

        public UserControlSendSession(string session)
        {
            InitializeComponent();
            labelSession.Text = session;
            labelUserID.Text = "";
            labelTime.Text = "";
        }
    }
}
