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

            x = -x;
            z = -z;

            Point[] groundPoints = new Point[3];

            groundPoints[0] = getp0(x, 6 * (width + height));
            groundPoints[1] = getp1(x, 6 * (width + height));
            groundPoints[2] = getp2(x, 12 * (width + height));

            

            if (true)//y <= Math.PI / 2.0 && y >= -Math.PI / 2.0)
            {
                groundPoints[0].X += (int)(width*(Math.Tan(-y)*Math.Sin(x)));
                groundPoints[0].Y -= (int)(height * (Math.Tan(-y) * Math.Cos(x)));
                groundPoints[1].X += (int)(width * (Math.Tan(-y) * Math.Sin(x)));
                groundPoints[1].Y -= (int)(height * (Math.Tan(-y) * Math.Cos(x)));
            }
            if (y > Math.PI / 2.0 || y < -Math.PI / 2.0)
            {
                groundPoints[2].X = -groundPoints[2].X;
                groundPoints[2].Y = -groundPoints[2].Y;
            }
            
            groundPoints[0].X += width / 2;
            groundPoints[0].Y += height / 2;
            groundPoints[1].X += width / 2;
            groundPoints[1].Y += height / 2;
            groundPoints[2].X += width / 2;
            groundPoints[2].Y += height / 2;
            try
            {
                flightGraphics.FillPolygon(ground, groundPoints);
                Pen level = new Pen(System.Drawing.Color.Black, 2);
                flightGraphics.DrawLine(level, 0, height / 2, width, height / 2);

                flightOrientation_updateZed(flightGraphics, width, height, z);
            }
            catch
            {

            }

        }

        private Point getp0(float x, int hyp)
        {
            Point p0 = new Point();

            p0.X = (int)(Math.Cos(x) * hyp);
            p0.Y = (int)(Math.Sin(x) * hyp);

            return p0;
        }

        private Point getp1(float x, int hyp)
        {
            Point p1 = new Point();

            p1.X = (int)(Math.Cos(x - (Math.PI)) * hyp);
            p1.Y = (int)(Math.Sin(x - (Math.PI)) * hyp);


            return p1;
        }

        private Point getp2(float x, int hyp)
        {
            Point p2 = new Point();

            p2.X = -(int)(Math.Cos(x-(.5*Math.PI)) * hyp);
            p2.Y = -(int)(Math.Sin(x-(.5 * Math.PI)) * hyp);

            return p2;
        }


        private void flightOrientation_updateZed(Graphics flightGraphics, int width, int height, float z){
            
            string zAxis =  "  -15  -30  -45  -60  -75  -90 -105 -120 -135 -150 -165  180  165  150  135  120  105   90   75   60   45   30   15   0   -15  -30  -45  -60  -75  -90 -105 -120 -135 -150 -165  180  165  150  135  120  105   90   75   60   45   30   15";
            zAxis +=    "\r\n   |    |    |    |    |    |    |    |    |    |    |    |    |    |    |    |    |    |    |    |    |    |    |    |    |    |    |    |    |    |    |    |    |    |    |    |    |    |    |    |    |    |    |    |    |    |    | ";

            float textWidth = (float)(((double)zAxis.Length) * 4.667);

            System.Drawing.Font drawFont = new System.Drawing.Font(FontFamily.GenericMonospace, 15, FontStyle.Regular, GraphicsUnit.Pixel);
            Brush drawBrush = new SolidBrush(System.Drawing.Color.Black);
            float test = (-(textWidth / (float)2.0));
            flightGraphics.DrawString(zAxis, drawFont, drawBrush, (-(textWidth / (float)2.0)) + (((float)width)/((float)2.0)) + (float)((((double)textWidth) / (710.0)) * (RadianToDegree(z))), (height / 2) - 22);
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
