using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        int turncounter = 2;
        private void button1_Click(object sender, EventArgs e)
        {
            turncounter++;
            label1.Text = ("Turn: " + turncounter/2);
        }

        

        int scorecounter1 = 0;
        private void button2_Click_1(object sender, EventArgs e)
        {
            scorecounter1++;
            label2.Text = ("Player 1: " + scorecounter1 + " points");
        }

        int scorecounter2 = 0;
        private void button3_Click_1(object sender, EventArgs e)
        {
            scorecounter2++;
            label3.Text = ("Player 2: " + scorecounter2 + " points");
        }
    }
}
