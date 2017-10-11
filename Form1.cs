using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory2
{
    public partial class Form1 : Form
    {
        int Rows = 4;
        int Columns = 4;
        PictureBox[] Plaatjes;

        //Label firstClicked = null;
        //Label secondClicked = null;

        public Form1()
        {
            InitializeComponent();
            randomAanmaken();
            /*
            //first clicked points to first label control
             firstClicked = Nothing;
            //second clicked points to the second label control 
            Private secondClicked = Nothing;
            */
        }

        //Genereert kaarten in random volgorde
        private void randomAanmaken()
        {
            //randomiser
            //Random Randomizer = new Random();
            //int imageplacer = Randomizer.Next(1, 16);

            //shuffle
                int[] shuf = new int[16] { 1, 2, 3, 4, 5, 6, 7, 8, 1, 2, 3, 4, 5, 6, 7, 8};
                Random rnd = new Random();
            /*
                for (int t = 0; t < shuf.Length; t++)
                {
                    int tmp = shuf[t];
                    int r = rnd.Next(t, shuf.Length);
                    shuf[t] = shuf[r];
                    shuf[r] = tmp;
                }
            */

            //images array size
            int[] ImagesArray = new int[Rows * Columns];

            //tags invullen array, 0 = niet gedraaid, 1 = gedraaid, 2 = geraden
            int[] TagArray = new int[Rows * Columns];
            for (int j = 0; j <(Rows * Columns); j++)
            {
                TagArray[j] = 0;
            }

            //plaatjes raster loops
            Plaatjes = new PictureBox[Rows * Columns];
            int i = 0;
            for (int cRow = 0; cRow < Rows; cRow++)
            {
                for (int cColumn = 0; cColumn < Columns; cColumn++)
                {
                    PictureBox Box = new PictureBox();
                    this.SuspendLayout();
                    Box.BackColor = System.Drawing.SystemColors.ActiveCaption;
                    string imgpath = (Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).ToString() + @"\placeholder\kaartje0" + ".png";
                    Box.Image = System.Drawing.Image.FromFile(imgpath);
                    Box.Location = new System.Drawing.Point(10 + cColumn * 210, cRow * 210);


                    //randomiser
                    int tmp = shuf[i];
                    int r = rnd.Next(i, shuf.Length);
                    shuf[i] = shuf[r];
                    shuf[r] = tmp;

                    Box.Name = "" + shuf[r];
                    int halfway = (Rows * Columns) / 2;
                    if (shuf[r] > halfway)
                    {
                        Box.Tag = shuf[r] - halfway;
                    }
                    else
                    {
                        Box.Tag = shuf[r];
                    }

                    Box.Size = new System.Drawing.Size(128, 128);
                    Plaatjes[i] = Box;
                    i++;
                    this.Controls.Add(Box);
                    Box.Click += Box_Click;
                    ((System.ComponentModel.ISupportInitialize)(Box)).EndInit();
                    this.ResumeLayout(false);
                }
            }
        }

        /*
private void InitializeComponent()
{
    throw new NotImplementedException();
}
*/

        public void Box_Click(object sender, EventArgs e)
        {
            PictureBox Boxje = (PictureBox)sender;

            //Label clickedLabel = sender as Label;

            string imgpath = (Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).ToString() + @"\placeholder\kaartje" + Boxje.Name + ".png";
            Boxje.Image = System.Drawing.Image.FromFile(imgpath);

            /*
            if (Boxje.Tag != null)
            {
                if (Boxje.BackColor ==Color.Black)
                return;
                Boxje.BackColor = Color.Black;
            }

            secondClicked = clickedLabel;
            secondClicked.ForeColor = Color.Black;
            if (firstClicked.Text == secondClicked.Text)
            {
                firstClicked = null;
                secondClicked = null;
                return;
            }
            */

            /*
            secondClicked = Boxje.Tag;
            secondClicked.ForeColor = Color.Black;
            if (firstClicked == secondClicked)
            {
                firstClicked = null;
                secondClicked = null;
                return;
            }
            */

        }
        private int IndexPlaatjes(PictureBox Boks)
        {
            int i = 0;
            foreach (PictureBox b in Plaatjes)
            {
                if (b == Boks)
                    return i;
                i++;
            }
            return -1;
        }

        /*
                 secondClicked = clickedLabel;
        secondClicked.ForeColor = Color.Black;

        // If the player clicked two matching icons, keep them 
        // black and reset firstClicked and secondClicked 
        // so the player can click another icon
        if (firstClicked.Text == secondClicked.Text)
        {
            firstClicked = null;
            secondClicked = null;
            return;
        }

        // If the player gets this far, the player 
        // clicked two different icons, so start the 
        // timer (which will wait three quarters of 
        // a second, and then hide the icons)
        timer1.Start();
         
         */
    }
}
