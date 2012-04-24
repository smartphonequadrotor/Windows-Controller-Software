using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using ZedGraph;
using QoD_DataCentre.Domain.JSON;
//using QoD_DataCentre.Domain.Enum;

namespace QoD_DataCentre.Controls
{
    public partial class Statistics : UserControl
    {
        public bool initialized = false;

        private int xMaxRange = 5; //range of x axis in ms
        List<RollingPointPairList> accelerometerDataSets = new List<RollingPointPairList>();
        List<RollingPointPairList> gyroDataSets = new List<RollingPointPairList>();
        List<RollingPointPairList> magDataSets = new List<RollingPointPairList>();
        List<RollingPointPairList> orientationDataSets = new List<RollingPointPairList>();
        List<RollingPointPairList> heightDataSet = new List<RollingPointPairList>();

        private string[] labelArrayXYZ = new string[] { "x", "y", "z" };
        private string[] labelArrayLatLong = new string[] { "latitude", "longitude", "height" };
        private string[] labelArrayMotors = new string[] { "Motor 1", "Motor 2", "Motor 3", "Motor 4" };

        long maxAccelTimeStamp;
        long maxOrientationTimeStamp;
        long maxGyroTimeStamp;
        long maxMagTimeStamp;
        long maxHeightTimeStamp;

        public Statistics()
        {
            InitializeComponent();
        }

        public void InitializeControl()
        {
            // Make up some data points based on the Sine function
            RollingPointPairList accelerometerX = new RollingPointPairList(30000);
            RollingPointPairList accelerometerY = new RollingPointPairList(30000);
            RollingPointPairList accelerometerZ = new RollingPointPairList(30000);

            RollingPointPairList orientationX = new RollingPointPairList(30000);
            RollingPointPairList orientationY = new RollingPointPairList(30000);
            RollingPointPairList orientationZ = new RollingPointPairList(30000);

            RollingPointPairList gyroX = new RollingPointPairList(30000);
            RollingPointPairList gyroY = new RollingPointPairList(30000);
            RollingPointPairList gyroZ = new RollingPointPairList(30000);

            RollingPointPairList magX = new RollingPointPairList(30000);
            RollingPointPairList magY = new RollingPointPairList(30000);
            RollingPointPairList magZ = new RollingPointPairList(30000);

            RollingPointPairList height = new RollingPointPairList(30000);

            //initialize point pair lists
            for (int i = 0; i < 30000; i++)
            {
                accelerometerX.Add(0, 0);
                accelerometerY.Add(0, 0);
                accelerometerZ.Add(0, 0);
                orientationX.Add(0, 0);
                orientationY.Add(0, 0);
                orientationZ.Add(0, 0);
                gyroX.Add(0, 0);
                gyroY.Add(0, 0);
                gyroZ.Add(0, 0);
                magX.Add(0, 0);
                magY.Add(0, 0);
                magZ.Add(0, 0);
                height.Add(0, 0);
            }
            accelerometerDataSets.Clear();
            accelerometerDataSets.Add(accelerometerX);
            accelerometerDataSets.Add(accelerometerY);
            accelerometerDataSets.Add(accelerometerZ);

            orientationDataSets.Clear();
            orientationDataSets.Add(orientationX);
            orientationDataSets.Add(orientationY);
            orientationDataSets.Add(orientationZ);

            gyroDataSets.Clear();
            gyroDataSets.Add(gyroX);
            gyroDataSets.Add(gyroY);
            gyroDataSets.Add(gyroZ);

            magDataSets.Clear();
            magDataSets.Add(magX);
            magDataSets.Add(magY);
            magDataSets.Add(magZ);

            heightDataSet.Clear();
            heightDataSet.Add(height);

            maxAccelTimeStamp = 0;
            maxOrientationTimeStamp = 0;
            maxGyroTimeStamp = 0;
            maxMagTimeStamp = 0;
            maxHeightTimeStamp = 0;

            for (int i = orientationVsTime.GraphPane.CurveList.Count - 1; i > -1; i--)
                orientationVsTime.GraphPane.CurveList.Remove(orientationVsTime.GraphPane.CurveList[i]);

            initializeGraph(orientationVsTime, "Orientation vs Time", "Orientation", "Time", orientationDataSets, labelArrayXYZ, 180);
            SetSize(ref orientationVsTime, 10);

            for (int i = accelerationVsTime.GraphPane.CurveList.Count - 1; i > -1; i-- )
                accelerationVsTime.GraphPane.CurveList.Remove(accelerationVsTime.GraphPane.CurveList[i]);
            
            initializeGraph(accelerationVsTime, "Acceleration vs Time", "Acceleration", "Time", accelerometerDataSets, labelArrayXYZ, 0);
            // Size the control to fit the window
            SetSize(ref accelerationVsTime, 320);

            for (int i = gyroVsTime.GraphPane.CurveList.Count - 1; i > -1; i--)
                gyroVsTime.GraphPane.CurveList.Remove(gyroVsTime.GraphPane.CurveList[i]);

            initializeGraph(gyroVsTime, "Gyroscope Values vs Time", "Gs", "Time", gyroDataSets, labelArrayXYZ, 0);
            SetSize(ref gyroVsTime, 630);

            for (int i = magVsTime.GraphPane.CurveList.Count - 1; i > -1; i--)
                magVsTime.GraphPane.CurveList.Remove(magVsTime.GraphPane.CurveList[i]);

            initializeGraph(magVsTime, "Magnetometer Values vs Time", "Magnetometer Value", "Time", magDataSets, labelArrayXYZ, 0);
            SetSize(ref magVsTime, 940);

            for (int i = heightVsTime.GraphPane.CurveList.Count - 1; i > -1; i--)
                heightVsTime.GraphPane.CurveList.Remove(heightVsTime.GraphPane.CurveList[i]);

            initializeGraph(heightVsTime, "Height Values vs Time", "Height Value", "Time", heightDataSet, labelArrayXYZ, 100);
            SetSize(ref heightVsTime, 1250);

            initialized = true;
        }

        private void initializeGraph(ZedGraphControl graph, string title, string yTitle, string xTitle, List<RollingPointPairList> dataSets, string[] labelArray, int range)
        {
            GraphPane gp = graph.GraphPane;
            // Set the titles and axis labels
            gp.Title.Text = title;
            gp.XAxis.Title.Text = xTitle;
            gp.YAxis.Title.Text = yTitle;
            //gp.Y2Axis.Title.Text = "Parameter B";

            Color[] colorArray = new Color[] { Color.Red, Color.Blue, Color.Green, Color.Yellow };

            int arrayIndex = 0;

            foreach (RollingPointPairList dataSet in dataSets)
            {
                gp.AddCurve(labelArray[arrayIndex], dataSet, colorArray[arrayIndex]);
                arrayIndex++;
            }

            // Show the x axis grid
            gp.XAxis.MajorGrid.IsVisible = true;

            //if(dataSets[
            //gp.XAxis.Scale.Max = 
            //gp.XAxis.Scale.Min = 0;
            //gp.XAxis.Scale.Max = xMaxRange;

            // turn off the opposite tics so the Y tics don't show up on the Y2 axis
            //gp.YAxis.MajorTic.IsOpposite = false;
            //gp.YAxis.MinorTic.IsOpposite = false;
            // Don't display the Y zero line
            //gp.YAxis.MajorGrid.IsZeroLine = false;
            // Align the Y axis labels so they are flush to the axis
            //gp.YAxis.Scale.Align = AlignP.Inside;
            // Manually set the axis range
            if (range > 0)
            {
                gp.YAxis.Scale.Min = -range;
                gp.YAxis.Scale.Max = range;
            }
            else
            {
                gp.YAxis.Scale.MaxAuto = true;
                gp.YAxis.Scale.MinAuto = true;
                gp.YAxis.Scale.MajorStepAuto = true;
                gp.YAxis.Scale.MinorStepAuto = true;
                gp.YAxis.Scale.MagAuto = true;
            }

                gp.XAxis.Scale.Min = 0;
                gp.XAxis.Scale.Max = 5;
            // Enable the Y2 axis display
            /*gp.Y2Axis.IsVisible = true;
            // Make the Y2 axis scale blue
            gp.Y2Axis.Scale.FontSpec.FontColor = Color.Blue;
            gp.Y2Axis.Title.FontSpec.FontColor = Color.Blue;
            // turn off the opposite tics so the Y2 tics don't show up on the Y axis
            gp.Y2Axis.MajorTic.IsOpposite = false;
            gp.Y2Axis.MinorTic.IsOpposite = false;
            // Display the Y2 axis grid lines
            gp.Y2Axis.MajorGrid.IsVisible = true;
            // Align the Y2 axis labels so they are flush to the axis
            gp.Y2Axis.Scale.Align = AlignP.Inside;*/

            // Fill the axis background with a gradient
            //gp.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0f);

            // Add a text box with instructions
            TextObj text = new TextObj(
                "Zoom: left mouse & drag\nPan: middle mouse & drag\nContext Menu: right mouse",
                0.05f, 0.95f, CoordType.ChartFraction, AlignH.Left, AlignV.Bottom);
            text.FontSpec.StringAlignment = StringAlignment.Near;
            gp.GraphObjList.Add(text);

            // Enable scrollbars if needed
            /*accelerationVsTime.IsShowHScrollBar = true;*/
            //accelerationVsTime.IsShowVScrollBar = true;
            graph.IsAutoScrollRange = true;
            //accelerationVsTime.IsScrollY2 = true;*/

            // OPTIONAL: Show tooltips when the mouse hovers over a point
            graph.IsShowPointValues = true;
            graph.PointValueEvent += new ZedGraphControl.PointValueHandler(MyPointValueHandler);

            // OPTIONAL: Add a custom context menu item
            //accelerationVsTime.ContextMenuBuilder += new ZedGraphControl.ContextMenuBuilderEventHandler(
            //              MyContextMenuBuilder);

            // OPTIONAL: Handle the Zoom Event
            graph.ZoomEvent += new ZedGraphControl.ZoomEventHandler(MyZoomEvent);

            // Tell ZedGraph to calculate the axis ranges
            // Note that you MUST call this after enabling IsAutoScrollRange, since AxisChange() sets
            // up the proper scrolling parameters
            graph.AxisChange();
            // Make sure the Graph gets redrawn
            graph.Invalidate();
        }

        public void updateGraph(ref JsonObjects.Envelope j)
        {
            if (!this.initialized)
                this.InitializeControl();
            //update acceleration vs time graph as needed
            if (j.Responses != null && j.Responses.Accel != null)
            {
                foreach (JsonObjects.TriAxisSensorData sensor in j.Responses.Accel)
                {
                    if (sensor.Timestamp > maxAccelTimeStamp)
                    {
                        updateGraph(ref accelerationVsTime, ref accelerometerDataSets, GraphData.X, sensor.Timestamp / 1000.0, sensor.X);
                        updateGraph(ref accelerationVsTime, ref accelerometerDataSets, GraphData.Y, sensor.Timestamp / 1000.0, sensor.Y);
                        updateGraph(ref accelerationVsTime, ref accelerometerDataSets, GraphData.Z, sensor.Timestamp / 1000.0, sensor.Z);
                    }
                }

                //find max acceleration time stamp
                foreach (JsonObjects.TriAxisSensorData sensor in j.Responses.Accel)
                {
                    if (sensor.Timestamp > maxAccelTimeStamp)
                    {
                        maxAccelTimeStamp = sensor.Timestamp;
                    }
                }
            }

                //update orientation vs time graph as needed
            if (j.Responses != null && j.Responses.Orientation != null)
            {
                foreach (JsonObjects.TriAxisSensorData sensor in j.Responses.Orientation)
                {
                    if (sensor.Timestamp > maxOrientationTimeStamp)
                    {
                        updateGraph(ref orientationVsTime, ref orientationDataSets, GraphData.X, sensor.Timestamp / 1000.0, (float)(360.0 * (sensor.X / (2.0 * Math.PI))));
                        updateGraph(ref orientationVsTime, ref orientationDataSets, GraphData.Y, sensor.Timestamp / 1000.0, (float)(360.0 * (sensor.Y / (2.0 * Math.PI))));
                        updateGraph(ref orientationVsTime, ref orientationDataSets, GraphData.Z, sensor.Timestamp / 1000.0, (float)(360.0 * (sensor.Z / (2.0 * Math.PI))));
                    }
                }

                //find max orientation time stamp
                foreach (JsonObjects.TriAxisSensorData sensor in j.Responses.Orientation)
                {
                    if (sensor.Timestamp > maxOrientationTimeStamp)
                    {
                        maxOrientationTimeStamp = sensor.Timestamp;
                    }
                }
            }

            if (j.Responses != null && j.Responses.Gyro != null)
            {
                foreach(JsonObjects.TriAxisSensorData sensor in j.Responses.Gyro)
                {

                    if (sensor.Timestamp > maxGyroTimeStamp)
                    {
                        updateGraph(ref gyroVsTime, ref gyroDataSets, GraphData.X, sensor.Timestamp / 1000.0, sensor.X);
                        updateGraph(ref gyroVsTime, ref gyroDataSets, GraphData.Y, sensor.Timestamp / 1000.0, sensor.Y);
                        updateGraph(ref gyroVsTime, ref gyroDataSets, GraphData.Z, sensor.Timestamp / 1000.0, sensor.Z);
                    }
                }

                //find max orientation time stamp
                foreach (JsonObjects.TriAxisSensorData sensor in j.Responses.Gyro)
                {
                    if (sensor.Timestamp > maxGyroTimeStamp)
                    {
                        maxGyroTimeStamp = sensor.Timestamp;
                    }
                }
            }

            if (j.Responses != null && j.Responses.Mag!= null)
            {
                foreach (JsonObjects.TriAxisSensorData sensor in j.Responses.Mag)
                {

                    if (sensor.Timestamp > maxMagTimeStamp)
                    {
                        updateGraph(ref magVsTime, ref magDataSets, GraphData.X, sensor.Timestamp / 1000.0, sensor.X);
                        updateGraph(ref magVsTime, ref magDataSets, GraphData.Y, sensor.Timestamp / 1000.0, sensor.Y);
                        updateGraph(ref magVsTime, ref magDataSets, GraphData.Z, sensor.Timestamp / 1000.0, sensor.Z);
                    }
                }

                //find max orientation time stamp
                foreach (JsonObjects.TriAxisSensorData sensor in j.Responses.Mag)
                {
                    if (sensor.Timestamp > maxMagTimeStamp)
                    {
                        maxMagTimeStamp = sensor.Timestamp;
                    }
                }
            }
            if (j.Responses != null && j.Responses.Height != null)
            {
                foreach (JsonObjects.HeightResponse sensor in j.Responses.Height)
                {

                    if (sensor.Timestamp > maxHeightTimeStamp)
                    {
                        updateGraph(ref heightVsTime, ref heightDataSet, GraphData.X, sensor.Timestamp / 1000.0, sensor.Height);
                    }
                }

                //find max orientation time stamp
                foreach (JsonObjects.HeightResponse sensor in j.Responses.Height)
                {
                    if (sensor.Timestamp > maxMagTimeStamp)
                    {
                        maxMagTimeStamp = sensor.Timestamp;
                    }
                }
            }

        }

        public void updateGraph(ref ZedGraphControl graph, ref List<RollingPointPairList> dataSets, GraphData valueToChange, double time, float data)
        {
            //change the x axis values shown to user
            double incomingTimeVal = (double)time;
            if (graph.GraphPane.XAxis.Scale.Max < incomingTimeVal)
            {
                graph.GraphPane.XAxis.Scale.Max = incomingTimeVal;
            }
            graph.GraphPane.XAxis.Scale.Min = graph.GraphPane.XAxis.Scale.Max - xMaxRange;

            dataSets[(int)valueToChange].Add(time, data);
            //dataSets[1].Add(time, y + 5);
            //dataSets[2].Add(time, y);
            //dataSets[3].Add(x, y - 10);

            graph.GraphPane.AxisChange();
            graph.Invalidate();
        }

        private void SetSize(ref ZedGraphControl graph, int locationY)
        {
            graph.Location = new Point(10, locationY);
            // Leave a small margin around the outside of the control
            graph.Size = new Size(500,//this.ClientRectangle.Width - 20,
                    300);//this.ClientRectangle.Height - 20);
        }

        /// <summary>
        /// Display customized tooltips when the mouse hovers over a point
        /// </summary>
        private string MyPointValueHandler(ZedGraphControl control, GraphPane pane,
                        CurveItem curve, int iPt)
        {
            // Get the PointPair that is under the mouse
            PointPair pt = curve[iPt];

            return curve.Label.Text + " is " + pt.Y.ToString("f2") + " units at " + pt.X.ToString("f1") + " days";
        }

        /// <summary>
        /// Customize the context menu by adding a new item to the end of the menu
        /// </summary>
        private void MyContextMenuBuilder(ZedGraphControl control, ContextMenuStrip menuStrip,
                        Point mousePt, ZedGraphControl.ContextMenuObjectState objState)
        {
            ToolStripMenuItem item = new ToolStripMenuItem();
            item.Name = "add-beta";
            item.Tag = "add-beta";
            item.Text = "Add a new Beta Point";
            item.Click += new System.EventHandler(AddBetaPoint);

            menuStrip.Items.Add(item);
        }

        /// <summary>
        /// Handle the "Add New Beta Point" context menu item.  This finds the curve with
        /// the CurveItem.Label = "Beta", and adds a new point to it.
        /// </summary>
        private void AddBetaPoint(object sender, EventArgs args)
        {
            // Get a reference to the "Beta" curve IPointListEdit
            IPointListEdit ip = accelerationVsTime.GraphPane.CurveList["Beta"].Points as IPointListEdit;
            if (ip != null)
            {
                double x = ip.Count * 5.0;
                double y = Math.Sin(ip.Count * Math.PI / 15.0) * 16.0 * 13.5;
                ip.Add(x, y);
                accelerationVsTime.AxisChange();
                accelerationVsTime.Refresh();
            }
        }

        // Respond to a Zoom Event
        private void MyZoomEvent(ZedGraphControl control, ZoomState oldState,
                    ZoomState newState)
        {
            // Here we get notification everytime the user zooms
        }

        private void orientationVsTime_Load(object sender, EventArgs e)
        {

        }
    }
}