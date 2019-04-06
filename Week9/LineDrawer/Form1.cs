using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LineDrawer
{
    public partial class Form1 : Form
    {
        Graphics gfx;
        Pen pen;
        Point pointStart;
        Point pointFinish;
        bool isDrawing;

        public Form1()
        {
            InitializeComponent();
            gfx = this.CreateGraphics();
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.Black, 20);

            isDrawing = false;
        }

        private void colorSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pen = new Pen(colorDialog1.Color, 20);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            pointStart = e.Location;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                //gfx.DrawLine(pen, pointStart, e.Location);    // looks ugly

                RectangleF rect = new RectangleF(e.Location.X - pen.Width / 2, e.Location.Y - pen.Width / 2, pen.Width, pen.Width);
                gfx.DrawEllipse(pen, rect);
            }
            
            pointStart = e.Location;
        }
    }
}
