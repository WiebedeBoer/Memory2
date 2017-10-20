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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
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
        /*
        public class Information
        {
        public string player1name;
        public string player2name;
        }
        */

        Thread thre;

        private void button1_Click(object sender, EventArgs e)
        {
            //player 1 naam
            string player1name = textBox1.Text;
            //player 2 naam
            string player2name = textBox2.Text;

            try
            {
                Information info = Form1.saveGame;
                info.player1name = textBox1.Text;
                info.player2name = textBox2.Text;
               
                SaveXML.SaveData(info, "spelers.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //new game thread
            this.Close();
            thre = new Thread(newgame);
            thre.SetApartmentState(ApartmentState.STA);
            thre.Start();
        }

        private void newgame(object obj)
        {
            //throw new NotImplementedException();
            Application.Run(new Form1());
        }
    }
}
