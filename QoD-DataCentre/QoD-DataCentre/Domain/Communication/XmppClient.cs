using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using agsXMPP;
using agsXMPP.protocol.client;
using agsXMPP.Collections;
using agsXMPP.protocol.iq.roster;
using System.Windows.Forms;
using QoD_DataCentre.Src.UI;
using System.Threading;


namespace QoD_DataCentre.Src.Communication
{
    class XmppClient// : INetworkConnection
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public XmppClient()
        {

        }
        


        public XmppClient(NetworkCommunicationManager networkCommunicationManager)
        {
            contact_dictionary = new Dictionary<string, int>();
            this.networkCommunicationManager = networkCommunicationManager;
        }

        

        /// <summary>
        /// Dictionary to contain possible contacts. 
        /// </summary>
        private Dictionary<string, int> contact_dictionary;

        /// <summary>
        /// current contact number;
        /// </summary>
        private int contact_num;

        /// <summary>
        /// This is the username of the QPhone's account on the Jabber server.
        /// </summary>
        public Dictionary<string, int> USER_DICTIONARY
        {
            get{return contact_dictionary;}
            
        }

        /// <summary>
        /// XmppCLientConnection Instance. 
        /// </summary>
        private XmppClientConnection xmpp;

        #region Connection Parameters
        
        /// <summary>
        /// This is the client's connecting JID.
        /// </summary>
        private String Jabber_ID;

        /// <summary>
        /// This is the partners's connecting JID.
        /// </summary>
        private String Partner_Jabber_ID;

        

        /// <summary>
        /// Not Implemented
        /// </summary>
        public String Server 
        {
            get { return "Not Implemented"; }
        }

       

        #endregion

        #region UI related variables

        /// <summary>
        /// This reference to the connectionSettings form is required to update it.
        /// </summary>
        private NetworkCommunicationManager networkCommunicationManager;
        
        #endregion

        #region INetworkConnection Members

        /// <summary>
        /// This method initiates a connection with the Jabber server. It also subscribes to the 
        /// OnMessage event of xmppCon.
        /// </summary>
        /// <param name="senderForm">The connection settings form whose status strip label needs to be updated</param>
        /// <returns>True if the connection was successful and false otherwise.</returns>
        public bool login(string username, string password)
        {
            Jabber_ID = username;
            
            contact_num = 0;
            contact_dictionary = new Dictionary<string, int>();

            networkCommunicationManager.start_progress();

             /*
             * Creating the Jid and the XmppClientConnection objects
             */
            Jid jidSender = new Jid(Jabber_ID);
            xmpp = new XmppClientConnection(jidSender.Server);

            /*
             * Open the connection
             * and register the OnLogin event handler
             */
            try
            {
                xmpp.OnError += new ErrorHandler(xmppCon_OnError);
                xmpp.OnSocketError += new ErrorHandler(xmppCon_OnSocketError);
                xmpp.OnLogin += new ObjectHandler(xmpp_OnLogin);
                xmpp.OnAuthError += new XmppElementHandler(xmpp_OnAuthError);
                xmpp.Open(jidSender.User, password);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                networkCommunicationManager.stop_progress();
                networkCommunicationManager.ConnectionStatus = "Connection Failed!";
                return false;
            }

            return true;
        }

        

        

        

        public void send_precence()
        {
            Console.WriteLine("Sending Precence");
            Presence p = new Presence(ShowType.chat, "Online");
            p.Type = PresenceType.available;
            xmpp.Send(p);
            Console.WriteLine();
        }

        void xmpp_OnLogin(object sender)
        {
            
            Console.WriteLine("Login Status:");
            Console.WriteLine("xmpp Connection State {0}", xmpp.XmppConnectionState);
            Console.WriteLine("xmpp Authenticated? {0}", xmpp.Authenticated);
            Console.WriteLine();
            send_precence();

            /*
            * 
            * get the roster (see who's online)
            */
            xmpp.OnPresence += new PresenceHandler(xmpp_OnPresence);
            

            //wait until we received the list of available contacts            
            Console.WriteLine();
            Thread.Sleep(500);

            networkCommunicationManager.stop_progress();
            networkCommunicationManager.ConnectionStatus = "Connected to XMPP server.";

        }

        // Is called, if the precence of a roster contact changed        
        void xmpp_OnPresence(object sender, Presence pres)
        {
            Console.WriteLine("Available Contacts: ");
            Console.WriteLine(pres.From.User + "@" + pres.From.Server + "  " + pres.Type);
            Console.WriteLine();

            if(pres.Type.ToString() == "available"){
                if(!networkCommunicationManager.isConnected)
                xmpp.MessageGrabber.Add(new Jid(pres.From.User + '@' + pres.From.Server),
                                     new BareJidComparer(),
                                     new MessageCB(MessageCallBack),
                                     null);
                if(!contact_dictionary.ContainsKey(pres.From.User + '@' + pres.From.Server))
                    contact_dictionary.Add(pres.From.User + '@' + pres.From.Server, ++contact_num);
            }
            else if (pres.Type.ToString() == "unavailable")
            {
                xmpp.MessageGrabber.Remove(new Jid(pres.From.User + '@' + pres.From.Server));
                contact_dictionary.Remove(pres.From.User + '@' + pres.From.Server);
                if (Partner_Jabber_ID != null && Partner_Jabber_ID == pres.From.User + '@' + pres.From.Server){
                    disconnect();
                    networkCommunicationManager.disconnectCallback();
                }
            }
            
            
            networkCommunicationManager.write_contact_list();
            
        }

        public void connect(string partnerID)
        {
            if (Partner_Jabber_ID != null && Partner_Jabber_ID != partnerID)
            {
                xmpp.MessageGrabber.Add(new Jid(partnerID),
                                     new BareJidComparer(),
                                     new MessageCB(MessageCallBack),
                                     null);
            }

            Partner_Jabber_ID = partnerID;
            
            foreach (KeyValuePair<string, int> pair in contact_dictionary)
                if(pair.Key != Partner_Jabber_ID)
                    xmpp.MessageGrabber.Remove(new Jid(pair.Key));          
        }

        

        //Handles incoming messages
        void MessageCallBack(object sender, agsXMPP.protocol.client.Message msg, object data)
        {
            Console.Out.WriteLine(msg.From.User + '@' + msg.From.Server+">"+msg.Body);
            if (msg.Body != null && msg.From.User+'@'+msg.From.Server == Partner_Jabber_ID)
            {
                networkCommunicationManager.RecieveMessage(msg.Body);
            }
        }

        
        

        /// <summary>
        /// This method disconnects this client from the Jabber server.
        /// </summary>
        /// <returns>True if the connection was closed successfully and false otherwise.</returns>
        public bool disconnect()
        {
            Partner_Jabber_ID = null;
            Jabber_ID = null;

            if(contact_dictionary != null)
                contact_dictionary.Clear();

            try
            {
                xmpp.Close();
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
            xmpp.Send(new agsXMPP.protocol.client.Message(new Jid(Partner_Jabber_ID), MessageType.chat, message));
            return true;
        }

        #endregion

        #region Helper methods

        
        /// <summary>
        /// This reports errors to the user through a message box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ex"></param>
        void xmppCon_OnError(object sender, Exception ex)
        {
            networkCommunicationManager.FatalConnectionError("XMPP Error!");
            networkCommunicationManager.stop_progress();
            networkCommunicationManager.ConnectionStatus = "Connection Failed!";
        }

        /// <summary>
        /// This reports errors to the user through a message box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ex"></param>
        void xmppCon_OnSocketError(object sender, Exception ex)
        {
            networkCommunicationManager.stop_progress();
            networkCommunicationManager.ConnectionStatus = "Connection Failed!";
            networkCommunicationManager.FatalConnectionError("Socket Error!");
            disconnect();
        }

        

        /// <summary>
        /// This reports errors to the user through a message box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ex"></param>
        void xmpp_OnAuthError(object sender, agsXMPP.Xml.Dom.Element e)
        {

            networkCommunicationManager.stop_progress();
            networkCommunicationManager.ConnectionStatus = "Authorization Failed!";
            networkCommunicationManager.FatalConnectionError("Authorization Error!");
            disconnect();
        }
        #endregion
    }
}
