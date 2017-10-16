using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory
{
    public partial class Form1 : Form
    {

          public Form1()
         {
            /*    InitializeComponent();
               for(int j = 0; j < 16; j++)
               {
                PictureBox newPB = new PictureBox();
                newPB.Size = new System.Drawing.Size(75,75);
                newPB.Location = new System.Drawing.Point();

           */     //form1.Controls.Add;  
            int totaldeckcount = 16;
         PictureBox pb = new PictureBox();
        pb.Size = new Size(this.Size.Width / 14, this.Size.Width / 12);  //I use this picturebox simply to debug and see if I can create a single picturebox, and that way I can tell if something goes wrong with my array of pictureboxes. Thus far however, neither are working.
        pb.BackgroundImage = Properties.Resources.cardback;
        pb.BackgroundImageLayout = ImageLayout.Stretch;
        pb.Location = new Point(50, 50);
        pb.Anchor = AnchorStyles.Left;
        pb.Visible = true;
        InitializeComponent();
        this.Controls.Add(pb);
        PictureBox[] pbName = new PictureBox[totaldeckcount];
        for (int i = 0; i<totaldeckcount; i++)
        {
            pbName[i] = new PictureBox();
        pbName[i].Size = new Size(this.Size.Width / 14, this.Size.Width / 12);
        pbName[i].BackgroundImage = Properties.Resources.cardback;
            pbName[i].BackgroundImageLayout = ImageLayout.Stretch;
            pbName[i].Image = Properties.Resources.cardback;
            pbName[i].Anchor = AnchorStyles.Left;
            pbName[i].Visible = true;
            int x = 0;
        int y = 15;
            if (i > 10)
            {
                y += (int) ((this.Size.Height* i) + 30);
        }
        x = (int) ((this.Size.Width / 12) * Math.IEEERemainder(i, 10));
            pbName[i].Location = new Point(x, y);
            this.Controls.Add(pbName[i]);
        }
              }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
    }
}
