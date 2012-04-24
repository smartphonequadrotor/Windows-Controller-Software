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
            this.flightOrientation1 = new QoD_DataCentre.Controls.flightOrientation();
            this.setStartKill = new System.Windows.Forms.Button();
            this.setFlightPID = new System.Windows.Forms.Button();
            this.setAltitude = new System.Windows.Forms.Button();
            this.startKillSource = new System.Windows.Forms.Label();
            this.startKillControl = new System.Windows.Forms.Label();
            this.flightPIDSource = new System.Windows.Forms.Label();
            this.altitudeSource = new System.Windows.Forms.Label();
            this.flightPIDControl = new System.Windows.Forms.Label();
            this.altitudeControl = new System.Windows.Forms.Label();
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
            this.label1.Location = new System.Drawing.Point(94, 0);
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
            this.tableLayoutPanel1.Controls.Add(this.flightOrientation1, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.setStartKill, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.setFlightPID, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.setAltitude, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.startKillSource, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.startKillControl, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.flightPIDSource, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.altitudeSource, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.flightPIDControl, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.altitudeControl, 2, 7);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(403, 348);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(259, 13);
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
            this.heightSource.Location = new System.Drawing.Point(94, 13);
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
            this.rollSource.Location = new System.Drawing.Point(94, 42);
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
            this.pitchSource.Location = new System.Drawing.Point(94, 71);
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
            this.heightControl.Location = new System.Drawing.Point(141, 13);
            this.heightControl.Name = "heightControl";
            this.heightControl.Size = new System.Drawing.Size(259, 29);
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
            this.rollControl.Location = new System.Drawing.Point(141, 42);
            this.rollControl.Name = "rollControl";
            this.rollControl.Size = new System.Drawing.Size(259, 29);
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
            this.pitchControl.Location = new System.Drawing.Point(141, 71);
            this.pitchControl.Name = "pitchControl";
            this.pitchControl.Size = new System.Drawing.Size(259, 29);
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
            this.yawSource.Location = new System.Drawing.Point(94, 100);
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
            this.yawControl.Location = new System.Drawing.Point(141, 100);
            this.yawControl.Name = "yawControl";
            this.yawControl.Size = new System.Drawing.Size(259, 29);
            this.yawControl.TabIndex = 13;
            this.yawControl.Text = "Source";
            this.yawControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flightOrientation1
            // 
            this.flightOrientation1.Location = new System.Drawing.Point(141, 219);
            this.flightOrientation1.Name = "flightOrientation1";
            this.flightOrientation1.Size = new System.Drawing.Size(132, 129);
            this.flightOrientation1.TabIndex = 14;
            // 
            // setStartKill
            // 
            this.setStartKill.Location = new System.Drawing.Point(3, 132);
            this.setStartKill.Name = "setStartKill";
            this.setStartKill.Size = new System.Drawing.Size(75, 23);
            this.setStartKill.TabIndex = 18;
            this.setStartKill.Text = "Set Start/Kill";
            this.setStartKill.UseVisualStyleBackColor = true;
            this.setStartKill.Click += new System.EventHandler(this.setStartKill_Click);
            // 
            // setFlightPID
            // 
            this.setFlightPID.Location = new System.Drawing.Point(3, 161);
            this.setFlightPID.Name = "setFlightPID";
            this.setFlightPID.Size = new System.Drawing.Size(85, 23);
            this.setFlightPID.TabIndex = 19;
            this.setFlightPID.Text = "Set Flight/PID";
            this.setFlightPID.UseVisualStyleBackColor = true;
            this.setFlightPID.Click += new System.EventHandler(this.setFlightPID_Click);
            // 
            // setAltitude
            // 
            this.setAltitude.Location = new System.Drawing.Point(3, 190);
            this.setAltitude.Name = "setAltitude";
            this.setAltitude.Size = new System.Drawing.Size(75, 23);
            this.setAltitude.TabIndex = 20;
            this.setAltitude.Text = "Set Altitude";
            this.setAltitude.UseVisualStyleBackColor = true;
            this.setAltitude.Click += new System.EventHandler(this.setAltitude_Click);
            // 
            // startKillSource
            // 
            this.startKillSource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startKillSource.AutoSize = true;
            this.startKillSource.Location = new System.Drawing.Point(94, 129);
            this.startKillSource.Name = "startKillSource";
            this.startKillSource.Size = new System.Drawing.Size(41, 29);
            this.startKillSource.TabIndex = 21;
            this.startKillSource.Text = "Source";
            this.startKillSource.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startKillControl
            // 
            this.startKillControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startKillControl.AutoSize = true;
            this.startKillControl.Location = new System.Drawing.Point(141, 129);
            this.startKillControl.Name = "startKillControl";
            this.startKillControl.Size = new System.Drawing.Size(259, 29);
            this.startKillControl.TabIndex = 22;
            this.startKillControl.Text = "Source";
            this.startKillControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flightPIDSource
            // 
            this.flightPIDSource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flightPIDSource.AutoSize = true;
            this.flightPIDSource.Location = new System.Drawing.Point(94, 158);
            this.flightPIDSource.Name = "flightPIDSource";
            this.flightPIDSource.Size = new System.Drawing.Size(41, 29);
            this.flightPIDSource.TabIndex = 23;
            this.flightPIDSource.Text = "Source";
            this.flightPIDSource.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // altitudeSource
            // 
            this.altitudeSource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.altitudeSource.AutoSize = true;
            this.altitudeSource.Location = new System.Drawing.Point(94, 187);
            this.altitudeSource.Name = "altitudeSource";
            this.altitudeSource.Size = new System.Drawing.Size(41, 29);
            this.altitudeSource.TabIndex = 24;
            this.altitudeSource.Text = "Source";
            this.altitudeSource.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flightPIDControl
            // 
            this.flightPIDControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flightPIDControl.AutoSize = true;
            this.flightPIDControl.Location = new System.Drawing.Point(141, 158);
            this.flightPIDControl.Name = "flightPIDControl";
            this.flightPIDControl.Size = new System.Drawing.Size(259, 29);
            this.flightPIDControl.TabIndex = 25;
            this.flightPIDControl.Text = "Source";
            this.flightPIDControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // altitudeControl
            // 
            this.altitudeControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.altitudeControl.AutoSize = true;
            this.altitudeControl.Location = new System.Drawing.Point(141, 187);
            this.altitudeControl.Name = "altitudeControl";
            this.altitudeControl.Size = new System.Drawing.Size(259, 29);
            this.altitudeControl.TabIndex = 26;
            this.altitudeControl.Text = "Source";
            this.altitudeControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ControlManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 372);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
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
        private flightOrientation flightOrientation1;
        private System.Windows.Forms.Button setStartKill;
        private System.Windows.Forms.Button setFlightPID;
        private System.Windows.Forms.Button setAltitude;
        private System.Windows.Forms.Label startKillSource;
        private System.Windows.Forms.Label startKillControl;
        private System.Windows.Forms.Label flightPIDSource;
        private System.Windows.Forms.Label altitudeSource;
        private System.Windows.Forms.Label flightPIDControl;
        private System.Windows.Forms.Label altitudeControl;
    }
}