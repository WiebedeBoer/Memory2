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
        public static int player1score;
        //player 2 score
        public static int player2score;
        //player 3 score
        public static int player3score;
        //player 4 score
        public static int player4score;
        //player 1 naam
        //string player1name = login.player1name;
        //public static string player1name = "naam1";
        public static Information saveGame = new Information();
        //player 2 naam
        //string player2name = login.player2name;
        //public static string player2name = "naam2";
        //public static Information player2name;
        //rijen
        public static int Rows = opties.oRows;
        //kolommen
        public static int Columns = opties.oColumns;
        //spelers
        public static int Players = opties.oPlayers;
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
        //Maximaal 2 kaart clicks per beurt
        public int MaxClick = 0;
        //theme path
        //public static string themePath = @"\thema\adventuretime\kaartje";
        //public static string themePath = opties.oThemaString;

        /*
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        int TimerDisplay = 7;
        */

        public Form1()
        {

            InitializeComponent();

            this.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + @"\..\..\thema\" + opties.oThemaBackground + @"\background.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;

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

        //class met highscores xml
        public class Highscores
        {
            public static void SaveData(object obj, string filename)
            {
                XmlSerializer sr = new XmlSerializer(obj.GetType());
                TextWriter writer = new StreamWriter(filename);
                sr.Serialize(writer, obj);
                writer.Close();
            }
        }

        //class meet scores
        public class Scores
        {
            private string naam;
            private int score;

            public string Naam
            {
                get { return naam; }
                set { naam = value; }
            }

            public int Score
            {
                get { return score; }
                set { score = value; }
            }
        }

        //highscore toevoegen
        //private void Highscore(object sender, EventArgs e)
        private void Highscore()
        {
            int AantalSpelers = saveGame.Players;
            for (int i = 0; i < AantalSpelers; i++)
            {
                try
                {
                    Scores info = new Scores();
                    if (i == 1)
                    {
                        info.Naam = Form1.saveGame.player1name;
                        info.Score = player1score;
                    }
                    if (i == 2)
                    {
                        info.Naam = Form1.saveGame.player2name;
                        info.Score = player2score;
                    }
                    if (i == 3)
                    {
                        info.Naam = Form1.saveGame.player3name;
                        info.Score = player3score;
                    }
                    if (i == 4)
                    {
                        info.Naam = Form1.saveGame.player4name;
                        info.Score = player4score;
                    }
                    AppendData(info, "data.xml");
                    //MessageBox.Show("De score is toegevoegd");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //highscores append
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



        //Genereert kaarten in random volgorde
        private void randomAanmaken()
        {

        //player 1 score
        player1score = 0;
        //player 2 score
        player2score = 0;
        //player 3 score
        player3score = 0;
        //player 4 score
        player4score = 0;

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
            for (int j = 0; j < (Rows * Columns); j++)
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
                    string imgpath = (Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).ToString() + saveGame.themePath + "0.png";
                    //Box.Image = Properties.Resources.kaartje0;
                    Box.Image = System.Drawing.Image.FromFile(imgpath);
                    //locatie van box
                    Box.Location = new System.Drawing.Point(10 + cColumn * 110, 150 + cRow * 110);
                    //stretch
                    Box.SizeMode = PictureBoxSizeMode.StretchImage;
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

        /*
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
        */


        /*
        private void InitializeComponent()
        {
        throw new NotImplementedException();
        }
        */

        public async void Box_Click(object sender, EventArgs e)
        {
        
            if (MaxClick< 2)
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
                    string imgpath = (Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).ToString() + saveGame.themePath + Boxje.Tag + ".png";
                    //Boxje.Image = (Image)Properties.Resources.ResourceManager.GetObject("kaartje" + Boxje.Tag);
                    Boxje.Image = System.Drawing.Image.FromFile(imgpath);
                    MaxClick++;
                //als er al wel een kaart is omgedraaid in een beurt, oftewel tweede zet in beurt van een speler
                if (FirstClicked != -1)
                {
                    MaxClick++;
                    //labels kleuren
                    if (saveGame.playerturn == 0)
                    {
                        this.label1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
                        this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
                        this.label2.BackColor = System.Drawing.SystemColors.Control;
                        this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
                            if (saveGame.Players ==3)
                            {
                                this.label3.BackColor = System.Drawing.SystemColors.Control;
                                this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
                            }
                            if (saveGame.Players ==4)
                            {
                                this.label3.BackColor = System.Drawing.SystemColors.Control;
                                this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
                                this.label4.BackColor = System.Drawing.SystemColors.Control;
                                this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
                            }
                        }
                    else if (saveGame.playerturn ==1)
                    {
                        this.label1.BackColor = System.Drawing.SystemColors.Control;
                        this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
                        this.label2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
                        this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
                    }
                    else if (saveGame.playerturn ==2)
                    {
                            this.label1.BackColor = System.Drawing.SystemColors.Control;
                            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
                            this.label2.BackColor = System.Drawing.SystemColors.Control;
                            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
                            this.label3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
                            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
                    }
                    else if (saveGame.playerturn ==3)
                    {
                            this.label1.BackColor = System.Drawing.SystemColors.Control;
                            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
                            this.label2.BackColor = System.Drawing.SystemColors.Control;
                            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
                            this.label3.BackColor = System.Drawing.SystemColors.Control;
                            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
                            this.label4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
                            this.label4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
                    }

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
                        MaxClick = 0;
                        //spelers score
                        switch (playerturn)
                        {
                            case 0:
                                saveGame.player1score = saveGame.player1score + 1;
                                Speler1Score.Text = Convert.ToString(saveGame.player1score);
                                break;
                            case 1:
                                saveGame.player2score = saveGame.player2score + 1;
                                Speler2Score.Text = Convert.ToString(saveGame.player2score);
                                break;
                            case 2:
                                saveGame.player3score = saveGame.player3score + 1;
                                Speler3Score.Text = Convert.ToString(saveGame.player3score);
                                break;
                            case 3:
                                saveGame.player4score = saveGame.player4score + 1;
                                Speler4Score.Text = Convert.ToString(saveGame.player4score);
                                break;
                        }
                        //spel stop
                        int totalscore = saveGame.player1score + saveGame.player2score + saveGame.player3score + saveGame.player4score;
                        if (totalscore >= halfway)
                        {
                            //bericht spel is stop
                            MessageBox.Show("spel is geeindigd");
                            //opslaan in highscores
                            Highscore();
                        }

                    }
                    //als het niet matched
                    else
                    {
                        //tags weer terug naar niet gedraaid
                        saveGame.TagArray[ClickedNum] = 0;
                        saveGame.TagArray[FirstClicked] = 0;

                        //spelers volgende beurt
                        if (playerturn < Players - 1)
                        {
                                saveGame.playerturn = saveGame.playerturn + 1;
                        }
                        else
                        {
                                saveGame.playerturn = 0;
                        }

                        //delay
                        await Task.Delay(800);

                        string imgbackpath = (Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).ToString() + saveGame.themePath + "0.png";

                            
                            //Properties.resources.kaartje0;
                            //draai 2 kaartjes terug
                            Plaatjes[FirstClicked].Image = System.Drawing.Image.FromFile(imgbackpath);
                            Plaatjes[ClickedNum].Image = System.Drawing.Image.FromFile(imgbackpath);

                            FirstClicked = -1;
                        SecondClicked = -1;
                        ClickedNum = 0;
                        MaxClick = 0;

                    }

                }
                //als er nog geen kaart is omgedraaid, oftewel eerste zet in beurt van een speler
                else
                {
                    //tag van eerste zet, zetten naar 1
                    saveGame.TagArray[ClickedNum] = 1;
                    FirstClicked = ClickedNum;
                    MaxClick = 0;
                }
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

            saveGame.themePath = opties.oThemaString;
            saveGame.themeBackground = opties.oThemaBackground;
            //new game
            randomAanmaken();
            

            string spelerfile = Environment.CurrentDirectory + @"\spelers.xml";
            if (File.Exists(spelerfile))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Information));
                FileStream read = new FileStream(spelerfile, FileMode.Open, FileAccess.Read, FileShare.Read);
                Information info = (Information)xs.Deserialize(read);
                //aantal spelers
                saveGame.Players = info.Players;

                label3.Enabled = saveGame.Players > 2;

                label4.Enabled = saveGame.Players > 3;

                saveGame.player1name = info.player1name;
                saveGame.player2name = info.player2name;

                this.label1.Text = saveGame.player1name;
                this.label2.Text = saveGame.player2name;
                this.Speler1Score.Text = Convert.ToString(Form1.saveGame.player1score);
                this.Speler2Score.Text = Convert.ToString(Form1.saveGame.player2score);


                if (saveGame.Players ==3)
                {
                    saveGame.player3name = info.player3name;
                    this.label3.Text = saveGame.player3name;
                    this.Speler3Score.Text = Convert.ToString(Form1.saveGame.player3score);
                }
                else if (saveGame.Players ==4)
                {
                    saveGame.player3name = info.player3name;
                    this.label3.Text = saveGame.player3name;
                    this.Speler3Score.Text = Convert.ToString(Form1.saveGame.player3score);
                    saveGame.player4name = info.player4name;
                    this.label4.Text = saveGame.player4name;
                    this.Speler4Score.Text = Convert.ToString(Form1.saveGame.player4score);
                }


            }
            //old game
            //Load_Click();
        }
        /*
        private void Form2_Load(object sender, EventArgs e)
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
    */
    }
}