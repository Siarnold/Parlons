namespace Parlons
{
    partial class FormParlons
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormParlons));
            this.flowLayoutPanelFriends = new System.Windows.Forms.FlowLayoutPanel();
            this.textBoxQuery = new System.Windows.Forms.TextBox();
            this.buttonQuery = new System.Windows.Forms.Button();
            this.buttonChangeUser = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBoxSession = new System.Windows.Forms.TextBox();
            this.flowLayoutPanelSession = new System.Windows.Forms.FlowLayoutPanel();
            this.checkedListBoxGroup = new System.Windows.Forms.CheckedListBox();
            this.pictureBoxMin = new System.Windows.Forms.PictureBox();
            this.pictureBoxClose = new System.Windows.Forms.PictureBox();
            this.pictureBoxGroupCancel = new System.Windows.Forms.PictureBox();
            this.pictureBoxGroupConfirm = new System.Windows.Forms.PictureBox();
            this.pictureBoxGroup = new System.Windows.Forms.PictureBox();
            this.pictureBoxSendEmoji = new System.Windows.Forms.PictureBox();
            this.pictureBoxSendFile = new System.Windows.Forms.PictureBox();
            this.textBoxGroupName = new System.Windows.Forms.TextBox();
            this.panelEmoji = new System.Windows.Forms.Panel();
            this.flowLayoutPanelSession.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGroupCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGroupConfirm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSendEmoji)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSendFile)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanelFriends
            // 
            this.flowLayoutPanelFriends.AutoScroll = true;
            this.flowLayoutPanelFriends.BackColor = System.Drawing.SystemColors.ControlLight;
            this.flowLayoutPanelFriends.Location = new System.Drawing.Point(27, 59);
            this.flowLayoutPanelFriends.Name = "flowLayoutPanelFriends";
            this.flowLayoutPanelFriends.Size = new System.Drawing.Size(251, 639);
            this.flowLayoutPanelFriends.TabIndex = 0;
            this.flowLayoutPanelFriends.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanelFriends_Paint);
            this.flowLayoutPanelFriends.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormParlons_MouseDown);
            // 
            // textBoxQuery
            // 
            this.textBoxQuery.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxQuery.Location = new System.Drawing.Point(27, 20);
            this.textBoxQuery.Name = "textBoxQuery";
            this.textBoxQuery.Size = new System.Drawing.Size(163, 25);
            this.textBoxQuery.TabIndex = 1;
            this.textBoxQuery.Text = "请输入查找账号";
            // 
            // buttonQuery
            // 
            this.buttonQuery.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonQuery.Location = new System.Drawing.Point(196, 16);
            this.buttonQuery.Name = "buttonQuery";
            this.buttonQuery.Size = new System.Drawing.Size(82, 37);
            this.buttonQuery.TabIndex = 2;
            this.buttonQuery.Text = "查找";
            this.buttonQuery.UseVisualStyleBackColor = true;
            this.buttonQuery.Click += new System.EventHandler(this.buttonQuery_Click);
            // 
            // buttonChangeUser
            // 
            this.buttonChangeUser.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChangeUser.Location = new System.Drawing.Point(937, 511);
            this.buttonChangeUser.Name = "buttonChangeUser";
            this.buttonChangeUser.Size = new System.Drawing.Size(86, 37);
            this.buttonChangeUser.TabIndex = 8;
            this.buttonChangeUser.Text = "切换账号";
            this.buttonChangeUser.UseVisualStyleBackColor = true;
            this.buttonChangeUser.Click += new System.EventHandler(this.buttonChangeUser_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSend.Location = new System.Drawing.Point(951, 662);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(72, 36);
            this.buttonSend.TabIndex = 6;
            this.buttonSend.Text = "发送";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // textBoxSession
            // 
            this.textBoxSession.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSession.Location = new System.Drawing.Point(297, 554);
            this.textBoxSession.Multiline = true;
            this.textBoxSession.Name = "textBoxSession";
            this.textBoxSession.Size = new System.Drawing.Size(726, 144);
            this.textBoxSession.TabIndex = 5;
            // 
            // flowLayoutPanelSession
            // 
            this.flowLayoutPanelSession.Controls.Add(this.checkedListBoxGroup);
            this.flowLayoutPanelSession.Location = new System.Drawing.Point(294, 40);
            this.flowLayoutPanelSession.Name = "flowLayoutPanelSession";
            this.flowLayoutPanelSession.Size = new System.Drawing.Size(729, 465);
            this.flowLayoutPanelSession.TabIndex = 7;
            // 
            // checkedListBoxGroup
            // 
            this.checkedListBoxGroup.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBoxGroup.FormattingEnabled = true;
            this.checkedListBoxGroup.Location = new System.Drawing.Point(3, 3);
            this.checkedListBoxGroup.Name = "checkedListBoxGroup";
            this.checkedListBoxGroup.Size = new System.Drawing.Size(288, 444);
            this.checkedListBoxGroup.TabIndex = 0;
            // 
            // pictureBoxMin
            // 
            this.pictureBoxMin.Image = global::Parlons.Properties.Resources.min;
            this.pictureBoxMin.Location = new System.Drawing.Point(992, 2);
            this.pictureBoxMin.Name = "pictureBoxMin";
            this.pictureBoxMin.Size = new System.Drawing.Size(26, 26);
            this.pictureBoxMin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMin.TabIndex = 16;
            this.pictureBoxMin.TabStop = false;
            // 
            // pictureBoxClose
            // 
            this.pictureBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxClose.Image")));
            this.pictureBoxClose.Location = new System.Drawing.Point(1024, 2);
            this.pictureBoxClose.Name = "pictureBoxClose";
            this.pictureBoxClose.Size = new System.Drawing.Size(26, 26);
            this.pictureBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxClose.TabIndex = 15;
            this.pictureBoxClose.TabStop = false;
            this.pictureBoxClose.Click += new System.EventHandler(this.pictureBoxClose_Click);
            // 
            // pictureBoxGroupCancel
            // 
            this.pictureBoxGroupCancel.Image = global::Parlons.Properties.Resources.cancel;
            this.pictureBoxGroupCancel.Location = new System.Drawing.Point(553, 516);
            this.pictureBoxGroupCancel.Name = "pictureBoxGroupCancel";
            this.pictureBoxGroupCancel.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxGroupCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxGroupCancel.TabIndex = 14;
            this.pictureBoxGroupCancel.TabStop = false;
            this.pictureBoxGroupCancel.Click += new System.EventHandler(this.pictureBoxGroupCancel_Click);
            // 
            // pictureBoxGroupConfirm
            // 
            this.pictureBoxGroupConfirm.Image = global::Parlons.Properties.Resources.confirm;
            this.pictureBoxGroupConfirm.Location = new System.Drawing.Point(515, 516);
            this.pictureBoxGroupConfirm.Name = "pictureBoxGroupConfirm";
            this.pictureBoxGroupConfirm.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxGroupConfirm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxGroupConfirm.TabIndex = 13;
            this.pictureBoxGroupConfirm.TabStop = false;
            this.pictureBoxGroupConfirm.Click += new System.EventHandler(this.pictureBoxGroupConfirm_Click);
            // 
            // pictureBoxGroup
            // 
            this.pictureBoxGroup.Image = global::Parlons.Properties.Resources.new_group;
            this.pictureBoxGroup.Location = new System.Drawing.Point(377, 514);
            this.pictureBoxGroup.Name = "pictureBoxGroup";
            this.pictureBoxGroup.Size = new System.Drawing.Size(34, 34);
            this.pictureBoxGroup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxGroup.TabIndex = 12;
            this.pictureBoxGroup.TabStop = false;
            this.pictureBoxGroup.Click += new System.EventHandler(this.pictureBoxGroup_Click);
            // 
            // pictureBoxSendEmoji
            // 
            this.pictureBoxSendEmoji.Image = global::Parlons.Properties.Resources.emoticon_smile;
            this.pictureBoxSendEmoji.Location = new System.Drawing.Point(337, 514);
            this.pictureBoxSendEmoji.Name = "pictureBoxSendEmoji";
            this.pictureBoxSendEmoji.Size = new System.Drawing.Size(34, 34);
            this.pictureBoxSendEmoji.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSendEmoji.TabIndex = 11;
            this.pictureBoxSendEmoji.TabStop = false;
            this.pictureBoxSendEmoji.Click += new System.EventHandler(this.pictureBoxSendEmoji_Click);
            // 
            // pictureBoxSendFile
            // 
            this.pictureBoxSendFile.Image = global::Parlons.Properties.Resources.Folder;
            this.pictureBoxSendFile.Location = new System.Drawing.Point(297, 514);
            this.pictureBoxSendFile.Name = "pictureBoxSendFile";
            this.pictureBoxSendFile.Size = new System.Drawing.Size(34, 34);
            this.pictureBoxSendFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSendFile.TabIndex = 10;
            this.pictureBoxSendFile.TabStop = false;
            this.pictureBoxSendFile.Click += new System.EventHandler(this.pictureBoxSendFile_Click);
            // 
            // textBoxGroupName
            // 
            this.textBoxGroupName.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGroupName.Location = new System.Drawing.Point(417, 516);
            this.textBoxGroupName.Name = "textBoxGroupName";
            this.textBoxGroupName.Size = new System.Drawing.Size(92, 25);
            this.textBoxGroupName.TabIndex = 1;
            this.textBoxGroupName.Text = "请输入群名";
            // 
            // panelEmoji
            // 
            this.panelEmoji.AutoScroll = true;
            this.panelEmoji.Location = new System.Drawing.Point(337, 554);
            this.panelEmoji.Name = "panelEmoji";
            this.panelEmoji.Size = new System.Drawing.Size(476, 135);
            this.panelEmoji.TabIndex = 1;
            // 
            // FormParlons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 715);
            this.Controls.Add(this.pictureBoxMin);
            this.Controls.Add(this.panelEmoji);
            this.Controls.Add(this.textBoxGroupName);
            this.Controls.Add(this.pictureBoxClose);
            this.Controls.Add(this.buttonChangeUser);
            this.Controls.Add(this.pictureBoxGroupCancel);
            this.Controls.Add(this.flowLayoutPanelSession);
            this.Controls.Add(this.pictureBoxGroupConfirm);
            this.Controls.Add(this.pictureBoxGroup);
            this.Controls.Add(this.pictureBoxSendEmoji);
            this.Controls.Add(this.buttonQuery);
            this.Controls.Add(this.pictureBoxSendFile);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.textBoxQuery);
            this.Controls.Add(this.flowLayoutPanelFriends);
            this.Controls.Add(this.textBoxSession);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormParlons";
            this.Text = "Parlons";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormParlons_MouseDown);
            this.flowLayoutPanelSession.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGroupCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGroupConfirm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSendEmoji)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSendFile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFriends;
        private System.Windows.Forms.TextBox textBoxQuery;
        private System.Windows.Forms.Button buttonQuery;
        private System.Windows.Forms.TextBox textBoxSession;
        public System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSession;
        private System.Windows.Forms.Button buttonChangeUser;
        private System.Windows.Forms.CheckedListBox checkedListBoxGroup;
        private System.Windows.Forms.PictureBox pictureBoxSendFile;
        private System.Windows.Forms.PictureBox pictureBoxSendEmoji;
        private System.Windows.Forms.PictureBox pictureBoxGroup;
        private System.Windows.Forms.PictureBox pictureBoxGroupCancel;
        private System.Windows.Forms.PictureBox pictureBoxGroupConfirm;
        private System.Windows.Forms.PictureBox pictureBoxClose;
        private System.Windows.Forms.PictureBox pictureBoxMin;
        private System.Windows.Forms.TextBox textBoxGroupName;
        private System.Windows.Forms.Panel panelEmoji;
    }
}