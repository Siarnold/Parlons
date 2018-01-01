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
    public partial class UserControlReceiveSession : UserControl
    {
        public UserControlReceiveSession(string session, string userID)
        {
            InitializeComponent();
            labelSession.Text = session;
            labelUserID.Text = userID;
            labelTime.Text = string.Format(
                           "{0:yyyy-MM-dd H:mm:ss}", DateTime.Now
                           );
        }

        public UserControlReceiveSession(string session)
        {
            InitializeComponent();
            labelSession.Text = session;
            labelUserID.Text = "";
            labelTime.Text = "";
        }
    }
}
