using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.IO;
using QoD_DataCentre.Src.UI;
using QoD_DataCentre.Domain.JSON;
using QoD_DataCentre.Domain.Communication;

namespace QoD_DataCentre.Src.Communication
{
    /// <summary>
    /// The two types of connections that can be used.
    /// </summary>
    public enum ConnectionType { XMPP, DirectSocket, COM };

    

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
            private JsonObjects.Envelope JSONmessage;

            public JsonObjects.Envelope JSONMessage
            {
                get { return JSONmessage; }
                set { JSONmessage = value; }
            }
            public string Message { get { return message; } set { message = value;} }
            public MsgRecievedEventArgs(string message)
            {
                this.Message = message;
                this.JSONmessage = (new JsonManager()).DeserializeEnvelope(message);
            }
            public MsgRecievedEventArgs(JsonObjects.Envelope message)
            {
                this.JSONMessage = message;
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

        public class IPPopulationEventArgs : EventArgs
        {
            string externalIp;
            string internalIp;
            int port;
            

            public IPPopulationEventArgs(string externalIp, string internalIp, int port)
            {
                this.externalIp = externalIp;
                this.internalIp = internalIp;
                this.port = port;
            }

            public String ExternalIP { get { return externalIp;} }
            public String InternalIP { get { return internalIp; } }
            public int Port { get { return port; } }

        }
        


        //private QoDForm main_GUI;
        //private ConnectionSettings connectionSettings;
        private XmppClient xmppClient;
        private qcfp comClient;

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


        public delegate void IPsUpdateEvent(object sender, IPPopulationEventArgs data);

        public event IPsUpdateEvent IPsUpdated;


        internal bool isConnected;
        internal string client_id;
        internal string phone_id;
        internal MyHttpServer httpServer;

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
            connectionType = ConnectionType.XMPP;
            xmppClient = new XmppClient(this);
            comClient = new qcfp(32, this);
        }

        public void SendMessage(JsonObjects.Envelope message)
        {
            Console.WriteLine(message);
            if (connectionType == ConnectionType.DirectSocket)
            {
                httpServer.WritePOSTRequest(message.ToJSON());
            }
            else if (connectionType == ConnectionType.XMPP)
            {
                xmppClient.writeMessage(message.ToJSON());
            }
            else if (connectionType == ConnectionType.COM)
            {
                comClient.writeMessage(message);
            }
        }

        public void Connect(string phoneID, int port){
            phone_id = phoneID;
            
            if (connectionType == ConnectionType.DirectSocket)
            {
                
            }
            else if (connectionType == ConnectionType.XMPP)
            {
                
                xmppClient.connect(phoneID);
                ConnectionStatus = "Connected to " + phoneID;
            }
            else if (connectionType == ConnectionType.COM)
            {
                comClient.connect(port);
            }

            if (onConnect != null)
                onConnect(this, new EventArgs());

            isConnected = true;
        }

        public string getServerIp()
        {
            String ip = "";
            WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    ip = stream.ReadToEnd();
                }
            }

            //Search for the ip in the html
            int first = ip.IndexOf("Address: ") + 9;
            int last = ip.LastIndexOf("</body>");
            ip = ip.Substring(first, last - first);

            return ip;
        }

        public void populateDirectSocketIps(string externalIp, string internalIp, int port)
        {

            if (IPsUpdated != null)
                IPsUpdated(this, new IPPopulationEventArgs( externalIp, internalIp, port));

        }

        public HttpServer directSocketServerConnect( int port)
        {
            
            try
            {
                //get server's ip (external)
                string externalIp = getServerIp();
                
                //get server's ip (internal)/port
                IPAddress[] ips = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
                String internalIp = "";
                foreach (IPAddress ip in ips)
                {
                    if (ip.AddressFamily.ToString() == "InterNetwork")
                    {
                        internalIp = ip.ToString();
                        break;
                    }
                }
                populateDirectSocketIps(externalIp, internalIp, port);

                IPAddress[] ipAddresses = Dns.GetHostAddresses("localhost");
                httpServer = new Src.Communication.MyHttpServer(this, ipAddresses[0], port);

                //print interna/external ips and port
                
                return httpServer;
               
            }
            catch
            {
                return null;
            }

            
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
                httpServer.disconnect();
            }
            else if (connectionType == ConnectionType.XMPP)
            {
                xmppClient.disconnect();
            }
            else if (connectionType == ConnectionType.COM)
            {
                comClient.disconnect();
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


        internal void msgRecievedJSON(JsonObjects.Envelope newEnv)
        {
            this.msgRecieved(this, new MsgRecievedEventArgs(newEnv));
        }
    }
}
