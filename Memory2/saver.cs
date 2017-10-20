using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace Memory2
{
    class saver
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

            //spelers namen

            //spelers beurt

            //zetten
            public int FirstClicked;
            //spelers score

            //kaartjes posities in raster         
            public int[] DraaiArray;
            //kaartjes gedraaid, niet gedraaid, geraden
            public int[] TagArray;
        }


        string filename = "memory.sav";

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
        public void Save_Click(object sender, EventArgs e)
        {
            //overwrite, 
            //delete voor maken
            //MessageBox.Show("ja bestaat");
            string savpath = (Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).ToString() + @"\memory.sav";

            if (File.Exists(savpath))
            {
                //File.Delete("memory.sav");
                MessageBox.Show("ja opgeslagen");
            }

            try
            {
                Information info = new Information();
                
                info.Rows = Form1.Rows;
                info.Columns = Form1.Columns;
                info.FirstClicked = Form1.FirstClicked;
                info.DraaiArray = Form1.DraaiArray;
                info.TagArray = Form1.TagArray;
                
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

        //load game
        public void Load_Click(string savname)
        {
            string savpath = (Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).ToString() + @"\memory.sav";
            //GameState gameState;
            //File.Decrypt(savpath);

            if (File.Exists(savpath))
            {

                XmlSerializer xs = new XmlSerializer(typeof(Information));

                FileStream read = new FileStream("memory.sav", FileMode.Open, FileAccess.Read, FileShare.Read);

                Information info = (Information)xs.Deserialize(read);

                Form1.Rows = info.Rows;
                Form1.Columns = info.Columns;
                Form1.FirstClicked = info.FirstClicked;
                Form1.DraaiArray = info.DraaiArray;
                Form1.TagArray = info.TagArray;

            }
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
        }

    }
}
