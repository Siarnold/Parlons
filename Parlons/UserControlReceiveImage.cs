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
    public partial class UserControlReceiveImage : UserControl
    {
        public UserControlReceiveImage(Image image, String session = "")
        {
            InitializeComponent();
            pictureBoxImage.Image = image;
            labelSession.Text = session;
            if (session == "")
            {
                labelSession.BackColor = System.Drawing.SystemColors.Control;
            }
        }
    }
}
