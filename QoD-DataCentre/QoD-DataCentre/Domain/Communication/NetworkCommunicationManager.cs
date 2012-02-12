using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QoD_DataCentre.Src.UI;


namespace QoD_DataCentre.Src.Communication
{
    /// <summary>
    /// The two types of connections that can be used.
    /// </summary>
    public enum ConnectionType { XMPP, DirectSocket };

    

    /// <summary>
    /// This class is used by the UI and the business logic for sending messages to and receiving messages from
    /// the QPhone.
    /// </summary>
    public class NetworkCommunicationManager
    {

        public ConnectionType connectionType { get; set; }

        public class MsgRecievedEventArgs : EventArgs
        {
            private string message;
            public string Message { get { return message; } set { message = value;} }
            public MsgRecievedEventArgs(string message)
            {
                this.Message = message;
            }
        }

        public class StatusEventArgs : EventArgs
        {
            private string status;
            public string Status { get { return status; } set { status = value; } }
            public StatusEventArgs(string status)
            {
                this.status = status;
            }
        }

        public class XmppContactEventArgs : EventArgs
        {
            Dictionary<string, int> contacts;
            public Dictionary<string, int> Contacts { get { return contacts; } set { contacts = value; } }
            public XmppContactEventArgs(Dictionary<string, int> contacts)
            {
                this.contacts = contacts;
            }
        }

        

        //private QoDForm main_GUI;
        //private ConnectionSettings connectionSettings;
        private XmppClient xmppClient;
        private DirectSocketServer directSocketServer;

        //msg recieved
        public delegate void msgRecieveEvent(object sender, MsgRecievedEventArgs data);

        //called when message is recieved...
        public event msgRecieveEvent msgRecieved;

        //connect event
        public delegate void connectEvent(object sender, EventArgs data);

        //called when a connection is setup...
        public event connectEvent onConnect;

        //disconnect event
        public delegate void disconnectEvent(object sender, EventArgs data);

        //called when a connection is disconnected
        public event disconnectEvent onDisconnect;

        //status event
        public delegate void statusEvent(object sender, StatusEventArgs data);

        //called when a connection status changes
        public event statusEvent onStatusChanged;

        //start busyness event
        public delegate void busyEvent(object sender, EventArgs data);

        //called when connecting...
        public event busyEvent onWorking;

        //called when now idle
        public event busyEvent onIdle;


        public delegate void xmppContactEvent(object sender, XmppContactEventArgs data);


        public event xmppContactEvent xmppContactsUpdated;

        //TODO: Create listeners or something to be called upon sucessful disconnect & connect (whenever status is changed)

        internal bool isConnected;
        internal string client_id;
        internal string phone_id;

        private string connectionStatus = "";
        public string ConnectionStatus
        {
            get { return connectionStatus; }
            set
            {
                connectionStatus = value; 
                if (onStatusChanged != null)
                {
                    onStatusChanged(this, new StatusEventArgs(value));
                }
            }
        }

        public NetworkCommunicationManager()
        {
            //main_GUI = main_Form;
            connectionType = ConnectionType.XMPP;
            xmppClient = new XmppClient(this);
            //directSocketServer = new DirectSocketServer(this);
        }

        public void SendMessage(string message)
        {

            if (connectionType == ConnectionType.DirectSocket)
            {

            }
            else if (connectionType == ConnectionType.XMPP)
            {
                xmppClient.writeMessage(message);
            }

        }

        public void Connect(string phoneID){
            phone_id = phoneID;
            
            if (connectionType == ConnectionType.DirectSocket)
            {

            }
            else if (connectionType == ConnectionType.XMPP)
            {
                
                xmppClient.connect(phoneID);
            }

            if (onConnect != null)
                onConnect(this, new EventArgs());

            isConnected = true;
            ConnectionStatus = "Connected To: " + phoneID;
        }

        public bool xmppUserConnect(string username, string password)
        {
            client_id = username;
            return xmppClient.login(username, password);
        }

        public void Disconnect()
        {
            

            if (connectionType == ConnectionType.DirectSocket)
            {

            }
            else if (connectionType == ConnectionType.XMPP)
            {
                xmppClient.disconnect();
                
            }
            
            disconnectCallback();

        }

        internal void disconnectCallback()
        {
            ConnectionStatus = "Not Connected.";
            isConnected = false;
            client_id = null;
            phone_id = null;

            if (onDisconnect != null)
                onDisconnect(this, new EventArgs());
        }     

        public void RecieveMessage(string message)
        {
            if(msgRecieved != null)
                msgRecieved(this, new MsgRecievedEventArgs(message));   
        }
        
        internal void FatalConnectionError(string error)
        {
            MessageBox.Show
                (
                    "Connection Failure: "+error,
                    "Connection Failure",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1
                );
            Console.Out.WriteLine(error);
        }

        internal void start_progress()
        {
            if(onWorking != null)
                onWorking(this, new EventArgs());
        }


        internal void stop_progress()
        {
            //invoke start progress...
            if (onIdle != null)
                onIdle(this, new EventArgs());
        }

        internal void updateContacts()
        {
            if (xmppContactsUpdated != null)
                xmppContactsUpdated(this, new XmppContactEventArgs(xmppClient.USER_DICTIONARY));
        }
        
        internal Dictionary<string, int> getXmppUsers()
        {
            return xmppClient.USER_DICTIONARY;
        }
        
    }
}
