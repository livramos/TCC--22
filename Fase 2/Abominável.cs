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
    class Abominável : PictureBox
    {
        private int Velocidade = 5;
        private int Vida = 10;
        private bool Carregado = false;
        private SoundPlayer soundPlayer = new SoundPlayer();
        private System.Windows.Forms.Timer temporizador = new System.Windows.Forms.Timer();

        private System.Windows.Forms.Timer temporizadorCarregar = new System.Windows.Forms.Timer();

        private System.Windows.Forms.Timer temporizadorAnimação = new System.Windows.Forms.Timer();
        List<Image> animaçãoImagens = new List<Image>();
        int animaçãoÍndice = 0;

        private System.Windows.Forms.Timer temporizadorAnimaçãoMorrendo = new System.Windows.Forms.Timer();
        List<Image> animaçãoMorrendoImagens = new List<Image>();
        int animaçãoMorrendoÍndice = 0;

        private System.Windows.Forms.Timer temporizadorAnimaçãoAtacando = new System.Windows.Forms.Timer();
        List<Image> animaçãoAtacandoImagens = new List<Image>();
        int animaçãoAtaqueÍndice = 0;


        public Abominável(Point initialPoint)
        {
            // Inicializando Proprieadades
            this.Image = ProjetoDudas.Properties.Resources.AbominávelAtacando_01;
            this.Location = initialPoint;
            this.Size = new Size(initialPoint);
            this.TabIndex = 0;
            this.Size = new Size(120,130);
            this.BackColor = Color.Transparent;
            this.TabStop = false;
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;


            // Temporizador de Carregamento
            this.temporizadorCarregar.Interval = 2000;
            this.temporizadorCarregar.Tick += new System.EventHandler(this.temporizadorCarregar_Tick);
            temporizadorCarregar.Start();

            // Temporizador de Movimento
            this.temporizador.Interval = 1;
            this.temporizador.Tick += new System.EventHandler(this.temporizador_Tick);
            temporizador.Start();

            // Temporizador de Animação de Movimento
            this.temporizadorAnimação.Interval = 500;
            this.temporizadorAnimação.Tick += new System.EventHandler(this.temporizadorAnimaçãoParado_Tick);
            animaçãoImagens.Add(global::ProjetoDudas.Properties.Resources.AbominávelParado_01);
            animaçãoImagens.Add(global::ProjetoDudas.Properties.Resources.AbominávelParado_02);
            temporizadorAnimação.Start();

            // Temporizador de Animação de Morte
            this.temporizadorAnimaçãoMorrendo.Interval = 100;
            this.temporizadorAnimaçãoMorrendo.Tick += new System.EventHandler(this.temporizadorAnimaçãoMorrendo_Tick);
            
            animaçãoMorrendoImagens.Add(global::ProjetoDudas.Properties.Resources.AbominávelPerdendoVida_01);
            animaçãoMorrendoImagens.Add(global::ProjetoDudas.Properties.Resources.AbominávelPerdendoVida_02);

            // Temporizador de Animação de Ataque
            this.temporizadorAnimaçãoAtacando.Interval = 100;
            this.temporizadorAnimaçãoAtacando.Tick += new System.EventHandler(this.temporizadorAnimaçãoAtaque_Tick);
            animaçãoAtacandoImagens.Add(global::ProjetoDudas.Properties.Resources.AbominávelArremessando_01);
            animaçãoAtacandoImagens.Add(global::ProjetoDudas.Properties.Resources.AbominávelArremessando_02);
            animaçãoAtacandoImagens.Add(global::ProjetoDudas.Properties.Resources.AbominávelArremessando_03);
            animaçãoAtacandoImagens.Add(global::ProjetoDudas.Properties.Resources.AbominávelArremessando_04);
            animaçãoAtacandoImagens.Add(global::ProjetoDudas.Properties.Resources.AbominávelArremessando_05);
            animaçãoAtacandoImagens.Add(global::ProjetoDudas.Properties.Resources.AbominávelArremessando_06);
        }



        public void Mover()
        {

            int x_atual = this.Location.X;
            int y_atual = this.Location.Y;

            if (y_atual < 0) Velocidade *= -1;
            if (y_atual > GlobalResources.SCENE_HEIGHT - this.Height) Velocidade *= -1;

            this.Location = new Point(x_atual, y_atual + Velocidade);
        }

        private void temporizador_Tick(object sender, EventArgs e)
        {
           // Mover();
        }

        private void temporizadorCarregar_Tick(object sender, EventArgs e)
        {
            Carregado = true;
        }

        private void temporizadorAnimaçãoParado_Tick(object sender, EventArgs e)
        {
            this.Image = animaçãoImagens[animaçãoÍndice];
            animaçãoÍndice++;
            if (animaçãoÍndice == animaçãoImagens.Count - 1)
            {
                animaçãoÍndice = 0;
            }
        }

        private void temporizadorAnimaçãoAtaque_Tick(object sender, EventArgs e)
        {
            this.Image = animaçãoAtacandoImagens[animaçãoAtaqueÍndice];
            animaçãoAtaqueÍndice++;
            if (animaçãoAtaqueÍndice == animaçãoAtacandoImagens.Count)
            {
                temporizadorAnimaçãoAtacando.Stop();
                animaçãoAtaqueÍndice = 0;
            }
        }

        private void temporizadorAnimaçãoMorrendo_Tick(object sender, EventArgs e)
        {
            this.Image = animaçãoMorrendoImagens[animaçãoÍndice];
            animaçãoMorrendoÍndice++;
            if (animaçãoMorrendoÍndice == animaçãoMorrendoImagens.Count)
            {
                temporizadorAnimaçãoMorrendo.Stop();
                animaçãoMorrendoÍndice = 0;
                this.Dispose();
            }
        }

        public bool Colidiu(PictureBox pictureBox)
        {
            if (this.Bounds.IntersectsWith(pictureBox.Bounds))
            {
                return true;
            }

            else return false;
        }

        public bool EstahCarregado()
        {
            return Carregado;
        }

        public Míssil DispararMíssil()
        {
            Carregado = false;
            Míssil novoMíssil = new Míssil(this.Location);
            return novoMíssil;
        }

        public void TomarDano(int dano)
        {
            Vida -= dano;
        }

        public bool EstahVivo()
        {
            if (Vida > 0) return true;
            else return false;
        }

        public void Morrer()
        {
            temporizadorAnimaçãoMorrendo.Start();
            soundPlayer.Stream = global::ProjetoDudas.Properties.Resources.hydrashipexplosionsound1;
            soundPlayer.Play();
            temporizadorCarregar.Stop();
        }

        public int VidaAtual()
        {
            return Vida;
        }
    }
}
