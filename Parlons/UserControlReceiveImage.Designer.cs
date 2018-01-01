namespace Parlons
{
    partial class UserControlReceiveImage
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
            this.pictureBoxAvatar = new System.Windows.Forms.PictureBox();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.labelSession = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxAvatar
            // 
            this.pictureBoxAvatar.Image = global::Parlons.Properties.Resources.profile_icon;
            this.pictureBoxAvatar.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxAvatar.Name = "pictureBoxAvatar";
            this.pictureBoxAvatar.Size = new System.Drawing.Size(65, 65);
            this.pictureBoxAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxAvatar.TabIndex = 0;
            this.pictureBoxAvatar.TabStop = false;
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Location = new System.Drawing.Point(82, 3);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(100, 70);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxImage.TabIndex = 1;
            this.pictureBoxImage.TabStop = false;
            // 
            // labelSession
            // 
            this.labelSession.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelSession.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSession.Location = new System.Drawing.Point(196, 28);
            this.labelSession.Name = "labelSession";
            this.labelSession.Size = new System.Drawing.Size(487, 45);
            this.labelSession.TabIndex = 2;
            this.labelSession.Text = "session";
            // 
            // UserControlReceiveImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelSession);
            this.Controls.Add(this.pictureBoxImage);
            this.Controls.Add(this.pictureBoxAvatar);
            this.Name = "UserControlReceiveImage";
            this.Size = new System.Drawing.Size(700, 80);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxAvatar;
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.Label labelSession;
    }
}
