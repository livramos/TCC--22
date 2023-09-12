using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoDudas;

namespace ProjetoHerosQuest
{
    class HydraShip : PictureBox
    {

        private int Velocidade = 5;
        private int Vida = 10;
        private bool Carregado = false;
        private SoundPlayer soundPlayer = new SoundPlayer();
        private System.Windows.Forms.Timer temporizador = new System.Windows.Forms.Timer();

        private System.Windows.Forms.Timer temporizadorCarregar = new System.Windows.Forms.Timer();

        private System.Windows.Forms.Timer temporizadorAnimação = new System.Windows.Forms.Timer();
        public List<Image> animaçãoImagens = new List<Image>();
        int animaçãoÍndice = 0;

        private System.Windows.Forms.Timer temporizadorAnimaçãoExplodindo = new System.Windows.Forms.Timer();
        public List<Image> animaçãoExplodindoImagens = new List<Image>();
        int animaçãoExplodindoÍndice = 0;

        public HydraShip(Point initialPoint)
        {
            // Inicializando Proprieadades
            this.Image = ProjetoDudas.Properties.Resources.HydraShipVoando1;
            this.Location = initialPoint;
            this.Size = new Size(initialPoint);
            this.TabIndex = 0;
            this.BackColor = Color.Transparent;
            this.TabStop = false;
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;


            // Temporizador de Carregamento
            this.temporizadorCarregar.Interval = 2000;
            this.temporizadorCarregar.Tick += new System.EventHandler(this.temporizadorCarregar_Tick);
            temporizadorCarregar.Start();

            // Temporizador de Movimento
            this.temporizador.Interval = 1;
            this.temporizador.Tick += new System.EventHandler(this.temporizador_Tick);
            temporizador.Start();

            // Temporizador de Animação de Movimento
            this.temporizadorAnimação.Interval = 100;
            this.temporizadorAnimação.Tick += new System.EventHandler(this.temporizadorAnimaçãoVoando_Tick);
            animaçãoImagens.Add(global::ProjetoDudas.Properties.Resources.HydraShip1);
            animaçãoImagens.Add(global::ProjetoDudas.Properties.Resources.HydraShip2);
            temporizadorAnimação.Start();

            // Temporizador de Animação de Explosão
            this.temporizadorAnimaçãoExplodindo.Interval = 60;
            this.temporizadorAnimaçãoExplodindo.Tick += new System.EventHandler(this.temporizadorAnimaçãoExplodindo_Tick);
            animaçãoExplodindoImagens.Add(global::ProjetoDudas.Properties.Resources.HydraShipDamaged2);
            animaçãoExplodindoImagens.Add(global::ProjetoDudas.Properties.Resources.hydrashipdamaged1);
            animaçãoExplodindoImagens.Add(global::ProjetoDudas.Properties.Resources.HydraShipExplosion3);
            animaçãoExplodindoImagens.Add(global::ProjetoDudas.Properties.Resources.HydraShipExplosion4);
            animaçãoExplodindoImagens.Add(global::ProjetoDudas.Properties.Resources.HydraShipExplosion5);
            animaçãoExplodindoImagens.Add(global::ProjetoDudas.Properties.Resources.HydraShipExplosion6);
            animaçãoExplodindoImagens.Add(global::ProjetoDudas.Properties.Resources.HydraShipExplosion7);
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
            Mover();
        }

        private void temporizadorCarregar_Tick(object sender, EventArgs e)
        {
            Carregado = true;
        }

        private void temporizadorAnimaçãoVoando_Tick(object sender, EventArgs e)
        {
            this.Image = animaçãoImagens[animaçãoÍndice];
            animaçãoÍndice++;
            if (animaçãoÍndice == animaçãoImagens.Count) animaçãoÍndice = 0;
        }

        private void temporizadorAnimaçãoExplodindo_Tick(object sender, EventArgs e)
        {
            this.Image = animaçãoExplodindoImagens[animaçãoExplodindoÍndice];
            animaçãoExplodindoÍndice++;
            if (animaçãoExplodindoÍndice == animaçãoExplodindoImagens.Count)
            {
                temporizadorAnimaçãoExplodindo.Stop();
                animaçãoExplodindoÍndice = 0;
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

        public bool EstahFuncionando()
        {
            if (Vida > 0) return true;
            else return false;
        }

        public void Explodir()
        {
            temporizadorAnimaçãoExplodindo.Start();
            soundPlayer.Stream = global::ProjetoDudas.Properties.Resources.hydrashipexplosionsound1;
            soundPlayer.Play();
            temporizadorCarregar.Stop();
        }

        public int VidaAtual()
        {
            return Vida;
        }

        public void pause()
        {

            Velocidade = 0;
            temporizadorCarregar.Stop();

        }

        public void retornar()
        {
            Velocidade = 5;
            temporizadorCarregar.Start();

        }

        public void mudarvariaveis_hydra(int Velo, int HP)
        {
            Velocidade = Velo;
            Vida = HP;
        }

    }
}
