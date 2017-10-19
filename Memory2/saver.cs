﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Memory2
{
    class saver
    {
        
        //device;
        //public class StorageContainer : IDisposable

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
        

        string savname = "memory";

        /*
        private void CreateXML_Click(object sender, EventArgs e)
        {
            try
            {
                Information info = new Information();
                info.Data1 = Rows;
                info.Data2 = Columns;
                info.Data3 = FirstClicked;
                info.Data4 = DraaiArray[];
                info.Data5 = TagArray[];

                SaveXML.SaveData(info, "data.xml");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        */


        //save game
        //public void Save_Click(string savname)
        public void Save_Click(object sender, EventArgs e)
        {
            try
            {
                Information info = new Information();
                /*
                info.Data1 = Rows;
                info.Data2 = Columns;
                info.Data3 = FirstClicked;
                info.Data4 = DraaiArray[];
                info.Data5 = TagArray[];
                */
                SaveXML.SaveData(info, "memory.sav");
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }


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
            if (File.Exists("memory.sav"))
            {

                XmlSerializer xs = new XmlSerializer(typeof(Information));

                FileStream read = new FileStream("memory.sav", FileMode.Open, FileAccess.Read, FileShare.Read);

                Information info = (Information)xs.Deserialize(read);
                /*
                Data1.Text = info.Data1;

                Data2.Text = info.Data2;

                Data3.Text = info.Data3;
                */
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