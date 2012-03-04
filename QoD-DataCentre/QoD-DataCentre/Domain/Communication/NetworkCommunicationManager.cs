using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.IO;
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

        //TODO: Create listeners or something to be called upon sucessful disconnect & connect (whenever status is changed)

        internal bool isConnected;
        internal string client_id;
        internal string phone_id;
        internal HttpServer httpServer;

        private string connectionStatus = "";
        public string ConnectionStatus { get{return connectionStatus;} set {connectionStatus = value; write_connection_status(); } }

        public NetworkCommunicationManager(QoDForm main_Form, ConnectionSettings cs)
        {
            main_GUI = main_Form;
            connectionType = ConnectionType.XMPP;
            connectionSettings = cs;
            xmppClient = new XmppClient(this);
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

        public void Connect(string phoneID, int port){
            phone_id = phoneID;
            
            if (connectionType == ConnectionType.DirectSocket)
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
                    IPAddress ipAddress = Dns.GetHostAddresses("localhost")[1];
                    httpServer = new Src.Communication.MyHttpServer(ipAddress, port);

                    //print interna/external ips and port
                    populateDirectSocketIps(externalIp, internalIp, port);

                    Thread thread = new Thread(new ThreadStart(httpServer.listen));
                    thread.Start();

                    ConnectionStatus = "Waiting for incoming connections...";
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error starting server. Check the port is valid and try again.");
                }
            }
            else if (connectionType == ConnectionType.XMPP)
            {
                xmppClient.connect(phoneID);
                ConnectionStatus = "Connected to " + phoneID;
            }
            
            main_GUI.Invoke((MethodInvoker)delegate
            {
                main_GUI.enable_text_control();
            });
            
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

            if (connectionSettings.IsHandleCreated)
                connectionSettings.Invoke((MethodInvoker)delegate
                {
                    connectionSettings.populateDirectSocketIps(externalIp, internalIp, port);
                });
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
