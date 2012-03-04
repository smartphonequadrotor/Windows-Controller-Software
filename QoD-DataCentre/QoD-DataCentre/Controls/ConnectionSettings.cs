using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace QoD_DataCentre.Src.UI
{

    public partial class ConnectionSettings : Form
    {
        private QoDForm qoDForm;

        public ConnectionSettings(QoDForm qoDForm)
        {
            InitializeComponent();
            this.qoDForm = qoDForm;
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            if (connectionSettingsTab.SelectedIndex == 0)
            {
                QoDMain.networkCommunicationManager.connectionType = Communication.ConnectionType.XMPP;
                QoDMain.networkCommunicationManager.Connect(xmppUsers.SelectedItem.ToString(), 0);
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

        private void updateStatusStrip(String msg)
        {
            statusStripLabel.Text = msg;
        }

        private void xmppConnect_Click(object sender, EventArgs e)
        {
            QoDMain.networkCommunicationManager.Disconnect();
            connectBtn.Enabled = false;
            xmppUsers.Items.Clear();

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
            e.Result = QoDMain.networkCommunicationManager.xmppUserConnect(xmppUsernameTxt.Text, xmppPwdTxt.Text);
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
            connection_status.Visible = false;
            connectionProgressBar.Visible = true;
            
            connectionProgressBar.MarqueeAnimationSpeed = 50;
        }

        public void stop_progress()
        {
            connectionProgressBar.Visible = false;
            connection_status.Visible = true;
            connectionProgressBar.Style = ProgressBarStyle.Blocks;
            connectionProgressBar.MarqueeAnimationSpeed = 0;
        }

        public void write_connection_status()
        {
            connection_status.Text = QoDMain.networkCommunicationManager.ConnectionStatus;
        }

        public void write_contact_list(Dictionary<string, int> contact_dictionary)
        {
            connectBtn.Enabled = false;
            xmppUsers.Items.Clear();
            foreach (KeyValuePair<string, int> pair in contact_dictionary)
                xmppUsers.Items.Add(pair.Key);
        }

        public void refresh_contact_list(Dictionary<string, int> contact_dictionary)
        {
            connectBtn.Enabled = false;
            xmppUsers.Items.Clear();
            foreach (KeyValuePair<string, int> pair in contact_dictionary)
                xmppUsers.Items.Add(pair.Key);
        }

        public void populateDirectSocketIps(string externalIp, string internalIp, int port)
        {
            directSocketExternalIp.Text = externalIp;
            directSocketInternalIp.Text = internalIp;
            directSocketPortTxt.Text = port.ToString();
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
            refresh_contact_list(QoDMain.networkCommunicationManager.getXmppUsers());
            
        }

        private void connectionSettingsTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (connectionSettingsTab.SelectedIndex == 0)
            {
                connectBtn.Visible = true;
                if (xmppUsers.SelectedIndex >= 0)
                {
                    connectBtn.Enabled = true;
                }
                else
                    connectBtn.Enabled = false;
            }
            else
            {
                connectBtn.Visible = false;
            }
        }

        private void startDirectSocketServerBtn_Click(object sender, EventArgs e)
        {
            if (startDirectSocketServerBtn.Text.Equals("Start Server"))
            {
                int port = 0;
                QoDMain.networkCommunicationManager.connectionType = Communication.ConnectionType.DirectSocket;
                try
                {
                    port = Convert.ToInt32(directSocketPortTxt.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Port must be an integer.");
                }
                QoDMain.networkCommunicationManager.Connect(null, port);

                startDirectSocketServerBtn.Text = "Stop Server";
                serverStartedLbl.Visible = true; ;
            }
            else
            {
                QoDMain.networkCommunicationManager.Disconnect();
                startDirectSocketServerBtn.Text = "Start Server";
                serverStartedLbl.Visible = false; ;
            }
        }

    }
}
