using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace QoD_DataCentre
{
    public partial class SerialSendUtilityForm : UserControl
    {
        private const int MAX_SPEED = 100;
		private SerialPort m_Port;

        private double currentSpeedMotor1;
        private double currentSpeedMotor2;
        private double currentSpeedMotor3;
        private double currentSpeedMotor4;

        private int[] changingMotors;

		private delegate void SetCommandBoxTextDelegate(string text);

        public SerialSendUtilityForm()
        {
            InitializeComponent();

            m_Port = new SerialPort();
			m_Port.DataReceived += new SerialDataReceivedEventHandler(SerialDataRx);
			m_Port.NewLine = "\n";
			m_Port.ReadTimeout = 100;	// ms before timeout

            //current speed starts at nothing
            currentSpeedMotor1 = 0;
            currentSpeedMotor2 = 0;
            currentSpeedMotor3 = 0;
            currentSpeedMotor4 = 0;

            this.currentSpeedM1.Text = currentSpeedMotor1.ToString();
            this.currentSpeedM2.Text = currentSpeedMotor2.ToString();
            this.currentSpeedM3.Text = currentSpeedMotor3.ToString();
            this.currentSpeedM4.Text = currentSpeedMotor4.ToString();

            changingMotors = new int[4];
        }
        
		private void CheckEnter(object sender, KeyPressEventArgs args)
		{
			if (args.KeyChar == (char)13)
			{
				EncodeSendButton.PerformClick();
				args.Handled = true;
			}
		}
		private void SetIncomingSerialText(string rxData)
		{
			try
			{
				// Read line consumes end of line characters
				LogTextBox.AppendText(">> " + rxData + "\n");
			}
			catch (Exception ex)
			{
				LogTextBox.AppendText(ex.Message + "\n");
			}
		}

		private void SerialDataRx(object sender, SerialDataReceivedEventArgs args)
		{
			try
			{
				string rxData = ((SerialPort)sender).ReadLine();
				LogTextBox.Invoke(new SetCommandBoxTextDelegate(SetIncomingSerialText), rxData);
			}
			catch (Exception ex)
			{
			}
		}

        private void OpenCloseCOMPortButton_Click(object sender, EventArgs e)
		{
			if (!m_Port.IsOpen)
			{
				try
				{
					m_Port.PortName = COMPortDropDown.Text;
					m_Port.BaudRate = int.Parse(BaudBox.Text);
					m_Port.DataBits = 8;
					m_Port.Parity = Parity.None;
					m_Port.StopBits = StopBits.One;
					m_Port.Handshake = Handshake.None;
					m_Port.Open();

					OpenCloseCOMPortButton.Text = "Close " + m_Port.PortName;
					LogTextBox.AppendText(m_Port.PortName + " is open.\n");
				}
				catch(Exception ex)
				{
					LogTextBox.AppendText(ex.Message + "\n");
				}
			}
			else
			{
				try
				{
					m_Port.Close();

					OpenCloseCOMPortButton.Text = "Open COM port";
					LogTextBox.AppendText(m_Port.PortName + " is closed.\n");
				}
				catch (Exception ex)
				{
					LogTextBox.AppendText(ex.Message + "\n");
				}
			}
		}

        private void EncodeSendButton_Click(object sender, EventArgs e)
		{

            //make sure port is open
            if (!m_Port.IsOpen)
            {
                LogTextBox.AppendText("Port is not open.\n");
                return;
            }

            //make sure all fields are filled out
            if (increaseSpeed.Checked == true || decreaseSpeed.Checked == true)
            {
                if (changeSpeedBy.Text == "")
                {
                    LogTextBox.AppendText("Increase/decrease speed value has not been set.\n");
                    return;
                }
                else
                {
                    if (motorToChange.CheckedItems.Count == 0)
                    {
                        LogTextBox.AppendText("Motor(s) to change has/have not been selected.\n");
                        return;
                    }
                }
            }
            else
            {
                LogTextBox.AppendText("Increase/decrease option has not been set.\n");
                return;
            }

            //create the command to send
            string command = "!10";

            //get the binary value of the motors to change
            string motorsToBeChanged = changeMotors(motorToChange.CheckedItems);
            
            //convert binary string to hex and add to command string
            command += Convert.ToString(Convert.ToInt32(motorsToBeChanged, 2), 16);

            //update the current speed of each motor on the gui and add to command
            //todo lisa not sure if the string formatting will work with numbers after the decimal
            if (increaseSpeed.Checked == true)
            {
                //todo lisa assuming we are playing with only motor 1
                double newSpeed = Convert.ToDouble(currentSpeedM1.Text) + (MAX_SPEED * (Convert.ToDouble(changeSpeedBy.Text) / 100));
                command += String.Format("{0:x3}", (uint)System.Convert.ToUInt32(newSpeed));
                updateMotorsOnGui('+');                
            }
            else
            {
                //todo lisa assuming we are only using motor 1
                double newSpeed = Convert.ToDouble(currentSpeedM1.Text) - (MAX_SPEED * (Convert.ToDouble(changeSpeedBy.Text) / 100));
                command += String.Format("{0:x3}", (uint)System.Convert.ToUInt32(newSpeed));
                updateMotorsOnGui('-');
            }

            //add the don't cares and carriage return/new line
            command += "zzzz\r\n";
            
			try
			{
				string TextToSend = EncodeCommand(command);
				m_Port.Write(TextToSend);
				LogTextBox.AppendText("<< " + TextToSend);
			}
			catch (Exception ex)
			{
				LogTextBox.AppendText(ex.Message + "\n");
			}
		}

        private string changeMotors(CheckedListBox.CheckedItemCollection c)
        {
            string binaryString;

            if (c.Contains("Motor 4"))
            {
                binaryString = "1";
                changingMotors[0] = 1;
            }
            else
            {
                binaryString = "0";
                changingMotors[0] = 0;
            }

            if (c.Contains("Motor 3"))
            {
                binaryString += "1";
                changingMotors[1] = 1;
            }
            else
            {
                binaryString += "0";
                changingMotors[1] = 0;
            }

            if (c.Contains("Motor 2"))
            {
                binaryString += "1";
                changingMotors[2] = 1;
            }
            else
            {
                binaryString += "0";
                changingMotors[2] = 0;
            }

            if (c.Contains("Motor 1"))
            {
                binaryString += "1";
                changingMotors[3] = 1;
            }
            else
            {
                binaryString += "0";
                changingMotors[3] = 0;
            }

            return binaryString;
        }

        private void updateMotorsOnGui(char c)
        {
            if (c == '+')
            {
                if (changingMotors[3] == 1)
                {
                    currentSpeedM1.Text = (currentSpeedMotor1 += MAX_SPEED * (Convert.ToDouble(changeSpeedBy.Text) / 100)).ToString();
                }

                if (changingMotors[2] == 1)
                {
                    currentSpeedM2.Text = (currentSpeedMotor2 += MAX_SPEED * (Convert.ToDouble(changeSpeedBy.Text) / 100)).ToString();
                }

                if (changingMotors[1] == 1)
                {
                    currentSpeedM3.Text = (currentSpeedMotor3 += MAX_SPEED * (Convert.ToDouble(changeSpeedBy.Text) / 100)).ToString();
                }

                if (changingMotors[0] == 1)
                {
                    currentSpeedM4.Text = (currentSpeedMotor4 += MAX_SPEED * (Convert.ToDouble(changeSpeedBy.Text) / 100)).ToString();
                }
            }
            else
            {
                if (changingMotors[3] == 1)
                {
                    currentSpeedM1.Text = (currentSpeedMotor1 -= MAX_SPEED * (Convert.ToDouble(changeSpeedBy.Text) / 100)).ToString();
                }

                if (changingMotors[2] == 1)
                {
                    currentSpeedM2.Text = (currentSpeedMotor2 -= MAX_SPEED * (Convert.ToDouble(changeSpeedBy.Text) / 100)).ToString();
                }

                if (changingMotors[1] == 1)
                {
                    currentSpeedM3.Text = (currentSpeedMotor3 -= MAX_SPEED * (Convert.ToDouble(changeSpeedBy.Text) / 100)).ToString();
                }

                if (changingMotors[0] == 1)
                {
                    currentSpeedM4.Text = (currentSpeedMotor4 -= MAX_SPEED * (Convert.ToDouble(changeSpeedBy.Text) / 100)).ToString();
                }
            }
        }

        private static string EncodeCommand(string command)
        {
            if (command.Length == 0)
            {
                throw new Exception("Command to encode must have length greater than 0.");
            }

            if (command.Length > 257)
            {
                throw new Exception("Command to encode must not be longer than 257 bytes (2 bytes for command and maximum 255 bytes of data).");
            }

            // Start framing byte
            string retVal = "!";

            // Command and data
            retVal += command;

            // Checksum
            int crc32Val = 0x0123;
            retVal += crc32Val.ToString("X4").Substring(0, 4);

            // End framing bytes
            retVal += "\r\n";

            return retVal;
        }
    }
}
