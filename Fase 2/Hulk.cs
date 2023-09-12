using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectHeroQuestVS2017;
using ProjetoDudas;
using ProjetoHerosQuest;

namespace ProjetoDudas.Jogo.Fase_2
{
    class Hulk : PictureBox
    {

        public enum Direção
        {
            Esquerda,
            Direita
        }

        Direção LastKey = Direção.Direita;

        private int SpaceCount = 1;
        private int Velocidade = 20;
        private int Vida = 1;
        private int MaxMunição = 3;
        private int QtdMunição = 3;
        private bool Destruir = false;
        private SoundPlayer soundPlayer = new SoundPlayer();

        private System.Windows.Forms.Timer temporizadorAnimaçãoParado = new System.Windows.Forms.Timer();
        List<Image> animaçãoParadoImagens = new List<Image>();
        int animaçãoParadoÍndice = 0;

        private System.Windows.Forms.Timer temporizadorAnimaçãoAtacando = new System.Windows.Forms.Timer();
        List<Image> animaçãoAtacandoImagens = new List<Image>();
        List<Image> animaçãoAtacandoImagens2 = new List<Image>();
        int animaçãoAtacandoÍndice = 0;
        int animaçãoAtacandoÍndice2 = 0;

        private System.Windows.Forms.Timer temporizadorAnimaçãoMorrendo = new System.Windows.Forms.Timer();
        List<Image> animaçãoMorrendoImagens = new List<Image>();
        int animaçãoMorrendoÍndice = 0;


        public Hulk(Point initialPoint)
        {
            this.Image = global::ProjetoDudas.Properties.Resources.HulkParado;
            this.Location = initialPoint;
            this.TabIndex = 0;
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Size = new Size(120, 130);
            this.BackColor = Color.Transparent;
            this.TabStop = false;

            // Temporizador de Animação do Hulk Parado
            this.temporizadorAnimaçãoParado.Interval = 500;
            this.temporizadorAnimaçãoParado.Tick += new System.EventHandler(this.temporizadorAnimaçãoParado_Tick);
            animaçãoParadoImagens.Add(global::ProjetoDudas.Properties.Resources.HulkParado);
            animaçãoParadoImagens.Add(global::ProjetoDudas.Properties.Resources.HulkParado2);
            temporizadorAnimaçãoParado.Start();

            // Temporizador de Animação de Ataque
            this.temporizadorAnimaçãoAtacando.Interval = 70;
            this.temporizadorAnimaçãoAtacando.Tick += new System.EventHandler(this.temporizadorAnimaçãoAtacando_Tick);
            //Lista 1
            animaçãoAtacandoImagens.Add(global::ProjetoDudas.Properties.Resources.HulkArremessando_01);
            animaçãoAtacandoImagens.Add(global::ProjetoDudas.Properties.Resources.HulkArremessando_02);
            animaçãoAtacandoImagens.Add(global::ProjetoDudas.Properties.Resources.HulkArremessando_03);
            animaçãoAtacandoImagens.Add(global::ProjetoDudas.Properties.Resources.HulkArremessando_04);
            animaçãoAtacandoImagens.Add(global::ProjetoDudas.Properties.Resources.HulkArremessando_05);
            animaçãoAtacandoImagens.Add(global::ProjetoDudas.Properties.Resources.HulkArremessando_06);
            animaçãoAtacandoImagens.Add(global::ProjetoDudas.Properties.Resources.HulkArremessando_07);


            // Temporizador de Animação de Morte
            this.temporizadorAnimaçãoMorrendo.Interval = 90;
            this.temporizadorAnimaçãoMorrendo.Tick += new System.EventHandler(this.temporizadorAnimaçãoMorrendo_Tick);
            animaçãoMorrendoImagens.Add(global::ProjetoDudas.Properties.Resources.HulkTomandoDano_01);
            animaçãoMorrendoImagens.Add(global::ProjetoDudas.Properties.Resources.HulkTomandoDano_02);
            animaçãoMorrendoImagens.Add(global::ProjetoDudas.Properties.Resources.HulkTomandoDano_03);
        }

        private void temporizadorAnimaçãoAtacando_Tick(object sender, EventArgs e)
        {
                    this.Image = animaçãoAtacandoImagens[animaçãoAtacandoÍndice];
                    animaçãoAtacandoÍndice++;

            if (animaçãoAtacandoÍndice == animaçãoAtacandoImagens.Count)
            {
                temporizadorAnimaçãoAtacando.Stop();
                animaçãoAtacandoÍndice = 0;
                this.temporizadorAnimaçãoParado.Start();
            }
      
        }

        private void temporizadorAnimaçãoParado_Tick(object sender, EventArgs e)
        {
            this.Image = animaçãoParadoImagens[animaçãoParadoÍndice];
            animaçãoParadoÍndice++;
            if (animaçãoParadoÍndice == animaçãoParadoImagens.Count)
            {
                animaçãoParadoÍndice = 0;
            }
        }

        private void temporizadorAnimaçãoMorrendo_Tick(object sender, EventArgs e)
        {
            this.Image = animaçãoMorrendoImagens[animaçãoMorrendoÍndice];
            animaçãoMorrendoÍndice++;
            if (animaçãoMorrendoÍndice == animaçãoMorrendoImagens.Count)
            {
                temporizadorAnimaçãoMorrendo.Stop();
                animaçãoMorrendoÍndice = 0;
                this.Dispose();
            }
        }

        private void Mover()
        {
            this.Image = global::ProjetoDudas.Properties.Resources.HulkParado;
        }

        public void MoverParaEsquerda()
        {
            this.Mover();

            this.Image = global::ProjetoDudas.Properties.Resources.HulkMovendo_Esquerda;
            int x_atual = this.Location.X;
            int y_atual = this.Location.Y;
            this.Location = new Point(x_atual - Velocidade, y_atual);
            LastKey = Direção.Esquerda;
        }

        public void MoverParaDireita()
        {
            this.Mover();

            this.Image = global::ProjetoDudas.Properties.Resources.HulkMovendo_Direita;
            int x_atual = this.Location.X;
            int y_atual = this.Location.Y;
            this.Location = new Point(x_atual + Velocidade, y_atual);
            LastKey = Direção.Direita;
        }

        public void Dash()
        {
            this.Mover();

            int x_atual = this.Location.X;
            int y_atual = this.Location.Y;


            switch (LastKey)
            {
                case Direção.Esquerda:
                    this.Location = new Point(x_atual - Velocidade * 2, y_atual);
                    break;

                case Direção.Direita:
                    this.Location = new Point(x_atual + Velocidade * 2, y_atual);
                    break;

            }

        }

        public void Parar()
        {
            this.Image = global::ProjetoDudas.Properties.Resources.HulkParado;
        }

        public void Morrer()
        {
            temporizadorAnimaçãoMorrendo.Start();
            soundPlayer.Stream = global::ProjetoDudas.Properties.Resources.hydrashipexplosionsound1;
            soundPlayer.Play();
        }

        public ProjétilHulk DispararProjétil()
        {

            temporizadorAnimaçãoParado.Stop();
            temporizadorAnimaçãoAtacando.Start();


            if (QtdMunição > 0)
            {
                QtdMunição--;
                ProjétilHulk novoProjétil = new ProjétilHulk(this.Location);
                novoProjétil.Image = global::ProjetoDudas.Properties.Resources.PedraHulk;
                soundPlayer.Stream = global::ProjetoDudas.Properties.Resources.RochasLevantando;
                soundPlayer.Play();
                return novoProjétil;
            }
            else return null;

        }

        public void PerderVida(int n)
        {
            Vida -= n;
        }

        public bool Morreu()
        {
            if (Vida <= 0)
            {
                temporizadorAnimaçãoParado.Stop();
                return true;
            }
            else return false;
        }

        public void AtualizarMunição()
        {
            QtdMunição = 1;
        }

        public bool Colidiu(PictureBox pictureBox)
        {
            if (this.Bounds.IntersectsWith(pictureBox.Bounds))
                return true;
            else return false;
        }

        public int VidaAtual()
        {
            return Vida;
        }


    }
}
