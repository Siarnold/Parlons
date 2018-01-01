namespace Parlons
{
    partial class UserControlSendSession
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
            this.labelSession = new System.Windows.Forms.Label();
            this.labelUserID = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.pictureBoxAvatar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // labelSession
            // 
            this.labelSession.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelSession.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSession.Location = new System.Drawing.Point(16, 22);
            this.labelSession.Name = "labelSession";
            this.labelSession.Size = new System.Drawing.Size(605, 45);
            this.labelSession.TabIndex = 1;
            this.labelSession.Text = "session";
            // 
            // labelUserID
            // 
            this.labelUserID.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserID.Location = new System.Drawing.Point(16, 4);
            this.labelUserID.Name = "labelUserID";
            this.labelUserID.Size = new System.Drawing.Size(118, 18);
            this.labelUserID.TabIndex = 2;
            this.labelUserID.Text = "userID";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.Location = new System.Drawing.Point(140, 4);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(38, 18);
            this.labelTime.TabIndex = 3;
            this.labelTime.Text = "time";
            // 
            // pictureBoxAvatar
            // 
            this.pictureBoxAvatar.Image = global::Parlons.Properties.Resources.LOGO;
            this.pictureBoxAvatar.Location = new System.Drawing.Point(627, 2);
            this.pictureBoxAvatar.Name = "pictureBoxAvatar";
            this.pictureBoxAvatar.Size = new System.Drawing.Size(65, 65);
            this.pictureBoxAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxAvatar.TabIndex = 0;
            this.pictureBoxAvatar.TabStop = false;
            // 
            // UserControlSendSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelUserID);
            this.Controls.Add(this.labelSession);
            this.Controls.Add(this.pictureBoxAvatar);
            this.Name = "UserControlSendSession";
            this.Size = new System.Drawing.Size(700, 70);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxAvatar;
        private System.Windows.Forms.Label labelSession;
        private System.Windows.Forms.Label labelUserID;
        private System.Windows.Forms.Label labelTime;
    }
}
