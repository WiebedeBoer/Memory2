﻿using System;
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
    public partial class opties : Form
    {
        public opties()
        {
            InitializeComponent();
        }




        /*string[,] highscoresarray = new string[4, 5] { { "Na2", "3", "2", "4", "7" }, { "Na1", "4", "2", "3", "7" }, { "Na3", "5", "1", "2", "8"}, {"Na4", "2", "1", "5", "8"} */
        /*int[] Na1 = new int[4] { 3, 2, 4, 7 };
        int[] Na2 = new int[4] { 4, 2, 3, 7 };
        int[] Na3 = new int[4] { 5, 1, 2, 8 };
        int[] Na4 = new int[4] { 2, 1, 5, 8 };*/
        string name1 = "naam 1";




        private void highscoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Panel dynamicPanel = new Panel();
            dynamicPanel.Location = new Point(0, 0);
            dynamicPanel.Name = "Panel1";
            dynamicPanel.Size = new Size(400, 400);
            dynamicPanel.BackColor = Color.LightBlue;

            /*Label hslabel1 = new Label();
            hslabel1.Location = new Point(10, 30);
            hslabel1.Text = "Highscores";
            hslabel1.Size = new Size(400, 20);

            Label hslabel2 = new Label();
            hslabel2.Location = new Point(10, 50);
            hslabel2.Text = "        Name:            Wins:  Ties:  Losses:  Games played:  ";
            hslabel2.Size = new Size(400, 20);*/

            ListView highscores = new ListView();
            highscores.Location = new Point(10, 30);
            highscores.Size = new Size(325, 100);
            highscores.Columns.Add("#", 20);
            highscores.Columns.Add("Name", 100);
            highscores.Columns.Add("Wins", 50);
            highscores.Columns.Add("Ties", 50);
            highscores.Columns.Add("Losses", 50);
            highscores.Columns.Add("Games", 50);
            highscores.View = View.Details;

            ListViewItem item1 = new ListViewItem("0", 0);
            item1.SubItems.Add("1");
            item1.SubItems.Add("2");
            item1.SubItems.Add("3");
            item1.SubItems.Add("4");
            item1.SubItems.Add("5");
            highscores.Items.AddRange(new ListViewItem[] { item1 });

            /*for (int i = 0; i < 4; i++)
            {
                Label results = new Label();
                results.Location = new Point(10, 70 + (i * 20));
                results.Text = ("#" + (i + 1) + "  " + highscoresarray[i, 0] + "  " + highscoresarray[i, 1] + " " + highscoresarray[i, 2] + " " + highscoresarray[i, 3] + " " + highscoresarray[i, 4]);
                results.Size = new Size(400, 20);
                dynamicPanel.Controls.Add(results);
            }*/
            /*Label results = new Label();
            results.Location = new Point(10 + (i * 50), 70);
            results.Text = "A";
            results.Size = new Size(50, 20);
            dynamicPanel.Controls.Add(results);*/

            dynamicPanel.Controls.Add(highscores);
            //dynamicPanel.Controls.Add(hslabel1);
            //dynamicPanel.Controls.Add(hslabel2);

            Controls.Add(dynamicPanel);


        }






    }
}