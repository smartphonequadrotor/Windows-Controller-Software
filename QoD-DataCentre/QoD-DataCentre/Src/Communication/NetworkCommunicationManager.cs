using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace QoD_DataCentre.Src.Communication
{
    /// <summary>
    /// The two types of connections that can be used.
    /// </summary>
    enum ConnectionType { XMPP, DirectSocket };

    /// <summary>
    /// This class is used by the UI and the business logic for sending messages to and receiving messages from
    /// the QPhone.
    /// </summary>
    class NetworkCommunicationManager
    {
        public XmppClient xmppClient;
        public DirectSocketServer directSocketServer;
        
        

        public NetworkCommunicationManager()
        {
            xmppClient = new XmppClient();
            directSocketServer = new DirectSocketServer();
        }

        public NetworkCommunicationManager(QoDForm main_Form)
        {
            xmppClient = new XmppClient(main_Form);
            directSocketServer = new DirectSocketServer();
        }


        public ConnectionType connectionType { get; set; }

    }
}
