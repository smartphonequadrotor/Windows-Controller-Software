using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QoD_DataCentre.Controls
{
    public partial class Coordinates : UserControl
    {
        public Coordinates()
        {
            InitializeComponent();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            //todo lisa test
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            button1.Text = "Cancel";
            button2.Show();

            //on saving or cancelling, revert to RO
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.Equals("x"))
            {
                DialogResult result = MessageBox.Show("Are you sure?");
                if (result == DialogResult.Yes)
                {
                    //todo lisa remove coordinates
                }
            }
            else
            {
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                //todo lisa
                //need to know whether this is a new location or if it is editing an existing location
                //this could be a bloody gong show, so don't forget to think carefully!
            }
        }
    }
}
