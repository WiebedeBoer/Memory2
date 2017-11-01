using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace Memory2
{
    public partial class highscores : Form
    {
        public highscores()
        {
            InitializeComponent();

            int rankcounter = 1;
            string rankdisplay = Convert.ToString(rankcounter);
            if (File.Exists("data.xml"))
            {
                DataSet ds = new DataSet();
                ds.ReadXml("data.xml", XmlReadMode.InferTypedSchema);
                ds.Tables[0].DefaultView.Sort = "Score DESC";
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Location = new Point(30, 0);
                dataGridView1.Size = new Size(150, (20 * (dataGridView1.RowCount+ 1)) + 3);
                
                listView1.Location = new Point(0, 0);
                listView1.Size = new Size(25, (20 * (dataGridView1.RowCount + 1)) + 3);
                listView1.Columns.Add("#");
                listView1.View = View.Details;
                listView1.Scrollable = false;
                

                for (int rowc = 0; rowc < dataGridView1.Rows.Count; rowc++)
                {
                    listView1.Items.Add(new ListViewItem(rankdisplay));
                    rankcounter++;
                    rankdisplay = Convert.ToString(rankcounter);
                }
                
            }

            /*
            private void button1_Click(object sender, EventArgs e)
            {
                try
                {
                    Scores info = new Scores();
                    info.Naam = textBoxNaam.Text;
                    info.Score = int.Parse(textBoxScore.Text);
                    AppendData(info, "data.xml");
                    MessageBox.Show("De score is toegevoegd");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            */

            /*
            static void AppendData(Scores obj, string filename)
            {
                XmlSerializer xmlser = new XmlSerializer(typeof(List<Scores>));
                List<Scores> list = null;
                try
                {
                    using (Stream s = File.OpenRead(filename))
                    {
                        list = xmlser.Deserialize(s) as List<Scores>;
                    }
                }
                catch
                {
                    list = new List<Scores>();
                }
                list.Add(obj);
                using (Stream s = File.OpenWrite(filename))
                {
                    xmlser.Serialize(s, list);
                }
            }
            */

        }

        













        /*

        string[][] highscoresarr1 = new string[][] { new string[2] { "6", "Na1" }, new string[2] { "2", "Na2" }, new string[2] { "3", "Na3" }, new string[2] { "5", "Na4" } };

        private void highscoresTool()
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

        /*
        //onload
        private void Highscores_Load(object sender, EventArgs e)
        {
            //highscores
            highscoresTool();


        }
            */

    }
}

