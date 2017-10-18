using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory2
{
    public partial class hoofdmenu : Form
    {
        public hoofdmenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var myForm = new Form1();
            myForm.Show();
        }
    }
}
