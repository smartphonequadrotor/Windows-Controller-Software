using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;

namespace QoD_DataCentre.Src.UI
{

    public partial class ConnectionSettings : Form
    {
        private QoDForm qoDForm;

        


        public ConnectionSettings(QoDForm qoDForm)
        {
            QoDMain.networkCommunicationManager.xmppContactsUpdated += new Communication.NetworkCommunicationManager.xmppContactEvent(networkCommunicationManager_xmppContactsUpdated);
            QoDMain.networkCommunicationManager.onWorking += new Communication.NetworkCommunicationManager.busyEvent(networkCommunicationManager_onWorking);
            QoDMain.networkCommunicationManager.onIdle += new Communication.NetworkCommunicationManager.busyEvent(networkCommunicationManager_onIdle);
            QoDMain.networkCommunicationManager.onStatusChanged += new Communication.NetworkCommunicationManager.statusEvent(networkCommunicationManager_onStatusChanged);
            InitializeComponent();
            this.qoDForm = qoDForm;
        }

        void networkCommunicationManager_onStatusChanged(object sender, Communication.NetworkCommunicationManager.StatusEventArgs data)
        {
            if (this.IsHandleCreated == true)
            {
                this.Invoke((MethodInvoker)delegate
                {

                    this.write_connection_status(data.Status);

                });
            }
        }

        void networkCommunicationManager_onIdle(object sender, EventArgs data)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.stop_progress();
            });
        }

        void networkCommunicationManager_onWorking(object sender, EventArgs data)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.start_progress();
            });
        }

        void networkCommunicationManager_xmppContactsUpdated(object sender, Communication.NetworkCommunicationManager.XmppContactEventArgs data)
        {
            if (this.IsHandleCreated == true)
                {
            this.Invoke((MethodInvoker)delegate
            {
                this.refresh_contact_list(data.Contacts);
            });
            
                }
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            #region Setting Direct Server parameters - empty
            #endregion
            //TODO should be changed to one common call
            if (connectionSettingsTab.SelectedIndex == 0)
            {                
                QoDMain.networkCommunicationManager.Connect(xmppUsers.SelectedItem.ToString());
            }
            else if (connectionSettingsTab.SelectedIndex == 1)
            {
                QoDMain.networkCommunicationManager.connectionType = Communication.ConnectionType.DirectSocket;

                Src.Communication.HttpServer httpServer;
                System.Net.IPAddress localAddress = Dns.GetHostAddresses("localhost")[1];
                httpServer = new Src.Communication.MyHttpServer(localAddress, 5225);
                
                Thread thread = new Thread(new ThreadStart(httpServer.listen));
                thread.Start();
            }

            //invoke start progress...
            qoDForm.Invoke((MethodInvoker)delegate
            {
                qoDForm.enable_text_control();
                qoDForm.reset_text_control();
            });
           
            this.Hide();
            //qoDForm.Show();
            
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
            if ((bool)e.Result)
            {
                xmppConnect.Text = "Change Connection";
            }
            else
            {
                xmppConnect.Text = "Connect To Server";
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

        public void write_connection_status(string status)
        {
            connection_status.Text = status;

        }


        public void refresh_contact_list(Dictionary<string, int> contact_dictionary)
        {

                connectBtn.Enabled = false;
                xmppUsers.Items.Clear();
                foreach (KeyValuePair<string, int> pair in contact_dictionary)
                    xmppUsers.Items.Add(pair.Key);

                if (QoDMain.networkCommunicationManager.isConnected && QoDMain.networkCommunicationManager.connectionType == Communication.ConnectionType.XMPP)
                {
                    xmppUsers.SelectedItem = QoDMain.networkCommunicationManager.phone_id;
                }
            
        }

        private void xmppUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (xmppUsers.SelectedIndex >= 0 && (xmppUsers.SelectedItem.ToString() != QoDMain.networkCommunicationManager.phone_id))
                connectBtn.Enabled = true;
            else
                connectBtn.Enabled = false;
        }

        private void ConnectionSettings_VisibleChanged(object sender, EventArgs e)
        {
            refresh_contact_list(QoDMain.networkCommunicationManager.getXmppUsers());
            write_connection_status(QoDMain.networkCommunicationManager.ConnectionStatus);
            
        }

        private void connectionSettingsTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (connectionSettingsTab.SelectedIndex == 0)
            {
                QoDMain.networkCommunicationManager.connectionType = Communication.ConnectionType.XMPP;
            }
            else
            {
                connectBtn.Enabled = true;
                QoDMain.networkCommunicationManager.connectionType = Communication.ConnectionType.DirectSocket;
            }
        }

    }
}
