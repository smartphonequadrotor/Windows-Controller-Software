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
        List<RollingPointPairList> orientationDataSets = new List<RollingPointPairList>();

        private string[] labelArrayXYZ = new string[] { "x", "y", "z" };
        private string[] labelArrayLatLong = new string[] { "latitude", "longitude", "height" };
        private string[] labelArrayMotors = new string[] { "Motor 1", "Motor 2", "Motor 3", "Motor 4" };

        private long time = 0;

        long maxAccelTimeStamp;
        long maxGyroTimeStamp;

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

            //initialize point pair lists
            for (int i = 0; i < 30000; i++)
            {
                accelerometerX.Add(0, 0);
                accelerometerY.Add(0, 0);
                accelerometerZ.Add(0, 0);
                orientationX.Add(0, 0);
                orientationY.Add(0, 0);
                orientationZ.Add(0, 0);
                /*double x = (double)i * 0.2;
                double y = Math.Sin((double)i * Math.PI / 15.0) * 16.0;
                double y2 = y / 2;
                double y3 = y / 4;
                double y4 = Math.Cos((double)i * Math.PI / 15.0) * 16.0;
                accelerometerX.Add(x, y);
                accelerometerY.Add(x, y2);
                accelerometerZ.Add(x, y3);
                list4.Add(x, y4);*/
            }

            accelerometerDataSets.Add(accelerometerX);
            accelerometerDataSets.Add(accelerometerY);
            accelerometerDataSets.Add(accelerometerZ);

            orientationDataSets.Add(orientationX);
            orientationDataSets.Add(orientationY);
            orientationDataSets.Add(orientationZ);

            maxAccelTimeStamp = 0;
            maxGyroTimeStamp = 0;

            initializeGraph(accelerationVsTime, "Acceleration vs Time", "Acceleration", "Time", accelerometerDataSets, labelArrayXYZ);
            // Size the control to fit the window
            SetSize(ref accelerationVsTime, 10);

            initializeGraph(orientationVsTime, "Orientation vs Time", "Orientation", "Time", orientationDataSets, labelArrayXYZ);
            SetSize(ref orientationVsTime, 320);

            initialized = true;
        }

        private void initializeGraph(ZedGraphControl graph, string title, string yTitle, string xTitle, List<RollingPointPairList> dataSets, string[] labelArray)
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
            gp.YAxis.Scale.Min = -30;
            gp.YAxis.Scale.Max = 30;

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
            //update acceleration vs time graph as needed
            for (int i = 0; i < j.Responses.Accel.Length; i++)
            {
                if (j.Responses.Accel[i].Timestamp > maxAccelTimeStamp)
                {
                    updateGraph(ref accelerationVsTime, ref accelerometerDataSets, GraphData.X, j.Responses.Accel[i].Timestamp, j.Responses.Accel[i].X);
                    updateGraph(ref accelerationVsTime, ref accelerometerDataSets, GraphData.Y, j.Responses.Accel[i].Timestamp, j.Responses.Accel[i].Y);
                    updateGraph(ref accelerationVsTime, ref accelerometerDataSets, GraphData.Z, j.Responses.Accel[i].Timestamp, j.Responses.Accel[i].Z);
                }
            }

            //find max acceleration time stamp
            for (int i = 0; i < j.Responses.Accel.Length; i++)
            {
                if (j.Responses.Accel[i].Timestamp > maxAccelTimeStamp)
                {
                    maxAccelTimeStamp = j.Responses.Accel[i].Timestamp;
                }
            }

            //update orientation vs time graph as needed
            for (int i = 0; i < j.Responses.Gyro.Length; i++)
            {
                if (j.Responses.Gyro[i].Timestamp > maxGyroTimeStamp)
                {
                    updateGraph(ref orientationVsTime, ref orientationDataSets, GraphData.X, j.Responses.Gyro[i].Timestamp, j.Responses.Gyro[i].X);
                    updateGraph(ref orientationVsTime, ref orientationDataSets, GraphData.Y, j.Responses.Gyro[i].Timestamp, j.Responses.Gyro[i].Y);
                    updateGraph(ref orientationVsTime, ref orientationDataSets, GraphData.Z, j.Responses.Gyro[i].Timestamp, j.Responses.Gyro[i].Z);
                }
            }

            //find max orientation time stamp
            for (int i = 0; i < j.Responses.Gyro.Length; i++)
            {
                if (j.Responses.Gyro[i].Timestamp > maxGyroTimeStamp)
                {
                    maxGyroTimeStamp = j.Responses.Gyro[i].Timestamp;
                }
            }
            //todo lisa
            /*for (int i = 0; i < j.Responses.Gyro.Length; i++)
            {
                if (j.Responses.Accel[i].Timestamp == maxAccelTimeStamp)
                {
                    updateGraph(GraphingData.accelerometerX, j.Responses.Accel[i].Timestamp, j.Responses.Accel[i].X);
                    updateGraph(GraphingData.accelerometerY, j.Responses.Accel[i].Timestamp, j.Responses.Accel[i].Y);
                    updateGraph(GraphingData.accelerometerZ, j.Responses.Accel[i].Timestamp, j.Responses.Accel[i].Z);
                }
            }*/
        }

        public void updateGraph(ref ZedGraphControl graph, ref List<RollingPointPairList> dataSets, GraphData valueToChange, long time, float data)
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

            //accelerationVsTime.GraphPane.AxisChange();
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
    }
}