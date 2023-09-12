using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoHerosQuest
{
    // Classe IronMan filha de PictureBox. Isso significa que um objeto de IronMan É uma PictureBox e, portanto,
    // apresenta Location, Size, Image e todos os outros atributos que constituem uma PictureBox
    class IronMan : PictureBox
    {
        public enum Direção
        {
            Cima,
            Baixo,
            Esquerda,
            Direita
        }

        Direção LastKey = Direção.Direita;

        private int SpaceCount = 1;
        private int Velocidade = 20;
        private int Vida = 1;
        private int MaxMunição = 3;
        public int QtdMunição = 0;
        private bool Destruir = false;
        private SoundPlayer soundPlayer = new SoundPlayer();

        private System.Windows.Forms.Timer temporizadorAnimaçãoVoando = new System.Windows.Forms.Timer();
        List<Image> animaçãoVoandoImagens = new List<Image>();
        int animaçãoVoandoÍndice = 0;

        private System.Windows.Forms.Timer temporizadorAnimaçãoAtacando = new System.Windows.Forms.Timer();
        List<Image> animaçãoAtacandoImagens = new List<Image>();
        List<Image> animaçãoAtacandoImagens2 = new List<Image>();
        int animaçãoAtacandoÍndice = 0;
        int animaçãoAtacandoÍndice2 = 0;

        private System.Windows.Forms.Timer temporizadorAnimaçãoMorrendo = new System.Windows.Forms.Timer();
        List<Image> animaçãoMorrendoImagens = new List<Image>();
        int animaçãoMorrendoÍndice = 0;


        public IronMan(Point initialPoint)
        {
            this.Image = global::ProjetoDudas.Properties.Resources.ironmanvoandoparado1;
            this.Location = initialPoint;
            this.TabIndex = 0;
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.BackColor = Color.Transparent;
            this.TabStop = false;

            // Temporizador de Animação de Vôo
            this.temporizadorAnimaçãoVoando.Interval = 200;
            this.temporizadorAnimaçãoVoando.Tick += new System.EventHandler(this.temporizadorAnimaçãoVoando_Tick);
            animaçãoVoandoImagens.Add(global::ProjetoDudas.Properties.Resources.ironmanvoandoparado1);
            animaçãoVoandoImagens.Add(global::ProjetoDudas.Properties.Resources.ironmanvoandoparado2);
            temporizadorAnimaçãoVoando.Start();

            // Temporizador de Animação de Ataque
            this.temporizadorAnimaçãoAtacando.Interval = 70;
            this.temporizadorAnimaçãoAtacando.Tick += new System.EventHandler(this.temporizadorAnimaçãoAtacando_Tick);
            //Lista 1
            animaçãoAtacandoImagens.Add(global::ProjetoDudas.Properties.Resources.ironmanatirando_01);
            animaçãoAtacandoImagens.Add(global::ProjetoDudas.Properties.Resources.ironmanatirando_02);
            animaçãoAtacandoImagens.Add(global::ProjetoDudas.Properties.Resources.ironmanatirando_03_1);
            animaçãoAtacandoImagens.Add(global::ProjetoDudas.Properties.Resources.ironmanatirando_03_2);
            animaçãoAtacandoImagens.Add(global::ProjetoDudas.Properties.Resources.ironmanatirando_03_3);
            animaçãoAtacandoImagens.Add(global::ProjetoDudas.Properties.Resources.ironmanatirando_03_4);
            animaçãoAtacandoImagens.Add(global::ProjetoDudas.Properties.Resources.ironmanatirando_05);
            //Lista 2
            animaçãoAtacandoImagens2.Add(global::ProjetoDudas.Properties.Resources.ironmanatirando_01);
            animaçãoAtacandoImagens2.Add(global::ProjetoDudas.Properties.Resources.ironmanatirando_04_1);
            animaçãoAtacandoImagens2.Add(global::ProjetoDudas.Properties.Resources.ironmanatirando_04_2);
            animaçãoAtacandoImagens2.Add(global::ProjetoDudas.Properties.Resources.ironmanatirando_04_3);
            animaçãoAtacandoImagens2.Add(global::ProjetoDudas.Properties.Resources.ironmanatirando_04_4);
            animaçãoAtacandoImagens2.Add(global::ProjetoDudas.Properties.Resources.ironmanatirando_05);


            // Temporizador de Animação de Morte
            this.temporizadorAnimaçãoMorrendo.Interval = 90;
            this.temporizadorAnimaçãoMorrendo.Tick += new System.EventHandler(this.temporizadorAnimaçãoMorrendo_Tick);
            animaçãoMorrendoImagens.Add(global::ProjetoDudas.Properties.Resources.ironmanexplosão_01);
            animaçãoMorrendoImagens.Add(global::ProjetoDudas.Properties.Resources.ironmanexplosão_02);
            animaçãoMorrendoImagens.Add(global::ProjetoDudas.Properties.Resources.ironmanexplosão_03);
            animaçãoMorrendoImagens.Add(global::ProjetoDudas.Properties.Resources.ironmanexplosão_04);
            animaçãoMorrendoImagens.Add(global::ProjetoDudas.Properties.Resources.ironmanexplosão_05);
            animaçãoMorrendoImagens.Add(global::ProjetoDudas.Properties.Resources.ironmanexplosão_06);
            animaçãoMorrendoImagens.Add(global::ProjetoDudas.Properties.Resources.ironmanexplosão_07);
        }

        private void temporizadorAnimaçãoAtacando_Tick(object sender, EventArgs e)
        {
            switch (SpaceCount)
            {
                case 1:
                    this.Image = animaçãoAtacandoImagens[animaçãoAtacandoÍndice];
                    animaçãoAtacandoÍndice++;
                    break;

                case 2:
                    this.Image = animaçãoAtacandoImagens2[animaçãoAtacandoÍndice2];
                    animaçãoAtacandoÍndice2++;
                    break;
            }
            if (animaçãoAtacandoÍndice == animaçãoAtacandoImagens.Count)
            {
                temporizadorAnimaçãoAtacando.Stop();
                animaçãoAtacandoÍndice = 0;
                this.temporizadorAnimaçãoVoando.Start();
                SpaceCount = 2;
            }
            else if (animaçãoAtacandoÍndice2 == animaçãoAtacandoImagens2.Count)
            {
                temporizadorAnimaçãoAtacando.Stop();
                animaçãoAtacandoÍndice2 = 0;
                this.temporizadorAnimaçãoVoando.Start();
                SpaceCount = 1;
            }
        }

        private void temporizadorAnimaçãoVoando_Tick(object sender, EventArgs e)
        {
            this.Image = animaçãoVoandoImagens[animaçãoVoandoÍndice];
            animaçãoVoandoÍndice++;
            if (animaçãoVoandoÍndice == animaçãoVoandoImagens.Count)
            {
                animaçãoVoandoÍndice = 0;
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
            this.Image = global::ProjetoDudas.Properties.Resources.ironmanvoandoparado1;
        }

        public void MoverParaCima()
        {
            this.Mover();

            int x_atual = this.Location.X;
            int y_atual = this.Location.Y;
            this.Location = new Point(x_atual, y_atual - Velocidade);
            LastKey = Direção.Cima;
        }

        public void MoverParaBaixo()
        {
            this.Mover();

            int x_atual = this.Location.X;
            int y_atual = this.Location.Y;
            this.Location = new Point(x_atual, y_atual + Velocidade);
            LastKey = Direção.Baixo;
        }

        public void MoverParaEsquerda()
        {
            this.Mover();

            int x_atual = this.Location.X;
            int y_atual = this.Location.Y;
            this.Location = new Point(x_atual - Velocidade, y_atual);
            LastKey = Direção.Esquerda;
        }

        public void MoverParaDireita()
        {
            this.Mover();

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

                case Direção.Cima:
                    this.Location = new Point(x_atual, y_atual - Velocidade * 4);
                    break;

                case Direção.Baixo:
                    this.Location = new Point(x_atual, y_atual + Velocidade * 4);
                    break;

                case Direção.Esquerda:
                    this.Location = new Point(x_atual - Velocidade * 4, y_atual);
                    break;

                case Direção.Direita:
                    this.Location = new Point(x_atual + Velocidade * 4, y_atual);
                    break;

            }

        }

        public void Parar()
        {
            this.Image = global::ProjetoDudas.Properties.Resources.ironmanvoandoparado1;
        }

        public void Morrer()
        {
            temporizadorAnimaçãoMorrendo.Start();
            soundPlayer.Stream = global::ProjetoDudas.Properties.Resources.hydrashipexplosionsound1;
            soundPlayer.Play();
        }

        public Projétil DispararProjétil()
        {

            temporizadorAnimaçãoVoando.Stop();
            temporizadorAnimaçãoAtacando.Start();


            if (QtdMunição > 1)
            {
                QtdMunição--;
                Point LocationProj = new Point(Location.X + 40, Location.Y + 5);
                Projétil novoProjétil = new Projétil(LocationProj);
                soundPlayer.Stream = global::ProjetoDudas.Properties.Resources.laser;
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
                temporizadorAnimaçãoVoando.Stop();
                //this.Image = global::ProjetoDudas.Properties.Resources.IronManJumping;
                return true;
            }
            else return false;
        }

        public void AtualizarMunição()
        {
            //mexer por aqui
            //QtdMunição = MaxMunição - projéteis_lançados;
            if (MaxMunição < 4)
                MaxMunição++;
            QtdMunição = MaxMunição;
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

        public void pause()
        {

            Velocidade = 0;
            temporizadorAnimaçãoAtacando.Stop();
            SpaceCount = 0;
            //QtdMunição = 0;

        }

        public void retornar()
        {
            Velocidade = 20;
            temporizadorAnimaçãoAtacando.Start();
            SpaceCount = 1;
        }
    }
}
