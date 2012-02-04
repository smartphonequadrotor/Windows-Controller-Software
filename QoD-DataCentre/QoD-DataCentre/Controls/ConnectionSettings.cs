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
    public delegate void UpdateStatusStripLabelDelegate(String msg);

    public partial class ConnectionSettings : Form
    {
        public UpdateStatusStripLabelDelegate updateStatusStripLabelDelegate;

        public ConnectionSettings()
        {
            InitializeComponent();
            updateStatusStripLabelDelegate = new UpdateStatusStripLabelDelegate(updateStatusStrip);
            xmppUsernameTxt.Text = "testcontroller";
            xmppPwdTxt.Text = "MegatronDump";
            xmppDomainTxt.Text = "ventus.com";
            xmppHostTxt.Text = "localhost";

            directSocketHostTxt.Text = "localhost";
            directSocketPortTxt.Text = "5225";
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            #region Setting XMPP parameters
            QoDMain.networkCommunicationManager.xmppClient.Username = xmppUsernameTxt.Text;
            QoDMain.networkCommunicationManager.xmppClient.Password = xmppPwdTxt.Text;
            QoDMain.networkCommunicationManager.xmppClient.Server = xmppDomainTxt.Text;
            QoDMain.networkCommunicationManager.xmppClient.ConnectServer = xmppHostTxt.Text;
            #endregion
            #region Setting direct socket params
            //QoDMain.networkCommunicationManager.directSocketServer.Host = directSocketHostTxt.Text;
            //QoDMain.networkCommunicationManager.directSocketServer.Port = Convert.ToInt32(directSocketPortTxt.Text);
            #endregion

            #region Setting Direct Server parameters - empty

            #endregion

            if (((String)ConnectionTypeCombo.SelectedItem).Equals("XMPP"))
            {
                QoDMain.networkCommunicationManager.connectionType = Communication.ConnectionType.XMPP;

                //use a method invoker instead of direct invoking to keep the UI responsive
                //MethodInvoker connectMethodInvoker = new MethodInvoker(xmppClientConnectLiason);
                //connectMethodInvoker.BeginInvoke(null, null);
                xmppClientConnectLiason();
            }
            else if (((String)ConnectionTypeCombo.SelectedItem).Equals("Direct Socket"))
            {
                QoDMain.networkCommunicationManager.connectionType = Communication.ConnectionType.DirectSocket;

                Src.Communication.HttpServer httpServer;
                System.Net.IPAddress localAddress = Dns.GetHostAddresses("localhost")[1];
                httpServer = new Src.Communication.MyHttpServer(localAddress, 5225);
                
                Thread thread = new Thread(new ThreadStart(httpServer.listen));
                thread.Start();
            }
        }

        /// <summary>
        /// This method simply calls the XmppClient.connect() method. Instead of returning a boolean,
        /// this method lets the user know of connection failure through a dialog box. This is required because
        /// a MethodInvoker constructor requires a method that returns void.
        /// </summary>
        private void xmppClientConnectLiason()
        {
            if (!QoDMain.networkCommunicationManager.xmppClient.connect(this))
            {
                MessageBox.Show
                (
                    "Failed to connect to xmpp server",
                    "Connection Failure",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1
                );
            }
        }

        private void updateStatusStrip(String msg)
        {
            statusStripLabel.Text = msg;
        }
    }
}
