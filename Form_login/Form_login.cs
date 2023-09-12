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
using WindowsFormsApp1;


namespace WindowsFormsApp1
{
    public partial class Form_login : Form 
    {
        DataBaseManager novo;
        
        
        public Form_login(string usuario)
        {
            InitializeComponent();

            novo = new DataBaseManager("TCC_1");
            DataTable Usuar = novo.ConsultarBanco($"SELECT Apelido FROM Usuario");
            for (int i = 0; i < Usuar.Rows.Count; i++)
                if (Usuar != null)
                {
                    
                    String Usuario = Convert.ToString(Usuar.Rows[i][0]);

                    comboBox1.Items.Add(Usuario);
                }
                else { }

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeComponent();

            

            

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            string sql_login = $"Select Senha FROM Usuario WHERE  Senha = '{textBox1.Text}'";
            //if (sql_login == textBox1.Text)
           // {
                SelectStageScreen selectStageScreen = new SelectStageScreen();
                this.Hide();
                selectStageScreen.ShowDialog();
            //}
            /*else
            {
                MessageBox.Show("Senha ou usuario incorretos");
            Form1 form1 = new Form1();
                this.Hide();
                form1.ShowDialog();
           }*/


           }

        }

       
    }

