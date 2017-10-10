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

            Random Randomizer = new Random();
            int imageplacer = Randomizer.Next(1, 16);
            int[] ImagesArray = new int[Rows * Columns];
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
                    Box.Name = "" + i;
                    if (i >8)
                    {
                        Box.Tag = i - 8;
                    }
                    else {
                        Box.Tag = i; }
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
            
            string imgpath = (Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).ToString() + @"\placeholder\kaartje" + Boxje.Name + ".png";
            Boxje.Image = System.Drawing.Image.FromFile(imgpath);

            if (Boxje.Tag != null)
            {
                if (Boxje.BackColor ==Color.Black)
                return;
                Boxje.BackColor = Color.Black;
            }


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
