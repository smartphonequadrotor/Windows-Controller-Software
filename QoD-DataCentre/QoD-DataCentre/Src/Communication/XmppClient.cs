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
        private QoDForm main_Form;

        public XmppClient(QoDForm main_form)
        {

            main_Form = main_form;
        }

        private bool is_connected = false;

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
        /// Tells whether an xmpp connection is established or not.
        /// </summary>
        public bool IS_CONNECTED
        {
            get { return is_connected; }
        }

        /// <summary>
        /// This is the client's connecting JID.
        /// </summary>
        public String JID
        {
            get { return Jabber_ID; }
            set { Jabber_ID = value; }
        }

        /// <summary>
        /// This is the partner's connecting JID.
        /// </summary>
        public String P_JID
        {
            get { return Partner_Jabber_ID; }
            set { Partner_Jabber_ID = value; }
        }

        /// <summary>
        /// This is the client's connecting Password.
        /// </summary>
        private String Jabber_Pass;

        /// <summary>
        /// This is password to the user's account.
        /// </summary>
        public String Password 
        {
            get { return Jabber_Pass; }
            set { Jabber_Pass = value; }
        }

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
        private ConnectionSettings connectionSettingsForm;
        
        #endregion

        #region INetworkConnection Members

        /// <summary>
        /// This method initiates a connection with the Jabber server. It also subscribes to the 
        /// OnMessage event of xmppCon.
        /// </summary>
        /// <param name="senderForm">The connection settings form whose status strip label needs to be updated</param>
        /// <returns>True if the connection was successful and false otherwise.</returns>
        public bool connect(ConnectionSettings connectionSettings)
        {
            
            connectionSettingsForm = connectionSettings;

            contact_num = 0;
            contact_dictionary = new Dictionary<string, int>();

            start_progress();

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
                xmpp.Open(jidSender.User, Password);
    
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                stop_progress();
                write_connection_status("Connection Failed!");
                return false;
            }

            return true;
        }

        

        private void start_progress()
        {
            //invoke start progress...
            if (connectionSettingsForm.IsHandleCreated)
            connectionSettingsForm.Invoke((MethodInvoker)delegate
            {
                connectionSettingsForm.start_progress();
            }); 
        }

        private void write_connection_status(String status)
        {
            //invoke start progress...
            if (connectionSettingsForm.IsHandleCreated)
            connectionSettingsForm.Invoke((MethodInvoker)delegate
            {
                connectionSettingsForm.write_connection_status(status);
            }); 
        }
        
        private void change_setupConnectionBtn_text(string text)
        {
            //invoke start progress...
            main_Form.Invoke((MethodInvoker)delegate
            {
                main_Form.change_setupConnectionBtn_text(text);
            });
        }

        private void change_connectionText_text(string text)
        {
            //invoke start progress...
            main_Form.Invoke((MethodInvoker)delegate
            {
                main_Form.change_connectionText_text(text);
            });
        } 

        private void stop_progress()
        {
            //invoke start progress...
            if (connectionSettingsForm.IsHandleCreated)
            connectionSettingsForm.Invoke((MethodInvoker)delegate
            {
                connectionSettingsForm.stop_progress();
            });
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

            stop_progress();
            write_connection_status("Connected to server!");
        }

        // Is called, if the precence of a roster contact changed        
        void xmpp_OnPresence(object sender, Presence pres)
        {
            Console.WriteLine("Available Contacts: ");
            Console.WriteLine(pres.From.User + "@" + pres.From.Server + "  " + pres.Type);
            Console.WriteLine();

            if(pres.Type.ToString() == "available"){
                if(!is_connected)
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
                }
            }
            
            
            write_contact_list();
            
        }

        public void set_connected()
        {
            is_connected = true;
            foreach (KeyValuePair<string, int> pair in contact_dictionary)
                if(pair.Key != Partner_Jabber_ID)
                    xmpp.MessageGrabber.Remove(new Jid(pair.Key));
            //ignore all other msg requests while connected.
            

            
        }

        void write_contact_list()
        {
            //invoke start progress...
            if(connectionSettingsForm.IsHandleCreated)
            connectionSettingsForm.Invoke((MethodInvoker)delegate
            {
                connectionSettingsForm.write_contact_list(contact_dictionary);
            }); 
        }

        //Handles incoming messages
        void MessageCallBack(object sender, agsXMPP.protocol.client.Message msg, object data)
        {
            Console.Out.WriteLine(msg.From.User + '@' + msg.From.Server+">"+msg.Body);
            if (msg.Body != null && msg.From.User+'@'+msg.From.Server == Partner_Jabber_ID)
            {
                write_msg_to_text_control(msg.Body);
            }
        }

        void write_msg_to_text_control(String text)
        {
            //invoke start progress...
                main_Form.Invoke((MethodInvoker)delegate
                {
                    main_Form.insert_write_to_text_control(Partner_Jabber_ID+">"+text+"\r\n");
                });
        }
        

        /// <summary>
        /// This method disconnects this client from the Jabber server.
        /// </summary>
        /// <returns>True if the connection was closed successfully and false otherwise.</returns>
        public bool disconnect()
        {
            Partner_Jabber_ID = null;
            is_connected = false;
            change_connectionText_text("Not Connected");
            change_setupConnectionBtn_text("Setup Connection");

            //add listeners for all in dictionary.
            if (xmpp != null)
            {
                xmpp.MessageGrabber.Clear();
                foreach (KeyValuePair<string, int> pair in contact_dictionary)
                    xmpp.MessageGrabber.Add(new Jid(pair.Key),
                                         new BareJidComparer(),
                                         new MessageCB(MessageCallBack),
                                         null);
            }
            main_Form.Invoke((MethodInvoker)delegate
            {
                main_Form.disable_text_control();
            });
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
            System.Windows.Forms.MessageBox.Show
            (
                ex.Message,
                "XMPP Communication error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1
            );
            Console.Out.WriteLine("connection error: " + ex.Message);
            stop_progress();
            write_connection_status("Connection Failed!");
        }

        /// <summary>
        /// This reports errors to the user through a message box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ex"></param>
        void xmppCon_OnSocketError(object sender, Exception ex)
        {
            MessageBox.Show
                (
                    "Failed to connect to xmpp server",
                    "Connection Failure",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1
                );
            Console.Out.WriteLine("socket exception: " + ex.Message);
            stop_progress();
            write_connection_status("Connection Failed!");
            change_connectionText_text("Not Connected");
            change_setupConnectionBtn_text("Setup Connection");
        }

        /// <summary>
        /// This reports errors to the user through a message box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ex"></param>
        void xmpp_OnAuthError(object sender, agsXMPP.Xml.Dom.Element e)
        {
            MessageBox.Show
                (
                    "Failed to authorize!",
                    "Connection Failure",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1
                );
            Console.Out.WriteLine("authorization exception: " + e.Value);
            stop_progress();
            write_connection_status("Authorization Failed!");
            change_connectionText_text("Not Connected");
            change_setupConnectionBtn_text("Setup Connection");
        }
        #endregion
    }
}
