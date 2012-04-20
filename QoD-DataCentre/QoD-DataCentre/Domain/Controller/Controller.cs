using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SdlDotNet.Core;
using SdlDotNet.Input;
using System.Timers;
using QoD_DataCentre.Domain.JSON;
using System.Windows.Forms;
using System.Runtime.InteropServices;



namespace QoD_DataCentre.Domain.Controller
{

    public class ControllerInput
    {

        [DllImport("user32.dll")]
        static extern ushort GetAsyncKeyState(System.Windows.Forms.Keys vKey); 

        private static float AXIS_SCALE = 2;
        private static float BUTTON_SCALE = 0.5f;
        private static float KEY_SCALE = 0.5f; 
        private static float JOYSTICK_CENTER = 0.5f;
        private static float JOYSTICK_AXIS_THRESHOLD = 0.1f;

        public enum Type { AXIS, BUTTON, KEYPRESS}
        private Type inputType;
        private JoystickAxis inputAXIS;
        private int inputButtonA;
        private int inputButtonB;
        private Keys inputKeyA;
        private Keys inputKeyB;
        

        public JoystickAxis InputAXIS
        {
            get { return inputAXIS; }
            set { inputAXIS = value; }
        }

        public int InputButtonA
        {
            get { return inputButtonA; }
            set { inputButtonA = value; }
        }

        public int InputButtonB
        {
            get { return inputButtonB; }
            set { inputButtonB = value; }
        }

        public Keys InputKeyA
        {
            get { return inputKeyA; }
            set { inputKeyA = value; }
        }

        public Keys InputKeyB
        {
            get { return inputKeyB; }
            set { inputKeyB = value; }
        }

        public Type InputType
        {
            get { return inputType; }
            set { inputType = value; }
        }

        public ControllerInput( JoystickAxis input)
        {
            inputType = Type.AXIS;
            inputAXIS = input;
        }

        public ControllerInput( int a, int b)
        {
            inputType = Type.AXIS;
            inputButtonA = a;
            inputButtonB = b;
        }

        public ControllerInput(Keys a, Keys b)
        {
            inputType = Type.KEYPRESS;
            inputKeyA = a;
            inputKeyB = b;
        }

        public ControllerInput()
        {

        }

        public float getControlState(Joystick J)
        {
            if (J != null && inputType == Type.AXIS)
            {
                float axis = J.GetAxisPosition(inputAXIS) - JOYSTICK_CENTER;
                if (Math.Abs(axis) > JOYSTICK_AXIS_THRESHOLD)
                    return AXIS_SCALE * axis;
                else
                    return 0;
            }
            else if (J != null && inputType == Type.BUTTON)
            {
                float button = 0;
                if (J.GetButtonState(inputButtonA) == ButtonKeyState.Pressed)
                    button -= 1.0f;
                if (J.GetButtonState(inputButtonB) == ButtonKeyState.Pressed)
                    button += 1.0f;

                return BUTTON_SCALE * button;
            }
            else if (inputType == Type.KEYPRESS)
            {
                float button = 0;
                if (GetAsyncKeyState(inputKeyA) != 0)
                    button -= 1.0f;
                if (GetAsyncKeyState(inputKeyB) != 0)
                    button += 1.0f;

                return KEY_SCALE * button;
            }
            else
                return 0;
        }

        public void AssignControllerInput(Joystick J)
        {
            if (J != null)
            {
                for (int i = 0; i < J.NumberOfAxes; i++)
                {
                    float axis = J.GetAxisPosition((JoystickAxis)i) - JOYSTICK_CENTER;
                    if (Math.Abs(axis) > JOYSTICK_AXIS_THRESHOLD)
                    {
                        this.inputAXIS = (JoystickAxis)i;
                        this.inputType = Type.AXIS;
                        return;
                    }
                }
                bool button = false;
                for (int i = 0; i < J.NumberOfButtons; i++)
                {

                    if (J.GetButtonState(i) == ButtonKeyState.Pressed)
                    {
                        if (button)
                        {
                            this.inputType = Type.BUTTON;
                            this.inputButtonB = i;
                            return;
                        }

                        this.inputButtonA = i;
                        button = true;
                    }
                }

            }
            bool key = false;
            Array keys = Enum.GetValues(typeof(Keys));
            for (int i = 0; i < keys.Length; i++)
            {
                while (i < keys.Length && (((Keys)(keys.GetValue(i))).ToString().Contains("LButton")))
                    i++;

                if (i == keys.Length)
                    break;

                ushort state = GetAsyncKeyState((Keys)keys.GetValue(i));
                if ( state != 0)
                {
                    if (key)
                    {
                        this.inputType = Type.KEYPRESS;
                        this.inputKeyB = (Keys)keys.GetValue(i);
                        return;
                    }

                    this.inputKeyA = (Keys)keys.GetValue(i);
                    key = true;
                }
            }

        }
    }

    class Controller
    {
        private bool noJoy = false;

        private bool userControlsEnabled = false;
        public bool Enabled
        {
            get { return userControlsEnabled; }
        }


        public enum direction {HEIGHT, ROLL, PITCH, YAW} 

        private ControllerInput[] controllerMapping;
        private float[] controllerValues;

        private static double SDL_POLL_INTERVAL = 500; // in ms
        private static float INPUT_TIMEOUT = 750;
        
        private static float MAX_HEIGHT_CHANGE = 20;
        private static float MAX_YAW_CHANGE = (float)(Math.PI / 12.0f);
        private static float MAX_PLANAR_CHANGE = ((float)Math.PI / 12.0f);
        

        private Joystick j = null;
        private System.Timers.Timer sdlTimer, inputTimer;

        public Controller()
        {
            sdlTimer = new System.Timers.Timer(SDL_POLL_INTERVAL);
            inputTimer = new System.Timers.Timer(INPUT_TIMEOUT);
            inputTimer.AutoReset = false;
            inputTimer.Elapsed += new ElapsedEventHandler(keyTimer_Elapsed);
            sdlTimer.Elapsed += new ElapsedEventHandler(sdlTimer_Elapsed);
            sdlTimer.Enabled = false;

            //we have 4 direction indexes... Height, Roll, Pitch, and Yaw
            controllerMapping = new ControllerInput[4];
            controllerValues = new float[4];

            controllerMapping[(int)direction.HEIGHT] = new ControllerInput(JoystickAxis.Axis4);
            controllerMapping[(int)direction.ROLL] = new ControllerInput(JoystickAxis.Horizontal);
            controllerMapping[(int)direction.PITCH] = new ControllerInput(JoystickAxis.Vertical);
            controllerMapping[(int)direction.YAW] = new ControllerInput(JoystickAxis.Axis3);
        }

        void keyTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            JsonObjects.Envelope jsonToSendEnvelope = new JsonObjects.Envelope();

            jsonToSendEnvelope.Commands = new JsonObjects.Commands();
            jsonToSendEnvelope.Commands.HRPY = new JsonObjects.SetDesiredAngleCommand[1];
            jsonToSendEnvelope.Commands.HRPY[0] = new JsonObjects.SetDesiredAngleCommand(0,0,0,0);

            QoDMain.networkCommunicationManager.SendMessage(jsonToSendEnvelope);
        }

        void sdlTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // if timer is enabled, j should not be null
            if ((j != null || noJoy) && userControlsEnabled)
            {
                if (!noJoy)
                {
                    // Get joystick state
                    SdlDotNet.Core.Events.Poll();
                }

                for (int i = 0; i < controllerMapping.Length; i++)
                {
                    controllerValues[i] = controllerMapping[i].getControlState(j);
                }

                if (controllerValues[(int)direction.HEIGHT] != 0 ||
                    MAX_PLANAR_CHANGE * controllerValues[(int)direction.ROLL] != 0 ||
                    MAX_PLANAR_CHANGE * controllerValues[(int)direction.PITCH] != 0 ||
                    MAX_YAW_CHANGE * controllerValues[(int)direction.YAW] != 0)
                {
                    inputTimer.Enabled = false;
                    JsonObjects.Envelope jsonToSendEnvelope = new JsonObjects.Envelope();

                    jsonToSendEnvelope.Commands = new JsonObjects.Commands();
                    jsonToSendEnvelope.Commands.HRPY = new JsonObjects.SetDesiredAngleCommand[1];
                    jsonToSendEnvelope.Commands.HRPY[0] = new JsonObjects.SetDesiredAngleCommand(
                        (int)(-MAX_HEIGHT_CHANGE*controllerValues[(int)direction.HEIGHT]),
                        -MAX_PLANAR_CHANGE * controllerValues[(int)direction.ROLL],
                        MAX_PLANAR_CHANGE * controllerValues[(int)direction.PITCH],
                        MAX_YAW_CHANGE * controllerValues[(int)direction.YAW]);

                    QoDMain.networkCommunicationManager.SendMessage(jsonToSendEnvelope);

                    inputTimer.Enabled = true;
                }
            }
        }

        public void Dispose()
        {
            sdlTimer.Enabled = false;
            if (j != null)
            {
                j.Dispose();
                j = null;
            }
        }

        internal void Enable()
        {
            userControlsEnabled = true;
            try
            {
                if (j == null && !noJoy)
                {
                    try
                    {
                        j = Joysticks.OpenJoystick(0);
                    }
                    catch
                    {
                        noJoy = true;
                    }
                    sdlTimer.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to open a joystick.");
                Console.WriteLine(ex.Message);
            }
        }

        internal void Disable()
        {
            userControlsEnabled = false;
            sdlTimer.Enabled = false;
            if (j != null)
            {
                j.Dispose();
                j = null;
            }
        }

        internal void ReAssignInput(direction index)
        {
            if (j == null && !noJoy)
            {
                try
                {
                    j = Joysticks.OpenJoystick(0);
                }
                catch
                {
                    noJoy = true;
                }
                sdlTimer.Enabled = true;
            }
            SdlDotNet.Core.Events.Poll();
            controllerMapping[(int)index].AssignControllerInput(j);
        }


        internal ControllerInput FetchControl(direction index)
        {
            return controllerMapping[(int)index];
        }
    }
}
