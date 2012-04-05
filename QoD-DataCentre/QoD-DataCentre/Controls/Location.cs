using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QoD_DataCentre.Domain.JSON;

namespace QoD_DataCentre.Controls
{
    public partial class Location : UserControl
    {
        public bool initialized = false;

        public Location()
        {
            InitializeComponent();
        }

        public void UpdateOrientation(JsonObjects.TriAxisResponse[] Orientation)
        {
            
            if (Orientation != null)
            {
                float avgX = 0, avgY = 0, avgZ = 0;
                foreach (JsonObjects.TriAxisResponse or in Orientation)
                {
                    avgX += or.X;
                    avgY += or.Y;
                    avgZ += or.Z;
                }
                avgX = avgX / Orientation.Length;
                avgY = avgY / Orientation.Length;
                avgZ = avgZ / Orientation.Length;

                flightOrientation_update(avgX, avgY, avgZ);
                
                
            }
        }

        private void flightOrientation_update(float x, float y, float z)
        {
            flightOrientation.Image = null;
            flightOrientation.Refresh();
            flightOrientation.BackColor = Color.LightBlue;
            int wid = flightOrientation.Width;
            int hgt = flightOrientation.Height;

            // Draw with double-buffering.
            Bitmap bm = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                flightOrientation_update(gr, wid, hgt, x, y, z);
            }
            flightOrientation.Image = bm;
            flightOrientation.Refresh();
        }

        private void flightOrientation_update(Graphics flightGraphics, int width, int height, float x, float y, float z)
        {
            
            Brush ground = new SolidBrush(System.Drawing.Color.SandyBrown);
            int groundX = (int)(Math.Tan(x) * (width / 2));
            int groundY = (int)(Math.Tan(y) * (width / 2));
            Point[] groundPoints = new Point[4];
            groundPoints[0].X = 0;
            groundPoints[0].Y = height;
            groundPoints[1].X = width;
            groundPoints[1].Y = height;
            groundPoints[2].X = width;
            groundPoints[2].Y = ((height / 2) + groundX) - groundY;
            groundPoints[3].X = 0;
            groundPoints[3].Y = ((height / 2) - groundX) - groundY;
            flightGraphics.FillPolygon(ground, groundPoints);

            Pen level = new Pen(System.Drawing.Color.Black, 2);
            flightGraphics.DrawLine(level, 0, height/2, width, height/2);
            
            flightOrientation_updateZed(flightGraphics, width, height, z);


        }

        private void flightOrientation_updateZed(Graphics flightGraphics, int width, int height, float z){
            
            string zAxis ="  180  165  150  135  120  105   90   75   60   45   30   15   0  -15  -30  -45  -60  -75  -90 -105 -120 -135 -150 -165";

            System.Drawing.Font drawFont = new System.Drawing.Font(FontFamily.GenericMonospace, 9, FontStyle.Regular);
            Brush drawBrush = new SolidBrush(System.Drawing.Color.Black);
            flightGraphics.DrawString(zAxis, drawFont, drawBrush, z * 10 - width, (height / 2) - 16);
        }

        private float RadianToDegree(float angle)
        {
            return angle * (float)(180.0 / Math.PI);
        }



        internal void InitializeControl()
        {
            flightOrientation_update(0, 0, 0);
            initialized = true;
        }

        private void flightOrientation_Resize(object sender, EventArgs e)
        {
            InitializeControl();
        }

        
    }
}
