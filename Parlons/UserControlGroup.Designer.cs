namespace Parlons
{
    partial class UserControlGroup
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
            this.labelGroupName = new System.Windows.Forms.Label();
            this.pictureBoxAvatar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // labelGroupName
            // 
            this.labelGroupName.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGroupName.Location = new System.Drawing.Point(53, 4);
            this.labelGroupName.Name = "labelGroupName";
            this.labelGroupName.Size = new System.Drawing.Size(115, 42);
            this.labelGroupName.TabIndex = 0;
            this.labelGroupName.Text = "群聊名";
            this.labelGroupName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UserControlGroup_MouseClick);
            // 
            // pictureBoxAvatar
            // 
            this.pictureBoxAvatar.Image = global::Parlons.Properties.Resources.profile_group_icon;
            this.pictureBoxAvatar.Location = new System.Drawing.Point(4, 4);
            this.pictureBoxAvatar.Name = "pictureBoxAvatar";
            this.pictureBoxAvatar.Size = new System.Drawing.Size(42, 42);
            this.pictureBoxAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxAvatar.TabIndex = 1;
            this.pictureBoxAvatar.TabStop = false;
            // 
            // UserControlGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.pictureBoxAvatar);
            this.Controls.Add(this.labelGroupName);
            this.Font = new System.Drawing.Font("方正清刻本悦宋简体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UserControlGroup";
            this.Size = new System.Drawing.Size(181, 51);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UserControlGroup_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelGroupName;
        private System.Windows.Forms.PictureBox pictureBoxAvatar;
    }
}
