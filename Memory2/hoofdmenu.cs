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

namespace Memory2
{
    public partial class hoofdmenu : Form
    {
        Thread th;

        public hoofdmenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            var formButton = (Control)sender;
            string formName = formButton.Name;
            if (formName =="Form1")
            {
                this.Close();
                th = new Thread(opennewform);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
                //Form myForm = new Form1();
                //myForm.Show();
            }
            else if (formName =="Highscores") {
                this.Close();
                th = new Thread(opennewhigh);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
                //Form myForm = new highscores();
                //myForm.Show();
            }
            else if (formName == "Opties")
            {
                this.Close();
                th = new Thread(opennewopties);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
                //Form myForm = new highscores();
                //myForm.Show();
            }
            else if (formName == "Load Game")
            {
                this.Close();
                th = new Thread(loadgame);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
                //Form myForm = new highscores();
                //myForm.Show();
            }
            else {
            }

            
        }

        private void opennewform(object obj)
        {
            //throw new NotImplementedException();
            Application.Run(new login());
        }

        private void opennewhigh(object obj)
        {
            //throw new NotImplementedException();
            Application.Run(new highscores());
        }

        private void opennewopties(object obj)
        {
            //throw new NotImplementedException();
            Application.Run(new opties());
        }

        private void loadgame(object obj)
        {
            //throw new NotImplementedException();
            Application.Run(new Form1());
        }

        /*
        private void button2_Click(object sender, EventArgs e)
        {
           
        }
        */

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
