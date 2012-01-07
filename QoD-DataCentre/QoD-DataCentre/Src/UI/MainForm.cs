using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QoD_DataCentre.Src.UI;

namespace QoD_DataCentre
{
    public partial class QoDForm : Form
    {
        ConnectionSettings connectionSettings;
        public QoDForm()
        {
            InitializeComponent();
        }

        private void setupConnectionBtn_Click(object sender, EventArgs e)
        {
            if (connectionSettings == null)
            {
                connectionSettings = new ConnectionSettings();
            }
            connectionSettings.ShowDialog();
        }
    }
}
