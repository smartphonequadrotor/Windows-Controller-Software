using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using QoD_DataCentre.Src.Communication;

namespace QoD_DataCentre.Src.UI
{

    public partial class ConnectionSettings : Form
    {
        private QoDForm qoDForm;

        public ConnectionSettings(QoDForm qoDForm)
        {
            QoDMain.networkCommunicationManager.xmppContactsUpdated += new Communication.NetworkCommunicationManager.xmppContactEvent(networkCommunicationManager_xmppContactsUpdated);
            QoDMain.networkCommunicationManager.IPsUpdated += new Communication.NetworkCommunicationManager.IPsUpdateEvent(networkCommunicationManager_IPsUpdated);
            QoDMain.networkCommunicationManager.onWorking += new Communication.NetworkCommunicationManager.busyEvent(networkCommunicationManager_onWorking);
            QoDMain.networkCommunicationManager.onIdle += new Communication.NetworkCommunicationManager.busyEvent(networkCommunicationManager_onIdle);
            QoDMain.networkCommunicationManager.onStatusChanged += new Communication.NetworkCommunicationManager.statusEvent(networkCommunicationManager_onStatusChanged);
            InitializeComponent();
            this.qoDForm = qoDForm;
        }

        void networkCommunicationManager_IPsUpdated(object sender, Communication.NetworkCommunicationManager.IPPopulationEventArgs data)
        {
            populateDirectSocketIps(data.ExternalIP, data.InternalIP, data.Port);
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

        public void populateDirectSocketIps(string externalIp, string internalIp, int port)
        {
            directSocketExternalIp.Text = externalIp;
            directSocketInternalIp.Text = internalIp;
            directSocketPortTxt.Text = port.ToString();
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


                if (directSocket_async_connect.IsBusy != true)
                {
                    // Start the asynchronous operation.
                    start_progress();
                    directSocket_async_connect.RunWorkerAsync(port);
                }


                serverStartedLbl.Visible = true; ;
            }
            else
            {
                QoDMain.networkCommunicationManager.Disconnect();
                serverStartedLbl.Visible = false;
            }
        }

        // This event handler is where the time-consuming work is done.
        private void directSocket_async_connect_DoWork(object sender, DoWorkEventArgs e)
        {
            //BackgroundWorker worker = sender as BackgroundWorker;
            e.Result = QoDMain.networkCommunicationManager.directSocketServerConnect((int)e.Argument);
        }

        // This event handler deals with the results of the background operation.
        private void directSocket_async_connect_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            stop_progress();
            if ((HttpServer)e.Result != null)
            {
                Thread Listener = new Thread(new ThreadStart(((HttpServer)e.Result).listen));
                Listener.Start();
                QoDMain.networkCommunicationManager.ConnectionStatus = "Waiting for incoming connections...";
                startDirectSocketServerBtn.Text = "Stop Server";
            }
            else
            {
                MessageBox.Show("Error starting server. Check the port is valid and try again.");
                xmppConnect.Text = "Start Server";
                serverStartedLbl.Visible = false;
            }

        }

    }
}
