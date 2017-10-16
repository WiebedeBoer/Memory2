using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimerDelay
{
    public partial class Form1 : Form
    {

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        int TimerDisplay = 7;
        public Form1()
        {
            timer.Stop();
            InitializeComponent();

            timer.Tick += new EventHandler(timer1_Tick);
            timer.Interval = 1000;
            timer.Enabled = true;
            
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            if (TimerDisplay >= 1)
            {
            TimerDisplay--;
            }
            else
            {
                timer1.Stop();
            }
            textBox1.Text = Convert.ToString(TimerDisplay);
          
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            TimerDisplay = 7;
            timer1.Start();
        }
        
        


        /*    private void timer1_Tick(object sender, EventArgs e)
            {
                if (TimeLeft > 0)
                {

                    TimeLeft = TimeLeft - 1;
                }
                else
                {
                    timer1.Stop();
                    MessageBox.Show("Te laat!");
                }

            }
            */
    }
}
