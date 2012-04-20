using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QoD_DataCentre.Domain.Controller;

namespace QoD_DataCentre.Controls
{
    public partial class ControlManager : Form
    {
        QoDForm parent;
        public ControlManager(QoDForm parent)
        {
            this.parent = parent;
            InitializeComponent();
            updateText(heightSource, heightControl, Controller.direction.HEIGHT);
            updateText(rollSource, rollControl, Controller.direction.ROLL);
            updateText(pitchSource, pitchControl, Controller.direction.PITCH);
            updateText(yawSource, yawControl, Controller.direction.YAW);
        }

        private void setHeight_Click(object sender, EventArgs e)
        {
            parent.configureHeightControl();
            updateText(heightSource, heightControl, Controller.direction.HEIGHT);
        }

        private void setRoll_Click(object sender, EventArgs e)
        {
            parent.configureRollControl();
            updateText(rollSource, rollControl, Controller.direction.ROLL);
        }

        private void setPitch_Click(object sender, EventArgs e)
        {
            parent.configurePitchControl();
            updateText(pitchSource, pitchControl, Controller.direction.PITCH);
        }

        private void setYaw_Click(object sender, EventArgs e)
        {
            parent.configureYawControl();
            updateText(yawSource, yawControl, Controller.direction.YAW);
        }

        private void ControlManager_KeyDown(object sender, KeyEventArgs e)
        {
            
            e.Handled = true;
        }

        private void updateText(Label source, Label control, Controller.direction direction)
        {
            ControllerInput.Type type = parent.getControl(direction).InputType;
            source.Text = type.ToString();
            if (type == ControllerInput.Type.AXIS)
                control.Text = parent.getControl(direction).InputAXIS.ToString();
            else if (type == ControllerInput.Type.BUTTON)
            {
                control.Text = parent.getControl(direction).InputButtonA.ToString();
                control.Text += ", ";
                control.Text += parent.getControl(direction).InputButtonB.ToString();
            }
            else if (type == ControllerInput.Type.KEYPRESS)
            {
                control.Text = parent.getControl(direction).InputKeyA.ToString();
                control.Text += ", ";
                control.Text += parent.getControl(direction).InputKeyB.ToString();
            }
        }
    }
}
