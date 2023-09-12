using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectHeroQuestVS2017
{

    public partial class SelectStageScreen : Form
    {
        private SoundPlayer soundPlayer2 = new SoundPlayer();
        public SelectStageScreen()
        {
            InitializeComponent();
            soundPlayer2.Stream = global::ProjetoDudas.Properties.Resources.menu_prin_original;
            soundPlayer2.PlayLooping();

        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            this.Opacity = 1.00;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            IronManForm IronManForm = new IronManForm();
            this.Hide();
            IronManForm.ShowDialog();
            this.Show();
        }
    }
}
