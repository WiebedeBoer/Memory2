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
    public partial class highscores : Form
    {
        public highscores()
        {
            InitializeComponent();
        }

        private void highscoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Panel dynamicPanel = new Panel();
            dynamicPanel.Location = new Point(0, 0);
            dynamicPanel.Name = "Panel1";
            dynamicPanel.Size = new Size(400, 400);
            dynamicPanel.BackColor = Color.LightBlue;

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

            dynamicPanel.Controls.Add(highscores);
            //dynamicPanel.Controls.Add(hslabel1);
            //dynamicPanel.Controls.Add(hslabel2);

            Controls.Add(dynamicPanel);
        }

    }
}
