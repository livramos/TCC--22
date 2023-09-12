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
using WindowsFormsApp1;
using ProjetoDudas;

namespace ProjetoDudas
{
    public partial class Form1 : Form
    {
        DataBaseManager gerenciador = null;
        bool perfilSelecioando = false;
        string usuario ="";

        public Form1()
        {
            InitializeComponent();
            gerenciador = new DataBaseManager("TCC_1");

        }

        private void btnInserir_Click(object sender, EventArgs e)
        {


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {   

            
            

                //string Usuario_login = logins.value;
                Form_login form_Login = new Form_login(usuario);
                this.Hide();
                form_Login.Show();
                 

                
                

                //DEPOIS QUE O VITOR E O LEVY TERMINAREM A FASE 1
                // CHamar o form contendo o game!!!
              /*  SelectStageScreen selectStageScreen  = new SelectStageScreen();
                  this.Hide();
                 selectStageScreen.ShowDialog();*/
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextBox textb = new TextBox();
            if (textBox1.Text == "")
            {
                MessageBox.Show("Por favor escreva seu nome!!!!");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Por favor escreva seu nickname!!!!");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Por favor repita sua senha!!!!");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Por favor informe um email!!!");
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Por favor coloque uma senha!!!!");
            }
            else
            {
                perfilSelecioando = true;
                string sql_insert = $"INSERT INTO Usuario (Email, Senha, Nome, Apelido, Imagem, Nascimento) VALUES('{textBox4.Text}', '{textBox5.Text}', '{textBox1.Text}', '{textBox2.Text}', 'picture', '{dateTimePicker1.Text}')";
                int linhas_afetadas = gerenciador.AtualizarBanco(sql_insert);

                if (linhas_afetadas > 0)
                    MessageBox.Show("Perfil Criado com sucesso!");
                else
                    MessageBox.Show("=(");


                textBox1.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox3.Clear();
                textBox2.Clear();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        public void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

 
            //int i = logins.SelectedIndex;
            //if(i >= 0)
            //usuario = logins.Items[i].ToString();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(3);
        }

        private void Historico_Nome_1_Click(object sender, EventArgs e)
        {

        }

        private void melhores_rank_Click(object sender, EventArgs e)
        {
           /* DataTable tabela = gerenciador.ConsultarBanco($"Select score  FROM SaveState");
            for (int i = 0; i < tabela.Rows.Count; i++)
                 if  (tabela != null){ 

                 String rank = Convert.ToString(tabela.Rows[1][0]);

                list_rank.Items.Add(rank);
                 }
                else { }
            */
        }

        private void att_rank_Click(object sender, EventArgs e)
        {
            string sql_rank = $"SELECT score idfase FROM SaveState ORDER BY score DESC";
            DataTable tabela = gerenciador.ConsultarBanco(sql_rank);
            if (tabela != null)
            {
                for (int i = 0; i < tabela.Rows.Count; i++)
                {
                    list_rank.Items.Add(tabela.Rows[i][0]);
                }
                
            }
            list_rank.ClearSelected();
        }

        private void list_rank_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable tabela = gerenciador.ConsultarBanco($"Select score  FROM SaveState");
            for (int i = 0; i < tabela.Rows.Count; i++)
                if (tabela != null)
                {

                    String rank = Convert.ToString(tabela.Rows[1][0]);

                    list_rank.Items.Add(rank);
                }
                else { }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            DataTable Historico = gerenciador.ConsultarBanco($"Select idpartidas FROM SaveState");
            for (int i = 0; i < Historico.Rows.Count; i++)
                if (Historico != null)
                {

                    String Hist = Convert.ToString(Historico.Rows[1][0]);

                    List_histórico.Items.Add(Hist); 
                }
                else { }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void logins_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void iniciar_Click(object sender, EventArgs e)
        {

        }

        private void List_histórico_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

          //int linhas_afetadas = gerenciador.AtualizarBanco(sql_insert);

           // if(linhas_afetadas > 0)
            //    MessageBox.Show("Perfil Criado com sucesso!");
           // else
              //  MessageBox.Show("=(");