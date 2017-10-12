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
        int[] TagArray;


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
            //half of total cards
            int halfway = (Rows * Columns) / 2;

            //shuffle array declareren
            int[] shuf = new int[Rows * Columns];
            Random rnd = new Random();
            //shuffle array vullen
            for (int k = 0; k < (Rows * Columns); k++)
            {
                if (k > halfway)
                {
                    shuf[k] = k + 1 - halfway;
                }
                else
                {
                    shuf[k] = k + 1;
                }
            }

            //images array size
            int[] ImagesArray = new int[Rows * Columns];

            //tags invullen array, 0 = niet gedraaid, 1 = gedraaid, 2 = geraden
            TagArray = new int[Rows * Columns];
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
                    //locatie van box
                    Box.Location = new System.Drawing.Point(10 + cColumn * 210, cRow * 210);
                    //randomiser
                    int tmp = shuf[i];
                    int r = rnd.Next(i, shuf.Length);
                    shuf[i] = shuf[r];
                    shuf[r] = tmp;
                    //box naam
                    Box.Name = "" + shuf[i];
                    //box tag
                    if (shuf[i] > halfway)
                    {
                        Box.Tag = shuf[i] - halfway;
                    }
                    else
                    {
                        Box.Tag = shuf[i];
                    }
                    //box  size
                    Box.Size = new System.Drawing.Size(200, 200);
                    Plaatjes[i] = Box;
                    //increment voor random
                    i++;
                    //box toevoegen
                    this.Controls.Add(Box);
                    //clicker
                    Box.Click += Box_Click;
                    //layout kaartjes
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
            //event koppelen aan box
            PictureBox Boxje = (PictureBox)sender;

            //string imgpath = (Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).ToString() + @"\placeholder\kaartje" + Boxje.Tag + ".png";
            //Boxje.Image = System.Drawing.Image.FromFile(imgpath);

            //plaats zoeken in array         
            int ClickedNum = Convert.ToInt32(Boxje.Name) - 1;
            //image path en tag veranderen, bij wel draaien, check of het 0, of 1 of 2 is
            if (TagArray[ClickedNum] == 0)
            {
                //draai kaartje om
                string imgpath = (Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).ToString() + @"\placeholder\kaartje" + Boxje.Tag + ".png";
                Boxje.Image = System.Drawing.Image.FromFile(imgpath);

                //zetten
                int FirstClicked = 0;
                int SecondClicked = 0;
                //spoor op in array of er een eerder geklikt kaartje is
                for (int l = 0; l <(Rows * Columns); l++)
                {
                    if (TagArray[l] ==1)
                    {
                        FirstClicked = l;
                    } 
                }
                //als er al wel een kaart is omgedraaid in een beurt, oftewel tweede zet in beurt van een speler
                if (FirstClicked > 0)
                {
                    /*
                    //als het matched
                    if (Boxje.Tag[FirstClicked] == Boxje.Tag[ClickedNum])
                    {
                        FirstClicked = FirstClicked;
                        SecondClicked = ClickedNum;

                        TagArray[SecondClicked] = 2;
                        TagArray[FirstClicked] = 2;
                    }
                    */

                }
                //als er nog geen kaart is omgedraaid, oftewel eerste zet in beurt van een speler
                else
                {
                    //als het matched
                    TagArray[ClickedNum] = 1;
                }
            }
            

            //Label clickedLabel = sender as Label;
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
