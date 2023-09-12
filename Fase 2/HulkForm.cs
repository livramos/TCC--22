using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectHeroQuestVS2017;
using ProjetoHerosQuest;
using System.Data;
using ProjetoDudas;
using System.Media;

namespace ProjetoDudas.Jogo.Fase_2
{
    public partial class HulkForm : Form
    {
        //Personagens
        Hulk Hulk;
        Abominável Abominável;
        CaixaMunição nova_caixa;
        vida CaixaVida;


        // Labels
        Label lblHulkVida;
        Label lblVidaAbominável;
        Label GameOver;

        // Sons
        private SoundPlayer soundPlayer = new SoundPlayer();


        bool ClosingGame = false;
        int ClosingTimer;

        public HulkForm()
        {
            InitializeComponent();
            // Otimizando Processamento:
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.AllPaintingInWmPaint, true);
            this.DoubleBuffered = true;
        }

        private void LimparListas()
        {
            foreach (Control control in Controls)
            {
                if (control == null)
                    Controls.Remove(control);
            }
        }


        private void HulkForm_Load(object sender, EventArgs e)
        {
            soundPlayer.Stream = global::ProjetoDudas.Properties.Resources.City_Under_Attack___War_Sound_Effects;
            soundPlayer.Play();

            Hulk = new Hulk(new Point(99, 325));
            this.Controls.Add(Hulk);
            Abominável = new Abominável(new Point(601, 325));
            this.Controls.Add(Abominável);

            this.lblHulkVida = new Label();
            this.lblHulkVida.AutoSize = true;
            this.lblHulkVida.Location = new System.Drawing.Point(0, 0);
            this.lblHulkVida.TabIndex = 0;
            this.lblHulkVida.Text = $"Vida: {Hulk.VidaAtual()}";
            this.Controls.Add(lblHulkVida);


            this.lblVidaAbominável = new Label();
            this.lblVidaAbominável.AutoSize = true;
            this.lblVidaAbominável.Location = new Point(425, 5);
            this.lblVidaAbominável.TabIndex = 0;
            this.lblVidaAbominável.Text = $"Vidas Hydra: {Abominável.VidaAtual()}";
            this.Controls.Add(lblVidaAbominável);


            // progressBar1
            // 
            CaixaVida = new vida();
            CaixaVida.Location = new Point(300, 20);
            //CaixaVida.Location = new System.Drawing.Point(12, 12);
            CaixaVida.Name = "progressBar1";
            CaixaVida.Size = new System.Drawing.Size(332, 23);
            CaixaVida.TabIndex = 0;
            CaixaVida.Value = 100;
            Controls.Add(CaixaVida);


            nova_caixa = new CaixaMunição();
            this.Controls.Add(nova_caixa);



            background.Controls.Add(Hulk);
            background.Controls.Add(Abominável);
        }



        private void TemporizadorPrincipalFase2_Tick(object sender, EventArgs e)
        {
            //Fechando Form
            if (ClosingGame == true)
            {
                ClosingTimer++;
            }
            if (ClosingTimer == 30)
                this.Close();


            //Abominável Atirando

            if (Controls.OfType<Míssil>().Count() < 1)
            {

                if (Abominável.EstahCarregado())
                {
                    // Um novo míssil é criado e adicionado na lista de controles
                    Míssil pedraAbominável = Abominável.DispararMíssil();
                    pedraAbominável.Image = global::ProjetoDudas.Properties.Resources.PedraAbominável;
                    background.Controls.Add(pedraAbominável);
                    this.Controls.Add(pedraAbominável);
                    //míssil.BringToFront();
                }
            }


            //Checando Colisões de Pedras com o Hulk

            foreach (Projétil pedra in background.Controls.OfType<Projétil>())
            {
                // Se uma pedra colidiu com o Hulk
                if (Hulk.Colidiu(pedra))
                {
                    // Vamos remover a pedra da lista de controles e destruí-lo
                    Controls.Remove(pedra);
                    pedra.Destruir();
                    background.Controls.Remove(pedra);

                    // Tirar a vida do Hulk em 1 unidade.
                    Hulk.PerderVida(1);
                    if (Hulk.Morreu())
                    {
                        // Remover o Hulk da lista de controles e destruí-lo
                        //  Controls.Remove(ironMan);
                        Hulk.Morrer();
                        this.GameOver = new Label();
                        this.GameOver.Font = new Font("Microsoft Sans Serif", 70);
                        this.GameOver.AutoSize = true;
                        this.GameOver.Location = new System.Drawing.Point(GlobalResources.SCENE_WIDTH / 2 - this.GameOver.Width * 3, GlobalResources.SCENE_HEIGHT / 2);
                        this.GameOver.TabIndex = 0;
                        this.GameOver.Text = "GAME OVER";
                        this.Controls.Add(GameOver);
                        GameOver.BringToFront();
                        ClosingGame = true;
                    }

                    if (pedra.Location.X <= 0)
                    {
                        pedra.Destruir();
                    }

                }
            }

            // Se uma pedra do Hulk colidiu com alguma pedra do Abominável
            foreach (Projétil pedraHulk in background.Controls.OfType<Projétil>())
            {
                if (pedraHulk.Colidiu(pedraHulk))
                {
                    // Vamos remover a pedraAbominável da lista de controles e destruí-la
                    Controls.Remove(pedraHulk); //Mudar para pedraAbominável
                    pedraHulk.Destruir();
                    background.Controls.Remove(pedraHulk);
                    // Vamos remover a pedraHulk da lista de controles e destruí-la
                    Controls.Remove(pedraHulk);
                    pedraHulk.Destruir();
                    background.Controls.Remove(pedraHulk);
                }
            }

            // Agora vamos checar se uma pedraHulk colidiu com o Abominável:
            foreach (Projétil pedraHulk in background.Controls.OfType<Projétil>())
            {
                // Se uma pedraHulk colidiu com o Abominável
                if (pedraHulk.Colidiu(Abominável))
                {
                    // Vamos remover a pedraHulk da lista de controles e destruí-lo
                    Controls.Remove(pedraHulk);
                    pedraHulk.Destruir();
                    background.Controls.Remove(pedraHulk);

                    // O Abominável vai tomar dano igual ao Poder do projeto
                    Abominável.TomarDano(pedraHulk.Poder);

                    // Se o Abominável NÃO está vivo
                    if (!Abominável.EstahVivo())
                    {
                        // Finalizar Abominável
                        Abominável.Morrer();
                        ClosingGame = true;
                    }
                }
        }

    }

        private void HulkForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
              
                case Keys.Left:
                    Hulk.MoverParaEsquerda();
                    break;
                case Keys.Right:
                    Hulk.MoverParaDireita();
                    break;
                case Keys.ShiftKey:
                    Hulk.Dash();
                    break;
                case Keys.Space:
                    ProjétilHulk pedraHulk = Hulk.DispararProjétil();
                    if (pedraHulk != null)
                    {
                        this.Controls.Add(pedraHulk);
                        background.Controls.Add(pedraHulk);
                        pedraHulk.BringToFront();
                    }
                    break;
            }
        }

    

        private void HulkForm_KeyUp(object sender, KeyEventArgs e)
        {
        switch (e.KeyCode)
        {
            case Keys.Left:
                Hulk.Parar();
                break;
            case Keys.Right:
                Hulk.Parar();
                break;
            case Keys.Space:
                Hulk.Parar();
                break;
        }
    }
    }
}
