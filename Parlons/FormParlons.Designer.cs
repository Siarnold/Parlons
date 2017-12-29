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
            this.flowLayoutPanelFriends = new System.Windows.Forms.FlowLayoutPanel();
            this.textBoxQuery = new System.Windows.Forms.TextBox();
            this.buttonQuery = new System.Windows.Forms.Button();
            this.labelDebug = new System.Windows.Forms.Label();
            this.groupBoxFunctions = new System.Windows.Forms.GroupBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBoxSession = new System.Windows.Forms.TextBox();
            this.flowLayoutPanelSession = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonSendFile = new System.Windows.Forms.Button();
            this.groupBoxFunctions.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelFriends
            // 
            this.flowLayoutPanelFriends.AutoScroll = true;
            this.flowLayoutPanelFriends.Location = new System.Drawing.Point(27, 59);
            this.flowLayoutPanelFriends.Name = "flowLayoutPanelFriends";
            this.flowLayoutPanelFriends.Size = new System.Drawing.Size(213, 390);
            this.flowLayoutPanelFriends.TabIndex = 0;
            // 
            // textBoxQuery
            // 
            this.textBoxQuery.Location = new System.Drawing.Point(27, 20);
            this.textBoxQuery.Name = "textBoxQuery";
            this.textBoxQuery.Size = new System.Drawing.Size(124, 25);
            this.textBoxQuery.TabIndex = 1;
            this.textBoxQuery.Text = "请输入查找账号";
            // 
            // buttonQuery
            // 
            this.buttonQuery.Location = new System.Drawing.Point(158, 20);
            this.buttonQuery.Name = "buttonQuery";
            this.buttonQuery.Size = new System.Drawing.Size(82, 29);
            this.buttonQuery.TabIndex = 2;
            this.buttonQuery.Text = "查找";
            this.buttonQuery.UseVisualStyleBackColor = true;
            this.buttonQuery.Click += new System.EventHandler(this.buttonQuery_Click);
            // 
            // labelDebug
            // 
            this.labelDebug.AutoSize = true;
            this.labelDebug.Location = new System.Drawing.Point(27, 456);
            this.labelDebug.Name = "labelDebug";
            this.labelDebug.Size = new System.Drawing.Size(55, 15);
            this.labelDebug.TabIndex = 3;
            this.labelDebug.Text = "label1";
            // 
            // groupBoxFunctions
            // 
            this.groupBoxFunctions.Controls.Add(this.buttonSendFile);
            this.groupBoxFunctions.Controls.Add(this.buttonSend);
            this.groupBoxFunctions.Location = new System.Drawing.Point(274, 289);
            this.groupBoxFunctions.Name = "groupBoxFunctions";
            this.groupBoxFunctions.Size = new System.Drawing.Size(546, 40);
            this.groupBoxFunctions.TabIndex = 4;
            this.groupBoxFunctions.TabStop = false;
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(474, 9);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(72, 31);
            this.buttonSend.TabIndex = 6;
            this.buttonSend.Text = "发送";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // textBoxSession
            // 
            this.textBoxSession.Location = new System.Drawing.Point(274, 346);
            this.textBoxSession.Multiline = true;
            this.textBoxSession.Name = "textBoxSession";
            this.textBoxSession.Size = new System.Drawing.Size(546, 103);
            this.textBoxSession.TabIndex = 5;
            // 
            // flowLayoutPanelSession
            // 
            this.flowLayoutPanelSession.Location = new System.Drawing.Point(274, 20);
            this.flowLayoutPanelSession.Name = "flowLayoutPanelSession";
            this.flowLayoutPanelSession.Size = new System.Drawing.Size(546, 263);
            this.flowLayoutPanelSession.TabIndex = 7;
            // 
            // buttonSendFile
            // 
            this.buttonSendFile.Location = new System.Drawing.Point(0, 9);
            this.buttonSendFile.Name = "buttonSendFile";
            this.buttonSendFile.Size = new System.Drawing.Size(86, 29);
            this.buttonSendFile.TabIndex = 7;
            this.buttonSendFile.Text = "发送文件";
            this.buttonSendFile.UseVisualStyleBackColor = true;
            this.buttonSendFile.Click += new System.EventHandler(this.buttonSendFile_Click);
            // 
            // FormParlons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 481);
            this.Controls.Add(this.flowLayoutPanelSession);
            this.Controls.Add(this.textBoxSession);
            this.Controls.Add(this.groupBoxFunctions);
            this.Controls.Add(this.labelDebug);
            this.Controls.Add(this.buttonQuery);
            this.Controls.Add(this.textBoxQuery);
            this.Controls.Add(this.flowLayoutPanelFriends);
            this.Name = "FormParlons";
            this.Text = "Parlons";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormParlons_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormParlons_FormClosed);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormParlons_MouseMove);
            this.groupBoxFunctions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFriends;
        private System.Windows.Forms.TextBox textBoxQuery;
        private System.Windows.Forms.Button buttonQuery;
        public System.Windows.Forms.Label labelDebug;
        private System.Windows.Forms.GroupBox groupBoxFunctions;
        private System.Windows.Forms.TextBox textBoxSession;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSession;
        private System.Windows.Forms.Button buttonSendFile;
    }
}