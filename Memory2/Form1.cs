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
using System.Xml.Serialization;
using static Memory2.saver;

namespace Memory2
{

    public partial class Form1 : Form
    {
        //reset spel
        Thread thr;
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            thr = new Thread(opennewgame);
            thr.SetApartmentState(ApartmentState.STA);
            thr.Start();
            /*
            randomAanmaken();
            player1score = 0;
            player2score = 0;
            player1name = "Naam1";
            player2name = "Naam2";
            */
        }
        //open spel na reset
        private void opennewgame(object obj)
        {
            //throw new NotImplementedException();
            Application.Run(new Form1());
        }
        //save spel
        private void button2_Click(object sender, EventArgs e)
        {
            saver.Save_Click();
        }

        /*
         private static Form1 instance = new Form1();
         public static Form1 GetInstance ()
         {

         }

         private UserControl view;
         private Form1() 
         {
         InitializeComponent();
         SetView(new Game ());
         }

         //size
         this.Size = new System.Draawing.Size(820, 920);

         public void SetView (UserControl view)
         {
         Controls.Remove(this.view);
         this.view = view;
         this.view.Dock = DockStyle.Fill;
         Controls.Add(view);
         }

        */

        //player 1 score
        public static int player1score = 0;
        //player 2 score
        public static int player2score = 0;
        //player 1 naam
        //string player1name = login.player1name;
        //public static string player1name = "naam1";
        public static Information saveGame = new Information();
        //player 2 naam
        //string player2name = login.player2name;
        //public static string player2name = "naam2";
        //public static Information player2name;
        //rijen
        public static int Rows = 4;
        //kolommen
        public static int Columns = 4;
        //spelers
        public static int Players = 2;
        //spelers beurt
        public static int playerturn = 0;
        //kaartjes array
        PictureBox[] Plaatjes;
        //array kaartje status, 0 = niet gedraaid, 1 = gedraaid, 2 = geraden
        //public static int[] TagArray;
        //array met tags kaartjes nummers 1 t/m 8
        ///public static int[] DraaiArray;
        //first clicked kaartje
        public static int FirstClicked = -1;
        //second clicked kaartje
        public static int SecondClicked = -1;

        //half of total cards
        public int halfway = (Rows * Columns) / 2;

        /*
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        int TimerDisplay = 7;
        */

        public Form1()
        {

            InitializeComponent();
            //randomAanmaken();
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
            saveGame.DraaiArray = new int[Rows * Columns];

            //tags invullen array, 0 = niet gedraaid, 1 = gedraaid, 2 = geraden
            saveGame.TagArray = new int[Rows * Columns];
            for (int j = 0; j <(Rows * Columns); j++)
            {
                saveGame.TagArray[j] = 0;
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
                        saveGame.DraaiArray[i] = shuf[i] - halfway;
                    }
                    else
                    {
                        Box.Tag = shuf[i];
                        saveGame.DraaiArray[i] = shuf[i];
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


        //load game
        //public void Load_Click(string savname)
        public void Load_Click()
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
                        Box.Click += Box_Click;
                        //layout kaartjes
                        ((System.ComponentModel.ISupportInitialize)(Box)).EndInit();
                        this.ResumeLayout(false);
                    }
                }
            }
        }


        /*
        private void InitializeComponent()
        {
        throw new NotImplementedException();
        }
        */

        public async void Box_Click(object sender, EventArgs e)
        {
            /*
            if (FirstClicked != -1 && SecondClicked != -1)
            {
                return;
            }
                */
                //event koppelen aan box
                PictureBox Boxje = (PictureBox)sender;

                //plaats zoeken in array         
                int ClickedNum = Convert.ToInt32(Boxje.Name);
                //image path en tag veranderen, bij wel draaien, check of het 0, of 1 of 2 is
                if (saveGame.TagArray[ClickedNum] == 0)
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

                    //als het wel matched
                    if (saveGame.DraaiArray[FirstClicked] == saveGame.DraaiArray[ClickedNum])
                        {

                            saveGame.TagArray[ClickedNum] = 2;
                            saveGame.TagArray[FirstClicked] = 2;
                            FirstClicked = -1;
                            SecondClicked = -1;
                            ClickedNum = 0;
                            //spelers score
                            switch (playerturn)
                            {
                            case 0:
                                player1score = player1score + 1;
                            break;
                            case 1:
                                player2score = player2score + 1;
                            break;
                            }
                            //spel stop
                            int totalscore = player1score + player2score;
                            if (totalscore >=halfway)
                            {
                            //bericht spel is stop
                            MessageBox.Show("spel is geeindigd");
                            //opslaan in hhighscores
                            }

                        }
                    //als het niet matched
                    else
                        {
                            //tags weer terug naar niet gedraaid
                            saveGame.TagArray[ClickedNum] = 0;
                            saveGame.TagArray[FirstClicked] = 0;

                        //spelers volgende beurt
                        if (playerturn < Players)
                        {
                            playerturn = playerturn + 1;
                        }
                        else
                        {
                            playerturn = 0;
                        }

                        //delay
                        await Task.Delay(800);

                            //string imgbackpath = (Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).ToString() + @"\placeholder\kaartje0.png";

                            //draai 2 kaartjes terug
                            Plaatjes[FirstClicked].Image = Properties.Resources.kaartje0;
                            Plaatjes[ClickedNum].Image = Properties.Resources.kaartje0;

                            FirstClicked = -1;
                            SecondClicked = -1;
                            ClickedNum = 0;

                        }

                    }
                    //als er nog geen kaart is omgedraaid, oftewel eerste zet in beurt van een speler
                    else
                    {
                        //tag van eerste zet, zetten naar 1
                        saveGame.TagArray[ClickedNum] = 1;
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

        //onload
        private void Form1_Load(object sender, EventArgs e)
        {
            //new game
            randomAanmaken();
            if (File.Exists("spelers.xml"))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Information));
                FileStream read = new FileStream("spelers.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
                Information info = (Information)xs.Deserialize(read);
                saveGame.player1name = info.player1name;
                saveGame.player2name = info.player2name;
            }
            //old game
            //Load_Click();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            /*
            //new game
            randomAanmaken();
            if (File.Exists("spelers.xml"))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Information));
                FileStream read = new FileStream("spelers.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
                Information info = (Information)xs.Deserialize(read);
                saveGame.player1name = info.player1name;
                saveGame.player2name = info.player2name;
            }
            */
            //old game
            Load_Click();
        }
    }
}