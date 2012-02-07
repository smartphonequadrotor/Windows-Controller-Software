namespace QoD_DataCentre.Src.UI
{
    partial class ConnectionSettings
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
            this.connectionSettingsTab = new System.Windows.Forms.TabControl();
            this.xmppTabPage = new System.Windows.Forms.TabPage();
            this.xmppUsers = new System.Windows.Forms.ListBox();
            this.xmppConnect = new System.Windows.Forms.Button();
            this.xmppPwdTxt = new System.Windows.Forms.TextBox();
            this.xmppUsernameTxt = new System.Windows.Forms.TextBox();
            this.xmppPwdLabel = new System.Windows.Forms.Label();
            this.xmppUsernameLabel = new System.Windows.Forms.Label();
            this.directSocketTabPage = new System.Windows.Forms.TabPage();
            this.connectBtn = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.connectionProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.connection_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.xmpp_async_connect = new System.ComponentModel.BackgroundWorker();
            this.connectionSettingsTab.SuspendLayout();
            this.xmppTabPage.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // connectionSettingsTab
            // 
            this.connectionSettingsTab.Controls.Add(this.xmppTabPage);
            this.connectionSettingsTab.Controls.Add(this.directSocketTabPage);
            this.connectionSettingsTab.Location = new System.Drawing.Point(16, 12);
            this.connectionSettingsTab.Name = "connectionSettingsTab";
            this.connectionSettingsTab.SelectedIndex = 0;
            this.connectionSettingsTab.Size = new System.Drawing.Size(256, 208);
            this.connectionSettingsTab.TabIndex = 2;
            this.connectionSettingsTab.SelectedIndexChanged += new System.EventHandler(this.connectionSettingsTab_SelectedIndexChanged);
            // 
            // xmppTabPage
            // 
            this.xmppTabPage.Controls.Add(this.xmppUsers);
            this.xmppTabPage.Controls.Add(this.xmppConnect);
            this.xmppTabPage.Controls.Add(this.xmppPwdTxt);
            this.xmppTabPage.Controls.Add(this.xmppUsernameTxt);
            this.xmppTabPage.Controls.Add(this.xmppPwdLabel);
            this.xmppTabPage.Controls.Add(this.xmppUsernameLabel);
            this.xmppTabPage.Location = new System.Drawing.Point(4, 22);
            this.xmppTabPage.Name = "xmppTabPage";
            this.xmppTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.xmppTabPage.Size = new System.Drawing.Size(248, 182);
            this.xmppTabPage.TabIndex = 0;
            this.xmppTabPage.Text = "XMPP";
            this.xmppTabPage.UseVisualStyleBackColor = true;
            // 
            // xmppUsers
            // 
            this.xmppUsers.FormattingEnabled = true;
            this.xmppUsers.Location = new System.Drawing.Point(10, 85);
            this.xmppUsers.Name = "xmppUsers";
            this.xmppUsers.Size = new System.Drawing.Size(232, 82);
            this.xmppUsers.TabIndex = 7;
            this.xmppUsers.SelectedIndexChanged += new System.EventHandler(this.xmppUsers_SelectedIndexChanged);
            // 
            // xmppConnect
            // 
            this.xmppConnect.Location = new System.Drawing.Point(123, 56);
            this.xmppConnect.Name = "xmppConnect";
            this.xmppConnect.Size = new System.Drawing.Size(119, 23);
            this.xmppConnect.TabIndex = 5;
            this.xmppConnect.Text = "Connect To Server";
            this.xmppConnect.UseVisualStyleBackColor = true;
            this.xmppConnect.Click += new System.EventHandler(this.xmppConnect_Click);
            // 
            // xmppPwdTxt
            // 
            this.xmppPwdTxt.Location = new System.Drawing.Point(72, 30);
            this.xmppPwdTxt.Name = "xmppPwdTxt";
            this.xmppPwdTxt.Size = new System.Drawing.Size(170, 20);
            this.xmppPwdTxt.TabIndex = 4;
            this.xmppPwdTxt.Text = "eraserQW12";
            this.xmppPwdTxt.UseSystemPasswordChar = true;
            // 
            // xmppUsernameTxt
            // 
            this.xmppUsernameTxt.Location = new System.Drawing.Point(72, 4);
            this.xmppUsernameTxt.Name = "xmppUsernameTxt";
            this.xmppUsernameTxt.Size = new System.Drawing.Size(170, 20);
            this.xmppUsernameTxt.TabIndex = 3;
            this.xmppUsernameTxt.Text = "ryan-c@tomatohome.net";
            // 
            // xmppPwdLabel
            // 
            this.xmppPwdLabel.AutoSize = true;
            this.xmppPwdLabel.Location = new System.Drawing.Point(7, 33);
            this.xmppPwdLabel.Name = "xmppPwdLabel";
            this.xmppPwdLabel.Size = new System.Drawing.Size(56, 13);
            this.xmppPwdLabel.TabIndex = 1;
            this.xmppPwdLabel.Text = "Password:";
            // 
            // xmppUsernameLabel
            // 
            this.xmppUsernameLabel.AutoSize = true;
            this.xmppUsernameLabel.Location = new System.Drawing.Point(7, 7);
            this.xmppUsernameLabel.Name = "xmppUsernameLabel";
            this.xmppUsernameLabel.Size = new System.Drawing.Size(58, 13);
            this.xmppUsernameLabel.TabIndex = 0;
            this.xmppUsernameLabel.Text = "Username:";
            // 
            // directSocketTabPage
            // 
            this.directSocketTabPage.Location = new System.Drawing.Point(4, 22);
            this.directSocketTabPage.Name = "directSocketTabPage";
            this.directSocketTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.directSocketTabPage.Size = new System.Drawing.Size(248, 182);
            this.directSocketTabPage.TabIndex = 1;
            this.directSocketTabPage.Text = "DirectSocket";
            this.directSocketTabPage.UseVisualStyleBackColor = true;
            // 
            // connectBtn
            // 
            this.connectBtn.Enabled = false;
            this.connectBtn.Location = new System.Drawing.Point(16, 226);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(256, 30);
            this.connectBtn.TabIndex = 3;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStripLabel,
            this.connectionProgressBar,
            this.connection_status});
            this.statusStrip.Location = new System.Drawing.Point(0, 259);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(290, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusStripLabel
            // 
            this.statusStripLabel.Name = "statusStripLabel";
            this.statusStripLabel.Size = new System.Drawing.Size(10, 17);
            this.statusStripLabel.Text = " ";
            // 
            // connectionProgressBar
            // 
            this.connectionProgressBar.MarqueeAnimationSpeed = 0;
            this.connectionProgressBar.Maximum = 1;
            this.connectionProgressBar.Name = "connectionProgressBar";
            this.connectionProgressBar.Size = new System.Drawing.Size(265, 16);
            this.connectionProgressBar.Step = 0;
            this.connectionProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.connectionProgressBar.Visible = false;
            // 
            // connection_status
            // 
            this.connection_status.Name = "connection_status";
            this.connection_status.Size = new System.Drawing.Size(0, 17);
            // 
            // xmpp_async_connect
            // 
            this.xmpp_async_connect.DoWork += new System.ComponentModel.DoWorkEventHandler(this.xmpp_async_connect_DoWork);
            this.xmpp_async_connect.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.xmpp_async_connect_RunWorkerCompleted);
            // 
            // ConnectionSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 281);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.connectionSettingsTab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ConnectionSettings";
            this.Text = "ConnectionSettings";
            this.VisibleChanged += new System.EventHandler(this.ConnectionSettings_VisibleChanged);
            this.connectionSettingsTab.ResumeLayout(false);
            this.xmppTabPage.ResumeLayout(false);
            this.xmppTabPage.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl connectionSettingsTab;
        private System.Windows.Forms.TabPage xmppTabPage;
        private System.Windows.Forms.Label xmppUsernameLabel;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.TextBox xmppPwdTxt;
        private System.Windows.Forms.TextBox xmppUsernameTxt;
        private System.Windows.Forms.Label xmppPwdLabel;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusStripLabel;
        private System.Windows.Forms.TabPage directSocketTabPage;
        private System.Windows.Forms.ListBox xmppUsers;
        private System.Windows.Forms.Button xmppConnect;
        private System.Windows.Forms.ToolStripProgressBar connectionProgressBar;
        private System.ComponentModel.BackgroundWorker xmpp_async_connect;
        private System.Windows.Forms.ToolStripStatusLabel connection_status;
    }
}