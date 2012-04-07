using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using QoD_DataCentre.Domain.JSON;

namespace QoD_DataCentre.Controls
{
    public partial class TextControl : UserControl
    {
        int line_length;
        int carat_pos;
        List<String> command_list = new List<String>();
        int command_number = -1;
        int line_count = 0;

        public TextControl()
        {
            InitializeComponent();
        }

        public void enableTerminal(bool enabled)
        {
            textControlTerminal.Enabled = enabled;
        }

        public void write_to_text_control(string text)
        {
            textControlTerminal.Text += text;
        }

        public void insertWriteToTextControl(string text)
        {
            if (textControlTerminal.Text.Length > 10000)
                resetTextControl();
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
            while (line_end.Success)
            {
                text = text.Insert(line_end.Index, "\r");
                line_end = Regex.Match(text, @"(?<!\r)\n");
            }
            //only convert macintosh style line endings
            line_end = Regex.Match(text, @"\r(?!\n)");
            while (line_end.Success)
            {
                text = text.Insert(line_end.Index + 1, "\r");
                line_end = Regex.Match(text, @"(?<!\r)\n");
            }
            return text;
        }

        public void resetTextControl()
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
                else
                {
                    carat_pos--;
                }
            }
            else if ((e.Alt || e.Control) && !e.Shift)
            {
                if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                {
                    if (e.KeyCode == Keys.Left)
                    {
                        if (carat_pos > line_length)
                            carat_pos--;
                    }
                    else
                    {
                        if (carat_pos < textControlTerminal.Text.Length)
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
                    if (e.KeyCode == Keys.Down && command_number < command_list.Count - 1 && command_list.Count != 0)
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
                if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Down || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up)
                {

                }
                else if (textControlTerminal.SelectionStart < line_length)
                    e.SuppressKeyPress = true;

            }
            textControlTerminal.ScrollToCaret();
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

        public void CommandParser(string message)
        {
            JsonObjects.Envelope test = new JsonObjects.Envelope();
            char[] delimiter = {' '};
            string[] words = message.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

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
                    else if (words[1] == "arm")
                    {
                        test.Commands = new JsonObjects.Commands();
                        test.Commands.SystemState = JsonObjects.Commands.SystemStates.ARMED.ToString();
                    }
                    else if (words[1] == "disarm")
                    {
                        test.Commands = new JsonObjects.Commands();
                        test.Commands.SystemState = JsonObjects.Commands.SystemStates.DISARMED.ToString();
                    }
                    else if (words[1] == "calibrate")
                    {
                        test.Commands = new JsonObjects.Commands();
                        test.Commands.SystemState = JsonObjects.Commands.SystemStates.CALIBRATING.ToString();
                    }
                    else if (words[1] == "debug")
                    {
                        test.Commands = new JsonObjects.Commands();
                        string[] delimiterS = {"cmd debug"};
                        string[] split = message.Split(delimiterS,StringSplitOptions.RemoveEmptyEntries);
                        test.Commands.Debug = split[0];
                    }
                    else
                        throw new Exception();

                }
                catch
                {
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
    }
}
