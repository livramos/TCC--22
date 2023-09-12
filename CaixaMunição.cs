using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectHeroQuestVS2017
{
    class CaixaMunição : PictureBox
    {
        private Timer timer1;
        private int SpaceCount = 1;
        private System.ComponentModel.IContainer components;
        List<Point> animaçãoDropMuni = new List<Point>();


        Random randomizar = new Random();


        public CaixaMunição()
        {
            this.Image = ProjetoDudas.Properties.Resources.ArcReactorMin;
            this.BackColor = System.Drawing.Color.Transparent;


            if (randomizar.Next(0, 6) == 0)
                Location = new System.Drawing.Point(250, 50);

            else if (randomizar.Next(0, 6) == 1)
                Location = new System.Drawing.Point(300, 50);

            else if (randomizar.Next(0, 6) == 2)
                Location = new System.Drawing.Point(250, 75);

            else if (randomizar.Next(0, 6) == 3)
                Location = new System.Drawing.Point(325, 250);

            else if (randomizar.Next(1, 6) == 4)
                Location = new System.Drawing.Point(250, 400);

            else if (randomizar.Next(1, 6) == 5)
                Location = new System.Drawing.Point(300, 350);


            this.Name = "pictureBox1";
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.TabIndex = 0;
            this.TabStop = false;

        }

        public bool Colidiu(PictureBox pictureBox)
        {
            if (this.Bounds.IntersectsWith(pictureBox.Bounds))
                return true;
            else return false;
        }

        public void Sumir()
        {
            this.Dispose();
        }

        public void DropMuni()
        {
            CaixaMunição nova_caixa = new CaixaMunição();
            this.Controls.Add(nova_caixa);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
