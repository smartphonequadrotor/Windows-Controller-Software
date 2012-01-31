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
    enum ConnectionType { XMPP, DirectSocket };

    /// <summary>
    /// This class is used by the UI and the business logic for sending messages to and receiving messages from
    /// the QPhone.
    /// </summary>
    class NetworkCommunicationManager
    {
        private QoDForm main_GUI;
        private ConnectionSettings connectionSettings;
        private XmppClient xmppClient;
        private DirectSocketServer directSocketServer;

        //TODO: Create listeners or something to be called upon sucessful disconnect & connect (whenever status is changed)

        internal bool isConnected;
        internal string client_id;
        internal string phone_id;

        private string connectionStatus = "";
        public string ConnectionStatus { get{return connectionStatus;} set {connectionStatus = value; write_connection_status(); } }

        public NetworkCommunicationManager()
        {
            xmppClient = new XmppClient();
            directSocketServer = new DirectSocketServer();
        }

        public NetworkCommunicationManager(QoDForm main_Form, ConnectionSettings cs)
        {

            main_GUI = main_Form;
            connectionSettings = cs;
            xmppClient = new XmppClient(this);
            directSocketServer = new DirectSocketServer();
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
            
            main_GUI.Invoke((MethodInvoker)delegate
            {
                main_GUI.enable_text_control();
            });
            
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
            main_GUI.Invoke((MethodInvoker)delegate
            {
                main_GUI.disable_text_control();
            });
        }

        

        internal void change_connectionText_text(string text)
        {
            //invoke start progress...
            main_GUI.Invoke((MethodInvoker)delegate
            {
                main_GUI.change_connectionText_text(text);
            });
        }

        public void RecieveMessage(string message)
        {
            write_msg_to_text_control(message);
            
        }

        internal void write_msg_to_text_control(String text)
        {
            //invoke start progress...
            main_GUI.Invoke((MethodInvoker)delegate
            {
                main_GUI.insert_write_to_text_control(phone_id + ">" + text + "\r\n");
            });
        }

        public ConnectionType connectionType { get; set; }


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
            //invoke start progress...
            if (connectionSettings.IsHandleCreated)
                connectionSettings.Invoke((MethodInvoker)delegate
                {
                    connectionSettings.start_progress();
                });
        }

        private void write_connection_status()
        {
            //invoke start progress...
            if (connectionSettings.IsHandleCreated)
                connectionSettings.Invoke((MethodInvoker)delegate
                {
                    connectionSettings.write_connection_status();
                });

            change_connectionText_text(ConnectionStatus);
        }



        internal void stop_progress()
        {
            //invoke start progress...
            if (connectionSettings.IsHandleCreated)
                connectionSettings.Invoke((MethodInvoker)delegate
                {
                    connectionSettings.stop_progress();
                });
        }

        internal void write_contact_list()
        {
            //invoke start progress...
            if (connectionSettings.IsHandleCreated)
                connectionSettings.Invoke((MethodInvoker)delegate
                {
                    connectionSettings.write_contact_list(xmppClient.USER_DICTIONARY);
                });
        }

        internal Dictionary<string, int> getXmppUsers()
        {
            return xmppClient.USER_DICTIONARY;
        }

        
    }
}
