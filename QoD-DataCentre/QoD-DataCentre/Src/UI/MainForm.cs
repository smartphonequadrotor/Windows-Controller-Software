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
        int line_count = 0;

        public QoDForm()
        {
            InitializeComponent();
        }

        private void setupConnectionBtn_Click(object sender, EventArgs e)
        {
            if (connectionSettings == null)
            {
                connectionSettings = new ConnectionSettings(this);
            }
            connectionSettings.ShowDialog();
            

        }

        public void change_setupConnectionBtn_text(string text)
        {
            setupConnectionBtn.Text = text;
        }

        public void change_connectionText_text(string text)
        {
            connectionText.Text = text;
        }


        internal void enable_text_control()
        {
            textControlTerminal.Enabled = true;
        }

        internal void disable_text_control()
        {
            textControlTerminal.Enabled = false;
        }

        public void write_to_text_control(string text)
        {
            textControlTerminal.Text += text;
        }

        public void insert_write_to_text_control(string text)
        {
            textControlTerminal.Text = textControlTerminal.Text.Insert(line_count, text);
            line_count += text.Length;
        }

        int line_length;
        private void textControlTerminal_KeyDown(object sender, KeyEventArgs e)
        {
            int send = line_count + (QoDMain.networkCommunicationManager.xmppClient.JID + ">").Length;
            if (e.KeyCode == Keys.Enter)
            {
                line_length = 0;
                QoDMain.networkCommunicationManager.xmppClient.writeMessage(textControlTerminal.Text.Substring(send));
                line_count = textControlTerminal.Text.Length + 2;
                textControlTerminal.Text += "\r\n" + QoDMain.networkCommunicationManager.xmppClient.JID + ">";
                e.SuppressKeyPress = true;
                textControlTerminal.SelectionStart = textControlTerminal.Text.Length;
            }
            else if (e.KeyCode == Keys.Back)
            {
                if (line_length == 0)
                    e.SuppressKeyPress = true;
                else{
                    line_length--;
                    textControlTerminal.Text = textControlTerminal.Text.Substring(0, textControlTerminal.Text.Length-1);
                    e.SuppressKeyPress = true;
                }
            }
            
        }



        internal void reset_text_control()
        {
            line_count = 0;
            textControlTerminal.Text = "";
        }

        private void textControlTerminal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' &&
                e.KeyChar != '\0' &&
                e.KeyChar != '\a' &&
                e.KeyChar != '\b' &&
                e.KeyChar != '\f' &&
                e.KeyChar != '\n' &&
                e.KeyChar != '\r' &&
                e.KeyChar != '\t' &&
                e.KeyChar != '\v')
            {
                line_length++;
                textControlTerminal.Text += e.KeyChar;
                textControlTerminal.SelectionStart = textControlTerminal.Text.Length;
            }
        }
    }
}
