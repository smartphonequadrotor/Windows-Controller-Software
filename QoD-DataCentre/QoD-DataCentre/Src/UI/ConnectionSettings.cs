using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QoD_DataCentre.Src.UI
{

    public partial class ConnectionSettings : Form
    {
        private QoDForm qoDForm;

        
        public ConnectionSettings()
        {
            InitializeComponent();
        }

        public ConnectionSettings(QoDForm qoDForm)
        {
            InitializeComponent();
            this.qoDForm = qoDForm;
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            
            #region Setting Direct Server parameters
            
            #endregion

            if (connectionSettingsTab.SelectedIndex == 0)
            {
                
                QoDMain.networkCommunicationManager.xmppClient.P_JID = xmppUsers.SelectedItem.ToString();
                QoDMain.networkCommunicationManager.xmppClient.set_connected();
                change_connectionText_text("Connected to: " + xmppUsers.SelectedItem.ToString());
                change_setupConnectionBtn_text("Setup Connection");
            }
            else if (connectionSettingsTab.SelectedIndex == 1)
            {
                QoDMain.networkCommunicationManager.connectionType = Communication.ConnectionType.DirectSocket;
            }

            //invoke start progress...
            qoDForm.Invoke((MethodInvoker)delegate
            {
                qoDForm.enable_text_control();
                qoDForm.reset_text_control();
            });
            write_to_text_control(QoDMain.networkCommunicationManager.xmppClient.JID.ToString() + ">");
            this.Hide();
        }

        public void write_to_text_control(String text)
        {
            //invoke start progress...
            qoDForm.Invoke((MethodInvoker)delegate
            {
                qoDForm.write_to_text_control(text);
            });
        }

        public void change_setupConnectionBtn_text(string text)
        {
            //invoke start progress...
            qoDForm.Invoke((MethodInvoker)delegate
            {
                qoDForm.change_setupConnectionBtn_text(text);
            }); 
        }

        public void change_connectionText_text(string text)
        {
            //invoke start progress...
            qoDForm.Invoke((MethodInvoker)delegate
            {
                qoDForm.change_connectionText_text(text);
            }); 
        } 

        private void updateStatusStrip(String msg)
        {
            statusStripLabel.Text = msg;
        }

        private void xmppConnect_Click(object sender, EventArgs e)
        {
            QoDMain.networkCommunicationManager.xmppClient.disconnect();
            connectBtn.Enabled = false;
            xmppUsers.Items.Clear();

            #region Setting XMPP parameters
            QoDMain.networkCommunicationManager.xmppClient.JID = xmppUsernameTxt.Text;
            QoDMain.networkCommunicationManager.xmppClient.Password = xmppPwdTxt.Text;
            #endregion

            if (xmpp_async_connect.IsBusy != true)
            {
                // Start the asynchronous operation.
                xmpp_async_connect.RunWorkerAsync();
            }
            
        }

        // This event handler is where the time-consuming work is done.
        private void xmpp_async_connect_DoWork(object sender, DoWorkEventArgs e)
        {
            //BackgroundWorker worker = sender as BackgroundWorker;
            e.Result = QoDMain.networkCommunicationManager.xmppClient.connect(this);
        }


        // This event handler deals with the results of the background operation.
        private void xmpp_async_connect_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {

            }
            else if (e.Error != null)
            {

            }
            else
            {

            }
        }

        public void start_progress()
        {
            connectionProgressBar.Style = ProgressBarStyle.Marquee;

            connectionProgressBar.MarqueeAnimationSpeed = 50;
        }

        public void stop_progress()
        {
            connectionProgressBar.Style = ProgressBarStyle.Blocks;
            connectionProgressBar.MarqueeAnimationSpeed = 0;
        }

        public void write_connection_status(String status)
        {
            connection_status.Text = status;
        }

        public void write_contact_list(Dictionary<string, int> contact_dictionary)
        {
            connectBtn.Enabled = false;
            xmppUsers.Items.Clear();
            foreach (KeyValuePair<string, int> pair in contact_dictionary)
                xmppUsers.Items.Add(pair.Key);
        }

        public void refresh_contact_list()
        {
            Dictionary<string, int> contact_dictionary = QoDMain.networkCommunicationManager.xmppClient.USER_DICTIONARY;
            connectBtn.Enabled = false;
            xmppUsers.Items.Clear();
            foreach (KeyValuePair<string, int> pair in contact_dictionary)
                xmppUsers.Items.Add(pair.Key);
        }

        private void xmppUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (xmppUsers.SelectedIndex >= 0)
                connectBtn.Enabled = true;
            else
                connectBtn.Enabled = false;
        }

        private void ConnectionSettings_VisibleChanged(object sender, EventArgs e)
        {
            refresh_contact_list();
        }
    }
}
