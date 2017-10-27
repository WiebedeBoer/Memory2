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

        //player 1 score
        public static int player1score = 0;
        //player 2 score
        public static int player2score = 0;
        //player 1 naam
        //string player1name = login.player1name;
        //public static string player1name = load.saveGame.player1name;
        public static Information saveGame = new Information();
        //player 2 naam
        //string player2name = login.player2name;
        //public static string player2name = load.saveGame.player2name;
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
        //public static int FirstClicked = load.saveGame.FirstClicked;
        public static int FirstClicked = -1;
        //second clicked kaartje
        public static int SecondClicked = -1;

        //half of total cards
        public int halfway = (Rows * Columns) / 2;

        //Maximaal 2 kaart clicks per beurt
        public int MaxClick = 0;

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
            try
            {
                Scores info = new Scores();
                info.Naam = Form1.saveGame.player1name;
                info.Score = player1score;
                AppendData(info, "data.xml");
                //MessageBox.Show("De score is toegevoegd");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

                XmlSerializer xs = new XmlSerializer(typeof(Information));

                //FileStream read = new FileStream("memory.sav", FileMode.Open, FileAccess.Read, FileShare.Read);
                FileStream read = new FileStream(savpath, FileMode.Open, FileAccess.Read, FileShare.Read);

                Information info = (Information)xs.Deserialize(read);

                load.saveGame.player1name = info.player1name;
                load.saveGame.player2name = info.player2name;
                load.saveGame.player1score = info.player1score;
                load.saveGame.player2score = info.player2score;
                load.saveGame.Rows = info.Rows;
                load.saveGame.Columns = info.Columns;
                load.saveGame.FirstClicked = info.FirstClicked;
                load.saveGame.DraaiArray = info.DraaiArray;
                load.saveGame.TagArray = info.TagArray;

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
                        //image
                        if (load.saveGame.TagArray[i] == 0)
                        {
                            Box.Image = Properties.Resources.kaartje0;
                        }
                        else
                        {
                            Box.Image = (Image)Properties.Resources.ResourceManager.GetObject("kaartje" + Box.Tag);
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
                Boxje.Image = (Image)Properties.Resources.ResourceManager.GetObject("kaartje" + Boxje.Tag);
                MaxClick++;
                //als er al wel een kaart is omgedraaid in een beurt, oftewel tweede zet in beurt van een speler
                if (FirstClicked != -1)
                {
                MaxClick++;
                    if (playerturn == 0)
                    {
                        this.label1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
                        this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
                        this.label2.BackColor = System.Drawing.SystemColors.Control;
                        this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
                    }
                    else
                    {
                        this.label1.BackColor = System.Drawing.SystemColors.Control;
                        this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
                        this.label2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
                        this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
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
                                player1score = player1score + 1;
                                break;
                            case 1:
                                player2score = player2score + 1;
                                break;
                        }
                        //spel stop
                        int totalscore = player1score + player2score;
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
        }



    }
}

    
