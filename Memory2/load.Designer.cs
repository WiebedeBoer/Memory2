namespace Memory2
{
    partial class load
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            //this.pictureBox1 = new System.Windows.Forms.PictureBox();

            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();

            this.Speler1Score = new System.Windows.Forms.Label();
            this.Speler2Score = new System.Windows.Forms.Label();
            this.Speler3Score = new System.Windows.Forms.Label();
            this.Speler4Score = new System.Windows.Forms.Label();

            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            //((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            //this.label1.Text = "Naam1";
            //this.label1.Text = load.player1name;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            //this.label2.Text = "Naam2";
            //this.label2.Text = load.player2name;

            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(245, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 5;
            //this.label3.Text = "player 3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(345, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 7;
            //this.label4.Text = "player 4";

            // 
            // Speler1Score
            // 
            this.Speler1Score.AutoSize = true;
            this.Speler1Score.Location = new System.Drawing.Point(11, 45);
            this.Speler1Score.Name = "Speler1Score";
            this.Speler1Score.Size = new System.Drawing.Size(14, 15);
            this.Speler1Score.TabIndex = 6;
            //this.Speler1Score.Text = "0";
            // 
            // Speler2Score
            // 
            this.Speler2Score.AutoSize = true;
            this.Speler2Score.Location = new System.Drawing.Point(124, 45);
            this.Speler2Score.Name = "Speler2Score";
            this.Speler2Score.Size = new System.Drawing.Size(14, 15);
            this.Speler2Score.TabIndex = 7;
            //this.Speler2Score.Text = "0";
            // 
            // Speler3Score
            // 
            this.Speler3Score.AutoSize = true;
            this.Speler3Score.Enabled = false;
            this.Speler3Score.Location = new System.Drawing.Point(245, 45);
            this.Speler3Score.Name = "Speler3Score";
            this.Speler3Score.Size = new System.Drawing.Size(14, 15);
            this.Speler3Score.TabIndex = 8;
            //this.Speler3Score.Text = "0";
            // 
            // Speler4Score
            // 
            this.Speler4Score.AutoSize = true;
            this.Speler4Score.Enabled = false;
            this.Speler4Score.Location = new System.Drawing.Point(345, 45);
            this.Speler4Score.Name = "Speler4Score";
            this.Speler4Score.Size = new System.Drawing.Size(14, 15);
            this.Speler4Score.TabIndex = 9;
            //this.Speler4Score.Text = "0";

            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(208, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(08, 65);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            /*
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(2, 2);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            */
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 462);
            //this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);

            this.Controls.Add(this.Speler4Score);
            this.Controls.Add(this.Speler3Score);
            this.Controls.Add(this.Speler2Score);
            this.Controls.Add(this.Speler1Score);

            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Name = "Load";
            this.Text = "Load";
            this.Load += new System.EventHandler(this.Form2_Load);
            //this.Load += new System.EventHandler(this.Form2_Load);
            //((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        //private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.Label Speler1Score;
        private System.Windows.Forms.Label Speler2Score;
        private System.Windows.Forms.Label Speler3Score;
        private System.Windows.Forms.Label Speler4Score;

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        /*
        private System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Timer timer1;
        */
    }
}



/*
namespace Memory2
{
    partial class load
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "load";
        }

        #endregion
    }
}
*/
