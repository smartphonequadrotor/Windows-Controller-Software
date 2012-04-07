namespace QoD_DataCentre.Controls
{
    partial class Statistics
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flightTimeValue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.orientationVsTime = new ZedGraph.ZedGraphControl();
            this.accelerationVsTime = new ZedGraph.ZedGraphControl();
            this.gyroVsTime = new ZedGraph.ZedGraphControl();
            this.magVsTime = new ZedGraph.ZedGraphControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Silver;
            this.splitContainer1.Panel1.Controls.Add(this.flightTimeValue);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.DimGray;
            this.splitContainer1.Panel2.Controls.Add(this.magVsTime);
            this.splitContainer1.Panel2.Controls.Add(this.gyroVsTime);
            this.splitContainer1.Panel2.Controls.Add(this.orientationVsTime);
            this.splitContainer1.Panel2.Controls.Add(this.accelerationVsTime);
            this.splitContainer1.Size = new System.Drawing.Size(444, 249);
            this.splitContainer1.SplitterDistance = 90;
            this.splitContainer1.TabIndex = 0;
            // 
            // flightTimeValue
            // 
            this.flightTimeValue.AutoSize = true;
            this.flightTimeValue.BackColor = System.Drawing.Color.Silver;
            this.flightTimeValue.Location = new System.Drawing.Point(63, 11);
            this.flightTimeValue.Name = "flightTimeValue";
            this.flightTimeValue.Size = new System.Drawing.Size(49, 13);
            this.flightTimeValue.TabIndex = 1;
            this.flightTimeValue.Text = "00:00:00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Flight Time:";
            // 
            // orientationVsTime
            // 
            this.orientationVsTime.Location = new System.Drawing.Point(3, 3);
            this.orientationVsTime.Name = "orientationVsTime";
            this.orientationVsTime.ScrollGrace = 0D;
            this.orientationVsTime.ScrollMaxX = 0D;
            this.orientationVsTime.ScrollMaxY = 0D;
            this.orientationVsTime.ScrollMaxY2 = 0D;
            this.orientationVsTime.ScrollMinX = 0D;
            this.orientationVsTime.ScrollMinY = 0D;
            this.orientationVsTime.ScrollMinY2 = 0D;
            this.orientationVsTime.Size = new System.Drawing.Size(150, 150);
            this.orientationVsTime.TabIndex = 1;
            this.orientationVsTime.Load += new System.EventHandler(this.orientationVsTime_Load);
            // 
            // accelerationVsTime
            // 
            this.accelerationVsTime.Location = new System.Drawing.Point(3, 159);
            this.accelerationVsTime.Name = "accelerationVsTime";
            this.accelerationVsTime.ScrollGrace = 0D;
            this.accelerationVsTime.ScrollMaxX = 0D;
            this.accelerationVsTime.ScrollMaxY = 0D;
            this.accelerationVsTime.ScrollMaxY2 = 0D;
            this.accelerationVsTime.ScrollMinX = 0D;
            this.accelerationVsTime.ScrollMinY = 0D;
            this.accelerationVsTime.ScrollMinY2 = 0D;
            this.accelerationVsTime.Size = new System.Drawing.Size(150, 150);
            this.accelerationVsTime.TabIndex = 0;
            // 
            // gyroVsTime
            // 
            this.gyroVsTime.Location = new System.Drawing.Point(3, 315);
            this.gyroVsTime.Name = "gyroVsTime";
            this.gyroVsTime.ScrollGrace = 0D;
            this.gyroVsTime.ScrollMaxX = 0D;
            this.gyroVsTime.ScrollMaxY = 0D;
            this.gyroVsTime.ScrollMaxY2 = 0D;
            this.gyroVsTime.ScrollMinX = 0D;
            this.gyroVsTime.ScrollMinY = 0D;
            this.gyroVsTime.ScrollMinY2 = 0D;
            this.gyroVsTime.Size = new System.Drawing.Size(150, 150);
            this.gyroVsTime.TabIndex = 2;
            // 
            // magVsTime
            // 
            this.magVsTime.Location = new System.Drawing.Point(3, 471);
            this.magVsTime.Name = "magVsTime";
            this.magVsTime.ScrollGrace = 0D;
            this.magVsTime.ScrollMaxX = 0D;
            this.magVsTime.ScrollMaxY = 0D;
            this.magVsTime.ScrollMaxY2 = 0D;
            this.magVsTime.ScrollMinX = 0D;
            this.magVsTime.ScrollMinY = 0D;
            this.magVsTime.ScrollMinY2 = 0D;
            this.magVsTime.Size = new System.Drawing.Size(150, 150);
            this.magVsTime.TabIndex = 3;
            // 
            // Statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.splitContainer1);
            this.Name = "Statistics";
            this.Size = new System.Drawing.Size(444, 249);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.Label flightTimeValue;
        private System.Windows.Forms.Label label1;
        private ZedGraph.ZedGraphControl accelerationVsTime;
        private ZedGraph.ZedGraphControl orientationVsTime;
        private ZedGraph.ZedGraphControl magVsTime;
        private ZedGraph.ZedGraphControl gyroVsTime;

    }
}
