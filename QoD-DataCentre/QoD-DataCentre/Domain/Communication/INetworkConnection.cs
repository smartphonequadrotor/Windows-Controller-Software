using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QoD_DataCentre.Src.Communication
{
    interface INetworkConnection
    {
        /// <summary>
        /// This method will deal with establishing the connection between the client and the server.
        /// </summary>
        /// <returns>True if the connection was successful and False otherwise.</returns>
        bool connect();
        
        /// <summary>
        /// This method will disconnect the client and the server.
        /// </summary>
        /// <returns>True if the connection was successfully disconnected and False otherwise.</returns>
        bool disconnect();

        /// <summary>
        /// This method will be responsible for sending a JSON packet (in the form of a string) to the 
        /// other end of this network connection.
        /// </summary>
        /// <param name="message">The JSON packet to the sent</param>
        /// <returns>True if the message was sent successfully and False otherwise</returns>
        bool writeMessage(String message);

        /// <summary>
        /// Subscribers of this event will be notified when a message is received from the other 
        /// end of this network connection.
        /// </summary>
        event EventHandler onMessageReceived;
    }
}
