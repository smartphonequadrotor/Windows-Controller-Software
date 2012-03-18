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
using System.Text.RegularExpressions;
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
        private long time;

        public ConnectionSettings ConnectionSettings
        {
            get { return connectionSettings; }
        }

        int line_count = 0;

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
            time++;
            updateTime();
		}

        public void updateTime()
        {
            if (connectionTimerLbl.InvokeRequired)
            {
                UpdateTimerCallback d = new UpdateTimerCallback(updateTime);
                this.Invoke(d, new object[] { });
            }
            else
            {
                connectionTimerLbl.Text = convertToTimeString(time);
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

        public void startTimer()
        {
            timer.Start();
        }

        public void stopTimer()
        {
            timer.Stop();
            time = 0;
            updateTime();
        }

        //when the status changes... we may want to update the status.
        void networkCommunicationManager_onStatusChanged(object sender, NetworkCommunicationManager.StatusEventArgs data)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.textControlTerminal.Enabled = false;
                this.connectionText.Text = data.Status;
            });
        }

        //on disconnect...
        void networkCommunicationManager_onDisconnect(object sender, EventArgs data)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.textControlTerminal.Enabled = false;
            });
        }

        //on sucessful connect... 
        void networkCommunicationManager_onConnect(object sender, EventArgs data)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.textControlTerminal.Enabled = true;
            });
        }

        //recieved message callback. Currently just adds data to command window... 
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

                    if (statistics1 != null)
                    {
                        statistics1.updateGraph(ref jsonEnvelope);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }

                insert_write_to_text_control(receivedText);
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
            textControlTerminal.Enabled = true;
        }

        internal void disable_text_control()
        {
            textControlTerminal.Enabled = false;
        }

        public void write_to_text_control(string text)
        {
            textControlTerminal.Text += text;
        }

        public void insert_write_to_text_control(string text)
        {
            text = convert_line_endings(text);
            text = QoDMain.networkCommunicationManager.phone_id + ">" + text + "\r\n";
            int carat = textControlTerminal.SelectionStart;
            textControlTerminal.Text = textControlTerminal.Text.Insert(line_count, text);

            if (carat >= line_length)
            {
                carat += text.Length;
            }

            carat_pos += text.Length;
            line_count += text.Length;
            line_length += text.Length;

            textControlTerminal.SelectionStart = carat;
            textControlTerminal.ScrollToCaret();

        }

        private string convert_line_endings(string text)
        {
            //only convert unix style line endings
            Match line_end = Regex.Match(text, @"(?<!\r)\n");
            while(line_end.Success)
            {
                text = text.Insert(line_end.Index,"\r");
                line_end = Regex.Match(text, @"(?<!\r)\n");
            }
            //only convert macintosh style line endings
            line_end = Regex.Match(text, @"\r(?!\n)");
            while (line_end.Success)
            {
                text = text.Insert(line_end.Index+1, "\r");
                line_end = Regex.Match(text, @"(?<!\r)\n");
            }
            return text;
        }

        int line_length;
        int carat_pos;
        List<String> command_list = new List<String>();
        int command_number = -1;

        private void textControlTerminal_KeyDown(object sender, KeyEventArgs e)
        {
            int send = line_count + (QoDMain.networkCommunicationManager.client_id + ">").Length;
            if (e.KeyCode == Keys.Enter)
            {
                if (!e.Shift)
                {
                    string message = textControlTerminal.Text.Substring(send);
                    command_list.Add(message);
                    command_number = command_list.Count;

                    CommandParser(message);
                    
                    
                    line_count = textControlTerminal.Text.Length + 2;
                    textControlTerminal.Text += "\r\n" + QoDMain.networkCommunicationManager.client_id + ">";
                    line_length = textControlTerminal.Text.Length;
                    carat_pos = line_length;
                    e.SuppressKeyPress = true;
                    textControlTerminal.SelectionStart = carat_pos;
                }
                else
                {
                    if (textControlTerminal.SelectionStart < line_length)
                        e.SuppressKeyPress = true;
                }
            }
            else if (e.KeyCode == Keys.Back)
            {
                if (textControlTerminal.SelectionStart <= line_length)
                    e.SuppressKeyPress = true;
                else{
                    carat_pos--;
                }
            }
            else if ((e.Alt || e.Control ) && !e.Shift)
            {
                if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                {
                    if(e.KeyCode == Keys.Left)
                    {
                        if (carat_pos > line_length)
                        carat_pos--;
                    }
                    else{
                        if(carat_pos < textControlTerminal.Text.Length)
                        carat_pos++;
                    }
                }
                if (e.Control && !e.Alt)
                {
                    
                    if (e.KeyCode == Keys.Up && command_number > 0 && command_list.Count != 0)
                    {
                        e.SuppressKeyPress = true;
                        if (textControlTerminal.Text.Length > line_length)
                            textControlTerminal.Text = textControlTerminal.Text.Remove(line_length);

                        /*if (command_number == command_list.Count && command_number > 0 )
                            command_number--;
                        */

                        command_number--;
                        textControlTerminal.Text += command_list[command_number];
                        
                        carat_pos = textControlTerminal.Text.Length;
                        textControlTerminal.SelectionStart = textControlTerminal.Text.Length;
                    }
                    if (e.KeyCode == Keys.Down && command_number < command_list.Count-1 && command_list.Count != 0)
                    {
                        e.SuppressKeyPress = true;
                        if (textControlTerminal.Text.Length > line_length)
                            textControlTerminal.Text = textControlTerminal.Text.Remove(line_length);
                        /*
                        if (command_number == -1 && command_number < command_list.Count)
                            command_number++;
                        */
                        command_number++;
                        textControlTerminal.Text += command_list[command_number];
                        

                        carat_pos = textControlTerminal.Text.Length;
                        textControlTerminal.SelectionStart = textControlTerminal.Text.Length;
                    }
                    else if (e.KeyCode == Keys.Down)
                    {
                        e.SuppressKeyPress = true;
                        command_number = command_list.Count;
                        if (textControlTerminal.Text.Length > line_length)
                            textControlTerminal.Text = textControlTerminal.Text.Remove(line_length);

                        carat_pos = textControlTerminal.Text.Length;
                        textControlTerminal.SelectionStart = textControlTerminal.Text.Length;
                    }
                }

            }
            else
            {
                if(e.KeyCode == Keys.Left || e.KeyCode == Keys.Down || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up)
                {

                }
                else if (textControlTerminal.SelectionStart < line_length)
                    e.SuppressKeyPress = true;

            }

            
            textControlTerminal.ScrollToCaret();

        }

        private void CommandParser(string message)
        {
            JsonObjects.Envelope test = new JsonObjects.Envelope();
            string[] words = message.Split(' ');

            if (words[0] == "cmd")
            {
                try
                {
                    if (words[1] == "move")
                    {

                        test.Commands = new JsonObjects.Commands();
                        test.Commands.Move = new JsonObjects.MovementCommand[1];
                        test.Commands.Move[0] = new JsonObjects.MovementCommand(float.Parse(words[2]), float.Parse(words[3]), float.Parse(words[4]), int.Parse(words[5]), uint.Parse(words[6]));
                    }
                    else 
                        throw new Exception();

                }
                catch{
                    MessageBox.Show("invalid arguments!");
                }
            }

            else if (words[0] == "req")
            {
                try
                {
                        test.Requests = new JsonObjects.Request[1];
                        test.Requests[0] = new JsonObjects.Request(words[1], int.Parse(words[2]));

                }
                catch 
                {
                    MessageBox.Show("invalid arguments!");
                }
            }

            QoDMain.networkCommunicationManager.SendMessage(test.ToJSON());
        }



        internal void reset_text_control()
        {
            line_count = 0;
            textControlTerminal.Text = "";
            int send = line_count + (QoDMain.networkCommunicationManager.client_id + ">").Length;
            line_count = textControlTerminal.Text.Length;
            textControlTerminal.Text += QoDMain.networkCommunicationManager.client_id + ">";
            line_length = textControlTerminal.Text.Length;
            carat_pos = line_length;
            textControlTerminal.SelectionStart = carat_pos;
            
        }

        private void textControlTerminal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' &&
                e.KeyChar != '\0' &&
                e.KeyChar != '\a' &&
                e.KeyChar != '\b' &&
                e.KeyChar != '\f' &&
                e.KeyChar != '\n' &&
                e.KeyChar != '\r' &&
                e.KeyChar != '\t' &&
                e.KeyChar != '\v')
            {
                if (textControlTerminal.SelectionStart >= line_length)
                {
                    carat_pos++;
                }
            }
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
    }
}
