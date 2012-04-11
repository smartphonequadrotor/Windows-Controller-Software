using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace QoD_DataCentre.Domain.JSON
{
    public static class JsonObjects
    {
        public class MovementCommand
        {
            private float xVector;
            private float yVector;
            private float zVector;
            private int speed;
            private uint duration;

            public float XVector
            {
                get { return xVector; }
                set { xVector = value; }
            }

            public float YVector
            {
                get { return yVector; }
                set { yVector = value; }
            }

            public float ZVector
            {
                get { return zVector; }
                set { zVector = value; }
            }

            public int Speed
            {
                get { return speed; }
                set { speed = value; }
            }

            public uint Duration
            {
                get { return duration; }
                set { duration = value; }
            }

            public MovementCommand()
            {
            }

            public MovementCommand(float xVector, float yVector, float zVector, int speed, uint duration)
            {
                this.XVector = xVector;
                this.YVector = yVector;
                this.ZVector = zVector;
                this.Speed = speed;
                this.Duration = duration;
            }

            override public string ToString()
            {
                return "X: " + XVector + ", Y: " + YVector + ", Z: " + ZVector + ", Speed: " + Speed + ", Duration: " + Duration;
            }

            public string ToJSON()
            {
                JsonSerializerSettings JsonSettings = new JsonSerializerSettings();
                JsonSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
                return JsonConvert.SerializeObject(this, Formatting.Indented, JsonSettings);
            }
        }

        public class SetDesiredAngleCommand
        {
            private int height;
            private float roll;
            private float pitch;
            private float yaw;

            public SetDesiredAngleCommand()
            {
            }

            public SetDesiredAngleCommand(int height, float roll, float pitch, float yaw)
            {
                this.height = height;
                this.roll = roll;
                this.pitch = pitch;
                this.yaw = yaw;
            }

            public int Height
            {
                get { return height; }
                set { height = value; }
            }

            public float Roll
            {
                get { return roll; }
                set { roll = value; }
            }

            public float Pitch
            {
                get { return pitch; }
                set { pitch = value; }
            }

            public float Yaw
            {
                get { return yaw; }
                set { yaw = value; }
            }

            override public string ToString()
            {
                return "Height: " + height + "Roll: " + roll + ", Pitch: " + pitch + ", Yaw: " + yaw;
            }

            public string ToJSON()
            {
                JsonSerializerSettings JsonSettings = new JsonSerializerSettings();
                JsonSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
                return JsonConvert.SerializeObject(this, Formatting.Indented, JsonSettings);
            }
        }

        public class Commands{

            public enum SystemStates { ARMED, DISARMED, CALIBRATING, CALIBRATED}

            private MovementCommand[] move;
            private SetDesiredAngleCommand[] hrpy;

            private string systemState;

            private string[] debug;

            public string[] Debug
            {
                get { return debug; }
                set { debug = value; }
            }

            public string SystemState
            {
                get { return systemState; }
                set { systemState = value; }
            }

            public MovementCommand[] Move
            {
                get { return move; }
                set { move = value; }
            }

            public SetDesiredAngleCommand[] HRPY
            {
                get { return hrpy; }
                set { hrpy = value; }
            }

            public Commands()
            {
            }

            override public string ToString()
            {
                string returnString = "Commands:\r\n";
                if (move != null)
                {
                    foreach (MovementCommand m in move)
                    {
                        returnString += "\r\nMove:\r\n\t" + m.ToString();
                    }
                }
                if (hrpy != null)
                {
                    foreach (SetDesiredAngleCommand c in hrpy)
                    {
                        returnString += "\r\nHrpy:\r\n\t" + c.ToString();
                    }
                }
                if (systemState != null)
                {
                    returnString += "\r\nSystem State: " + systemState + "\r\n";
                }
                if (debug != null)
                {
                    returnString += "\r\nDebug: " + debug + "\r\n";
                }
                return returnString;
            }
        }

        public class Request
        {
            private string resource;
            private int period;

            public string Resource
            {
                get { return resource; }
                set { resource = value; }
            }

            public int Period
            {
                get { return period; }
                set { period = value; }
            }

            public Request()
            {
            }

            public Request(String resource, int period)
            {
                this.resource = resource;
                this.period = period;
            }

            public override string ToString()
            {
                return "Resource: " + Resource + ", Period: " + Period;

            }
        }

        public abstract class Response
        {
            private long timestamp;

            public long Timestamp
            {
                get { return timestamp; }
                set { timestamp = value; }
            }

            public Response()
            {
            }

            public Response(long timestamp)
            {
                this.Timestamp = timestamp;
            }
        }

        public class HeightResponse : Response
        {
            private int height;

            public int Height
            {
                get { return height; }
                set { height = value; }
            }

            public HeightResponse(int h)
            {
                height = h;
            }

            override
            public  string  ToString()
            {
 	             string response = "Timestamp: "+this.Timestamp+"\r\n";
                response += "Height: " + this.height;

                return response;
            }

        }

        public class TriAxisSensorData : Response
        {
            private float x;
            private float y;
            private float z;

            public float X
            {
                get { return x; }
                set { x = value; }
            }

            public float Y
            {
                get { return y; }
                set { y = value; }
            }

            public float Z
            {
                get { return z; }
                set { z = value; }
            }

            public TriAxisSensorData()
            {

            }

            public TriAxisSensorData(float x, float y, float z)
            {
                this.X = x;
                this.Y = y;
                this.Z = z;
            }
        }

        public class TriAxisResponse : TriAxisSensorData
        {
            public TriAxisResponse()
            {
            }

            override public string ToString()
            {
                
                string response = "Timestamp: "+this.Timestamp+"\r\n";
                response += "X: " + this.X + ", Y: " + this.Y + ", Z: " + this.Z;

                return response;
            }
        }


        public class CameraResponse : Response
        {



            public CameraResponse()
            {

            }



        }

        public class Responses
        {
            private TriAxisResponse[] orientation;

            
            private TriAxisResponse[] gyro;
            private TriAxisResponse[] accel;
            private TriAxisResponse[] mag;
            private HeightResponse[] height;

            public HeightResponse[] Height
            {
                get { return height; }
                set { height = value; }
            }

            private string systemState;
            private string debug;

            public TriAxisResponse[] Orientation
            {
                get { return orientation; }
                set { orientation = value; }
            }
            
            public string Debug
            {
                get { return debug; }
                set { debug = value; }
            }

            public string SystemState
            {
                get { return systemState; }
                set { systemState = value; }
            }

            public TriAxisResponse[] Gyro
            {
                get { return gyro; }
                set { gyro = value; }
            }

            public TriAxisResponse[] Accel
            {
                get { return accel; }
                set { accel = value; }
            }

            public TriAxisResponse[] Mag
            {
                get { return mag; }
                set { mag = value; }
            }

            public Responses()
            {
                gyro = null;
                accel = null;
            }

            override public string ToString()
            {
                string responses = "Responses:";
               
                if (Orientation != null && Orientation.Length > 0)
                {
                    responses += "\r\n\r\nOrientation:\r\n";

                    foreach (QoD_DataCentre.Domain.JSON.JsonObjects.TriAxisResponse orient in Orientation)
                    {
                        if (orient != null)
                        {
                            responses += "\r\n\t" + orient.ToString().Replace("\r\n", "\r\n\t");
                        }
                    }
                }
                if (Accel != null && Accel.Length > 0)
                {
                    responses += "\r\n\r\nAccelerometer:\r\n";

                    foreach (QoD_DataCentre.Domain.JSON.JsonObjects.TriAxisResponse accel in Accel)
                    {
                        if (accel != null)
                        {
                            responses += "\r\n\t" + accel.ToString().Replace("\r\n", "\r\n\t");
                        }
                    }
                }
                if (Gyro != null && Gyro.Length > 0)
                {
                    responses += "\r\n\r\nGyroscope:\r\n";

                    foreach (QoD_DataCentre.Domain.JSON.JsonObjects.TriAxisResponse gyro in Gyro)
                    {
                        if (gyro != null)
                        {
                            responses += "\r\n\t" + gyro.ToString().Replace("\r\n", "\r\n\t");
                        }
                    }
                }
                if (Mag != null && Mag.Length > 0)
                {
                    responses += "\r\n\r\nMagnetometer:\r\n";

                    foreach (QoD_DataCentre.Domain.JSON.JsonObjects.TriAxisResponse mag in Mag)
                    {
                        if (mag != null)
                        {
                            responses += "\r\n\t" + mag.ToString().Replace("\r\n", "\r\n\t");
                        }
                    }
                }
                if (Height != null && Height.Length > 0)
                {
                    responses += "\r\n\r\nHeight:\r\n";

                    foreach (QoD_DataCentre.Domain.JSON.JsonObjects.HeightResponse h in Height)
                    {
                        if (h != null)
                        {
                            responses += "\r\n\t" + h.ToString().Replace("\r\n", "\r\n\t");
                        }
                    }
                }
                

                if (SystemState != null)
                {
                    responses += "\r\n\r\nSystemState: ";
                    responses += SystemState + "\r\n";
                }

                if (Debug != null)
                {
                    responses += "\r\nDebug: ";
                    responses += Debug + "\r\n";
                }

                return responses;
            }

            public string ToJSON()
            {
                JsonSerializerSettings JsonSettings = new JsonSerializerSettings();
                JsonSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
                return JsonConvert.SerializeObject(this, Formatting.Indented, JsonSettings);
            }

        }

        public class Envelope
        {
            Commands commands;
            Request[] requests;
            Responses responses;

            public Commands Commands
            {
                get { return commands; }
                set { commands = value; }
            }

            public Request[] Requests
            {
                get { return requests; }
                set { requests = value; }
            }

            public Responses Responses
            {
                get { return responses; }
                set { responses = value; }
            }

            public Envelope()
            {
            }

            public Envelope(Commands commands, Request[] requests, Responses responses)
            {
                this.commands = commands;
                this.requests = requests;
                this.responses = responses;
            }

            override public string ToString()
            {
                string returnString = "\r\nEnvelope: \r\n";
                if(commands != null)
                    returnString += "\r\n" + commands.ToString().Replace("\r\n","\r\n\t");
                if (requests != null)
                {
                    returnString += "\r\n\r\nRequests\r\n";
                    foreach (Request req in requests)
                        returnString += "\t" + req.ToString() + "\r\n";
                }
                if(responses != null)
                    returnString += "\r\n" + responses.ToString().Replace("\r\n", "\r\n\t");

                return returnString;
            }

            public string ToJSON()
            {
                JsonSerializerSettings JsonSettings = new JsonSerializerSettings();
                JsonSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
                return JsonConvert.SerializeObject(this, Formatting.Indented, JsonSettings); 
            }

        }
    }
}
