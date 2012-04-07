namespace QoD_DataCentre
{
    partial class QoDForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QoDForm));
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.welcome1 = new QoD_DataCentre.Modules.Welcome();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.location1 = new QoD_DataCentre.Controls.Location();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.statistics1 = new QoD_DataCentre.Controls.Statistics();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.liveFeed1 = new QoD_DataCentre.Controls.LiveFeed();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.textControl1 = new QoD_DataCentre.Controls.TextControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.plugins1 = new QoD_DataCentre.Controls.Plugins();
            this.label2 = new System.Windows.Forms.Label();
            this.setupConnectionBtn = new System.Windows.Forms.Button();
            this.connectionText = new System.Windows.Forms.Label();
            this.connectionTimerLbl = new System.Windows.Forms.Label();
            this.flyPrep = new System.Windows.Forms.Button();
            this.userInput = new System.Windows.Forms.Button();
            this.userControlStatusPictureBox = new System.Windows.Forms.PictureBox();
            this.batteryLevelPictureBox = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userControlStatusPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.batteryLevelPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SF New Republic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(402, 49);
            this.label1.TabIndex = 1;
            this.label1.Text = "smartphone quadrotor";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(12, 80);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(782, 359);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.welcome1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(774, 333);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Welcome";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // welcome1
            // 
            this.welcome1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.welcome1.BackColor = System.Drawing.Color.Transparent;
            this.welcome1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.welcome1.Location = new System.Drawing.Point(6, 6);
            this.welcome1.Name = "welcome1";
            this.welcome1.Size = new System.Drawing.Size(762, 321);
            this.welcome1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.location1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(774, 333);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Location";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // location1
            // 
            this.location1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.location1.BackColor = System.Drawing.Color.Transparent;
            this.location1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.location1.Location = new System.Drawing.Point(6, 6);
            this.location1.Name = "location1";
            this.location1.Size = new System.Drawing.Size(762, 321);
            this.location1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.tabPage3.Controls.Add(this.statistics1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(774, 333);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Statistics";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // statistics1
            // 
            this.statistics1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statistics1.BackColor = System.Drawing.Color.Pink;
            this.statistics1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.statistics1.Location = new System.Drawing.Point(6, 6);
            this.statistics1.Name = "statistics1";
            this.statistics1.Size = new System.Drawing.Size(762, 321);
            this.statistics1.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.liveFeed1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(774, 333);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Live Feed";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // liveFeed1
            // 
            this.liveFeed1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.liveFeed1.BackColor = System.Drawing.Color.Green;
            this.liveFeed1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.liveFeed1.Location = new System.Drawing.Point(6, 6);
            this.liveFeed1.Name = "liveFeed1";
            this.liveFeed1.Size = new System.Drawing.Size(762, 321);
            this.liveFeed1.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.textControl1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(774, 333);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Text Control";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // textControl1
            // 
            this.textControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textControl1.BackColor = System.Drawing.Color.White;
            this.textControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.textControl1.Location = new System.Drawing.Point(6, 6);
            this.textControl1.Name = "textControl1";
            this.textControl1.Size = new System.Drawing.Size(762, 321);
            this.textControl1.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.plugins1);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(774, 333);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Plugins";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // plugins1
            // 
            this.plugins1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plugins1.BackColor = System.Drawing.Color.Blue;
            this.plugins1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.plugins1.Location = new System.Drawing.Point(6, 6);
            this.plugins1.Name = "plugins1";
            this.plugins1.Size = new System.Drawing.Size(762, 321);
            this.plugins1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Connection Time:";
            // 
            // setupConnectionBtn
            // 
            this.setupConnectionBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.setupConnectionBtn.Location = new System.Drawing.Point(643, 56);
            this.setupConnectionBtn.Name = "setupConnectionBtn";
            this.setupConnectionBtn.Size = new System.Drawing.Size(147, 23);
            this.setupConnectionBtn.TabIndex = 5;
            this.setupConnectionBtn.Text = "Setup Connection";
            this.setupConnectionBtn.UseVisualStyleBackColor = true;
            this.setupConnectionBtn.Click += new System.EventHandler(this.setupConnectionBtn_Click);
            // 
            // connectionText
            // 
            this.connectionText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connectionText.Location = new System.Drawing.Point(203, 61);
            this.connectionText.Name = "connectionText";
            this.connectionText.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.connectionText.Size = new System.Drawing.Size(434, 13);
            this.connectionText.TabIndex = 6;
            this.connectionText.Text = "Not Connected.";
            this.connectionText.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // connectionTimerLbl
            // 
            this.connectionTimerLbl.AutoSize = true;
            this.connectionTimerLbl.Location = new System.Drawing.Point(144, 61);
            this.connectionTimerLbl.Name = "connectionTimerLbl";
            this.connectionTimerLbl.Size = new System.Drawing.Size(49, 13);
            this.connectionTimerLbl.TabIndex = 7;
            this.connectionTimerLbl.Text = "00:00:00";
            // 
            // flyPrep
            // 
            this.flyPrep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.flyPrep.Location = new System.Drawing.Point(12, 445);
            this.flyPrep.Name = "flyPrep";
            this.flyPrep.Size = new System.Drawing.Size(115, 23);
            this.flyPrep.TabIndex = 8;
            this.flyPrep.Text = "Calibrate";
            this.flyPrep.UseVisualStyleBackColor = true;
            this.flyPrep.Visible = false;
            this.flyPrep.Click += new System.EventHandler(this.fly_Click);
            // 
            // userInput
            // 
            this.userInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.userInput.Location = new System.Drawing.Point(664, 445);
            this.userInput.Name = "userInput";
            this.userInput.Size = new System.Drawing.Size(101, 23);
            this.userInput.TabIndex = 9;
            this.userInput.Text = "Enable Keys";
            this.userInput.UseVisualStyleBackColor = true;
            this.userInput.Visible = false;
            this.userInput.Click += new System.EventHandler(this.userInput_Click);
            // 
            // userControlStatusPictureBox
            // 
            this.userControlStatusPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.userControlStatusPictureBox.Image = global::QoD_DataCentre.Properties.Resources.userControlIndicatorDisabled;
            this.userControlStatusPictureBox.Location = new System.Drawing.Point(769, 445);
            this.userControlStatusPictureBox.Name = "userControlStatusPictureBox";
            this.userControlStatusPictureBox.Size = new System.Drawing.Size(23, 23);
            this.userControlStatusPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.userControlStatusPictureBox.TabIndex = 10;
            this.userControlStatusPictureBox.TabStop = false;
            this.userControlStatusPictureBox.Visible = false;
            // 
            // batteryLevelPictureBox
            // 
            this.batteryLevelPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("batteryLevelPictureBox.Image")));
            this.batteryLevelPictureBox.Location = new System.Drawing.Point(12, 54);
            this.batteryLevelPictureBox.Name = "batteryLevelPictureBox";
            this.batteryLevelPictureBox.Size = new System.Drawing.Size(30, 20);
            this.batteryLevelPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.batteryLevelPictureBox.TabIndex = 3;
            this.batteryLevelPictureBox.TabStop = false;
            // 
            // QoDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 472);
            this.Controls.Add(this.userControlStatusPictureBox);
            this.Controls.Add(this.userInput);
            this.Controls.Add(this.flyPrep);
            this.Controls.Add(this.connectionTimerLbl);
            this.Controls.Add(this.connectionText);
            this.Controls.Add(this.setupConnectionBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.batteryLevelPictureBox);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QoDForm";
            this.Text = "Smartphone Quadrotor";
            this.Load += new System.EventHandler(this.QoDForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.QoDForm_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userControlStatusPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.batteryLevelPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox batteryLevelPictureBox;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button setupConnectionBtn;
        private System.Windows.Forms.Label connectionText;
        private System.Windows.Forms.Label connectionTimerLbl;
        private Modules.Welcome welcome1;
        private Controls.Location location1;
        private Controls.LiveFeed liveFeed1;
        private Controls.Plugins plugins1;
        private Controls.TextControl textControl1;
        public System.Windows.Forms.Button flyPrep;
        private System.Windows.Forms.Button userInput;
        private System.Windows.Forms.PictureBox userControlStatusPictureBox;
        private Controls.Statistics statistics1;
    }
}

