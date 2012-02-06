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

            public float XVector
            {
                get { return xVector; }
                set { xVector = value; }
            }
            private float yVector;

            public float YVector
            {
                get { return yVector; }
                set { yVector = value; }
            }
            private float zVector;

            public float ZVector
            {
                get { return zVector; }
                set { zVector = value; }
            }
            private int speed;

            public int Speed
            {
                get { return speed; }
                set { speed = value; }
            }
            private uint duration;

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

            public string ToJSON()
            {
                JsonSerializerSettings JsonSettings = new JsonSerializerSettings();
                JsonSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
                return JsonConvert.SerializeObject(this, Formatting.Indented, JsonSettings);
            }

        }

        public class Commands{

            private MovementCommand[] move;

            public MovementCommand[] Move
            {
                get { return move; }
                set { move = value; }
            }


            public Commands()
            {

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

        public class TriAxisSensorData
        {

            private float x;

            public float X
            {
                get { return x; }
                set { x = value; }
            }
            private float y;

            public float Y
            {
                get { return y; }
                set { y = value; }
            }
            private float z;

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

        public class TriAxisResponse : Response
        {
            private TriAxisSensorData data;

            public TriAxisSensorData Data
            {
                get { return data; }
                set { data = value; }
            }

            public TriAxisResponse()
            {
                Data = new TriAxisSensorData();

            }

            override
            public string ToString()
            {
                string response = "Timestamp: "+this.Timestamp+"\r\n";
                response += "X: " + this.data.X + ", Y: " + this.data.Y + ", Z: " + this.data.Z;

                return response;
            }
        }

        public class Responses
        {
            private TriAxisResponse[] gyro;
            private TriAxisResponse[] accel;

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

            public Responses()
            {
                gyro = null;
                accel = null;
            }

            override
            public string ToString()
            {
                string responses = "";

                if (Gyro != null && Gyro.Length > 0)
                {
                    responses += "Gyroscope:\r\n\r\n";

                    foreach (QoD_DataCentre.Domain.JSON.JsonObjects.TriAxisResponse gyro in Gyro)
                    {
                        responses += gyro.ToString() + "\r\n\r\n";
                    }


                }

                if (Accel != null && Accel.Length > 0)
                {
                    responses += "Accelarometer:\r\n\r\n";

                    foreach (QoD_DataCentre.Domain.JSON.JsonObjects.TriAxisResponse accel in Accel)
                    {
                        responses += accel.ToString() + "\r\n\r\n";
                    }


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

        public class Envelope{

            Commands commands;

            public Commands Commands
            {
                get { return commands; }
                set { commands = value; }
            }
            Request[] requests;

            public Request[] Requests
            {
                get { return requests; }
                set { requests = value; }
            }
            Responses responses;

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

            public string ToJSON()
            {
                JsonSerializerSettings JsonSettings = new JsonSerializerSettings();
                JsonSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
                return JsonConvert.SerializeObject(this, Formatting.Indented, JsonSettings); 
            }

        }
        

    }
}
