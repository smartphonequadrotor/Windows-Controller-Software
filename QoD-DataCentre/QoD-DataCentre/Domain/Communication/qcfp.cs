using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QoD_DataCentre.Domain.JSON;
using System.IO.Ports;

namespace QoD_DataCentre.Domain.Communication
{

    public class qcfp
    {

        public class SendQCFPEventArgs : EventArgs
        {
            private byte[] message;
            public byte[] Message { get { return message; } set { message = value; } }
            public SendQCFPEventArgs(byte[] message)
            {
                this.Message = message;
            }
        }

        //msg recieved
        public delegate void SendQCFPEvent(object sender, SendQCFPEventArgs data);

        public class ReceiveQCFPEventArgs : EventArgs
        {
            private JSON.JsonObjects.Envelope message;
            public JSON.JsonObjects.Envelope Message { get { return message; } set { message = value; } }
            public ReceiveQCFPEventArgs(JSON.JsonObjects.Envelope message)
            {
                this.Message = message;
            }
        }

        //msg recieved
        public delegate void ReceiveQCFPEvent(object sender, ReceiveQCFPEventArgs data);

        //called when message is recieved...
        public event SendQCFPEvent msgToSend;
        public event ReceiveQCFPEvent msgRecieved;

        public static class QcfpCommands
        {
            public const byte QCFP_ASYNC_DATA = 0x10;

            public const byte QCFP_CALIBRATE_QUADROTOR = 0x40;
            public const byte QCFP_CALIBRATE_QUADROTOR_STOP = 0x00;
            public const byte QCFP_CALIBRATE_QUADROTOR_START = 0x01;

            public const byte QCFP_CALIBRATE_QUADROTOR_UNCALIBRATED = 0x00;
            public const byte QCFP_CALIBRATE_QUADROTOR_CALIBRATED = 0x01;
            public const byte QCFP_CALIBRATE_QUADROTOR_CALIBRATING = 0x02;
            public const byte QCFP_CALIBRATE_QUADROTOR_UNABLE_TO_CALIBRATE = 0x03;

            public const byte QCFP_FLIGHT_MODE = 0x41;
            public const byte QCFP_FLIGHT_MODE_DISABLE = 0x00;
            public const byte QCFP_FLIGHT_MODE_ENABLE = 0x01;
            public const byte QCFP_FLIGHT_MODE_PENDING = 0x02;

            public const byte QCFP_CONTROL_METHOD_OVERRIDE = 0xF1;
            public const byte QCFP_CONTROL_MODE_PID  = 2;
            public const byte QCFP_SET_THROTTLE = 0x24;

            public const byte QCFP_RAW_MOTOR_CONTROL = (byte)0xF0; 	// Verify that this
            // cast doesn't
            // change the
            // bit pattern
            // or anything
        }
        

            static int QCFP_MAX_ENCODED_PACKET_SIZE = 100;
            private enum cobsState
            {
                COBS_DECODE,
                COBS_COPY,
                COBS_SYNC,
            }

            public static int QCFP_MAX_PACKET_SIZE = 32;
            public static byte COBS_TERM_BYTE = 0;

            private int maxPacketSize;
            private cobsState decodeState;
            private byte[] incomingPacket; // Extra space in case of overflow
            private int packetSize; // Counts packet size
            private int byteCount; // Counts number of encoded bytes

            SerialPort comPort;
            /**
             * Creates a parser object that will not allow a decoded packet greater than
             * size maxPacketSize.
             * 
             * @param maxPacketSize
             *            Maximum allowable packet size.
             * @param packetHandlers
             *            Object that will handle packets.
             */
            public qcfp(int maxPacketSize)
            {
                this.maxPacketSize = maxPacketSize;
                this.byteCount = 0;
                this.packetSize = 0;
                this.decodeState = cobsState.COBS_SYNC;
                this.incomingPacket = new byte[this.maxPacketSize + 2];
                this.comPort = new SerialPort();
                comPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
            }

            void comPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
            {

                int bytes = comPort.BytesToRead;
                //create a byte array to hold the awaiting data
                byte[] comBuffer = new byte[bytes];
                //read the data and store it
                comPort.Read(comBuffer, 0, bytes);
                addData(comBuffer, bytes);
        
            }

            /**
             * Adds the data in buffer of length to any previously processed data. This
             * method is equivalent in function to the function qcfp_data_received in
             * the firmware.
             * 
             * @param buffer
             *            Data to be processed.
             * @param length
             *            Number of bytes to process.
             */
            public void addData(byte[] buffer, int length)
            {

                // Decode data from buffer
                for (int i = 0; i < length; i++)
                {
                    if (this.packetSize > this.maxPacketSize)
                    {
                        this.decodeState = cobsState.COBS_SYNC;
                    }

                    switch (this.decodeState)
                    {
                        case cobsState.COBS_DECODE:
                            if (buffer[i] == COBS_TERM_BYTE)
                            {
                                if ((this.packetSize > 0) && (this.byteCount == 0))
                                {
                                    // Handle packet
                                    if (this.incomingPacket[this.packetSize] == COBS_TERM_BYTE)
                                    {
                                        this.packetSize--;
                                    }
                                    //TODO: RUN Handler here!
                                    packetHandler(this.incomingPacket, this.packetSize);
                                }
                                this.packetSize = 0;
                                this.byteCount = 0;
                            }
                            else
                            {
                                this.byteCount = buffer[i];
                                this.decodeState = cobsState.COBS_COPY;
                            }
                            break;
                        case cobsState.COBS_COPY:
                            if (this.byteCount == 1)
                            {
                                this.incomingPacket[this.packetSize++] = 0;
                                i--; 	// i points to the next data chunk byte currently,
                                // which is what the decode state needs
                                this.byteCount--;
                                this.decodeState = cobsState.COBS_DECODE;
                            }
                            else
                            {
                                if (buffer[i] == COBS_TERM_BYTE)
                                {
                                    // Got a zero when expecting data, re-sync
                                    this.byteCount = 0;
                                    this.packetSize = 0;
                                    this.decodeState = cobsState.COBS_DECODE;
                                }
                                else
                                {
                                    if (byteCount > 1)
                                    {
                                        this.incomingPacket[this.packetSize++] = buffer[i];
                                        this.byteCount--;
                                    }
                                }
                            }
                            break;
                        case cobsState.COBS_SYNC:
                        default:
                            this.packetSize = 0;
                            this.byteCount = 0;
                            if (buffer[i] == COBS_TERM_BYTE)
                            {
                                this.decodeState = cobsState.COBS_DECODE;
                            }
                            break;
                    }
                }
            }

            private void packetHandler(byte[] array, int packetSize)
            {
                switch (array[0])
                {
                    case QcfpCommands.QCFP_ASYNC_DATA:
                        asyncDataCallback(array, packetSize);
                        break;
                    case QcfpCommands.QCFP_FLIGHT_MODE:
                        flightModeCallback(array, packetSize);
                        break;
                    case QcfpCommands.QCFP_CALIBRATE_QUADROTOR:
                        calibrationStatusCallback(array, packetSize);
                        break;
                        

                }
            }


        void flightModeCallback (byte[] packet, int length){
		    int CMD41_ENABLE_INDEX = 1;
			//check if the length of the command is appropriate. 
			if (length == 2) {
				int flightMode = packet[CMD41_ENABLE_INDEX];
				//owner.flightModeReceivedfromQcb(flightMode);
			}
		}

	
	/**
	 * This callback receives data from the bluetooth. The data is in the form of a 
	 * byte array and needs to be parsed according to the QCFB protocol guide in the
	 * project documents folder on google docs.
	 * The data contains information regarding whether the QCB has entered calibration mode
	 * or not.
	 */
	void calibrationStatusCallback(byte[] packet, int length) {
		int CMD40_ENABLE_INDEX = 1;
			//check if the length of the command is appropriate. 
			if (length == 2) {
				int calibrationStatus = packet[CMD40_ENABLE_INDEX];
				//owner.calibrationStatusReceivedfromQcb(calibrationStatus);
			}
		}
	
	/**
	 * This callback receives data from the bluetooth. The data is in the form of a 
	 * byte array and needs to be parsed according to the QCFB protocol guide in the
	 * project documents folder on google docs.
	 */
    void asyncDataCallback(byte[] packet, int length)
    {
        const byte CMD10_DATA_SOURCE_INDEX = 1;
        const byte DATA_SOURCE_ACCEL = 0x01;
        const byte DATA_SOURCE_GYRO = 0x02;
        const byte DATA_SOURCE_MAG = 0x03;
        const byte DATA_SOURCE_KIN = 0x06;
        const byte DATA_SOURCE_HEIGHT = 0x07;

        const byte ACCEL_PAYLOAD_LENGTH = 18;
        const byte GYRO_PAYLOAD_LENGTH = 18;
        const byte MAG_PAYLOAD_LENGTH = 18;
        const byte KIN_PAYLOAD_LENGTH = 18;
        const byte HEIGHT_PAYLOAD_LENGTH = 8;

        const byte TIMESTAMP_START_INDEX = 2;

        const byte HEIGHT_INDEX_LSB = 6;
        const byte HEIGHT_INDEX_MSB = 7;

        const byte X_START_INDEX = 6;
        const byte Y_START_INDEX = 10;
        const byte Z_START_INDEX = 14;
        const byte ROLL_START_INDEX = 6;
        const byte PITCH_START_INDEX = 10;
        const byte YAW_START_INDEX = 14;


        // Require command id, data source, 4 timestamp, and at least 1 payload
        if (length >= 7)
        {
            // values from tri axis sensors
            float x, y, z;

            // Timestamp is unsigned
            long timestamp =
                    ((packet[TIMESTAMP_START_INDEX] << 0) & 0x00000000FF) |
                    ((packet[TIMESTAMP_START_INDEX + 1] << 8) & 0x000000FF00) |
                    ((packet[TIMESTAMP_START_INDEX + 2] << 16) & 0x0000FF0000) |
                    ((packet[TIMESTAMP_START_INDEX + 3] << 24) & 0x00FF000000);

            JsonObjects.Responses newRes = null;
            JsonObjects.TriAxisResponse newTriAxis= null;
            // sensor data is signed
            byte type = packet[CMD10_DATA_SOURCE_INDEX];
            switch (type)
            {
                case DATA_SOURCE_ACCEL:
                    if (length == ACCEL_PAYLOAD_LENGTH)
                    {
                        x = decodeFloat(packet, X_START_INDEX);
                        y = decodeFloat(packet, Y_START_INDEX);
                        z = decodeFloat(packet, Z_START_INDEX);
                        newTriAxis = new JsonObjects.TriAxisResponse();
                        newTriAxis.Timestamp = timestamp;
                        newTriAxis.X = x;
                        newTriAxis.Y = y;
                        newTriAxis.Z = z;
                        newRes = new JsonObjects.Responses();
                        newRes.Accel = new JsonObjects.TriAxisResponse[1];
                        newRes.Accel[0] = newTriAxis;
                    }
                    break;
                case DATA_SOURCE_GYRO:
                    if (length == GYRO_PAYLOAD_LENGTH)
                    {
                        x = decodeFloat(packet, X_START_INDEX);
                        y = decodeFloat(packet, Y_START_INDEX);
                        z = decodeFloat(packet, Z_START_INDEX);
                        newTriAxis = new JsonObjects.TriAxisResponse();
                        newTriAxis.Timestamp = timestamp;
                        newTriAxis.X = x;
                        newTriAxis.Y = y;
                        newTriAxis.Z = z;
                        newRes = new JsonObjects.Responses();
                        newRes.Gyro = new JsonObjects.TriAxisResponse[1];
                        newRes.Gyro[0] = newTriAxis;
                    }
                    break;
                case DATA_SOURCE_MAG:
                    if (length == MAG_PAYLOAD_LENGTH)
                    {
                        x = decodeFloat(packet, X_START_INDEX);
                        y = decodeFloat(packet, Y_START_INDEX);
                        z = decodeFloat(packet, Z_START_INDEX);
                        newTriAxis = new JsonObjects.TriAxisResponse();
                        newTriAxis.Timestamp = timestamp;
                        newTriAxis.X = x;
                        newTriAxis.Y = y;
                        newTriAxis.Z = z;
                        newRes = new JsonObjects.Responses();
                        newRes.Mag = new JsonObjects.TriAxisResponse[1];
                        newRes.Mag[0] = newTriAxis;
                    }
                    break;
                case DATA_SOURCE_KIN:
                    if (length == KIN_PAYLOAD_LENGTH)
                    {
                        float yaw, pitch, roll;
                        // Assuming roll, pitch, yaw corresponds to x, y, z and that that is
                        // the order the values are sent in.
                        // Kinematics angles are in radians.
                        roll = decodeFloat(packet, ROLL_START_INDEX);
                        pitch = decodeFloat(packet, PITCH_START_INDEX);
                        yaw = decodeFloat(packet, YAW_START_INDEX);

                        newTriAxis = new JsonObjects.TriAxisResponse();
                        newTriAxis.Timestamp = timestamp;
                        newTriAxis.X = roll;
                        newTriAxis.Y = pitch;
                        newTriAxis.Z = yaw;
                        newRes = new JsonObjects.Responses();
                        newRes.Orientation = new JsonObjects.TriAxisResponse[1];
                        newRes.Orientation[0] = newTriAxis;
                    }
                    break;
                case DATA_SOURCE_HEIGHT:
                    if (length == HEIGHT_PAYLOAD_LENGTH)
                    {
                        int height = (packet[HEIGHT_INDEX_LSB] & 0x00FF) + ((packet[HEIGHT_INDEX_MSB] & 0x00FF) << 8);
                        // TODO: Do something with the height. Height is in cm.
                        // The value isn't reliable when the height is approximately less than 20cm.
                    }
                    break;
                default:
                    break;
            }
            JsonObjects.Envelope newEnv = new JsonObjects.Envelope(null, null, newRes);
            this.msgRecieved(this, new ReceiveQCFPEventArgs(newEnv));
        }
    }










            public static float decodeFloat(byte[] buffer, int index)
            {
                return System.BitConverter.ToSingle(buffer, index);
            }

            /**
             * Sends raw motor speeds to the QCB. Motor values will only take effect if
             * the QCB is in flight mode.
             * @param motor1 Motor speed to set motor 1 to. 0 will turn the motor off. 1 is the lowest
             * setting and the current maximum defined is 80. Sending a higher value will result in the
             * motor being set to 80. These values will result in a PWM duty cycle on the motors of
             * (PWM_BASE + value)/PWM_PERIOD*100% where PWM_BASE is currently 110 and PWM_PERIOD is 200.
             * @param motor2 See motor1.
             * @param motor3 See motor1.
             * @param motor4 See motor1.
             * @throws Exception Throws an exception if the command cannot be sent (Bluetooth manager couldn't write).
             */
            public void sendRawMotorSpeeds(byte motor1, byte motor2, byte motor3, byte motor4)
            {
                byte[] buffer = new byte[5];
                buffer[0] = QcfpCommands.QCFP_RAW_MOTOR_CONTROL;
                buffer[1] = motor1;
                buffer[2] = motor2;
                buffer[3] = motor3;
                buffer[4] = motor4;
                sendCOMMessage(encodeData(buffer, buffer.Length));
            }

            /**
             * Sends the command to enable flight mode in the firmware. This mode must be enabled for
             * the sendRawMotorSpeeds method to have an effect. Flight mode will not take effect if
             * the quadrotor is currently being calibrated.
             * Flight mode takes several seconds to take effect. As such, this command must continue to
             * be sent until the QCB responds with the byte QcfpCommands.QCFP_FLIGHT_MODE_ENABLE in the
             * response payload. If the motors/ESCs are still being initialized, the response payload
             * will be QcfpCommands.QCFP_FLIGHT_MODE_PENDING.
             * @param enabled true to enable flight mode, false to disable flight mode
             * @throws Exception Throws an exception if the command cannot be sent (Bluetooth manager couldn't write).
             */
            public void sendFlightMode(Boolean enabled)
            {
                byte[] buffer = new byte[2];
                buffer[0] = QcfpCommands.QCFP_FLIGHT_MODE;
                if (enabled == true)
                {
                    buffer[1] = QcfpCommands.QCFP_FLIGHT_MODE_ENABLE;
                }
                else
                {
                    buffer[1] = QcfpCommands.QCFP_FLIGHT_MODE_DISABLE;
                }
                sendCOMMessage(encodeData(buffer, buffer.Length));
            }

            /**
             * Queries the current flight mode.
             * @throws Exception
             */
            public void queryFlightMode()
            {
                byte[] buffer = new byte[1];
                buffer[0] = QcfpCommands.QCFP_FLIGHT_MODE;
                sendCOMMessage(encodeData(buffer, buffer.Length));
            }

            /**
             * 
             * @param start Starts a calibration if true, stop a calibration if false.
             * @throws Exception Throws an exception if the command cannot be sent (Bluetooth manager couldn't write).
             */
            public void sendStartStopCalibration(Boolean start)
            {
                byte[] buffer = new byte[2];
                buffer[0] = QcfpCommands.QCFP_CALIBRATE_QUADROTOR;
                if (start == true)
                {
                    buffer[1] = QcfpCommands.QCFP_CALIBRATE_QUADROTOR_START;
                }
                else
                {
                    buffer[1] = QcfpCommands.QCFP_CALIBRATE_QUADROTOR_STOP;
                }
                sendCOMMessage(encodeData(buffer, buffer.Length));
            }

            /**
             * Queries the calibration state.
             * @throws Exception
             */
            public void queryCalibration()
            {
                byte[] buffer = new byte[1];
                buffer[0] = QcfpCommands.QCFP_CALIBRATE_QUADROTOR;
                sendCOMMessage(encodeData(buffer, buffer.Length));
            }

            /**
             * This uses the {@link BluetoothManager} to send a message to the QCB
             * over bluetooth.
             * @param message
             */
            private void sendCOMMessage(byte[] message)
            {
                msgToSend(this,new SendQCFPEventArgs(message));
            }

            /**
             * This method is equivalent in function to the function qcfp_send_data in
             * the firmware.
             * 
             * @param buffer The buffer to send.
             * @param length The length of the buffer.
             * @return Returns a COBS encoded byte array that can be sent to the QCB.
             * @throws IllegalArgumentException
             */
            public static byte[] encodeData(byte[] buffer, int length)
            {

                byte[] encodedData = new byte[QCFP_MAX_ENCODED_PACKET_SIZE];
                byte byteCount = 1;
                int encodedDataIndex = 1, chunkIndex = 1;

                // First byte is always COBS_TERM_BYTE
                encodedData[0] = qcfp.COBS_TERM_BYTE;

                for (int i = 0; i < length; i++, byteCount++)
                {
                    if (buffer[i] == qcfp.COBS_TERM_BYTE)
                    {
                        encodedData[chunkIndex] = byteCount;
                        chunkIndex = ++encodedDataIndex;
                        byteCount = 0;
                    }
                    else
                    {
                        encodedData[++encodedDataIndex] = buffer[i];
                    }
                }

                if (byteCount > 1)
                {
                    encodedData[chunkIndex] = byteCount;
                    encodedDataIndex++;
                }

                if (buffer[length - 1] == qcfp.COBS_TERM_BYTE)
                {
                    encodedData[encodedDataIndex++] = 1;
                }

                encodedData[encodedDataIndex++] = qcfp.COBS_TERM_BYTE;

                byte[] returnArray = new byte[encodedDataIndex];
                Array.ConstrainedCopy(encodedData, 0, returnArray, 0, encodedDataIndex);
                return returnArray;
            }

            internal void sendPIDStart(bool start)
            {
                byte[] buffer = new byte[2];
                buffer[0] = QcfpCommands.QCFP_CONTROL_METHOD_OVERRIDE;
                buffer[1] = QcfpCommands.QCFP_CONTROL_MODE_PID;
                sendCOMMessage(encodeData(buffer, buffer.Length));
            }

            internal void sendThrottle(int speed)
            {
                byte[] buffer = new byte[3];
                buffer[0] = QcfpCommands.QCFP_SET_THROTTLE;
                buffer[1] = (byte)( 0x000000FF & speed);
                buffer[2] = (byte)((0x0000FF00 & speed)>>8);
                sendCOMMessage(encodeData(buffer, buffer.Length));
            }

            internal void writeMessage(JsonObjects.Envelope message)
            {

            }

            internal void connect(int port)
            {
                if(comPort.IsOpen)
                    comPort.Close();
                comPort.BaudRate = 115200;
                comPort.PortName = "COM" + port;
                comPort.Open();
            }

            internal void disconnect()
            {
                if (comPort.IsOpen)
                    comPort.Close();
            }
    }

    }

