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
        public ConnectionSettings()
        {
            InitializeComponent();
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            #region Setting XMPP parameters
            QoDMain.networkCommunicationManager.xmppClient.Username = xmppUsernameTxt.Text;
            QoDMain.networkCommunicationManager.xmppClient.Password = xmppPwdTxt.Text;
            QoDMain.networkCommunicationManager.xmppClient.Server = xmppDomainTxt.Text;
            QoDMain.networkCommunicationManager.xmppClient.ConnectServer = xmppHostTxt.Text;
            #endregion

            #region Setting Direct Server parameters

            #endregion

            if (((String)ConnectionTypeCombo.SelectedItem).Equals("XMPP"))
            {
                QoDMain.networkCommunicationManager.connectionType = Communication.ConnectionType.XMPP;

                //use a method invoker instead of direct invoking to keep the UI responsive
                MethodInvoker connectMethodInvoker = new MethodInvoker(xmppClientConnectLiason);
                connectMethodInvoker.BeginInvoke(null, null);
            }
            else if (((String)ConnectionTypeCombo.SelectedItem).Equals("Direct Socket"))
            {
                QoDMain.networkCommunicationManager.connectionType = Communication.ConnectionType.DirectSocket;
            }
        }

        /// <summary>
        /// This method simply calls the XmppClient.connect() method. Instead of returning a boolean,
        /// this method lets the user know of connection failure through a dialog box. This is required because
        /// a MethodInvoker constructor requires a method that returns void.
        /// </summary>
        private void xmppClientConnectLiason()
        {
            if (!QoDMain.networkCommunicationManager.xmppClient.connect())
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
    }
}
