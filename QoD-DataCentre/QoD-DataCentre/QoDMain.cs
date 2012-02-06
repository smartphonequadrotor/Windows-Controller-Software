using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using QoD_DataCentre.Src.Communication;
using QoD_DataCentre.Src.UI;

namespace QoD_DataCentre
{
    static class QoDMain
    {
        /// <summary>
        /// A static instance of the network communication manager.
        /// </summary>
        public static NetworkCommunicationManager networkCommunicationManager;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            QoDForm mainForm = new QoDForm();
            networkCommunicationManager = new NetworkCommunicationManager(mainForm, mainForm.ConnectionSettings);
            QoDMain.networkCommunicationManager.msgRecieved += new Src.Communication.NetworkCommunicationManager.msgRecieve(mainForm.networkCommunicationManager_msgRecieved);
            Application.Run(mainForm);
            
        }

    }
}
