namespace Parlons
{
    partial class FormLogIn
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogIn));
            this.textBoxUserID = new System.Windows.Forms.TextBox();
            this.labelUserID = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonLogIn = new System.Windows.Forms.Button();
            this.pictureBoxMin = new System.Windows.Forms.PictureBox();
            this.pictureBoxClose = new System.Windows.Forms.PictureBox();
            this.pictureBoxBackground = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxUserID
            // 
            this.textBoxUserID.Location = new System.Drawing.Point(186, 92);
            this.textBoxUserID.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxUserID.Name = "textBoxUserID";
            this.textBoxUserID.Size = new System.Drawing.Size(184, 30);
            this.textBoxUserID.TabIndex = 3;
            this.textBoxUserID.Text = "2015011451";
            // 
            // labelUserID
            // 
            this.labelUserID.AutoSize = true;
            this.labelUserID.BackColor = System.Drawing.SystemColors.Highlight;
            this.labelUserID.Font = new System.Drawing.Font("方正清刻本悦宋简体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelUserID.Location = new System.Drawing.Point(113, 96);
            this.labelUserID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUserID.Name = "labelUserID";
            this.labelUserID.Size = new System.Drawing.Size(47, 20);
            this.labelUserID.TabIndex = 4;
            this.labelUserID.Text = "账号";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.BackColor = System.Drawing.SystemColors.Highlight;
            this.labelPassword.Font = new System.Drawing.Font("方正清刻本悦宋简体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelPassword.Location = new System.Drawing.Point(113, 143);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(47, 20);
            this.labelPassword.TabIndex = 5;
            this.labelPassword.Text = "密码";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassword.Location = new System.Drawing.Point(186, 139);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(184, 28);
            this.textBoxPassword.TabIndex = 6;
            this.textBoxPassword.Text = "net2017";
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // buttonLogIn
            // 
            this.buttonLogIn.Font = new System.Drawing.Font("方正清刻本悦宋简体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonLogIn.Location = new System.Drawing.Point(199, 213);
            this.buttonLogIn.Name = "buttonLogIn";
            this.buttonLogIn.Size = new System.Drawing.Size(80, 39);
            this.buttonLogIn.TabIndex = 7;
            this.buttonLogIn.Text = "登录";
            this.buttonLogIn.UseVisualStyleBackColor = true;
            this.buttonLogIn.Click += new System.EventHandler(this.buttonLogIn_Click);
            // 
            // pictureBoxMin
            // 
            this.pictureBoxMin.Image = global::Parlons.Properties.Resources.min;
            this.pictureBoxMin.Location = new System.Drawing.Point(440, -1);
            this.pictureBoxMin.Name = "pictureBoxMin";
            this.pictureBoxMin.Size = new System.Drawing.Size(26, 26);
            this.pictureBoxMin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMin.TabIndex = 12;
            this.pictureBoxMin.TabStop = false;
            this.pictureBoxMin.Click += new System.EventHandler(this.pictureBoxMin_Click);
            // 
            // pictureBoxClose
            // 
            this.pictureBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxClose.Image")));
            this.pictureBoxClose.Location = new System.Drawing.Point(468, -1);
            this.pictureBoxClose.Name = "pictureBoxClose";
            this.pictureBoxClose.Size = new System.Drawing.Size(26, 26);
            this.pictureBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxClose.TabIndex = 11;
            this.pictureBoxClose.TabStop = false;
            this.pictureBoxClose.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBoxBackground
            // 
            this.pictureBoxBackground.Image = global::Parlons.Properties.Resources.LogInBackground;
            this.pictureBoxBackground.Location = new System.Drawing.Point(-2, -1);
            this.pictureBoxBackground.Name = "pictureBoxBackground";
            this.pictureBoxBackground.Size = new System.Drawing.Size(506, 203);
            this.pictureBoxBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBackground.TabIndex = 10;
            this.pictureBoxBackground.TabStop = false;
            this.pictureBoxBackground.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormLogIn_MouseDown);
            // 
            // FormLogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 291);
            this.Controls.Add(this.pictureBoxMin);
            this.Controls.Add(this.pictureBoxClose);
            this.Controls.Add(this.buttonLogIn);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelUserID);
            this.Controls.Add(this.textBoxUserID);
            this.Controls.Add(this.pictureBoxBackground);
            this.Font = new System.Drawing.Font("Book Antiqua", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormLogIn";
            this.Text = "Parlons";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormLogIn_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUserID;
        private System.Windows.Forms.Label labelUserID;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonLogIn;
        private System.Windows.Forms.PictureBox pictureBoxBackground;
        private System.Windows.Forms.PictureBox pictureBoxClose;
        private System.Windows.Forms.PictureBox pictureBoxMin;
    }
}

