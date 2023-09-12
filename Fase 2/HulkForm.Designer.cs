
namespace ProjetoDudas.Jogo.Fase_2
{
    partial class HulkForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.background = new System.Windows.Forms.PictureBox();
            this.TemporizadorPrincipalFase2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.background)).BeginInit();
            this.SuspendLayout();
            // 
            // background
            // 
            this.background.Image = global::ProjetoDudas.Properties.Resources.CenárioFase2;
            this.background.Location = new System.Drawing.Point(0, 0);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(988, 463);
            this.background.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.background.TabIndex = 0;
            this.background.TabStop = false;
            // 
            // TemporizadorPrincipalFase2
            // 
            this.TemporizadorPrincipalFase2.Interval = 50;
            this.TemporizadorPrincipalFase2.Tick += new System.EventHandler(this.TemporizadorPrincipalFase2_Tick);
            // 
            // HulkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.background);
            this.Name = "HulkForm";
            this.Text = "HulkForm";
            this.Load += new System.EventHandler(this.HulkForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HulkForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.HulkForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.background)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox background;
        private System.Windows.Forms.Timer TemporizadorPrincipalFase2;
    }
}