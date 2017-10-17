using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
        int[] DraaiArray;

        int FirstClicked = -1;
        int SecondClicked = 0;
        /*
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        int TimerDisplay = 7;
        */

        public Form1()
        {

            InitializeComponent();
            randomAanmaken();
            /*
            //timer
            timer.Stop();
            InitializeComponent();
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Interval = 1000;
            timer.Enabled = true;
            */
        }
        /*
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            if (TimerDisplay >= 1)
            {
                TimerDisplay--;
            }
            else
            {
                timer1.Stop();
            }
            textBox1.Text = Convert.ToString(TimerDisplay);
        }
        */

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
            //draai array size
            DraaiArray = new int[Rows * Columns];

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
                    //this.SuspendLayout();
                    Box.BackColor = System.Drawing.SystemColors.ActiveCaption;
                    //string imgpath = (Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).ToString() + @"\placeholder\kaartje0" + ".png";
                    Box.Image = Properties.Resources.kaartje0;
                    //locatie van box
                    Box.Location = new System.Drawing.Point(10 + cColumn * 110, 150 + cRow * 110);
                    //randomiser
                    int tmp = shuf[i];
                    int r = rnd.Next(i, shuf.Length);
                    shuf[i] = shuf[r];
                    shuf[r] = tmp;
                    //box naam
                    Box.Name = i.ToString();
                    //box tag
                    if (shuf[i] > halfway)
                    {
                        Box.Tag = shuf[i] - halfway;
                        DraaiArray[i] = shuf[i] - halfway;
                    }
                    else
                    {
                        Box.Tag = shuf[i];
                        DraaiArray[i] = shuf[i];
                    }
                    //box  size
                    Box.Size = new System.Drawing.Size(100, 100);
                    //aan plaates array
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

        public void Save_Click()
        {

        }

        public void Box_Click(object sender, EventArgs e)
        {
       
                //event koppelen aan box
                PictureBox Boxje = (PictureBox)sender;

                //plaats zoeken in array         
                int ClickedNum = Convert.ToInt32(Boxje.Name);
                //image path en tag veranderen, bij wel draaien, check of het 0, of 1 of 2 is
                if (TagArray[ClickedNum] == 0)
                {
                    //draai kaartje om
                    //string imgpath = (Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).ToString() + @"\placeholder\kaartje" + Boxje.Tag + ".png";
                    Boxje.Image = (Image)Properties.Resources.ResourceManager.GetObject("kaartje"+ Boxje.Tag);

                    //als er al wel een kaart is omgedraaid in een beurt, oftewel tweede zet in beurt van een speler
                    if (FirstClicked != -1)
                    {
                        /*
                        //timer
                        timer1.Stop();
                        TimerDisplay = 7;
                        timer1.Start();
                        */

                    //Delay functie, in milliseconden, 1000 milli = 1 sec.
                    int DelayMilli = 1800;
                    Thread.Sleep(DelayMilli);


                    //als het wel matched
                    if (DraaiArray[FirstClicked] == DraaiArray[ClickedNum])
                        {

                            TagArray[ClickedNum] = 2;
                            TagArray[FirstClicked] = 2;
                            FirstClicked = -1;
                            SecondClicked = 0;
                            ClickedNum = 0;

                        }
                        //als het niet matched
                        else
                        {
                            //tags weer terug naar niet gedraaid
                            TagArray[ClickedNum] = 0;
                            TagArray[FirstClicked] = 0;


                        
                              //string imgbackpath = (Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).ToString() + @"\placeholder\kaartje0.png";
                        
                            //draai 2 kaartjes terug
                            Plaatjes[FirstClicked].Image = Properties.Resources.kaartje0;
                            Plaatjes[ClickedNum].Image = Properties.Resources.kaartje0;

                            FirstClicked = -1;
                            SecondClicked = 0;
                            ClickedNum = 0;

                        }

                    }
                    //als er nog geen kaart is omgedraaid, oftewel eerste zet in beurt van een speler
                    else
                    {
                        //als het matched
                        TagArray[ClickedNum] = 1;
                        FirstClicked = ClickedNum;
                    }
                }     

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


    }
}