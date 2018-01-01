namespace Parlons
{
    partial class UserControlFriend
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.labelUserID = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.pictureBoxAvatar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // labelUserID
            // 
            this.labelUserID.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserID.Location = new System.Drawing.Point(52, 4);
            this.labelUserID.Name = "labelUserID";
            this.labelUserID.Size = new System.Drawing.Size(119, 26);
            this.labelUserID.TabIndex = 0;
            this.labelUserID.Text = "userID";
            this.labelUserID.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UserControlFriend_MouseClick);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("方正清刻本悦宋简体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelStatus.Location = new System.Drawing.Point(52, 30);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(38, 16);
            this.labelStatus.TabIndex = 2;
            this.labelStatus.Text = "在线";
            this.labelStatus.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UserControlFriend_MouseClick);
            // 
            // pictureBoxAvatar
            // 
            this.pictureBoxAvatar.Image = global::Parlons.Properties.Resources.profile_icon;
            this.pictureBoxAvatar.Location = new System.Drawing.Point(4, 4);
            this.pictureBoxAvatar.Name = "pictureBoxAvatar";
            this.pictureBoxAvatar.Size = new System.Drawing.Size(42, 42);
            this.pictureBoxAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxAvatar.TabIndex = 3;
            this.pictureBoxAvatar.TabStop = false;
            this.pictureBoxAvatar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UserControlFriend_MouseClick);
            // 
            // UserControlFriend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.pictureBoxAvatar);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelUserID);
            this.Font = new System.Drawing.Font("方正清刻本悦宋简体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UserControlFriend";
            this.Size = new System.Drawing.Size(181, 51);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UserControlFriend_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUserID;
        public System.Windows.Forms.Label labelStatus;
        public System.Windows.Forms.PictureBox pictureBoxAvatar;

    }
}
