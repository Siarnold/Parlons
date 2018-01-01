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
    public partial class UserControlEmoji : PictureBox
    {
        string emojiName;
        public UserControlEmoji(string eName)
        {
            InitializeComponent();
            emojiName = eName;
            this.Click += new EventHandler(userControlEmoji_Click);
        }

        private void userControlEmoji_Click(Object sender, EventArgs e)
        {
            if (FormParlons.PARLONS.isGroup)
            {
                MessageBox.Show("该功能暂不支持哦！", "温馨提示");
                return;
            }
            FormParlons.PARLONS.sendEmoji(emojiName);
        }

    }
}
