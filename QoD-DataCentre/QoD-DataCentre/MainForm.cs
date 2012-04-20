using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using System.IO;
using System.Drawing.Text;
using QoD_DataCentre.Src.UI;
using QoD_DataCentre.Domain.JSON;
using QoD_DataCentre.Src.Communication;
using QoD_DataCentre.Domain.Controller;
using QoD_DataCentre.Controls;


enum TabName
{
    Welcome = 1,
    Location,
    Statistics,
    LiveFeed,
    TextControl,
    Plugins
}

namespace QoD_DataCentre
{
    public partial class QoDForm : Form
    {
       

        delegate void UpdateTimerCallback();

        private ConnectionSettings connectionSettings;
        private System.Timers.Timer timer;
        private long connectionTime;
        private long flightTime;
        private bool connected;
        private bool flying;

        private ControlManager controlManager;
        private Controller controller;

        public ConnectionSettings ConnectionSettings
        {
            get { return connectionSettings; }
        }

        public QoDForm()
        {
            connectionSettings = new ConnectionSettings(this);
            
            QoDMain.networkCommunicationManager.msgRecieved += new Src.Communication.NetworkCommunicationManager.msgRecieveEvent(this.networkCommunicationManager_msgRecieved);
            QoDMain.networkCommunicationManager.onConnect += new NetworkCommunicationManager.connectEvent(networkCommunicationManager_onConnect);
            QoDMain.networkCommunicationManager.onDisconnect += new NetworkCommunicationManager.disconnectEvent(networkCommunicationManager_onDisconnect);
            QoDMain.networkCommunicationManager.onStatusChanged += new NetworkCommunicationManager.statusEvent(networkCommunicationManager_onStatusChanged);

            timer = new System.Timers.Timer(1000);

            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Enabled = true;

            timer.Stop();

            connectionTime = 0;
            flightTime = 0;

            connected = false;
            flying = false;


            controller = new Controller();
            controlManager = new ControlManager(this);
            // If the timer is declared in a long-running method, use
            // KeepAlive to prevent garbage collection from occurring
            // before the method ends.
            //GC.KeepAlive(timer); 
            InitializeComponent();
        }

        ~QoDForm()
        {
            controller.Dispose();
        }

        // Specify what you want to happen when the Elapsed event is 
        // raised.
        void OnTimedEvent(object source, ElapsedEventArgs e)
        {   
            if (connected)
            {
                connectionTime++;
            }

            if (flying)
            {
                flightTime++;
            }

            updateTime();
		}

        public void updateTime()
        {
            if (connected)
            {
                if (connectionTimerLbl.InvokeRequired)
                {
                    UpdateTimerCallback d = new UpdateTimerCallback(updateTime);
                    this.Invoke(d, new object[] { });
                }
                else
                {
                    connectionTimerLbl.Text = convertToTimeString(connectionTime);
                }
            }

            if (flying)
            {
                if (statistics1.flightTimeValue.InvokeRequired)
                {
                    UpdateTimerCallback d = new UpdateTimerCallback(updateTime);
                    this.Invoke(d, new object[] { });
                }
                else
                {
                    statistics1.flightTimeValue.Text = convertToTimeString(flightTime);
                }
            }
        }

        public string convertToTimeString(long time)
        {
            //if less than a minute, can parse out directly
            if (time < 60)
            {
                if (time < 10)
                {
                    if (time == 0)
                    {
                        return "00:00:00";
                    }
                    else
                    {
                        return "00:00:0" + time;
                    }
                }
                else
                {
                    return "00:00:" + time;
                }
            }
            else
            {
                //divide by 60 to get minutes
                decimal minutes = time / 60;
                if (minutes < 60)
                {
                    //create time string
                    int fullMinutes = (int)minutes;
                    decimal seconds = minutes - (decimal)fullMinutes;
                    if (fullMinutes < 10)
                    {
                        long secs = time - (long)(minutes * 60);
                        if (secs < 10)
                        {
                            if (secs == 0)
                            {
                                return "00:0" + minutes + ":00";
                            }
                            else
                            {
                                return "00:0" + minutes + ":0" + secs;
                            }
                        }
                        else
                        {
                            return "00:0" + minutes + ":" + secs;
                        }
                    }
                    else
                    {
                        int secs = (int)seconds * 60;
                        if (secs < 10)
                        {
                            if (secs == 0)
                            {
                                return "00:" + minutes + ":00";
                            }
                            else
                            {
                                return "00:" + minutes + ":0" + secs;
                            }
                        }
                        else
                        {
                            return "00:" + minutes + ":" + secs;
                        }
                    }
                }
                else
                {
                    //divide by 3600 to get hours
                    decimal hours = time / 3600;

                    int hrs = (int)hours;

                    long mins_s = time - hrs * 3600;

                    decimal mins = mins_s / 60;
                    int m = (int)mins;

                    long s = time - (long)(hrs * 3600) - (long)(mins * 60);

                    if (m < 10)
                    {
                        if (s < 10)
                        {
                            if (s == 0)
                            {
                                return hrs + ":0" + m + ":00";
                            }
                            else
                            {
                                return hrs + ":0" + m + ":0" + s;
                            }
                        }
                        else
                        {
                            return hrs + ":0" + m + ":" + s;
                        }
                    }
                    else
                    {
                        if (s < 10)
                        {
                            if (s == 0)
                            {
                                return hrs + ":" + m + ":00";
                            }
                            else
                            {
                                return hrs + ":" + m + ":0" + s;
                            }
                        }
                        else
                        {
                            return hrs + ":" + m + ":" + s;
                        }
                    }
                }
            }
        }

        public void startTimer(ref System.Timers.Timer timer)
        {
            timer.Start();
            
            connected = true;
        }

        public void stopTimer(ref System.Timers.Timer timer)
        {
            timer.Stop();
            
            connectionTime = 0;
            
            updateTime();

            connected = false;
        }

        //when the status changes... we may want to update the status.
        void networkCommunicationManager_onStatusChanged(object sender, NetworkCommunicationManager.StatusEventArgs data)
        {
            this.Invoke((MethodInvoker)delegate
            {
                enableControls(false);
                this.connectionText.Text = data.Status;
                statistics1.InitializeControl();
                location1.InitializeControl();
            });
        }

        //on disconnect...
        void networkCommunicationManager_onDisconnect(object sender, EventArgs data)
        {
            this.Invoke((MethodInvoker)delegate
            {
                enableControls(false);
                stopTimer(ref timer);
            });
        }

        //on sucessful connect... 
        void networkCommunicationManager_onConnect(object sender, EventArgs data)
        {
            this.Invoke((MethodInvoker)delegate
            {
                startTimer(ref timer);
                enableControls(true);
            });
        }

        //recieved message callback.
        public void networkCommunicationManager_msgRecieved(object sender,  NetworkCommunicationManager.MsgRecievedEventArgs data)
        {
            this.Invoke((MethodInvoker)delegate
            {

                //try
                //{
                    JsonObjects.Envelope jsonEnvelope = data.JSONMessage;

                    if (jsonEnvelope != null && jsonEnvelope.Responses != null && jsonEnvelope.Responses.Orientation != null)
                    {
                        location1.UpdateOrientation(jsonEnvelope.Responses.Orientation);
                    }
                    
                    if (jsonEnvelope != null && statistics1 != null)
                    {
                        statistics1.updateGraph(ref jsonEnvelope);
                    }
           //     }
           //     catch (Exception e)
           //     {
           //         MessageBox.Show(e.Message);
           //     }

                    textControl1.insertWriteToTextControl(jsonEnvelope.ToString());
            });
        }

        private void setupConnectionBtn_Click(object sender, EventArgs e)
        {
            connectionSettings.ShowDialog(this);
        }

        public void change_setupConnectionBtn_text(string text)
        {
            setupConnectionBtn.Text = text;
        }

        public void change_connectionText_text(string text)
        {
            connectionText.Text = text;
        }

        internal void enable_text_control()
        {
            textControl1.enableTerminal(true);
        }

        internal void disable_text_control()
        {
            textControl1.enableTerminal(false);
        }

        internal void reset_text_control()
        {
            textControl1.resetTextControl();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedTab.Text.Equals(tabPagesEnumToString((int)TabName.Statistics)) && !statistics1.initialized)
            {
                statistics1.InitializeControl();
            }
        }

        public string tabPagesEnumToString(int i)
        {
            switch (i)
            {
                case 1:
                    return "Welcome";
                case 2:
                    return "Location";
                case 3:
                    return "Statistics";
                case 4:
                    return "Live Feed";
                case 5: 
                    return "Text Control";
                case 6:
                    return "Plugins";
                default:
                    return "";
            }
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            if (tabControl1.SelectedTab.Text.Equals(tabPagesEnumToString((int)TabName.Statistics)) && !statistics1.initialized)
            {
                statistics1.InitializeControl();
            }
            else if (tabControl1.SelectedTab.Text.Equals(tabPagesEnumToString((int)TabName.Location)) && !location1.initialized)
            {
                location1.InitializeControl();
            }
        }

        private void userInput_Click(object sender, EventArgs e)
        {
            if (userInput.Text == "Enable Keys")
            {
                userControlStatusPictureBox.Image = Properties.Resources.userControlIndicatorEnabled;
                userInput.Text = "Disable Keys";
                KeyPreview = true;
                controller.Enable();
            }
            else
            {
                userControlStatusPictureBox.Image = Properties.Resources.userControlIndicatorDisabled;
                userInput.Text = "Enable Keys";
                KeyPreview = false;
                controller.Disable();
            }
        }

        private void fly_Click(object sender, EventArgs e)
        {
            if (flyPrep.Text == "Calibrate")
            {
               
                textControl1.CommandParser("cmd calibrate");
                flyPrep.Text = "Arm Motors";
            }
            else if (flyPrep.Text == "Arm Motors")
            {
                DialogResult result = MessageBox.Show("Are you sure you want to start the quadrotor?", "Starting Quadrotor", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    textControl1.CommandParser("cmd arm");
                    flying = true;
                    flyPrep.Text = "PID";
                }
            }
            else if (flyPrep.Text == "PID")
            {
                
                /*
                JsonObjects.Envelope test = new JsonObjects.Envelope();
                
                        test.Commands = new JsonObjects.Commands();
                        test.Commands.Debug = new string[1];
                        test.Commands.Debug[0] = "f102";
                        QoDMain.networkCommunicationManager.SendMessage(test);
                */
                textControl1.CommandParser("cmd debug f102");
                    flyPrep.Text = "Disarm";
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure you want to disarm the quadrotor?", "Disarming Quadrotor", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    textControl1.CommandParser("cmd disarm");
                    flightTime = 0;
                    updateTime();
                    flying = false;
                    flyPrep.Text = "Calibrate";
                }
            }


        }

        public void enableControls(bool enable)
        {
            textControl1.enableTerminal(enable);
            userControlStatusPictureBox.Visible = enable;
            userInput.Visible = enable;
            configureControls.Visible = enable;
            flyPrep.Visible = enable;
        }

        private void QoDForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(controller.Enabled)
                e.SuppressKeyPress = true;
        }

        private void QoDForm_Load(object sender, EventArgs e)
        {
            //todo lisa need to install appropriate fon if not on user machine
            /*fonts = new PrivateFontCollection();
            var test = Properties.Resources.SF_New_Republic_Bold;
            string path = "Resources\\SF New Republic Bold.ttf";
            if (File.Exists(path))
            {
                MessageBox.Show("font file exists at path: " + path);
            }
            fonts.AddFontFile(path);
            //label1.Font = fonts.
            if (!File.Exists("C:\\Windows\\Fonts\\SF New Republic Bold.ttf"))
            {
                if (File.Exists("C:\\Windows\\Fonts\\"))
                {
                    MessageBox.Show("Holy crap it exists!");
                }
                else
                {
                    MessageBox.Show("Doesn't exist :'(");
                }
                //File.WriteAllBytes("\\\\Windows\\Fonts\\", Properties.Resources.SF_New_Republic_Bold);
            }*/
        }

        private void cofigureControls_Click(object sender, EventArgs e)
        {
            controlManager.ShowDialog(this);
        }

        internal ControllerInput getControl(Controller.direction index)
        {
            return controller.FetchControl(index);
        }

        internal void configureHeightControl()
        {
            controller.ReAssignInput(Controller.direction.HEIGHT);
        }

        internal void configureRollControl()
        {
            controller.ReAssignInput(Controller.direction.ROLL);
        }

        internal void configurePitchControl()
        {
            controller.ReAssignInput(Controller.direction.PITCH);
        }

        internal void configureYawControl()
        {
            controller.ReAssignInput(Controller.direction.YAW);
        }
        
    }
}
