using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void optionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    
    string[][] highscoresarr1 = new string[][] { new string[2] { "6", "Na1" }, new string[2] { "2", "Na2" }, new string[2] { "3", "Na3" }, new string[2] { "5", "Na4" } };
        string[][] highscoresarr2 = new string[][] { new string[2] { "10", "Na1" }, new string[2] { "8", "Na2" }, new string[2] { "6", "Na3" }, new string[2] { "12", "Na4" } };
        

        private void highscoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Panel dynamicPanel1 = new Panel();
            dynamicPanel1.Location = new Point(0, 0);
            dynamicPanel1.Name = "Panel1";
            dynamicPanel1.Size = new Size(400, 400);
            dynamicPanel1.BackColor = Color.LightBlue;

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
                string j = Convert.ToString(i+1);
                ListViewItem item1 = new ListViewItem(highscoresarr1[i][0], 0);
                item1.SubItems.Add(highscoresarr1[i][1]);
                highscores.Items.AddRange(new ListViewItem[] { item1 });
                i++;
                rank.Items.Add(new ListViewItem(j));
            }

            highscores.Sorting = SortOrder.Descending;
            
            dynamicPanel1.Controls.Add(rank);
            dynamicPanel1.Controls.Add(highscores);
            Controls.Add(dynamicPanel1);
            
        }

        private void highscores2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Panel dynamicPanel2 = new Panel();
            dynamicPanel2.Location = new Point(0, 0);
            dynamicPanel2.Name = "Panel1";
            dynamicPanel2.Size = new Size(400, 400);
            dynamicPanel2.BackColor = Color.LightBlue;

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

            foreach (string[] subArray in highscoresarr2)
            {
                string j = Convert.ToString(i + 1);
                ListViewItem item1 = new ListViewItem(highscoresarr2[i][0], 0);
                item1.SubItems.Add(highscoresarr2[i][1]);
                highscores.Items.AddRange(new ListViewItem[] { item1 });
                i++;
                rank.Items.Add(new ListViewItem(j));
            }

            highscores.Sorting = SortOrder.Descending;

            dynamicPanel2.Controls.Add(rank);
            dynamicPanel2.Controls.Add(highscores);
            Controls.Add(dynamicPanel2);
        }
}
