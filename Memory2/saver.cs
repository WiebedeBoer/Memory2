using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace Memory2
{
    public class saver
    {
        
        //device;
        //public class StorageContainer : IDisposable
        [Serializable]
        //save game data
        public class Information
        {
            //raster breedte en hoogte (rijen en kolommen)
            public int Rows;
            public int Columns;
            //thema

            //aantal spelers
            public int Players;
            //spelers namen
            //player 1 naam
            public string player1name;
            //player 2 naam
            public string player2name;
            //spelers beurt
            public int playerturn;
            //zetten
            public int FirstClicked;
            public int SecondClicked;
            //spelers score
            //player 1 score
            public int player1score;
            //player 2 score
            public int player2score;
            //kaartjes posities in raster         
            public int[] DraaiArray;
            //kaartjes gedraaid, niet gedraaid, geraden
            public int[] TagArray;
        }


        //string filename = "memory.sav";

        public class SaveXML
        {
            public static void SaveData(object obj, string filename)
            {
                XmlSerializer sr = new XmlSerializer(obj.GetType());
                TextWriter writer = new StreamWriter(filename);
                sr.Serialize(writer, obj);
                writer.Close();
            }
        }
        
        //save game
        //public void Save_Click(string savname)
        public static void Save_Click()
        {
            //overwrite, 
            //delete voor maken
            //MessageBox.Show("ja bestaat");
            //string savpath = (Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).ToString() + @"\memory.sav";

            string savpath = Environment.CurrentDirectory + "/memory.sav";

            if (File.Exists(savpath))
            {
                //File.Delete("memory.sav");
                MessageBox.Show("ja opgeslagen");
            }

            try
            {
                Information info = Form1.saveGame;
                
                info.Rows = Form1.Rows;
                info.Columns = Form1.Columns;
                info.FirstClicked = Form1.FirstClicked;
                /*
                info.DraaiArray = Form1.saveGame.DraaiArray;
                info.TagArray = Form1.saveGame.TagArray;
                */
                SaveXML.SaveData(info, "memory.sav");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //File.WriteAllBytes (savpath, Serialized);
            //File.Encrypt(savpath);


            /*
            //open een storage container
            IAsyncResult result = device.BeginOpenContainer("StorageDemo", null, null);
            //wacht op de WaitHandle to become signaled
            result.AsyncWaitHandle.WaitOne();
            //maak storage container aan
            StorageContainer container = device.EndOpenContainer(result);
            //close wait handle
            result.AsyncWaitHandle.Close();
            //filename
            string filename = savname + ".sav";
            //Check of save bestand bestaat
            if (container.FileExists(filename))
                //delete bestaande zodat nieuwe sav aangemaakt kan worden
                container.DeleteFile(filename);
            //create the file
            Stream stream = container.CreateFile(filename);
            //converteer object naar XML data en zet in stream
            XmlSerializer serializer = new XmlSerializer(typeof(SaveGameData));
            //call serializer
            serializer.Serialize(stream, data);
            //close file en stream
            stream.Close();
            // Dispose the container, to commit changes.
            container.Dispose();
            */

        }

        /*
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
                        Box.Click += Box_Click;
                        //layout kaartjes
                        ((System.ComponentModel.ISupportInitialize)(Box)).EndInit();
                        this.ResumeLayout(false);
                    }
                }

            }
            */
            /*
            //open storage container
            IAsyncResult result = device.BeginOpenContainer("StorageDemo", null, null);
            //wacht op WaitHandle to become signaled.
            result.AsyncWaitHandle.WaitOne();
            //storage container
            StorageContainer container = device.EndOpenContainer(result);
            //close wait handle
            result.AsyncWaitHandle.Close();
            string filename = savname + ".sav";
            // Check of save bestand bestaat
            if (!container.FileExists(filename))
            {
                // If not, dispose of the container and return.
                container.Dispose();
                return;
            }
            //open file
            Stream stream = container.OpenFile(filename, FileMode.Open);
            //xml serializer
            XmlSerializer serializer = new XmlSerializer(typeof(SaveGameData));
            //deserialize
            SaveGameData data = (SaveGameData)serializer.Deserialize(stream);
            //close file een stream
            stream.Close();
            //dispose container
            container.Dispose();
            */
        /*
        }

        */

    }
}
