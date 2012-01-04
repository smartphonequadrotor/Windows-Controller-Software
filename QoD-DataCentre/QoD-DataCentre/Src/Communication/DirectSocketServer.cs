using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QoD_DataCentre.Src.Communication
{
    class DirectSocketServer : INetworkConnection
    {
        #region INetworkConnection Members

        public bool connect()
        {
            throw new NotImplementedException();
        }

        public bool disconnect()
        {
            throw new NotImplementedException();
        }

        public bool writeMessage(string message)
        {
            throw new NotImplementedException();
        }

        public event EventHandler onMessageReceived;

        #endregion
    }
}
