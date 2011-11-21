namespace QoD_DataCentre
{
    partial class SerialSendUtilityForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.currentSpeedM4 = new System.Windows.Forms.TextBox();
            this.currentSpeedM3 = new System.Windows.Forms.TextBox();
            this.currentSpeedM2 = new System.Windows.Forms.TextBox();
            this.increaseDecreaseBox = new System.Windows.Forms.GroupBox();
            this.increaseSpeed = new System.Windows.Forms.RadioButton();
            this.decreaseSpeed = new System.Windows.Forms.RadioButton();
            this.motorToChange = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.changeSpeedBy = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.currentSpeedM1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BaudBox = new System.Windows.Forms.ComboBox();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.EncodeSendButton = new System.Windows.Forms.Button();
            this.COMPortDropDown = new System.Windows.Forms.ComboBox();
            this.OpenCloseCOMPortButton = new System.Windows.Forms.Button();
            this.increaseDecreaseBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // currentSpeedM4
            // 
            this.currentSpeedM4.Location = new System.Drawing.Point(306, 39);
            this.currentSpeedM4.Name = "currentSpeedM4";
            this.currentSpeedM4.ReadOnly = true;
            this.currentSpeedM4.Size = new System.Drawing.Size(70, 20);
            this.currentSpeedM4.TabIndex = 36;
            // 
            // currentSpeedM3
            // 
            this.currentSpeedM3.Location = new System.Drawing.Point(233, 39);
            this.currentSpeedM3.Name = "currentSpeedM3";
            this.currentSpeedM3.ReadOnly = true;
            this.currentSpeedM3.Size = new System.Drawing.Size(67, 20);
            this.currentSpeedM3.TabIndex = 35;
            // 
            // currentSpeedM2
            // 
            this.currentSpeedM2.Location = new System.Drawing.Point(160, 39);
            this.currentSpeedM2.Name = "currentSpeedM2";
            this.currentSpeedM2.ReadOnly = true;
            this.currentSpeedM2.Size = new System.Drawing.Size(67, 20);
            this.currentSpeedM2.TabIndex = 34;
            // 
            // increaseDecreaseBox
            // 
            this.increaseDecreaseBox.Controls.Add(this.increaseSpeed);
            this.increaseDecreaseBox.Controls.Add(this.decreaseSpeed);
            this.increaseDecreaseBox.Location = new System.Drawing.Point(6, 66);
            this.increaseDecreaseBox.Name = "increaseDecreaseBox";
            this.increaseDecreaseBox.Size = new System.Drawing.Size(84, 72);
            this.increaseDecreaseBox.TabIndex = 33;
            this.increaseDecreaseBox.TabStop = false;
            // 
            // increaseSpeed
            // 
            this.increaseSpeed.AutoSize = true;
            this.increaseSpeed.Location = new System.Drawing.Point(6, 19);
            this.increaseSpeed.Name = "increaseSpeed";
            this.increaseSpeed.Size = new System.Drawing.Size(66, 17);
            this.increaseSpeed.TabIndex = 10;
            this.increaseSpeed.TabStop = true;
            this.increaseSpeed.Text = "Increase";
            this.increaseSpeed.UseVisualStyleBackColor = true;
            // 
            // decreaseSpeed
            // 
            this.decreaseSpeed.AutoSize = true;
            this.decreaseSpeed.Location = new System.Drawing.Point(6, 42);
            this.decreaseSpeed.Name = "decreaseSpeed";
            this.decreaseSpeed.Size = new System.Drawing.Size(71, 17);
            this.decreaseSpeed.TabIndex = 11;
            this.decreaseSpeed.TabStop = true;
            this.decreaseSpeed.Text = "Decrease";
            this.decreaseSpeed.UseVisualStyleBackColor = true;
            // 
            // motorToChange
            // 
            this.motorToChange.FormattingEnabled = true;
            this.motorToChange.Items.AddRange(new object[] {
            "Motor 1",
            "Motor 2",
            "Motor 3",
            "Motor 4"});
            this.motorToChange.Location = new System.Drawing.Point(309, 74);
            this.motorToChange.Name = "motorToChange";
            this.motorToChange.Size = new System.Drawing.Size(80, 64);
            this.motorToChange.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(278, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "on";
            // 
            // changeSpeedBy
            // 
            this.changeSpeedBy.Location = new System.Drawing.Point(167, 94);
            this.changeSpeedBy.Name = "changeSpeedBy";
            this.changeSpeedBy.Size = new System.Drawing.Size(100, 20);
            this.changeSpeedBy.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(104, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "speed by";
            // 
            // currentSpeedM1
            // 
            this.currentSpeedM1.Location = new System.Drawing.Point(87, 39);
            this.currentSpeedM1.Name = "currentSpeedM1";
            this.currentSpeedM1.ReadOnly = true;
            this.currentSpeedM1.Size = new System.Drawing.Size(67, 20);
            this.currentSpeedM1.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Current Speed:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Baud rate:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Port:";
            // 
            // BaudBox
            // 
            this.BaudBox.FormattingEnabled = true;
            this.BaudBox.Items.AddRange(new object[] {
            "9600",
            "14400",
            "19200",
            "28800",
            "38400",
            "56000",
            "57600",
            "115200",
            "128000",
            "153600",
            "230400",
            "256000",
            "460800",
            "921600"});
            this.BaudBox.Location = new System.Drawing.Point(276, 8);
            this.BaudBox.Name = "BaudBox";
            this.BaudBox.Size = new System.Drawing.Size(121, 21);
            this.BaudBox.TabIndex = 24;
            // 
            // LogTextBox
            // 
            this.LogTextBox.AcceptsReturn = true;
            this.LogTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LogTextBox.Location = new System.Drawing.Point(3, 144);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LogTextBox.Size = new System.Drawing.Size(501, 213);
            this.LogTextBox.TabIndex = 23;
            // 
            // EncodeSendButton
            // 
            this.EncodeSendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EncodeSendButton.Location = new System.Drawing.Point(395, 117);
            this.EncodeSendButton.Name = "EncodeSendButton";
            this.EncodeSendButton.Size = new System.Drawing.Size(100, 21);
            this.EncodeSendButton.TabIndex = 22;
            this.EncodeSendButton.Text = "Send";
            this.EncodeSendButton.UseVisualStyleBackColor = true;
            this.EncodeSendButton.Click += new System.EventHandler(this.EncodeSendButton_Click);
            // 
            // COMPortDropDown
            // 
            this.COMPortDropDown.FormattingEnabled = true;
            this.COMPortDropDown.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13",
            "COM14",
            "COM15",
            "COM16",
            "COM17",
            "COM18",
            "COM19",
            "COM20"});
            this.COMPortDropDown.Location = new System.Drawing.Point(87, 8);
            this.COMPortDropDown.Name = "COMPortDropDown";
            this.COMPortDropDown.Size = new System.Drawing.Size(121, 21);
            this.COMPortDropDown.TabIndex = 21;
            // 
            // OpenCloseCOMPortButton
            // 
            this.OpenCloseCOMPortButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenCloseCOMPortButton.Location = new System.Drawing.Point(404, 7);
            this.OpenCloseCOMPortButton.Name = "OpenCloseCOMPortButton";
            this.OpenCloseCOMPortButton.Size = new System.Drawing.Size(100, 21);
            this.OpenCloseCOMPortButton.TabIndex = 20;
            this.OpenCloseCOMPortButton.Text = "Open COM port";
            this.OpenCloseCOMPortButton.UseVisualStyleBackColor = true;
            this.OpenCloseCOMPortButton.Click += new System.EventHandler(this.OpenCloseCOMPortButton_Click);
            // 
            // SerialSendUtilityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.currentSpeedM4);
            this.Controls.Add(this.currentSpeedM3);
            this.Controls.Add(this.currentSpeedM2);
            this.Controls.Add(this.increaseDecreaseBox);
            this.Controls.Add(this.motorToChange);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.changeSpeedBy);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.currentSpeedM1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BaudBox);
            this.Controls.Add(this.LogTextBox);
            this.Controls.Add(this.EncodeSendButton);
            this.Controls.Add(this.COMPortDropDown);
            this.Controls.Add(this.OpenCloseCOMPortButton);
            this.Name = "SerialSendUtilityForm";
            this.Size = new System.Drawing.Size(507, 367);
            this.increaseDecreaseBox.ResumeLayout(false);
            this.increaseDecreaseBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox currentSpeedM4;
        private System.Windows.Forms.TextBox currentSpeedM3;
        private System.Windows.Forms.TextBox currentSpeedM2;
        private System.Windows.Forms.GroupBox increaseDecreaseBox;
        private System.Windows.Forms.RadioButton increaseSpeed;
        private System.Windows.Forms.RadioButton decreaseSpeed;
        private System.Windows.Forms.CheckedListBox motorToChange;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox changeSpeedBy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox currentSpeedM1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox BaudBox;
        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.Button EncodeSendButton;
        private System.Windows.Forms.ComboBox COMPortDropDown;
        private System.Windows.Forms.Button OpenCloseCOMPortButton;
    }
}
