namespace QoD_DataCentre.Controls
{
    partial class flightOrientation
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
            this.flightOrientationBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.flightOrientationBox)).BeginInit();
            this.SuspendLayout();
            // 
            // flightOrientation
            // 
            this.flightOrientationBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flightOrientationBox.BackColor = System.Drawing.Color.White;
            this.flightOrientationBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flightOrientationBox.Location = new System.Drawing.Point(0, 0);
            this.flightOrientationBox.Margin = new System.Windows.Forms.Padding(0);
            this.flightOrientationBox.Name = "flightOrientation";
            this.flightOrientationBox.Size = new System.Drawing.Size(300, 300);
            this.flightOrientationBox.TabIndex = 1;
            this.flightOrientationBox.TabStop = false;
            // 
            // fligthOrientation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flightOrientationBox);
            this.Name = "fligthOrientation";
            this.Size = new System.Drawing.Size(300, 300);
            ((System.ComponentModel.ISupportInitialize)(this.flightOrientationBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox flightOrientationBox;
    }
}
