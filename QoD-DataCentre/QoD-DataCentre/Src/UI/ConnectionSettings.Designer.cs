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
            this.ConnectionTypeLabel = new System.Windows.Forms.Label();
            this.ConnectionTypeCombo = new System.Windows.Forms.ComboBox();
            this.connectionSettingsTab = new System.Windows.Forms.TabControl();
            this.xmppTabPage = new System.Windows.Forms.TabPage();
            this.directSocketTabPage = new System.Windows.Forms.TabPage();
            this.connectBtn = new System.Windows.Forms.Button();
            this.xmppUsernameLabel = new System.Windows.Forms.Label();
            this.xmppPwdLabel = new System.Windows.Forms.Label();
            this.xmppDomainLabel = new System.Windows.Forms.Label();
            this.xmppUsernameTxt = new System.Windows.Forms.TextBox();
            this.xmppPwdTxt = new System.Windows.Forms.TextBox();
            this.xmppDomainTxt = new System.Windows.Forms.TextBox();
            this.xmppHostTxt = new System.Windows.Forms.TextBox();
            this.xmppHostLabel = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.connectionSettingsTab.SuspendLayout();
            this.xmppTabPage.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConnectionTypeLabel
            // 
            this.ConnectionTypeLabel.AutoSize = true;
            this.ConnectionTypeLabel.Location = new System.Drawing.Point(13, 13);
            this.ConnectionTypeLabel.Name = "ConnectionTypeLabel";
            this.ConnectionTypeLabel.Size = new System.Drawing.Size(91, 13);
            this.ConnectionTypeLabel.TabIndex = 0;
            this.ConnectionTypeLabel.Text = "Connection Type:";
            // 
            // ConnectionTypeCombo
            // 
            this.ConnectionTypeCombo.FormattingEnabled = true;
            this.ConnectionTypeCombo.Items.AddRange(new object[] {
            "XMPP",
            "Direct Socket"});
            this.ConnectionTypeCombo.Location = new System.Drawing.Point(111, 13);
            this.ConnectionTypeCombo.Name = "ConnectionTypeCombo";
            this.ConnectionTypeCombo.Size = new System.Drawing.Size(161, 21);
            this.ConnectionTypeCombo.TabIndex = 1;
            // 
            // connectionSettingsTab
            // 
            this.connectionSettingsTab.Controls.Add(this.xmppTabPage);
            this.connectionSettingsTab.Controls.Add(this.directSocketTabPage);
            this.connectionSettingsTab.Location = new System.Drawing.Point(16, 40);
            this.connectionSettingsTab.Name = "connectionSettingsTab";
            this.connectionSettingsTab.SelectedIndex = 0;
            this.connectionSettingsTab.Size = new System.Drawing.Size(256, 161);
            this.connectionSettingsTab.TabIndex = 2;
            // 
            // xmppTabPage
            // 
            this.xmppTabPage.Controls.Add(this.xmppHostLabel);
            this.xmppTabPage.Controls.Add(this.xmppHostTxt);
            this.xmppTabPage.Controls.Add(this.xmppDomainTxt);
            this.xmppTabPage.Controls.Add(this.xmppPwdTxt);
            this.xmppTabPage.Controls.Add(this.xmppUsernameTxt);
            this.xmppTabPage.Controls.Add(this.xmppDomainLabel);
            this.xmppTabPage.Controls.Add(this.xmppPwdLabel);
            this.xmppTabPage.Controls.Add(this.xmppUsernameLabel);
            this.xmppTabPage.Location = new System.Drawing.Point(4, 22);
            this.xmppTabPage.Name = "xmppTabPage";
            this.xmppTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.xmppTabPage.Size = new System.Drawing.Size(248, 135);
            this.xmppTabPage.TabIndex = 0;
            this.xmppTabPage.Text = "XMPP";
            this.xmppTabPage.UseVisualStyleBackColor = true;
            // 
            // directSocketTabPage
            // 
            this.directSocketTabPage.Location = new System.Drawing.Point(4, 22);
            this.directSocketTabPage.Name = "directSocketTabPage";
            this.directSocketTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.directSocketTabPage.Size = new System.Drawing.Size(248, 135);
            this.directSocketTabPage.TabIndex = 1;
            this.directSocketTabPage.Text = "DirectSocket";
            this.directSocketTabPage.UseVisualStyleBackColor = true;
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(16, 207);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(256, 30);
            this.connectBtn.TabIndex = 3;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
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
            // xmppPwdLabel
            // 
            this.xmppPwdLabel.AutoSize = true;
            this.xmppPwdLabel.Location = new System.Drawing.Point(7, 33);
            this.xmppPwdLabel.Name = "xmppPwdLabel";
            this.xmppPwdLabel.Size = new System.Drawing.Size(56, 13);
            this.xmppPwdLabel.TabIndex = 1;
            this.xmppPwdLabel.Text = "Password:";
            // 
            // xmppDomainLabel
            // 
            this.xmppDomainLabel.AutoSize = true;
            this.xmppDomainLabel.Location = new System.Drawing.Point(7, 60);
            this.xmppDomainLabel.Name = "xmppDomainLabel";
            this.xmppDomainLabel.Size = new System.Drawing.Size(46, 13);
            this.xmppDomainLabel.TabIndex = 2;
            this.xmppDomainLabel.Text = "Domain:";
            // 
            // xmppUsernameTxt
            // 
            this.xmppUsernameTxt.Location = new System.Drawing.Point(72, 4);
            this.xmppUsernameTxt.Name = "xmppUsernameTxt";
            this.xmppUsernameTxt.Size = new System.Drawing.Size(170, 20);
            this.xmppUsernameTxt.TabIndex = 3;
            // 
            // xmppPwdTxt
            // 
            this.xmppPwdTxt.Location = new System.Drawing.Point(72, 30);
            this.xmppPwdTxt.Name = "xmppPwdTxt";
            this.xmppPwdTxt.Size = new System.Drawing.Size(170, 20);
            this.xmppPwdTxt.TabIndex = 4;
            this.xmppPwdTxt.UseSystemPasswordChar = true;
            // 
            // xmppDomainTxt
            // 
            this.xmppDomainTxt.Location = new System.Drawing.Point(72, 57);
            this.xmppDomainTxt.Name = "xmppDomainTxt";
            this.xmppDomainTxt.Size = new System.Drawing.Size(170, 20);
            this.xmppDomainTxt.TabIndex = 5;
            // 
            // xmppHostTxt
            // 
            this.xmppHostTxt.Location = new System.Drawing.Point(72, 84);
            this.xmppHostTxt.Name = "xmppHostTxt";
            this.xmppHostTxt.Size = new System.Drawing.Size(170, 20);
            this.xmppHostTxt.TabIndex = 6;
            // 
            // xmppHostLabel
            // 
            this.xmppHostLabel.AutoSize = true;
            this.xmppHostLabel.Location = new System.Drawing.Point(7, 87);
            this.xmppHostLabel.Name = "xmppHostLabel";
            this.xmppHostLabel.Size = new System.Drawing.Size(32, 13);
            this.xmppHostLabel.TabIndex = 7;
            this.xmppHostLabel.Text = "Host:";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStripLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 240);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(284, 22);
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
            // ConnectionSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.connectionSettingsTab);
            this.Controls.Add(this.ConnectionTypeCombo);
            this.Controls.Add(this.ConnectionTypeLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ConnectionSettings";
            this.Text = "ConnectionSettings";
            this.connectionSettingsTab.ResumeLayout(false);
            this.xmppTabPage.ResumeLayout(false);
            this.xmppTabPage.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ConnectionTypeLabel;
        private System.Windows.Forms.ComboBox ConnectionTypeCombo;
        private System.Windows.Forms.TabControl connectionSettingsTab;
        private System.Windows.Forms.TabPage xmppTabPage;
        private System.Windows.Forms.Label xmppUsernameLabel;
        private System.Windows.Forms.TabPage directSocketTabPage;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.Label xmppHostLabel;
        private System.Windows.Forms.TextBox xmppHostTxt;
        private System.Windows.Forms.TextBox xmppDomainTxt;
        private System.Windows.Forms.TextBox xmppPwdTxt;
        private System.Windows.Forms.TextBox xmppUsernameTxt;
        private System.Windows.Forms.Label xmppDomainLabel;
        private System.Windows.Forms.Label xmppPwdLabel;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusStripLabel;
    }
}