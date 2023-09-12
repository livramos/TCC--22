using ProjetoHerosQuest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoDudas;
using ProjectHeroQuestVS2017;

namespace ProjectHeroQuestVS2017
{
    public partial class IronManForm : Form
    {
        // Main Entities
        IronMan ironMan;
        HydraShip ship;
        HydraShip ship2;
        CaixaMunição nova_caixa;
        vida CaixaVida;
        vida CaixaVida2;

        // Labels
        Label lblIronManVida;
        Label lblIronManMuni;
        Label lblVidaHydra;
        Label GameOver;

        bool ClosingGame = false;
        int ClosingTimer;
        bool acione_stage2 = false;

        public IronManForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.AllPaintingInWmPaint, true);
            // OR
            this.DoubleBuffered = true; // sets both flags
        }

        private void LimparListas()
        {
            foreach (Control control in Controls)
            {
                if (control == null)
                    Controls.Remove(control);
            }
        }

        private void pause()
        {
            temporizadorPrincipal.Interval = 0;
        }

        private void temporizadorPrincipal_Tick(object sender, EventArgs e)
        {
            // Poderia ser removida... só para garantir que quando um controle
            // é destruído (Disposed) ele também será retirado da lista de controles
            //LimparListas();


            // --> Atualiza a Munição do ironMan
            // Isso é feito contando quantos projéteis estão na tela e passando
            // para o método AtualizarMunição
            //ironMan.AtualizarMunição(Controls.OfType<Projétil>().Count());

            // --> Disparo de Míssil do Hydra Ship
            // Se o ship está carregado, então ele vai disparar um novo míssil

            // TENTANDO RESOLVER O PROBLEMA DE MUITOS MISSEIS NA TELA

            if (acione_stage2 == true) //&& Controls.OfType<HydraShip>().Count() < 1)
            {
                instanciar_ship2();
                acione_stage2 = false;
            }


            //AQUI ESTAO OS TESTES EM LOOP DA SHIP1

            if (Controls.OfType<Míssil>().Count() < 5)
            {

                if (ship.EstahCarregado())
                {
                    // Um novo míssil é criado e adicionado na lista de controles
                    Míssil míssil = ship.DispararMíssil();
                    background.Controls.Add(míssil);
                    //míssil.BringToFront();
                }

                else if (ship2 != null && ship2.EstahCarregado())
                {
                    // Um novo míssil é criado e adicionado na lista de controles
                    Míssil míssil = ship2.DispararMíssil();
                    background.Controls.Add(míssil);
                    //míssil.BringToFront();
                }
            }


            if (Controls.OfType<CaixaMunição>().Count() == 0)
            {
                DropMuni.Start();
            }

            switch (ship.VidaAtual())
            {
                case 10:
                    CaixaVida.Value = 100;
                    break;
                case 9:
                    CaixaVida.Value = 90;
                    break;
                case 8:
                    CaixaVida.Value = 80;
                    break;
                case 7:
                    CaixaVida.Value = 70;
                    break;
                case 6:
                    CaixaVida.Value = 60;
                    break;
                case 5:
                    CaixaVida.Value = 50;
                    break;
                case 4:
                    CaixaVida.Value = 40;
                    break;
                case 3:
                    CaixaVida.Value = 30;
                    break;
                case 2:
                    CaixaVida.Value = 20;
                    break;
                case 1:
                    CaixaVida.Value = 10;
                    break;
                case 0:
                    CaixaVida.Value = 0;
                    break;
            }

            /*
            if(ship2 != null)
            {
                switch (ship2.VidaAtual())
                {
                    case 10:
                        CaixaVida.Value = 100;
                        break;
                    case 9:
                        CaixaVida.Value = 90;
                        break;
                    case 8:
                        CaixaVida.Value = 80;
                        break;
                    case 7:
                        CaixaVida.Value = 70;
                        break;
                    case 6:
                        CaixaVida.Value = 60;
                        break;
                    case 5:
                        CaixaVida.Value = 50;
                        break;
                    case 4:
                        CaixaVida.Value = 40;
                        break;
                    case 3:
                        CaixaVida.Value = 30;
                        break;
                    case 2:
                        CaixaVida.Value = 20;
                        break;
                    case 1:
                        CaixaVida.Value = 10;
                        break;
                    case 0:
                        CaixaVida.Value = 0;
                        break;
                }
            }*/




            if (ClosingGame == true)
            {
                ClosingTimer++;
            }
            if (ClosingTimer == 30)
                this.Close();



            // --> Checando por Colisões
            // Primeiro vamos checar se um Míssil colidiu com algo:
            foreach (Míssil míssil in background.Controls.OfType<Míssil>())
            {
                // Se um míssil colidiu com o ironMan
                if (ironMan.Colidiu(míssil))
                {
                    // Vamos remover o míssil da lista de controles e destruí-lo
                    Controls.Remove(míssil);

                    míssil.Destruir();

                    // Tirar a vida do ironMan em 1 unidade.
                    ironMan.PerderVida(1);
                    if (ironMan.Morreu())
                    {
                        // Remover o ironMan da lista de controles e destruí-lo
                        //  Controls.Remove(ironMan);
                        ironMan.Morrer();
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

                    if (míssil.Location.X <= 0)
                    {
                        míssil.Destruir();
                    }

                }

                // Se um míssil colidiu com algum projétil do ironMan
                foreach (Projétil projétil in background.Controls.OfType<Projétil>())
                {
                    if (projétil.Colidiu(míssil))
                    {
                        // Vamos remover o míssil da lista de controles e destruí-lo
                        Controls.Remove(míssil);
                        míssil.Destruir();
                        // Vamos remover o projétil da lista de controles e destruí-lo
                        Controls.Remove(projétil);
                        projétil.Destruir();
                    }
                }


                foreach (CaixaMunição nova_caixa in background.Controls.OfType<CaixaMunição>())
                {
                    if (nova_caixa.Colidiu(ironMan))
                    {
                        ironMan.AtualizarMunição();
                        Controls.Remove(míssil);
                        Controls.Remove(nova_caixa);
                        nova_caixa.Sumir();
                        lblIronManMuni.Text = $"Munição: {ironMan.QtdMunição - 1}";
                    }
                }

            }

            // Agora vamos checar se um projétil colidiu com algo:
            foreach (Projétil projétil in background.Controls.OfType<Projétil>())
            {
                // Se um projétil colidiu com o ship
                if (acione_stage2 == false)
                {
                    if (projétil.Colidiu(ship))
                    {
                        lblVidaHydra.Text = $"Vidas Hydra: {ship.VidaAtual() - 1}";
                        // Vamos remover o projétil da lista de controles e destruí-lo
                        Controls.Remove(projétil);
                        projétil.Destruir();

                        // O ship vai tomar dano igual ao Poder do projeto
                        ship.TomarDano(projétil.Poder);
                        lblVidaHydra.Text = $"Vidas Hydra: {ship.VidaAtual()}";

                        // Se o ship NÃO está funcionando
                        if (!ship.EstahFuncionando())
                        {
                            // Destruir o Ship
                            ship.Explodir();
                            ClosingGame = true;

                            //acione_stage2 = true;
                        }
                    }
                }

                if (ship2 != null)
                {
                    if (projétil.Colidiu(ship2))
                    {

                        {
                            // Vamos remover o projétil da lista de controles e destruí-lo
                            Controls.Remove(projétil);
                            projétil.Destruir();

                            // O ship vai tomar dano igual ao Poder do projeto
                            ship2.TomarDano(projétil.Poder);

                            // Se o ship NÃO está funcionando
                            if (!ship2.EstahFuncionando())
                            {
                                // Destruir o Ship
                                ship2.Explodir();
                                ClosingGame = true;
                            }
                        }
                    }
                }
            }

        }


        private void instanciar_ship2()
        {
            ship2 = new HydraShip(new Point(GlobalResources.SCENE_WIDTH, GlobalResources.SCENE_HEIGHT / 2));
            ship2.Location = new Point(GlobalResources.SCENE_WIDTH - ship2.Width, GlobalResources.SCENE_HEIGHT / 2);
            //ship2.Image = ;
            ship2.mudarvariaveis_hydra(8, 15);
            this.Controls.Add(ship2);
            background.Controls.Add(ship2);

            CaixaVida2 = new vida();
            CaixaVida2.Location = new Point(300, 20);
            //CaixaVida.Location = new System.Drawing.Point(12, 12);
            CaixaVida2.Name = "progressBar1";
            CaixaVida2.Size = new System.Drawing.Size(332, 23);
            CaixaVida2.TabIndex = 0;
            CaixaVida2.Value = 100;
            Controls.Add(CaixaVida2);

            lblVidaHydra.Text = $"Vidas Hydra: {ship2.VidaAtual()}";

            // Adicionar todos os elementos gráficos a esta lista também.
            background.SendToBack();
            background.Controls.Add(ship);
            background.Controls.Add(ironMan);
            background.Controls.Add(CaixaVida);
            background.Controls.Add(lblIronManVida);
            background.Controls.Add(lblVidaHydra);
            background.Controls.Add(GameOver);
            background.Controls.Add(nova_caixa);



        }

        private void IronManForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.P:
                    ship.pause();
                    ironMan.pause();

                    checkBox1.Checked = true;
                    break;

                case Keys.O:
                    ship.retornar();
                    ironMan.retornar();
                    checkBox1.Checked = false;
                    break;

                case Keys.Up:
                    ironMan.MoverParaCima();
                    break;
                case Keys.Down:
                    ironMan.MoverParaBaixo();
                    break;
                case Keys.Left:
                    ironMan.MoverParaEsquerda();
                    break;
                case Keys.Right:
                    ironMan.MoverParaDireita();
                    break;
                case Keys.ShiftKey:
                    ironMan.Dash();
                    break;
                case Keys.Space:
                    Projétil novoProjétil = ironMan.DispararProjétil();
                    if (novoProjétil != null)
                    {
                        this.Controls.Add(novoProjétil);
                        background.Controls.Add(novoProjétil);
                        novoProjétil.BringToFront();
                        lblIronManMuni.Text = $"Munição: {ironMan.QtdMunição - 1}";
                    }
                    break;
            }
        }

        private void IronManForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    ironMan.Parar();
                    break;
                case Keys.Down:
                    ironMan.Parar();
                    break;
                case Keys.Left:
                    ironMan.Parar();
                    break;
                case Keys.Right:
                    ironMan.Parar();
                    break;
                case Keys.Space:
                    ironMan.Parar();
                    break;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        private void IronManForm_Load(object sender, EventArgs e)
        {
            LimparListas();
            this.Size = new Size(GlobalResources.SCENE_WIDTH, GlobalResources.SCENE_HEIGHT);
            //BackgroundImage = Properties.Resources.NewYorkPhase1;

            ironMan = new IronMan(new Point(0, GlobalResources.SCENE_HEIGHT / 2));
            this.Controls.Add(ironMan);

            ship = new HydraShip(new Point(GlobalResources.SCENE_WIDTH, GlobalResources.SCENE_HEIGHT / 2));
            ship.Location = new Point(GlobalResources.SCENE_WIDTH - ship.Width, GlobalResources.SCENE_HEIGHT / 2);
            this.Controls.Add(ship);


            this.lblIronManVida = new Label();
            this.lblIronManVida.AutoSize = true;
            this.lblIronManVida.Location = new System.Drawing.Point(3, 1);
            this.lblIronManVida.TabIndex = 0;
            this.lblIronManVida.Text = $"Vida: {ironMan.VidaAtual()}";
            this.Controls.Add(lblIronManVida);

            this.lblIronManMuni = new Label();
            this.lblIronManMuni.AutoSize = true;
            this.lblIronManMuni.Location = new System.Drawing.Point(0, 447);
            this.lblIronManMuni.TabIndex = 0;
            this.lblIronManMuni.Text = $"Munição: {ironMan.QtdMunição}";
            this.Controls.Add(lblIronManMuni);

            this.lblVidaHydra = new Label();
            this.lblVidaHydra.AutoSize = true;
            this.lblVidaHydra.Location = new Point(425, 5);
            this.lblVidaHydra.TabIndex = 0;
            this.lblVidaHydra.Text = $"Vidas Hydra: {ship.VidaAtual()}";
            this.Controls.Add(lblVidaHydra);


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

            // Adicionar todos os elementos gráficos a esta lista também.
            background.SendToBack();
            background.Controls.Add(ship);
            background.Controls.Add(ironMan);
            background.Controls.Add(CaixaVida);
            background.Controls.Add(lblIronManVida);
            background.Controls.Add(lblVidaHydra);
            background.Controls.Add(GameOver);
            background.Controls.Add(nova_caixa);

            /* foreach (Control control in Controls)
             {
                 background.Controls.Add(control);
             }*/

        }

        private void DropMuni_Tick(object sender, EventArgs e)
        {
            nova_caixa = new CaixaMunição();
            background.Controls.Add(nova_caixa);
        }
    }
}
