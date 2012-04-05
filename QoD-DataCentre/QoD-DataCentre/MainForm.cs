using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using QoD_DataCentre.Src.UI;
using QoD_DataCentre.Domain.JSON;
using QoD_DataCentre.Src.Communication;

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
        private JsonObjects.Envelope jsonEnvelope;
        private System.Timers.Timer timer;
        private long connectionTime;
        private long flightTime;
        private bool connected;
        private bool flying;
        private bool userControlsEnabled = false;

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

            // If the timer is declared in a long-running method, use
            // KeepAlive to prevent garbage collection from occurring
            // before the method ends.
            //GC.KeepAlive(timer); 
   
            InitializeComponent();
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
                string receivedText = data.Message;

                try
                {
                    JsonManager commandConvert = new JsonManager();
                    jsonEnvelope = commandConvert.DeserializeEnvelope(receivedText);

                    if (jsonEnvelope != null)
                    {
                        receivedText = jsonEnvelope.ToString();
                    }

                    if (jsonEnvelope != null && jsonEnvelope.Responses.Orientation != null)
                    {
                        location1.UpdateOrientation(jsonEnvelope.Responses.Orientation);
                    }
                    
                    if (jsonEnvelope != null && statistics1 != null)
                    {
                        statistics1.updateGraph(ref jsonEnvelope);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                
                textControl1.insertWriteToTextControl(receivedText);
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
                userControlsEnabled = true;
                KeyPreview = true;
            }
            else
            {
                userControlStatusPictureBox.Image = Properties.Resources.userControlIndicatorDisabled;
                userInput.Text = "Enable Keys";
                userControlsEnabled = false;
                KeyPreview = false;
            }
        }

        private void fly_Click(object sender, EventArgs e)
        {
            if (flyPrep.Text == "Arm Motors")
            {
                DialogResult result = MessageBox.Show("Are you sure you want to start the quadrotor?", "Starting Quadrotor", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    flying = true;
                    flyPrep.Text = "Stop";
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure you want to stop the quadrotor?", "Stopping Quadrotor", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    flightTime = 0;
                    updateTime();
                    flying = false;
                    flyPrep.Text = "Arm Motors";
                }
            }
        }

        public void enableControls(bool enable)
        {
            textControl1.enableTerminal(enable);
            userControlStatusPictureBox.Visible = enable;
            userInput.Visible = enable;
            flyPrep.Visible = enable;
        }

        private void QoDForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (userControlsEnabled)
            {
                float x = 0;
                float y = 0;
                float z = 0;
                int speed = 50;
                uint duration = 1000;
                //KEY -> ACTION
                //A -> Left (x = -1)
                //S -> Back (y = -1)
                //D -> Right (x = 1)
                //W -> Forward (y = 1)
                //arrow up -> gain altitude (z = 1)
                //arrow down -> lose altitude (z = -1)
                //arrow left -> rotate to the left
                //arrow right -> rotate to the right
                if (e.KeyCode == Keys.A)
                {
                    x = -1;
                }
                else if (e.KeyCode == Keys.S)
                {
                    y = -1;
                }
                else if (e.KeyCode == Keys.D)
                {
                    x = 1;
                }
                else if (e.KeyCode == Keys.W)
                {
                    y = 1;
                }
                else if (e.KeyCode == Keys.Up)
                {
                    z = 1;
                }
                else if (e.KeyCode == Keys.Down)
                {
                    z = -1;
                }
                else if (e.KeyCode == Keys.Left)
                {
                    x = -1;
                    y = 1;
                }
                else if (e.KeyCode == Keys.Right)
                {
                    x = 1;
                    y = 1;
                }

                JsonObjects.Envelope jsonToSendEnvelope = new JsonObjects.Envelope();

                jsonToSendEnvelope.Commands = new JsonObjects.Commands();
                jsonToSendEnvelope.Commands.Move = new JsonObjects.MovementCommand[1];
                jsonToSendEnvelope.Commands.Move[0] = new JsonObjects.MovementCommand(x, y, z, speed, duration);

                QoDMain.networkCommunicationManager.SendMessage(jsonToSendEnvelope.ToJSON());

            }
        }
    }
}
