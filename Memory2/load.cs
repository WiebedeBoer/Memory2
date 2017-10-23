using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using static Memory2.saver;



namespace Memory2
{
    public partial class load : Form
    {
        /*
        public load()
        {
            InitializeComponent();
        }
        */


        //load game
        public void Load_Click(string savname)
        {
            //string savpath = (Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).ToString() + @"\memory.sav";
            //GameState gameState;
            //File.Decrypt(savpath);

            string savpath = Environment.CurrentDirectory + "/memory.sav";

            if (File.Exists(savpath))
            {

                XmlSerializer xs = new XmlSerializer(typeof(Information));

                FileStream read = new FileStream("memory.sav", FileMode.Open, FileAccess.Read, FileShare.Read);

                Information info = (Information)xs.Deserialize(read);

                Form1.saveGame.player1name = info.player1name;
                Form1.saveGame.player2name = info.player2name;
                Form1.saveGame.player1score = info.player1score;
                Form1.saveGame.player2score = info.player2score;
                Form1.saveGame.Rows = info.Rows;
                Form1.saveGame.Columns = info.Columns;
                Form1.saveGame.FirstClicked = info.FirstClicked;
                Form1.saveGame.DraaiArray = info.DraaiArray;
                Form1.saveGame.TagArray = info.TagArray;

                //kaartjes array
                PictureBox[] Plaatjes;
                //plaatjes raster loops
                Plaatjes = new PictureBox[info.Rows * info.Columns];

                //plaatjes raster loops
                ///Plaatjes = new PictureBox[info.Rows * info.Columns];
                int i = 0;
                for (int cRow = 0; cRow < info.Rows; cRow++)
                {
                    for (int cColumn = 0; cColumn < info.Columns; cColumn++)
                    {
                        PictureBox Box = new PictureBox();
                        //this.SuspendLayout();
                        Box.BackColor = System.Drawing.SystemColors.ActiveCaption;
                        Box.Image = Properties.Resources.kaartje0;
                        //locatie van box
                        Box.Location = new System.Drawing.Point(10 + cColumn * 110, 150 + cRow * 110);

                        //box naam
                        Box.Name = i.ToString();
                        //box tag
                        Box.Tag = info.DraaiArray[i];

                        //box  size
                        Box.Size = new System.Drawing.Size(100, 100);
                        //aan plaates array
                        Plaatjes[i] = Box;
                        //increment voor random
                        i++;
                        //box toevoegen
                        this.Controls.Add(Box);
                        //clicker
                        ///Box.Click += Box_Click;
                        //layout kaartjes
                        ((System.ComponentModel.ISupportInitialize)(Box)).EndInit();
                        this.ResumeLayout(false);
                    }
                }

            }


        }

    }
}

    
