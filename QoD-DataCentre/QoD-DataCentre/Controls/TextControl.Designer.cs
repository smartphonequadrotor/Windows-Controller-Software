namespace QoD_DataCentre.Controls
{
    partial class TextControl
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
            this.textControlTerminal = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textControlTerminal
            // 
            this.textControlTerminal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textControlTerminal.Enabled = false;
            this.textControlTerminal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textControlTerminal.Location = new System.Drawing.Point(3, 3);
            this.textControlTerminal.Multiline = true;
            this.textControlTerminal.Name = "textControlTerminal";
            this.textControlTerminal.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textControlTerminal.Size = new System.Drawing.Size(894, 454);
            this.textControlTerminal.TabIndex = 1;
            this.textControlTerminal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textControlTerminal_KeyDown);
            this.textControlTerminal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textControlTerminal_KeyPress);
            // 
            // TextControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Goldenrod;
            this.Controls.Add(this.textControlTerminal);
            this.Name = "TextControl";
            this.Size = new System.Drawing.Size(900, 460);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textControlTerminal;
    }
}
