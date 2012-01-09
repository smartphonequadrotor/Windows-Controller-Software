using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using agsXMPP;
using agsXMPP.protocol;
using agsXMPP.protocol.client;
using System.Windows.Forms;
using QoD_DataCentre.Src.UI;

namespace QoD_DataCentre.Src.Communication
{
    class XmppClient// : INetworkConnection
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public XmppClient()
        {
            this.xmppCon = new XmppClientConnection();
        }

        #region Connection Parameters
        /// <summary>
        /// This is an instance of the XmppClientConnection that does all the XMPP stuff.
        /// </summary>
        private XmppClientConnection xmppCon;

        /// <summary>
        /// This is the username that will identify this client. The user will be required to enter this.
        /// </summary>
        public String Username 
        { 
            get { return xmppCon.Username; }
            set { xmppCon.Username = value; }
        }

        /// <summary>
        /// This is password to the user's account.
        /// </summary>
        public String Password 
        {
            get { return xmppCon.Password; }
            set { xmppCon.Password = value; }
        }

        /// <summary>
        /// This is the name of the Jabber server. Note that this is not the IP address. This name
        /// is set in the configuration of the XMPP server.
        /// </summary>
        public String Server 
        {
            get { return xmppCon.Server; }
            set { xmppCon.Server = value; }
        }

        /// <summary>
        /// This is the actual IP address of the machine hosting the server. For example, in a demo where the server
        /// is hosted by the same machine as this application, this will be "localhost".
        /// </summary>
        public String ConnectServer 
        {
            get { return xmppCon.ConnectServer; }
            set { xmppCon.ConnectServer = value; }
        }

        /// <summary>
        /// This is a string that will correctly identify the machine running this application to the user.
        /// Since a particular user account can be logged into from multiple machines, this string will be
        /// used to identify the machine currently being used.
        /// </summary>
        public String Resource
        {
            get { return xmppCon.Resource; }
            set { xmppCon.Resource = value; }
        }

        /// <summary>
        /// This is the username of the QPhone's account on the Jabber server.
        /// </summary>
        public String QPhoneUsername
        {
            get;
            set;
        }

        /// <summary>
        /// This is the resource name of the QPhone.
        /// </summary>
        public String QPhoneResource
        {
            get;
            set;
        }
        #endregion

        #region UI related variables

        /// <summary>
        /// This reference to the connectionSettings form is required to update its status strip label.
        /// </summary>
        private ConnectionSettings connectionSettingsForm;
        
        #endregion

        #region INetworkConnection Members

        /// <summary>
        /// This method initiates a connection with the Jabber server. It also subscribes to the 
        /// OnMessage event of xmppCon.
        /// </summary>
        /// <param name="senderForm">The connection settings form whose status strip label needs to be updated</param>
        /// <returns>True if the connection was successful and false otherwise.</returns>
        public bool connect(ConnectionSettings connectionSettingsForm)
        {
            this.connectionSettingsForm = connectionSettingsForm;

            xmppCon.AutoResolveConnectServer = false;
            xmppCon.AutoAgents = false;
            xmppCon.AutoPresence = true;
            xmppCon.AutoRoster = true;
            xmppCon.AutoResolveConnectServer = true;

            try
            {
                xmppCon.OnMessage += new agsXMPP.protocol.client.MessageHandler(xmppCon_OnMessage);
                xmppCon.OnXmppConnectionStateChanged += new XmppConnectionStateHandler(xmppCon_OnXmppConnectionStateChanged);
                xmppCon.OnError += new ErrorHandler(xmppCon_OnError);
                xmppCon.Open();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// This method disconnects this client from the Jabber server.
        /// </summary>
        /// <returns>True if the connection was closed successfully and false otherwise.</returns>
        public bool disconnect()
        {
            try
            {
                xmppCon.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// This method is used to send the appropriate JSON packet to the Jabber server.
        /// </summary>
        /// <param name="message">The JSON packet to be sent.</param>
        /// <returns>True if the message was sent successfully and false otherwise</returns>
        public bool writeMessage(string message)
        {
            try
            {
                xmppCon.Send(new agsXMPP.protocol.client.Message(new Jid(QPhoneUsername, Server, QPhoneResource), message));
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public event EventHandler onMessageReceived;

        #endregion

        #region Helper methods

        private void xmppCon_OnMessage(object sender, agsXMPP.protocol.client.Message msg)
        {
            if (onMessageReceived != null)
            {
                onMessageReceived(this, new QPhoneMessageEventArgs(msg.Body));
            }
        }

        /// <summary>
        /// Temporary method for debugging.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="state"></param>
        void xmppCon_OnXmppConnectionStateChanged(object sender, XmppConnectionState state)
        {
            Console.WriteLine("Connection state changed to: " + state.ToString());
            if (connectionSettingsForm != null)
            {
                connectionSettingsForm.BeginInvoke(connectionSettingsForm.updateStatusStripLabelDelegate, new Object[] { state.ToString() });
            }
        }

        /// <summary>
        /// This reports errors to the user through a message box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ex"></param>
        void xmppCon_OnError(object sender, Exception ex)
        {
            System.Windows.Forms.MessageBox.Show
            (
                ex.Message,
                "XMPP Communication error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1
            );
        }

        #endregion
    }
}
