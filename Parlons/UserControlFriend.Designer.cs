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
            this.SuspendLayout();
            // 
            // labelUserID
            // 
            this.labelUserID.Location = new System.Drawing.Point(86, 23);
            this.labelUserID.Name = "labelUserID";
            this.labelUserID.Size = new System.Drawing.Size(120, 30);
            this.labelUserID.TabIndex = 0;
            this.labelUserID.Text = "userID";
            this.labelUserID.MouseClick += new System.Windows.Forms.MouseEventHandler(this.labelUserID_MouseClick);
            // 
            // UserControlFriend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelUserID);
            this.Name = "UserControlFriend";
            this.Size = new System.Drawing.Size(243, 80);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UserControlFriend_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelUserID;

    }
}
