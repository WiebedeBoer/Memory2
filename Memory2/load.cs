using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using static Memory2.saver;



namespace Memory2
{
    public partial class load : Form
    {
        
        public load()
        {
            InitializeComponent();

            //this.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + @"\..\..\thema\" + saveGame.themeBackground + @"\background.jpg");
            //this.BackgroundImageLayout = ImageLayout.Stretch;

        }
        

        //reset spel
        Thread thr;
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            thr = new Thread(opennewgame);
            thr.SetApartmentState(ApartmentState.STA);
            thr.Start();
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

        //info
        public static Information saveGame = new Information();

        //player 1 score
        public static int player1score = load.saveGame.player1score;
        //player 2 score
        public static int player2score = load.saveGame.player2score;
        //player 3 score
        public static int player3score;
        //player 4 score
        public static int player4score;
        //player 1 naam
        //string player1name = login.player1name;
        //public static string player1name = load.saveGame.player1name;
        //public static Information saveGame = new Information();
        //player 2 naam
        //string player2name = login.player2name;
        //public static string player2name = load.saveGame.player2name;
        //public static Information player2name;
        public static string player1name = load.saveGame.player1name;
        public static string player2name = load.saveGame.player2name;
        //rijen
        public static int Rows = load.saveGame.Rows;
        //kolommen
        public static int Columns = load.saveGame.Columns;
        //spelers
        public static int Players = load.saveGame.Players;
        //spelers beurt
        public static int playerturn = load.saveGame.playerturn;
        //kaartjes array
        PictureBox[] Plaatjes;
        //array kaartje status, 0 = niet gedraaid, 1 = gedraaid, 2 = geraden
        //public static int[] TagArray;
        //array met tags kaartjes nummers 1 t/m 8
        ///public static int[] DraaiArray;
        //first clicked kaartje
        //public static int FirstClicked = load.saveGame.FirstClicked;
        public static int FirstClicked = load.saveGame.FirstClicked;
        //second clicked kaartje
        public static int SecondClicked = -1;

        //half of total cards
        public int halfway = (saveGame.Rows * saveGame.Columns) / 2;

        //Maximaal 2 kaart clicks per beurt
        public int MaxClick = 0;
        //theme path
        public static string themePath = load.saveGame.themePath;


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



        //load game
        //public void Load_Click(string savname)
        public void LoadGame()
        {
            //string savpath = (Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).ToString() + @"\memory.sav";
            //GameState gameState;
            //File.Decrypt(savpath);

            string savpath = Environment.CurrentDirectory + "/memory.sav";

            if (File.Exists(savpath))
            {

                //File.Decrypt(savpath);
                XmlSerializer xs = new XmlSerializer(typeof(Information));

                //FileStream read = new FileStream("memory.sav", FileMode.Open, FileAccess.Read, FileShare.Read);
                FileStream read = new FileStream(savpath, FileMode.Open, FileAccess.Read, FileShare.Read);

                Information info = (Information)xs.Deserialize(read);

                load.saveGame.player1name = info.player1name;
                load.saveGame.player2name = info.player2name;
                load.saveGame.player1score = info.player1score;
                load.saveGame.player2score = info.player2score;

                load.saveGame.Players = info.Players;

                if (saveGame.Players ==3)
                {
                    load.saveGame.player3name = info.player3name;
                    load.saveGame.player3score = info.player3score;
                }
                else if (saveGame.Players == 4)
                {
                    load.saveGame.player3name = info.player3name;
                    load.saveGame.player3score = info.player3score;
                    load.saveGame.player4name = info.player4name;
                    load.saveGame.player4score = info.player4score;
                }


                load.saveGame.Rows = info.Rows;
                load.saveGame.Columns = info.Columns;
                load.saveGame.FirstClicked = info.FirstClicked;
                load.saveGame.DraaiArray = info.DraaiArray;
                load.saveGame.TagArray = info.TagArray;
                if(info.themePath == null)
                    load.saveGame.themePath = opties.oThemaString;
                else
                    load.saveGame.themePath = info.themePath;
                this.label1.Text = saveGame.player1name;
                this.label2.Text = saveGame.player2name;
                if (saveGame.Players == 3)
                {
                    this.label3.Text = saveGame.player3name;
                }
                else if (saveGame.Players == 4)
                {
                    this.label3.Text = saveGame.player3name;
                    this.label4.Text = saveGame.player4name;
                }


                //kaartjes array
                //PictureBox[] Plaatjes;
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
                        
                        //locatie van box
                        Box.Location = new System.Drawing.Point(10 + cColumn * 110, 150 + cRow * 110);
                        //stretch
                        Box.SizeMode = PictureBoxSizeMode.StretchImage;

                        //box naam
                        Box.Name = i.ToString();
                        //box tag
                        Box.Tag = info.DraaiArray[i];

                        //box  size
                        Box.Size = new System.Drawing.Size(100, 100);
                        //aan plaates array
                        Plaatjes[i] = Box;
                        //image
                        if (load.saveGame.TagArray[i] == 0)
                        {
                            //Box.Image = Properties.Resources.kaartje0;
                            string imgpath = (Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).ToString() + saveGame.themePath + "0.png";
                            Box.Image = System.Drawing.Image.FromFile(imgpath);
                        }
                        else
                        {
                            //Box.Image = (Image)Properties.Resources.ResourceManager.GetObject("kaartje" + Box.Tag);
                            string imgpath = (Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).ToString() + saveGame.themePath + Box.Tag + ".png";
                            Box.Image = System.Drawing.Image.FromFile(imgpath);
                        }
                        
                        //increment 
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
                //File.Encrypt(savpath);
            }
        }


        public async void Box_Click(object sender, EventArgs e)
        {
            if (MaxClick < 2)
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
                //Boxje.Image = (Image)Properties.Resources.ResourceManager.GetObject("kaartje" + Boxje.Tag);
                string imgpath = (Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).ToString() + saveGame.themePath + Boxje.Tag + ".png";
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
                            if (saveGame.Players == 3)
                            {
                                this.label3.BackColor = System.Drawing.SystemColors.Control;
                                this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
                            }
                            if (saveGame.Players == 4)
                            {
                                this.label3.BackColor = System.Drawing.SystemColors.Control;
                                this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
                                this.label4.BackColor = System.Drawing.SystemColors.Control;
                                this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
                            }
                        }
                        else if (saveGame.playerturn == 1)
                        {
                            this.label1.BackColor = System.Drawing.SystemColors.Control;
                            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
                            this.label2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
                            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
                        }
                        else if (saveGame.playerturn == 2)
                        {
                            this.label1.BackColor = System.Drawing.SystemColors.Control;
                            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
                            this.label2.BackColor = System.Drawing.SystemColors.Control;
                            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
                            this.label3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
                            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
                        }
                        else if (saveGame.playerturn == 3)
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
                        switch (saveGame.playerturn)
                        {
                                case 0:
                                    saveGame.player1score = saveGame.player1score + 1;
                                    this.Speler1Score.Text = Convert.ToString(load.saveGame.player1score);
                                    break;
                                case 1:
                                    saveGame.player2score = saveGame.player2score + 1;
                                    this.Speler2Score.Text = Convert.ToString(load.saveGame.player2score);
                                    break;
                                case 2:
                                    saveGame.player3score = saveGame.player3score + 1;
                                    this.Speler3Score.Text = Convert.ToString(load.saveGame.player3score);
                                    break;
                                case 3:
                                    saveGame.player4score = saveGame.player4score + 1;
                                    this.Speler4Score.Text = Convert.ToString(load.saveGame.player4score);
                                    break;
                        }
                        //spel stop
                        int totalscore = player1score + player2score + player3score + player4score;
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
                        if (playerturn < saveGame.Players)
                        {
                            saveGame.playerturn = saveGame.playerturn + 1;
                        }
                        else
                        {
                            saveGame.playerturn = 0;
                        }

                        //delay
                        await Task.Delay(800);

                        //string imgbackpath = (Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).ToString() + @"\placeholder\kaartje0.png";
                        string imgbackpath = (Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).ToString() + saveGame.themePath + "0.png";
                        //draai 2 kaartjes terug
                        Plaatjes[FirstClicked].Image = System.Drawing.Image.FromFile(imgbackpath);//null reference, object not set to an instance
                        //Plaatjes[FirstClicked].Image = (Image)Properties.Resources.ResourceManager.GetObject("kaartje" + Boxje.Tag);                                                                           //Plaatjes[2].Image = Properties.Resources.kaartje0;
                            Plaatjes[ClickedNum].Image = System.Drawing.Image.FromFile(imgbackpath);
                            //Plaatjes[ClickedNum].Image = (Image)Properties.Resources.ResourceManager.GetObject("kaartje" + Boxje.Tag);

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

        private void Form2_Load(object sender, EventArgs e)
        {
            //old game
            //Load_Click();
            LoadGame();
            /*
            string savpath = Environment.CurrentDirectory + "/memory.sav";
            XmlSerializer xs = new XmlSerializer(typeof(Information));
            FileStream read = new FileStream(savpath, FileMode.Open, FileAccess.Read, FileShare.Read);
            Information info = (Information)xs.Deserialize(read);
            load.saveGame.player1name = info.player1name;
            load.saveGame.player2name = info.player2name;
            */
            //saveGame.player1name = load.saveGame.player1name;
            //saveGame.player2name = load.saveGame.player2name;



            Information info = load.saveGame;
            info.Players = load.saveGame.Players;
            info.player1name = load.saveGame.player1name;
            info.player2name = load.saveGame.player2name;

            this.label1.Text = saveGame.player1name;
            this.label2.Text = saveGame.player2name;
            this.Speler1Score.Text = Convert.ToString(load.saveGame.player1score);
            this.Speler2Score.Text = Convert.ToString(load.saveGame.player2score);

            this.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + @"\..\..\thema\" + saveGame.themeBackground + @"\background.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            if (info.Players ==3)
            {
                info.player3name = load.saveGame.player3name;
                this.label3.Text = saveGame.player3name;
                this.Speler3Score.Text = Convert.ToString(load.saveGame.player3score);
            }
            else if(info.Players ==4){
                info.player3name = load.saveGame.player3name;
                this.label3.Text = saveGame.player3name;
                this.Speler3Score.Text = Convert.ToString(load.saveGame.player3score);
                info.player4name = load.saveGame.player4name;
                this.label4.Text = saveGame.player4name;
                this.Speler4Score.Text = Convert.ToString(load.saveGame.player4score);
            }
            

            SaveXML.SaveData(info, "spelers.xml");

            /*
            if (File.Exists("spelers.xml"))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Information));
                FileStream read = new FileStream("spelers.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
                Information info = (Information)xs.Deserialize(read);
                saveGame.player1name = info.player1name;
                saveGame.player2name = info.player2name;
            }
            */

        }



    }
}

    
