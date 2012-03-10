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
            this.serverStartedLbl = new System.Windows.Forms.Label();
            this.startDirectSocketServerBtn = new System.Windows.Forms.Button();
            this.directSocketWarning = new System.Windows.Forms.TextBox();
            this.directSocketInternalIp = new System.Windows.Forms.Label();
            this.directSocketExternalPortLbl = new System.Windows.Forms.Label();
            this.directSocketInternalIpLbl = new System.Windows.Forms.Label();
            this.directSocketPortTxt = new System.Windows.Forms.TextBox();
            this.directSocketExternalIp = new System.Windows.Forms.Label();
            this.directSocketInternalPortLbl = new System.Windows.Forms.Label();
            this.directSocketExternalIpLbl = new System.Windows.Forms.Label();
            this.connectBtn = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.connectionProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.connection_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.xmpp_async_connect = new System.ComponentModel.BackgroundWorker();
            this.directSocket_async_connect = new System.ComponentModel.BackgroundWorker();
            this.connectionSettingsTab.SuspendLayout();
            this.xmppTabPage.SuspendLayout();
            this.directSocketTabPage.SuspendLayout();
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
            this.xmppConnect.Location = new System.Drawing.Point(9, 56);
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
            this.directSocketTabPage.Controls.Add(this.serverStartedLbl);
            this.directSocketTabPage.Controls.Add(this.startDirectSocketServerBtn);
            this.directSocketTabPage.Controls.Add(this.directSocketWarning);
            this.directSocketTabPage.Controls.Add(this.directSocketInternalIp);
            this.directSocketTabPage.Controls.Add(this.directSocketExternalPortLbl);
            this.directSocketTabPage.Controls.Add(this.directSocketInternalIpLbl);
            this.directSocketTabPage.Controls.Add(this.directSocketPortTxt);
            this.directSocketTabPage.Controls.Add(this.directSocketExternalIp);
            this.directSocketTabPage.Controls.Add(this.directSocketInternalPortLbl);
            this.directSocketTabPage.Controls.Add(this.directSocketExternalIpLbl);
            this.directSocketTabPage.Location = new System.Drawing.Point(4, 22);
            this.directSocketTabPage.Name = "directSocketTabPage";
            this.directSocketTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.directSocketTabPage.Size = new System.Drawing.Size(248, 182);
            this.directSocketTabPage.TabIndex = 1;
            this.directSocketTabPage.Text = "DirectSocket";
            this.directSocketTabPage.UseVisualStyleBackColor = true;
            // 
            // serverStartedLbl
            // 
            this.serverStartedLbl.AutoSize = true;
            this.serverStartedLbl.Location = new System.Drawing.Point(102, 147);
            this.serverStartedLbl.Name = "serverStartedLbl";
            this.serverStartedLbl.Size = new System.Drawing.Size(75, 13);
            this.serverStartedLbl.TabIndex = 9;
            this.serverStartedLbl.Text = "Server Started";
            this.serverStartedLbl.Visible = false;
            // 
            // startDirectSocketServerBtn
            // 
            this.startDirectSocketServerBtn.Location = new System.Drawing.Point(6, 142);
            this.startDirectSocketServerBtn.Name = "startDirectSocketServerBtn";
            this.startDirectSocketServerBtn.Size = new System.Drawing.Size(89, 23);
            this.startDirectSocketServerBtn.TabIndex = 8;
            this.startDirectSocketServerBtn.Text = "Start Server";
            this.startDirectSocketServerBtn.UseVisualStyleBackColor = true;
            this.startDirectSocketServerBtn.Click += new System.EventHandler(this.startDirectSocketServerBtn_Click);
            // 
            // directSocketWarning
            // 
            this.directSocketWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.directSocketWarning.ForeColor = System.Drawing.Color.Black;
            this.directSocketWarning.Location = new System.Drawing.Point(9, 7);
            this.directSocketWarning.Multiline = true;
            this.directSocketWarning.Name = "directSocketWarning";
            this.directSocketWarning.ReadOnly = true;
            this.directSocketWarning.Size = new System.Drawing.Size(233, 36);
            this.directSocketWarning.TabIndex = 7;
            this.directSocketWarning.Text = "Warning: Unless you know what you are doing, please stick with XMPP.";
            // 
            // directSocketInternalIp
            // 
            this.directSocketInternalIp.AutoSize = true;
            this.directSocketInternalIp.Location = new System.Drawing.Point(67, 93);
            this.directSocketInternalIp.Name = "directSocketInternalIp";
            this.directSocketInternalIp.Size = new System.Drawing.Size(13, 13);
            this.directSocketInternalIp.TabIndex = 6;
            this.directSocketInternalIp.Text = "0";
            // 
            // directSocketExternalPortLbl
            // 
            this.directSocketExternalPortLbl.AutoSize = true;
            this.directSocketExternalPortLbl.Location = new System.Drawing.Point(39, 65);
            this.directSocketExternalPortLbl.Name = "directSocketExternalPortLbl";
            this.directSocketExternalPortLbl.Size = new System.Drawing.Size(140, 13);
            this.directSocketExternalPortLbl.TabIndex = 5;
            this.directSocketExternalPortLbl.Text = "Port: Defined on your router.";
            // 
            // directSocketInternalIpLbl
            // 
            this.directSocketInternalIpLbl.AutoSize = true;
            this.directSocketInternalIpLbl.Location = new System.Drawing.Point(10, 93);
            this.directSocketInternalIpLbl.Name = "directSocketInternalIpLbl";
            this.directSocketInternalIpLbl.Size = new System.Drawing.Size(61, 13);
            this.directSocketInternalIpLbl.TabIndex = 4;
            this.directSocketInternalIpLbl.Text = "Internal IP: ";
            // 
            // directSocketPortTxt
            // 
            this.directSocketPortTxt.Location = new System.Drawing.Point(67, 109);
            this.directSocketPortTxt.Name = "directSocketPortTxt";
            this.directSocketPortTxt.Size = new System.Drawing.Size(100, 20);
            this.directSocketPortTxt.TabIndex = 3;
            this.directSocketPortTxt.Text = "5225";
            // 
            // directSocketExternalIp
            // 
            this.directSocketExternalIp.AutoSize = true;
            this.directSocketExternalIp.Location = new System.Drawing.Point(65, 48);
            this.directSocketExternalIp.Name = "directSocketExternalIp";
            this.directSocketExternalIp.Size = new System.Drawing.Size(13, 13);
            this.directSocketExternalIp.TabIndex = 2;
            this.directSocketExternalIp.Text = "0";
            // 
            // directSocketInternalPortLbl
            // 
            this.directSocketInternalPortLbl.AutoSize = true;
            this.directSocketInternalPortLbl.Location = new System.Drawing.Point(39, 112);
            this.directSocketInternalPortLbl.Name = "directSocketInternalPortLbl";
            this.directSocketInternalPortLbl.Size = new System.Drawing.Size(29, 13);
            this.directSocketInternalPortLbl.TabIndex = 1;
            this.directSocketInternalPortLbl.Text = "Port:";
            // 
            // directSocketExternalIpLbl
            // 
            this.directSocketExternalIpLbl.AutoSize = true;
            this.directSocketExternalIpLbl.Location = new System.Drawing.Point(6, 48);
            this.directSocketExternalIpLbl.Name = "directSocketExternalIpLbl";
            this.directSocketExternalIpLbl.Size = new System.Drawing.Size(64, 13);
            this.directSocketExternalIpLbl.TabIndex = 0;
            this.directSocketExternalIpLbl.Text = "External IP: ";
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
            // directSocket_async_connect
            // 
            this.directSocket_async_connect.DoWork += new System.ComponentModel.DoWorkEventHandler(this.directSocket_async_connect_DoWork);
            this.directSocket_async_connect.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.directSocket_async_connect_RunWorkerCompleted);
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
            this.directSocketTabPage.ResumeLayout(false);
            this.directSocketTabPage.PerformLayout();
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
        private System.Windows.Forms.TextBox directSocketPortTxt;
        private System.Windows.Forms.Label directSocketExternalIp;
        private System.Windows.Forms.Label directSocketInternalPortLbl;
        private System.Windows.Forms.Label directSocketExternalIpLbl;
        private System.Windows.Forms.Label directSocketInternalIpLbl;
        private System.Windows.Forms.Label directSocketExternalPortLbl;
        private System.Windows.Forms.Label directSocketInternalIp;
        private System.Windows.Forms.TextBox directSocketWarning;
        private System.Windows.Forms.Button startDirectSocketServerBtn;
        private System.Windows.Forms.Label serverStartedLbl;
        private System.ComponentModel.BackgroundWorker directSocket_async_connect;
    }
}