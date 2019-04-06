using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RectangleDrawer
{
    public partial class Form1 : Form
    {
        Point pointStart; //= new Point();
        Point pointFinish; // = new Point();
        Pen pen;
        Graphics gfx;

        bool isStart;

        public Form1()
        {
            InitializeComponent();
            pointStart = new Point();
            pointFinish = new Point();
            isStart = false;
            pen = new Pen(Color.Green, 10);
            gfx = this.CreateGraphics(); // this = this Form
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Text = e.Location.ToString();
            isStart = !isStart; // true => false, false => true

            if (isStart)
            {
                pointStart = e.Location;
            } else
            {
                pointFinish = e.Location;
                //Rectangle rectangle = new Rectangle(pointStart.X, pointStart.Y, pointFinish.X - pointStart.X, pointFinish.Y - pointStart.Y);
                //Rectangle rectangle = new Rectangle(pointStart, new Size(pointFinish));



                // support if startPoint is to the right-bottom
                int absWidth = Math.Abs(pointFinish.X - pointStart.X);
                int absHeight = Math.Abs(pointFinish.Y - pointStart.Y);

                Rectangle rectangle;

                if (EuclideanDistance(pointStart) <= EuclideanDistance(pointFinish))
                {
                    rectangle = new Rectangle(pointStart.X, pointStart.Y, absWidth, absHeight);
                } else
                {
                    rectangle = new Rectangle(pointFinish.X, pointFinish.Y, absWidth, absHeight);
                }
                
                gfx.DrawRectangle(pen, rectangle);
            }
        }

        private double EuclideanDistance(Point point)
        {
            return Math.Sqrt(point.X * point.X + point.Y * point.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(159, 220, 70));
            gfx.FillEllipse(solidBrush, 20, 20, 100, 150);

        }
    }
}
