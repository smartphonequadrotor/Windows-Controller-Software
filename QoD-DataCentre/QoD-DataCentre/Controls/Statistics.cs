using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace QoD_DataCentre.Controls
{
    public partial class Statistics : UserControl
    {
        public Statistics()
        {
            InitializeComponent();
        }

        public void InitializeControl()
        {
            //todo lisa -- for the actual data, probably want to use the RollingPointPairList as in the
            //stack overflow question - http://stackoverflow.com/questions/7671070/scrolling-does-not-work-with-zedgraph
            // Make up some data points based on the Sine function
            RollingPointPairList list = new RollingPointPairList(40);
            RollingPointPairList list2 = new RollingPointPairList(40);
            RollingPointPairList list3 = new RollingPointPairList(40);
            RollingPointPairList list4 = new RollingPointPairList(40);
            for (int i = 0; i < 40; i++)
            {
                double x = (double)i * 5.0;
                double y = Math.Sin((double)i * Math.PI / 15.0) * 16.0;
                double y2 = y / 2;
                double y3 = y / 4;
                double y4 = Math.Cos((double)i * Math.PI / 15.0) * 16.0;
                list.Add(x, y);
                list2.Add(x, y2);
                list3.Add(x, y3);
                list4.Add(x, y4);
            }

            List<RollingPointPairList> dataSets = new List<RollingPointPairList>();
            dataSets.Add(list);
            dataSets.Add(list2);
            dataSets.Add(list3);
            dataSets.Add(list4);

            string[] labelArray = new string[]{"x", "y", "z", "woohoo!"};

            initializeGraph(accelerationVsTime.GraphPane, "Acceleration vs Time", "Acceleration", "Time", dataSets, labelArray);

            System.Threading.Thread.Sleep(200);

            //this should update every 30 ms

            int time = 200;

            dataSets[0].Add(time, 10);
            dataSets[1].Add(time, 5);
            dataSets[2].Add(time, 0);
            dataSets[3].Add(time, -10);

            //need to change the x axis values shown to user
            /*double xRange = myPane02m.XAxis.Scale.Max - myPane02m.XAxis.Scale.Min;
            myPane02m.XAxis.Scale.Max = new XDate(DateTime.Now);
            myPane02m.XAxis.Scale.Min = myPane02m.XAxis.Scale.Max - xRange;*/

            System.Threading.Thread.Sleep(200);
            dataSets[0].Add(time+10, 10);
            dataSets[1].Add(time+10, 5);
            dataSets[2].Add(time+10, 0);
            dataSets[3].Add(time+10, -10);
            System.Threading.Thread.Sleep(200);
            dataSets[0].Add(time+20, 10);
            dataSets[1].Add(time+20, 5);
            dataSets[2].Add(time+20, 0);
            dataSets[3].Add(time+20, -10);
            System.Threading.Thread.Sleep(200);
            dataSets[0].Add(time+30, 10);
            dataSets[1].Add(time+30, 5);
            dataSets[2].Add(time+30, 0);
            dataSets[3].Add(time+30, -10);
            System.Threading.Thread.Sleep(200);
            dataSets[0].Add(time+40, 10);
            dataSets[1].Add(time+40, 5);
            dataSets[2].Add(time+40, 0);
            dataSets[3].Add(time+40, -10);
            System.Threading.Thread.Sleep(200);
            dataSets[0].Add(time+50, 10);
            dataSets[1].Add(time+50, 5);
            dataSets[2].Add(time+50, 0);
            dataSets[3].Add(time+50, -10);
            System.Threading.Thread.Sleep(200);
            dataSets[0].Add(time + 60, 10);
            dataSets[1].Add(time+60, 5);
            dataSets[2].Add(time+60, 0);
            dataSets[3].Add(time+60, -10);
            System.Threading.Thread.Sleep(200);
            dataSets[0].Add(time + 70, 10);
            dataSets[1].Add(time+70, 5);
            dataSets[2].Add(time+70, 0);
            dataSets[3].Add(time+70, -10);
            System.Threading.Thread.Sleep(200);
            dataSets[0].Add(time + 80, 10);
            dataSets[1].Add(time+80, 5);
            dataSets[2].Add(time+80, 0);
            dataSets[3].Add(time+80, -10);
            System.Threading.Thread.Sleep(200);
            dataSets[0].Add(time + 90, 10);
            dataSets[1].Add(time+90, 5);
            dataSets[2].Add(time+90, 0);
            dataSets[3].Add(time+90, -10);
            System.Threading.Thread.Sleep(200);
            dataSets[0].Add(time + 100, 10);
            dataSets[1].Add(time+100, 5);
            dataSets[2].Add(time+100, 0);
            dataSets[3].Add(time+100, -10);
            System.Threading.Thread.Sleep(200);
            dataSets[0].Add(time + 110, 10);
            dataSets[1].Add(time+110, 5);
            dataSets[2].Add(time+110, 0);
            dataSets[3].Add(time+110, -10);
            System.Threading.Thread.Sleep(200);
            dataSets[0].Add(time + 120, 10);
            dataSets[1].Add(time+120, 5);
            dataSets[2].Add(time+120, 0);
            dataSets[3].Add(time+120, -10);
            System.Threading.Thread.Sleep(200);
            dataSets[0].Add(time + 130, 10);
            dataSets[1].Add(time+130, 5);
            dataSets[2].Add(time+130, 0);
            dataSets[3].Add(time+130, -10);
            System.Threading.Thread.Sleep(200);
            dataSets[0].Add(time + 140, 10);
            System.Threading.Thread.Sleep(200);
            dataSets[0].Add(time + 150, 10);
            System.Threading.Thread.Sleep(200);
            dataSets[0].Add(time + 160, 10);
            System.Threading.Thread.Sleep(200);
            dataSets[0].Add(time + 170, 10);
            System.Threading.Thread.Sleep(200);
            dataSets[0].Add(time + 180, 10);

            //todo lisa - all graphs in goodnotes are expected to have 3 sets of data (x, y, z; lat, long, height, etc)
            //except raw data which has 4 (data for each motor). suggested method of implementation - initializeGraph
            //will accept an array of pointLists
        }

        private void initializeGraph(GraphPane gp, string title, string yTitle, string xTitle, List<RollingPointPairList> dataSets, string[] labelArray)
        {
            // Set the titles and axis labels
            gp.Title.Text = title;
            gp.XAxis.Title.Text = xTitle;
            gp.YAxis.Title.Text = yTitle;
            //gp.Y2Axis.Title.Text = "Parameter B";

            Color[] colorArray = new Color[]{Color.Red, Color.Blue, Color.Green, Color.Yellow};

            int arrayIndex = 0;

            foreach (RollingPointPairList dataSet in dataSets)
            {
                gp.AddCurve(labelArray[arrayIndex], dataSet, colorArray[arrayIndex]);
                arrayIndex++;
            }

            // Show the x axis grid
            gp.XAxis.MajorGrid.IsVisible = true;

            // turn off the opposite tics so the Y tics don't show up on the Y2 axis
            //gp.YAxis.MajorTic.IsOpposite = false;
            //gp.YAxis.MinorTic.IsOpposite = false;
            // Don't display the Y zero line
            //gp.YAxis.MajorGrid.IsZeroLine = false;
            // Align the Y axis labels so they are flush to the axis
            //gp.YAxis.Scale.Align = AlignP.Inside;
            // Manually set the axis range
            //gp.YAxis.Scale.Min = -30;
            //gp.YAxis.Scale.Max = 30;

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
            /*accelerationVsTime.IsShowHScrollBar = true;
            accelerationVsTime.IsShowVScrollBar = true;
            accelerationVsTime.IsAutoScrollRange = true;
            accelerationVsTime.IsScrollY2 = true;*/

            // OPTIONAL: Show tooltips when the mouse hovers over a point
            accelerationVsTime.IsShowPointValues = true;
            accelerationVsTime.PointValueEvent += new ZedGraphControl.PointValueHandler(MyPointValueHandler);

            // OPTIONAL: Add a custom context menu item
            //accelerationVsTime.ContextMenuBuilder += new ZedGraphControl.ContextMenuBuilderEventHandler(
              //              MyContextMenuBuilder);

            // OPTIONAL: Handle the Zoom Event
            accelerationVsTime.ZoomEvent += new ZedGraphControl.ZoomEventHandler(MyZoomEvent);

            // Size the control to fit the window
            SetSize();

            // Tell ZedGraph to calculate the axis ranges
            // Note that you MUST call this after enabling IsAutoScrollRange, since AxisChange() sets
            // up the proper scrolling parameters
            accelerationVsTime.AxisChange();
            // Make sure the Graph gets redrawn
            accelerationVsTime.Invalidate();
        }

        private void SetSize()
        {
            accelerationVsTime.Location = new Point(10, 10);
            // Leave a small margin around the outside of the control
            accelerationVsTime.Size = new Size(500,//this.ClientRectangle.Width - 20,
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

/*

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace ZGControlTest
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load( object sender, EventArgs e )
		{
			
		}

		/// <summary>
		/// On resize action, resize the ZedGraphControl to fill most of the Form, with a small
		/// margin around the outside
		/// </summary>
		private void Form1_Resize( object sender, EventArgs e )
		{
			SetSize();
		}

		

		


	}
}
*/