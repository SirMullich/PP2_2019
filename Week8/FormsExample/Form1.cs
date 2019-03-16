using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsExample
{
    public partial class Form1 : Form
    {
        private int count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Clicked";

            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //label2.Text = count.ToString();
            //count++;

            DateTime dt = DateTime.Now;
            label2.Text = dt.ToString("T");


        }
    }
}
