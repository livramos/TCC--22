using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoHerosQuest
{
    class ProjétilHulk : PictureBox
    {
        private int Velocidade = 8;
        public int Poder = 1;
        private System.Windows.Forms.Timer temporizador = new System.Windows.Forms.Timer();

        private System.Windows.Forms.Timer temporizadorAnimação = new System.Windows.Forms.Timer();
        List<Image> animaçãoImagens = new List<Image>();
        int animaçãoÍndice = 0;

        public ProjétilHulk(Point initialPoint)
        {
            // Inicializando Proprieadades
            //this.Image = Properties.Resources.IronManPower;
            this.Location = initialPoint;
            this.Size = new Size(initialPoint);
            this.TabIndex = 0;
            this.BackColor = Color.Transparent;
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.TabStop = false;

            // Temporizador de Movimento
            this.temporizador.Interval = 1;
            this.temporizador.Tick += new System.EventHandler(this.temporizador_Tick);
            temporizador.Start();

            // Temporizador de Animação
            this.temporizadorAnimação.Interval = 100;
            this.temporizadorAnimação.Tick += new System.EventHandler(this.temporizadorAnimaçãoVoando_Tick);
            animaçãoImagens.Add(global::ProjetoDudas.Properties.Resources.PedraHulk);
            temporizadorAnimação.Start();
        }

        public void Mover()
        {
            int x_atual = this.Location.X;
            int y_atual = this.Location.Y;
            this.Location = new Point(x_atual + Velocidade, y_atual);

        }

        private void temporizador_Tick(object sender, EventArgs e)
        {
            Mover();
            // Se o projétil atravessou a largura máxima da tela, então vamos destruí-lo
            if (this.Location.X > GlobalResources.SCENE_WIDTH)
                this.Dispose();
        }

        private void temporizadorAnimaçãoVoando_Tick(object sender, EventArgs e)
        {
            this.Image = animaçãoImagens[animaçãoÍndice];
            animaçãoÍndice++;
            if (animaçãoÍndice == animaçãoImagens.Count) animaçãoÍndice = 0;
        }

        public bool Colidiu(PictureBox pictureBox)
        {
            if (this.Bounds.IntersectsWith(pictureBox.Bounds))
                return true;
            else return false;
        }

        public void Destruir()
        {
            this.Dispose();
        }
    }
}
