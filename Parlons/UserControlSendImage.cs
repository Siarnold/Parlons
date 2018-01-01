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
    public partial class UserControlSendImage : UserControl
    {
        public UserControlSendImage(Image image, string session = "")
        {
            InitializeComponent();
            labelSession.Text = session;
            pictureBoxImage.Image = image;
            if (session == "")
            {
                labelSession.BackColor = System.Drawing.SystemColors.Control;
            }
        }
    }
}
