using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QoD_DataCentre.Domain.Controller;
using QoD_DataCentre.Domain.JSON;

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
            updateText(startKillSource, startKillControl, Controller.special.START_KILL);
            updateText(flightPIDSource, flightPIDControl, Controller.special.FLIGHT);
            updateText(altitudeSource, altitudeControl, Controller.special.ALTITUDE_CONTROL);
            flightOrientation1.InitializeControl();
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

        private void setStartKill_Click(object sender, EventArgs e)
        {
            parent.configureStartKillControl();
            updateText(startKillSource, startKillControl, Controller.special.START_KILL);
        }

        private void setFlightPID_Click(object sender, EventArgs e)
        {
            parent.configureFlightPIDControl();
            updateText(flightPIDSource, flightPIDControl, Controller.special.FLIGHT);
        }

        private void setAltitude_Click(object sender, EventArgs e)
        {
            parent.configureAltitude();
            updateText(altitudeSource, altitudeControl, Controller.special.ALTITUDE_CONTROL);
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

        private void updateText(Label source, Label control, Controller.special special)
        {
            ControllerInput.Type type = parent.getControl(special).InputType;
            source.Text = type.ToString();
            if (type == ControllerInput.Type.AXIS)
                control.Text = parent.getControl(special).InputAXIS.ToString();
            else if (type == ControllerInput.Type.BUTTON)
            {
                control.Text = parent.getControl(special).InputButtonA.ToString();
                control.Text += ", ";
                control.Text += parent.getControl(special).InputButtonB.ToString();
            }
            else if (type == ControllerInput.Type.KEYPRESS)
            {
                control.Text = parent.getControl(special).InputKeyA.ToString();
                control.Text += ", ";
                control.Text += parent.getControl(special).InputKeyB.ToString();
            }
        }

        public void updatePreview(JsonObjects.SetDesiredAngleCommand controller){
            JsonObjects.TriAxisResponse[] controllerInput = new JsonObjects.TriAxisResponse[1];
            controllerInput[0] = new JsonObjects.TriAxisResponse();
            controllerInput[0].X = controller.Roll;
            controllerInput[0].Y = controller.Pitch;
            controllerInput[0].Z = controller.Yaw;
            flightOrientation1.UpdateOrientation(controllerInput);
        }

        

    }
}
