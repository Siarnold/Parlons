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
    public partial class UserControlSession : UserControl
    {
        public UserControlSession(string session)
        {
            InitializeComponent();
            labelSession.Text = session;
        }
    }
}
