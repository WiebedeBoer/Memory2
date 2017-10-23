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
        /*
        string[][] highscoresarr1 = new string[][] { new string[2] { "6", "Na1" }, new string[2] { "2", "Na2" }, new string[2] { "3", "Na3" }, new string[2] { "5", "Na4" } };

        private void highscoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Panel dynamicPanel = new Panel();
            dynamicPanel.Location = new Point(0, 0);
            dynamicPanel.Name = "Panel1";
            dynamicPanel.Size = new Size(400, 400);
            dynamicPanel.BackColor = Color.LightBlue;

            ListView rank = new ListView();
            rank.Location = new Point(10, 30);
            rank.Size = new Size(25, 100);
            rank.Columns.Add("#", 100);
            rank.View = View.Details;
            rank.Scrollable = false;

            ListView highscores = new ListView();
            highscores.Location = new Point(50, 30);
            highscores.Size = new Size(105, 100);
            highscores.Columns.Add("Points", 50);
            highscores.Columns.Add("Name", 50);
            highscores.View = View.Details;

            int i = 0;

            foreach (string[] subArray in highscoresarr1)
            {
                string j = Convert.ToString(i + 1);
                ListViewItem item1 = new ListViewItem(highscoresarr1[i][0], 0);
                item1.SubItems.Add(highscoresarr1[i][1]);
                highscores.Items.AddRange(new ListViewItem[] { item1 });
                i++;
                rank.Items.Add(new ListViewItem(j));
            }

            highscores.Sorting = SortOrder.Descending;

            dynamicPanel.Controls.Add(rank);
            dynamicPanel.Controls.Add(highscores);
            Controls.Add(dynamicPanel);

        }
        */

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

         /*
        private void button3_Click(object sender, EventArgs e)
        {

        }
        */
    }
}
