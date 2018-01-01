namespace Parlons
{
    partial class UserControlReceiveSession
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelUserID = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelSession
            // 
            this.labelSession.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelSession.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSession.Location = new System.Drawing.Point(78, 21);
            this.labelSession.Name = "labelSession";
            this.labelSession.Size = new System.Drawing.Size(611, 45);
            this.labelSession.TabIndex = 0;
            this.labelSession.Text = "session";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Parlons.Properties.Resources.profile_icon;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(65, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // labelUserID
            // 
            this.labelUserID.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserID.Location = new System.Drawing.Point(78, 3);
            this.labelUserID.Name = "labelUserID";
            this.labelUserID.Size = new System.Drawing.Size(114, 18);
            this.labelUserID.TabIndex = 2;
            this.labelUserID.Text = "userID";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.Location = new System.Drawing.Point(198, 3);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(38, 18);
            this.labelTime.TabIndex = 3;
            this.labelTime.Text = "time";
            // 
            // UserControlReceiveSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelUserID);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelSession);
            this.Name = "UserControlReceiveSession";
            this.Size = new System.Drawing.Size(700, 70);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSession;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelUserID;
        private System.Windows.Forms.Label labelTime;
    }
}
