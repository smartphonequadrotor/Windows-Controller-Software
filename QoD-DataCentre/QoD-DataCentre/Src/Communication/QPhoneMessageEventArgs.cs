using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QoD_DataCentre.Src.Communication
{
    class QPhoneMessageEventArgs : EventArgs
    {
        public String Message { get; set; }

        public QPhoneMessageEventArgs(String msg)
        {
            this.Message = msg;
        }
    }
}
