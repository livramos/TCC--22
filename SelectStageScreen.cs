using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectHeroQuestVS2017;
using ProjetoDudas;
using ProjetoDudas.Jogo.Fase_2;


namespace ProjetoDudas
{
    public partial class SelectStageScreen : Form
    {
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private SoundPlayer soundPlayer = new SoundPlayer();
        private SoundPlayer soundPlayer2 = new SoundPlayer();

        public SelectStageScreen()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox5
            // 
            this.pictureBox5.Cursor = System.Windows.Forms.Cursors.No;
            this.pictureBox5.Location = new System.Drawing.Point(785, 0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(180, 400);
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.No;
            this.pictureBox4.Location = new System.Drawing.Point(598, 101);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(180, 400);
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.No;
            this.pictureBox3.Location = new System.Drawing.Point(410, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(180, 400);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::ProjetoDudas.Properties.Resources.DeadpoolStageLocked;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::ProjetoDudas.Properties.Resources.HulkSelecao_03;
            this.pictureBox2.Location = new System.Drawing.Point(222, 101);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(180, 400);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBox2.MouseLeave += new System.EventHandler(this.pictureBox2_MouseLeave);
            this.pictureBox2.MouseHover += new System.EventHandler(this.pictureBox2_MouseHover);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::ProjetoDudas.Properties.Resources.SelecaoIronMan_02;
            this.pictureBox1.Location = new System.Drawing.Point(35, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 400);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
            // 
            // SelectStageScreen
            // 
            this.ClientSize = new System.Drawing.Size(999, 501);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "SelectStageScreen";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }



        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            soundPlayer.Stream = global::ProjetoDudas.Properties.Resources.menu_1_ironman;
            soundPlayer.PlayLooping();
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            soundPlayer.Stream = global::ProjetoDudas.Properties.Resources.menu_1_hulk;
            soundPlayer.PlayLooping();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            soundPlayer.Stream = global::ProjetoDudas.Properties.Resources.menu_2_ironman;
            soundPlayer.Play();
            IronManForm IronManForm = new IronManForm();
            this.Hide();
            IronManForm.ShowDialog();
            this.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            HulkForm HulkForm = new HulkForm();
            this.Hide();
            HulkForm.ShowDialog();
            this.Show();
            soundPlayer.Stream = global::ProjetoDudas.Properties.Resources.menu_2_hulk;
            soundPlayer.Play();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            soundPlayer.Stop();
            soundPlayer2.Stream = global::ProjetoDudas.Properties.Resources.menu_prin_original;
            soundPlayer2.PlayLooping();
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            soundPlayer.Stop();
            soundPlayer2.Stream = global::ProjetoDudas.Properties.Resources.menu_prin_original;
            soundPlayer2.PlayLooping();

        }


    }
}
