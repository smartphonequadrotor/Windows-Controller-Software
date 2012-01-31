﻿namespace QoD_DataCentre
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.textControlTerminal = new System.Windows.Forms.TextBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.setupConnectionBtn = new System.Windows.Forms.Button();
            this.connectionText = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.welcome1 = new QoD_DataCentre.Modules.Welcome();
            this.location1 = new QoD_DataCentre.Controls.Location();
            this.statistics1 = new QoD_DataCentre.Controls.Statistics();
            this.liveFeed1 = new QoD_DataCentre.Controls.LiveFeed();
            this.plugins1 = new QoD_DataCentre.Controls.Plugins();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(218, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(419, 42);
            this.label1.TabIndex = 1;
            this.label1.Text = "Smartphone Quadrotor";
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
            this.tabControl1.Size = new System.Drawing.Size(782, 386);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.welcome1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(774, 360);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Welcome";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.location1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(774, 360);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Location";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.statistics1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(774, 360);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Statistics";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.liveFeed1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(774, 360);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Live Feed";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.textControlTerminal);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(774, 360);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Text Control";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // textControlTerminal
            // 
            this.textControlTerminal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textControlTerminal.Enabled = false;
            this.textControlTerminal.Font = new System.Drawing.Font("Monospac821 BT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textControlTerminal.Location = new System.Drawing.Point(3, 3);
            this.textControlTerminal.Multiline = true;
            this.textControlTerminal.Name = "textControlTerminal";
            this.textControlTerminal.Size = new System.Drawing.Size(768, 354);
            this.textControlTerminal.TabIndex = 0;
            this.textControlTerminal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textControlTerminal_KeyDown);
            this.textControlTerminal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textControlTerminal_KeyPress);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.plugins1);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(774, 360);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Plugins";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 54);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Elapsed Flight Time:";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(153, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "00:00";
            // 
            // welcome1
            // 
            this.welcome1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.welcome1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.welcome1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.welcome1.Location = new System.Drawing.Point(6, 6);
            this.welcome1.Name = "welcome1";
            this.welcome1.Size = new System.Drawing.Size(762, 348);
            this.welcome1.TabIndex = 0;
            // 
            // location1
            // 
            this.location1.BackColor = System.Drawing.Color.Orange;
            this.location1.Location = new System.Drawing.Point(6, 6);
            this.location1.Name = "location1";
            this.location1.Size = new System.Drawing.Size(762, 348);
            this.location1.TabIndex = 0;
            // 
            // statistics1
            // 
            this.statistics1.BackColor = System.Drawing.Color.Pink;
            this.statistics1.Location = new System.Drawing.Point(6, 6);
            this.statistics1.Name = "statistics1";
            this.statistics1.Size = new System.Drawing.Size(762, 348);
            this.statistics1.TabIndex = 0;
            // 
            // liveFeed1
            // 
            this.liveFeed1.BackColor = System.Drawing.Color.Green;
            this.liveFeed1.Location = new System.Drawing.Point(3, 3);
            this.liveFeed1.Name = "liveFeed1";
            this.liveFeed1.Size = new System.Drawing.Size(768, 354);
            this.liveFeed1.TabIndex = 0;
            // 
            // plugins1
            // 
            this.plugins1.BackColor = System.Drawing.Color.Blue;
            this.plugins1.Location = new System.Drawing.Point(3, 3);
            this.plugins1.Name = "plugins1";
            this.plugins1.Size = new System.Drawing.Size(768, 354);
            this.plugins1.TabIndex = 0;
            // 
            // QoDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 478);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.connectionText);
            this.Controls.Add(this.setupConnectionBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QoDForm";
            this.Text = "Quadrotor of Doom";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button setupConnectionBtn;
        private System.Windows.Forms.Label connectionText;
        private System.Windows.Forms.Label label4;
        private Modules.Welcome welcome1;
        private Controls.Location location1;
        private Controls.Statistics statistics1;
        private Controls.LiveFeed liveFeed1;
        private Controls.Plugins plugins1;
        private System.Windows.Forms.TextBox textControlTerminal;
    }
}

