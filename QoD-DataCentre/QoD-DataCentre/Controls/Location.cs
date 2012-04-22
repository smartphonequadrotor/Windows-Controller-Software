using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QoD_DataCentre.Domain.JSON;

namespace QoD_DataCentre.Controls
{
    public partial class Location : UserControl
    {
        
        bool initialized = false;

        public Location()
        {
            InitializeComponent();
        }

        
        internal void InitializeControl()
        {
            initialized = true;
            flightOrientation1.InitializeControl();
        }

        public bool isInitialized()
        {
            return initialized;
        }

        internal void UpdateOrientation(JsonObjects.TriAxisResponse[] triAxisResponse)
        {
            flightOrientation1.UpdateOrientation(triAxisResponse);
        }
    }
}
