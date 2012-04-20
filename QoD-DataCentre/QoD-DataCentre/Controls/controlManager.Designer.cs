namespace QoD_DataCentre.Controls
{
    partial class ControlManager
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
            this.setHeight = new System.Windows.Forms.Button();
            this.setRoll = new System.Windows.Forms.Button();
            this.setPitch = new System.Windows.Forms.Button();
            this.setYaw = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.heightSource = new System.Windows.Forms.Label();
            this.rollSource = new System.Windows.Forms.Label();
            this.pitchSource = new System.Windows.Forms.Label();
            this.heightControl = new System.Windows.Forms.Label();
            this.rollControl = new System.Windows.Forms.Label();
            this.pitchControl = new System.Windows.Forms.Label();
            this.yawSource = new System.Windows.Forms.Label();
            this.yawControl = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // setHeight
            // 
            this.setHeight.Location = new System.Drawing.Point(3, 16);
            this.setHeight.Name = "setHeight";
            this.setHeight.Size = new System.Drawing.Size(75, 23);
            this.setHeight.TabIndex = 0;
            this.setHeight.Text = "Set Height";
            this.setHeight.UseVisualStyleBackColor = true;
            this.setHeight.Click += new System.EventHandler(this.setHeight_Click);
            // 
            // setRoll
            // 
            this.setRoll.Location = new System.Drawing.Point(3, 45);
            this.setRoll.Name = "setRoll";
            this.setRoll.Size = new System.Drawing.Size(75, 23);
            this.setRoll.TabIndex = 1;
            this.setRoll.Text = "Set Roll";
            this.setRoll.UseVisualStyleBackColor = true;
            this.setRoll.Click += new System.EventHandler(this.setRoll_Click);
            // 
            // setPitch
            // 
            this.setPitch.Location = new System.Drawing.Point(3, 74);
            this.setPitch.Name = "setPitch";
            this.setPitch.Size = new System.Drawing.Size(75, 23);
            this.setPitch.TabIndex = 2;
            this.setPitch.Text = "Set Pitch";
            this.setPitch.UseVisualStyleBackColor = true;
            this.setPitch.Click += new System.EventHandler(this.setPitch_Click);
            // 
            // setYaw
            // 
            this.setYaw.Location = new System.Drawing.Point(3, 103);
            this.setYaw.Name = "setYaw";
            this.setYaw.Size = new System.Drawing.Size(75, 23);
            this.setYaw.TabIndex = 3;
            this.setYaw.Text = "Set Yaw";
            this.setYaw.UseVisualStyleBackColor = true;
            this.setYaw.Click += new System.EventHandler(this.setYaw_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Source";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.setYaw, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.setPitch, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.setRoll, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.setHeight, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.heightSource, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.rollSource, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.pitchSource, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.heightControl, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.rollControl, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.pitchControl, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.yawSource, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.yawControl, 2, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(310, 272);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(131, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Control";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // heightSource
            // 
            this.heightSource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.heightSource.AutoSize = true;
            this.heightSource.Location = new System.Drawing.Point(84, 13);
            this.heightSource.Name = "heightSource";
            this.heightSource.Size = new System.Drawing.Size(41, 29);
            this.heightSource.TabIndex = 6;
            this.heightSource.Text = "Source";
            this.heightSource.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rollSource
            // 
            this.rollSource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rollSource.AutoSize = true;
            this.rollSource.Location = new System.Drawing.Point(84, 42);
            this.rollSource.Name = "rollSource";
            this.rollSource.Size = new System.Drawing.Size(41, 29);
            this.rollSource.TabIndex = 7;
            this.rollSource.Text = "Source";
            this.rollSource.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pitchSource
            // 
            this.pitchSource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pitchSource.AutoSize = true;
            this.pitchSource.Location = new System.Drawing.Point(84, 71);
            this.pitchSource.Name = "pitchSource";
            this.pitchSource.Size = new System.Drawing.Size(41, 29);
            this.pitchSource.TabIndex = 8;
            this.pitchSource.Text = "Source";
            this.pitchSource.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // heightControl
            // 
            this.heightControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.heightControl.AutoSize = true;
            this.heightControl.Location = new System.Drawing.Point(131, 13);
            this.heightControl.Name = "heightControl";
            this.heightControl.Size = new System.Drawing.Size(176, 29);
            this.heightControl.TabIndex = 9;
            this.heightControl.Text = "Source";
            this.heightControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rollControl
            // 
            this.rollControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rollControl.AutoSize = true;
            this.rollControl.Location = new System.Drawing.Point(131, 42);
            this.rollControl.Name = "rollControl";
            this.rollControl.Size = new System.Drawing.Size(176, 29);
            this.rollControl.TabIndex = 10;
            this.rollControl.Text = "Source";
            this.rollControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pitchControl
            // 
            this.pitchControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pitchControl.AutoSize = true;
            this.pitchControl.Location = new System.Drawing.Point(131, 71);
            this.pitchControl.Name = "pitchControl";
            this.pitchControl.Size = new System.Drawing.Size(176, 29);
            this.pitchControl.TabIndex = 11;
            this.pitchControl.Text = "Source";
            this.pitchControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // yawSource
            // 
            this.yawSource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yawSource.AutoSize = true;
            this.yawSource.Location = new System.Drawing.Point(84, 100);
            this.yawSource.Name = "yawSource";
            this.yawSource.Size = new System.Drawing.Size(41, 29);
            this.yawSource.TabIndex = 12;
            this.yawSource.Text = "Source";
            this.yawSource.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // yawControl
            // 
            this.yawControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yawControl.AutoSize = true;
            this.yawControl.Location = new System.Drawing.Point(131, 100);
            this.yawControl.Name = "yawControl";
            this.yawControl.Size = new System.Drawing.Size(176, 29);
            this.yawControl.TabIndex = 13;
            this.yawControl.Text = "Source";
            this.yawControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ControlManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 296);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ControlManager";
            this.Text = "controlManager";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ControlManager_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button setHeight;
        private System.Windows.Forms.Button setRoll;
        private System.Windows.Forms.Button setPitch;
        private System.Windows.Forms.Button setYaw;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label heightSource;
        private System.Windows.Forms.Label rollSource;
        private System.Windows.Forms.Label pitchSource;
        private System.Windows.Forms.Label heightControl;
        private System.Windows.Forms.Label rollControl;
        private System.Windows.Forms.Label pitchControl;
        private System.Windows.Forms.Label yawSource;
        private System.Windows.Forms.Label yawControl;
    }
}